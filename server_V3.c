#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <unistd.h>
#include <pthread.h>
#include <mysql/mysql.h>
#include <arpa/inet.h>

#define MAX_JUGADORES 10
#define MAX_NOMBRE 20
#define PUERTO 9050
#define MAX_CLIENTES 10

MYSQL *conn;
pthread_mutex_t mutex_conexiones = PTHREAD_MUTEX_INITIALIZER;
char jugadores_conectados[MAX_JUGADORES][MAX_NOMBRE];
int num_conectados = 0;
int clientes_conectados[MAX_CLIENTES];


void conectarBD() {
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear la conexion: %u %s\n", mysql_errno(NULL), mysql_error(NULL));
		exit(1);
	}
	
	// Intentamos la conexión
	if (mysql_real_connect(conn, "localhost", "root", "mysql", "Juego", 0, NULL, 0) == NULL) {
		printf("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		mysql_close(conn);  // Limpiar la conexion si falla
		exit(1);
	}
}

void EnviarListaJugadores() {
    char respuesta[512];
    strcpy(respuesta, "Jugadores en linea:");

    pthread_mutex_lock(&mutex_conexiones);
    for (int i = 0; i < num_conectados; i++) {
        strcat(respuesta, " ");
        strcat(respuesta, jugadores_conectados[i]);
    }
    pthread_mutex_unlock(&mutex_conexiones);

    // Enviar la lista de jugadores conectados a todos los clientes
    // Asumiendo que tienes un array de sockets para los clientes conectados
    for (int i = 0; i < num_conectados; i++) {
        int sock_cliente = clientes_conectados[i] ;
        write(sock_cliente, respuesta, strlen(respuesta));
    }
}

void agregarCliente(int sock_cliente) {
	if (num_conectados < MAX_CLIENTES) {
		clientes_conectados[num_conectados++] = sock_cliente;
	} else {
		printf("Numero maximo de clientes alcanzado\n");
	}
}

void *AtenderCliente(void *socket) {
    int sock_conn = *(int *)socket;
    free(socket);
    
    char peticion[512];
    char respuesta[512];
    int ret;
    
    conectarBD();

    int terminar = 0;
    char nombre[MAX_NOMBRE];

    while (terminar == 0) {
        ret = read(sock_conn, peticion, sizeof(peticion));
        peticion[ret] = '\0';
        printf("Peticion: %s\n", peticion);

        char *p = strtok(peticion, "/");
        int codigo = atoi(p);
        if (codigo != 0) {
            p = strtok(NULL, "/");
            strcpy(nombre, p);
            printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
        }

        if (codigo == 0) { // Desconexion
            terminar = 1;

            // Eliminar jugador de la lista de conectados
            pthread_mutex_lock(&mutex_conexiones);
            for (int i = 0; i < num_conectados; i++) {
                if (strcmp(jugadores_conectados[i], nombre) == 0) {
                    for (int j = i; j < num_conectados - 1; j++) {
                        strcpy(jugadores_conectados[j], jugadores_conectados[j + 1]);
                    }
                    num_conectados--;
                    break;
                }
            }
            pthread_mutex_unlock(&mutex_conexiones);

            // Actualizar lista a todos los jugadores conectados
            EnviarListaJugadores();

        } else if (codigo == 1) { // Registrar
            char query[512];
            char password[20];
            p = strtok(NULL, "/");
            strcpy(password, p);

            // Generar nuevo ID
            sprintf(query, "SELECT COUNT(*) FROM Jugador;");
            if (mysql_query(conn, query)) {
                printf("Error al contar jugadores: %s\n", mysql_error(conn));
                sprintf(respuesta, "Error en el registro");
            } else {
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                row = mysql_fetch_row(res);
                int id = atoi(row[0]) + 1;
                mysql_free_result(res);

                // Insertar jugador en la tabla Jugador
                sprintf(query, "INSERT INTO Jugador(ID, Nombre, contrase�a) VALUES ('%d', '%s', '%s')", id, nombre, password);
                if (mysql_query(conn, query)) {
                    printf("Error al insertar en Jugador: %s\n", mysql_error(conn));
                    sprintf(respuesta, "Error en el registro");
                } else {
                    // Insertar en las tablas auxiliares
                    sprintf(query, "INSERT INTO PartidasGanadas(ID, victorias) VALUES ('%d', '0')", id);
                    mysql_query(conn, query);
                    sprintf(query, "INSERT INTO MedallasObtenidas(ID, Medallas) VALUES ('%d', '0')", id);
                    mysql_query(conn, query);

                    printf("Usuario registrado con exito\n");
                    sprintf(respuesta, "Registro exitoso");

                    // Añadir a la lista de conectados
                    pthread_mutex_lock(&mutex_conexiones);
                    strcpy(jugadores_conectados[num_conectados], nombre);
                    num_conectados++;
                    pthread_mutex_unlock(&mutex_conexiones);

                    // Actualizar lista a todos los jugadores conectados
                    EnviarListaJugadores();
                }
            }
            write(sock_conn, respuesta, strlen(respuesta));

        } else if (codigo == 2) { // Iniciar Sesion
            char query[512];
            char password[20];
            p = strtok(NULL, "/");
            strcpy(password, p);

            sprintf(query, "SELECT * FROM Jugador WHERE Nombre='%s' AND contrase�a='%s'", nombre, password);
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "Error en el inicio de sesion");
            } else {
                MYSQL_RES *res = mysql_store_result(conn);
                if (mysql_num_rows(res) > 0) {
                    printf("Inicio de sesion exitoso\n");
                    sprintf(respuesta, "Inicio de sesion exitoso");

                    // Añadir a la lista de conectados
                    pthread_mutex_lock(&mutex_conexiones);
                    strcpy(jugadores_conectados[num_conectados], nombre);
                    num_conectados++;
                    pthread_mutex_unlock(&mutex_conexiones);

                    // Actualizar lista a todos los jugadores conectados
                    EnviarListaJugadores();
                } else {
                    printf("Usuario o contrase�a incorrectos\n");
                    sprintf(respuesta, "Usuario o contrase�a incorrectos");
                }
                mysql_free_result(res);
            }
            write(sock_conn, respuesta, strlen(respuesta));

        } else if (codigo == 6) { // Solicitar lista de jugadores conectados
            EnviarListaJugadores();

        } else if (codigo == 3) { // Consulta Nombre
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM Jugador WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "Error en la consulta");
            } else {
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) {
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "Nombre: %s", row[1]);
                } else {
                    sprintf(respuesta, "No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
            write(sock_conn, respuesta, strlen(respuesta));
        } else if (codigo == 4) { // Consulta Victorias
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM PartidasGanadas WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "Error en la consulta");
            } else {
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) {
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "Victorias: %d", atoi(row[1]));
                } else {
                    sprintf(respuesta, "No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
            write(sock_conn, respuesta, strlen(respuesta));
        } else if (codigo == 5) { // Consulta Medallas
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM MedallasObtenidas WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) {
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "Error en la consulta");
            } else {
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) {
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "Medallas: %d", atoi(row[1]));
                } else {
                    sprintf(respuesta, "No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
            write(sock_conn, respuesta, strlen(respuesta));
        }

       
    }

    close(sock_conn);
    return NULL;
}

int main() {
    int sock_listen, sock_conn;
    struct sockaddr_in serv_addr;
    pthread_t thread;

    conectarBD();  // Conectar a la base de datos

    // Crear socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
        perror("Error creando socket");
        exit(EXIT_FAILURE);
    }

    // Configurar dirección del servidor
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = INADDR_ANY;
    serv_addr.sin_port = htons(PUERTO);

    // Asociar el socket al puerto
    if (bind(sock_listen, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0) {
        perror("Error en bind");
        exit(EXIT_FAILURE);
    }

    // Escuchar conexiones entrantes
    if (listen(sock_listen, MAX_JUGADORES) < 0) {
        perror("Error en listen");
        exit(EXIT_FAILURE);
    }
    printf("Servidor escuchando en el puerto %d\n", PUERTO);

    while (1) {
        sock_conn = accept(sock_listen, NULL, NULL);
        printf("Nueva conexion aceptada\n");

        int *sock_ptr = malloc(sizeof(int));
        *sock_ptr = sock_conn;

        // Crear un nuevo hilo para manejar el cliente
        pthread_create(&thread, NULL, AtenderCliente, sock_ptr);
        pthread_detach(thread);  // Liberar el hilo automáticamente al terminar
    }

    mysql_close(conn);  // Cerrar la conexión a la base de datos
    return 0;
}
