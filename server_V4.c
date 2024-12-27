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

//Clases
typedef struct
{
	int sock;
	char Nombre[MAX_NOMBRE];
} Cliente;

typedef struct
{
	Cliente cliente[100];
	int numero_clientes;

} Cliente_Lista;

//Variables 
MYSQL *conn;
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int Socket[100];
Cliente_Lista Clis;
char query[512];

void conectarBD() {
	conn = mysql_init(NULL);
	if (conn == NULL) {
		printf("Error al crear la conexion: %u %s\n", mysql_errno(NULL), mysql_error(NULL));
		exit(1);
	}
	
	// Intentamos la conexion
	if (mysql_real_connect(conn, "localhost", "root", "mysql", "Juego", 0, NULL, 0) == NULL) {
		printf("Error al inicializar la conexion: %u %s\n", mysql_errno(conn), mysql_error(conn));
		mysql_close(conn);  // Limpiar la conexion si falla
		exit(1);
		
	}
}

void actualizar_onlines(int sock_cliente, int codigo, char nom[MAX_NOMBRE]) 
{
	if (codigo == 1)
	{
		if (Clis.numero_clientes < MAX_CLIENTES) // Añadir cliente
		{
			Clis.numero_clientes++;
			Clis.cliente[Clis.numero_clientes - 1].sock = sock_cliente;
			strcpy(Clis.cliente[Clis.numero_clientes - 1].Nombre, nom);
		} 
		else 
		{
			printf("Numero maximo de clientes alcanzado\n");
		}
	}
	
	if (codigo == 2) // Desconectar cliente	
	{	
		if(Clis.numero_clientes > 0)
		{

			for (int u = 0; u < Clis.numero_clientes; u++)
			{
				if (strcmp(Clis.cliente[u].Nombre, nom) == 0)
				{
					int cont = u;
					while (cont < Clis.numero_clientes)
					{
						Clis.cliente[cont].sock = Clis.cliente[cont+1].sock;
						strcpy(Clis.cliente[cont].Nombre, Clis.cliente[cont+1].Nombre);
						cont++;
					}
					Clis.numero_clientes--;
				}
			}
		}		
	}
	
	char clientes[1024];
	strcpy(clientes, "2/");
	for (int j = 0; j < Clis.numero_clientes; j++)
	{
		strcat (clientes, Clis.cliente[j].Nombre);
		strcat (clientes, " ");
	}
	if (codigo==1 || codigo==2)
	{
		printf("Lista de conectados:%s\n", clientes);
		for (int i = 0; i < Clis.numero_clientes; i++) 
		{
			write(Clis.cliente[i].sock, clientes, strlen(clientes));
		}
	}
	if (codigo==0)
	{
		printf("%s\n", clientes);
		write(sock_cliente, clientes,strlen(clientes));
	}
}

void *AtenderCliente(void *socket) 
{
	int sock_conn = *(int *)socket;
    free(socket);
	char peticion[512];
	char respuesta[512];
    int ret;
    
    conectarBD();

    int terminar = 0;
    char nombre[MAX_NOMBRE];
	char password[20];

    while (terminar == 0) 
	{
        ret = read(sock_conn, peticion, sizeof(peticion));
        peticion[ret] = '\0';
        printf("Peticion: %s\n", peticion);
		
        char *p = strtok(peticion, "/");
        int codigo = atoi(p);
        if (codigo != 0 && codigo !=6 && codigo != 7 && codigo !=8) 
		{
            p = strtok(NULL, "/");
            strcpy(nombre, p);
            printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
        }
		
        if (codigo == 0) // Desconexion
		{ 
			printf("%s desconctado \n", nombre);
			terminar = 1;
			pthread_mutex_lock(&mutex);
			actualizar_onlines(sock_conn, 2, nombre);
			pthread_mutex_unlock(&mutex);
		}
		
		if (codigo == 1) // Registrar
		{ 
            p = strtok(NULL, "/");
            strcpy(password, p);
			
            // Generar nuevo ID
            sprintf(query, "SELECT COUNT(*) FROM Jugador;");
            
			if (mysql_query(conn, query)) 
			{
                printf("Error al contar jugadores: %s\n", mysql_error(conn));
                sprintf(respuesta, "1/Error en el registro");
            } 
			
			else 
			{
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                row = mysql_fetch_row(res);
                int id = atoi(row[0]) + 1;
                mysql_free_result(res);
				
                // Insertar jugador en la tabla Jugador
                sprintf(query, "INSERT INTO Jugador(ID, Nombre, contraseña) VALUES ('%d', '%s', '%s')", id, nombre, password);
                if (mysql_query(conn, query)) 
				{
                    printf("Error al insertar en Jugador: %s\n", mysql_error(conn));
                    sprintf(respuesta, "1/Error en el registro");
                } 
				
				else 
				{
                    // Insertar en las tablas auxiliares
                    sprintf(query, "INSERT INTO PartidasGanadas(ID, victorias) VALUES ('%d', '0')", id);
                    mysql_query(conn, query);
                    sprintf(query, "INSERT INTO MedallasObtenidas(ID, Medallas) VALUES ('%d', '0')", id);
                    mysql_query(conn, query);
                    printf("Usuario registrado con exito\n");
                    sprintf(respuesta, "1/Registro exitoso");
                }
            }
            write(sock_conn, respuesta, strlen(respuesta));
        } 
		
		else if (codigo == 2)  // Iniciar Sesion
		{ 
            char query[512];
            char password[20];
            p = strtok(NULL, "/");
            strcpy(password, p);
			respuesta[0] = '\0';
			
            sprintf(query, "SELECT * FROM Jugador WHERE Nombre='%s' AND contraseña='%s'", nombre, password);
            if (mysql_query(conn, query)) 
			{
                printf("Error en la consulta: %s\n", mysql_error(conn));
            } 
			
			else 
			{
                MYSQL_RES *res = mysql_store_result(conn);
                if (mysql_num_rows(res) > 0) 
				{
                    printf("Inicio de sesion exitoso\n");
					actualizar_onlines(sock_conn, 1, nombre);
                } 
				else 
				{
                    printf("Usuario o contraseña incorrectos\n");
                }
                mysql_free_result(res);
            }
			
		}


        else if (codigo == 3) // Consulta Nombre
		{ 
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM Jugador WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) 
			{
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "3/Error en la consulta");
            } 
			else 
			{
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) {
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "3/Nombre: %s", row[1]);
                } else {
                    sprintf(respuesta, "3/No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
			write(sock_conn, respuesta, strlen(respuesta));
        } 
		
		else if (codigo == 4) // Consulta Victorias
		{ 
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM PartidasGanadas WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) 
			{
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "4/Error en la consulta");
            } 
			
			else 
			{
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) {
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "4/Victorias: %d", atoi(row[1]));
                } else {
                    sprintf(respuesta, "4/No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
			write(sock_conn, respuesta, strlen(respuesta));
        } 
		else if (codigo == 5) // Consulta Medallas
		{
            char query[512];
            char ID[10];
            
            strcpy(ID, p);
            int id = atoi(ID);
            sprintf(query, "SELECT * FROM MedallasObtenidas WHERE ID='%d'", id);
            
            if (mysql_query(conn, query)) 
			{
                printf("Error en la consulta: %s\n", mysql_error(conn));
                sprintf(respuesta, "5/Error en la consulta");
            } 
			else 
			{
                MYSQL_RES *res = mysql_store_result(conn);
                MYSQL_ROW row;
                
                if ((row = mysql_fetch_row(res))) 
				{
                    printf("Consulta exitosa\n");
                    sprintf(respuesta, "5/Medallas: %d", atoi(row[1]));
                } 
				else 
				{
                    sprintf(respuesta, "5/No se encontraron datos para el usuario");
                }
                mysql_free_result(res);
            }
            write(sock_conn, respuesta, strlen(respuesta));
		}
		else if (codigo == 6) //invitacion
		{
			int i;
			char usuario_1[MAX_NOMBRE];
			p = strtok(NULL, "/");
			strcpy(usuario_1, p);			
			p = strtok(NULL, "/");
			strcpy(nombre, p);
			for(i=0; i<Clis.numero_clientes+1;i++)
			{
				if(strcmp(nombre, Clis.cliente[i].Nombre)==0)
				{
					break;
				}
			}
			sprintf(respuesta, "6/%s", usuario_1);
			write(Clis.cliente[i].sock, respuesta, strlen(respuesta));
        }
		else if (codigo == 7) //respuesta invitacion
		{
			int i;
			char usuario_1[MAX_NOMBRE];
			p = strtok(NULL, "/");
			strcpy(nombre, p);	
			for(i=0; i<Clis.numero_clientes;i++)
			{
				if(strcmp(nombre, Clis.cliente[i].Nombre)==0)
				{
					break;
				}
			}
			p = strtok(NULL, "/");
			strcpy(usuario_1, p);
			p = strtok(NULL, "/");
			if ( strcmp(p, "si")==0)
			{
				sprintf( respuesta, "7/%s ha aceptado la invitacion", usuario_1);
				write(Clis.cliente[i].sock, respuesta, strlen(respuesta));
			}
			if ( strcmp(p, "no")==0)
			{
				sprintf( respuesta, "7/%s ha rechazado la invitacion", usuario_1);
				write(Clis.cliente[i].sock, respuesta, strlen(respuesta));
			}
		}
		else if ( codigo == 8) //mensaje de chat
		{
			char usuario_1[MAX_NOMBRE];
			p = strtok(NULL,"/");
			strcpy(usuario_1, p);
			p = strtok(NULL, "/");
			sprintf(respuesta,"8/%s: %s", usuario_1,p);
			for  (int i =0; i < Clis.numero_clientes; i++)
			{
				write(Clis.cliente[i].sock, respuesta, strlen(respuesta));
			}
		}
    }
    close(sock_conn);
    return NULL;
}

int main() 
{
    int sock_listen, sock_conn;
    struct sockaddr_in serv_addr;
    pthread_t thread;

    conectarBD();  // Conectar a la base de datos

    // Crear socket
    if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) 
	{
        perror("Error creando socket");
        exit(EXIT_FAILURE);
    }

    // Configurar direcciÃ³n del servidor
    serv_addr.sin_family = AF_INET;
    serv_addr.sin_addr.s_addr = INADDR_ANY;
    serv_addr.sin_port = htons(PUERTO);

    // Asociar el socket al puerto
    if (bind(sock_listen, (struct sockaddr *)&serv_addr, sizeof(serv_addr)) < 0) 
	{
        perror("Error en bind");
        exit(EXIT_FAILURE);
    }

    // Escuchar conexiones entrantes
    if (listen(sock_listen, MAX_JUGADORES) < 0) 
	{
        perror("Error en listen");
        exit(EXIT_FAILURE);
    }
    printf("Servidor escuchando en el puerto %d\n", PUERTO);
    while (1) 
	{
        sock_conn = accept(sock_listen, NULL, NULL);
        printf("Nueva conexion aceptada\n");
		
        int *sock_ptr = malloc(sizeof(int));
        *sock_ptr = sock_conn;
		
        // Crear un nuevo hilo para manejar el cliente
        pthread_create(&thread, NULL, AtenderCliente, sock_ptr);
        pthread_detach(thread);  // Liberar el hilo automÃ¡ticamente al terminar
    }
    mysql_close(conn);  // Cerrar la  a la conexion base de datos
    return 0;
}
