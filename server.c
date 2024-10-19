#include <sys/time.h>
#include <mysql/my_global.h>
#include <sys/types.h> 
#include <sys/socket.h> 
#include <netinet/in.h> 
#include <stdio.h>
#include <string.h>
#include <stdlib.h>
#include <unistd.h>
#include <stdbool.h>
#include <mysql/mysql.h>
#include <pthread.h>


MYSQL *conn;
int puerto = 9050;
void *AtenderCliente(void *socket)
{
	int sock_conn;
	int *s;
	s = (int *) socket;
	sock_conn = *s;
		
	char peticion[512];
	char respuesta[512];
	int ret;
	
	conectarBD(); // Conexion a la base de datos
	
		int terminar = 0;
		while (terminar == 0)
		{
			
			
			ret = read(sock_conn, peticion, sizeof(peticion));
			peticion[ret] = '\0';
			printf("Peticion: %s\n", peticion);
			
			char *p = strtok(peticion, "/");
			int codigo = atoi(p);
			char nombre[20];
			if (codigo != 0)
			{
				p = strtok(NULL, "/");
				strcpy(nombre, p);
				printf("Codigo: %d, Nombre: %s\n", codigo, nombre);
			}
			
			if (codigo == 0) // Desconexion
			{
				terminar = 1;
			}
			else if (codigo == 1) // Registrar
			{ 
				char query[512];
				char password[20];
				p = strtok(NULL, "/");
				strcpy(password, p);
				sprintf(query, "INSERT INTO Jugador(Nombre, contrase�a) VALUES ('%s', '%s')", nombre, password);
				
				if (mysql_query(conn, query)) 
				{
					printf("Error al insertar datos en la tabla: %s\n", mysql_error(conn));
					sprintf(respuesta, "Error en el registro");
				} 
				else 
				{
					printf("Usuario registrado con exito\n");
					sprintf(respuesta, "Registro exitoso");
				}
				
				write(sock_conn, respuesta, strlen(respuesta));
				
			} 
			else if (codigo == 2)  // Iniciar Sesion
			{
				char query[512];
				char password[20];
				p = strtok(NULL, "/");
				strcpy(password, p);
				sprintf(query, "SELECT * FROM Jugador WHERE Nombre='%s' AND contrase�a='%s'", nombre, password);
				
				if (mysql_query(conn, query)) 
				{
					printf("Error en la consulta: %s\n", mysql_error(conn));
					sprintf(respuesta, "Error en el inicio de sesion");
				}
				else 
				{
					MYSQL_RES *res = mysql_store_result(conn);
					if (mysql_num_rows(res) > 0) 
					{
						printf("Inicio de sesion exitoso\n");
						sprintf(respuesta, "Inicio de sesion exitoso");
					} 
					else 
					{
						printf("Usuario o contrase�a incorrectos\n");
						sprintf(respuesta, "Usuario o contrase�a incorrectos");
					}
					mysql_free_result(res);
				}
				write(sock_conn, respuesta, strlen(respuesta));
			} 
			else if (codigo == 3) // Consulta
			{	
				char query[512];
				sprintf(query, "SELECT * FROM Jugador WHERE Nombre='%s'", nombre);
				
				if (mysql_query(conn, query)) 
				{
					printf("Error en la consulta: %s\n", mysql_error(conn));
					sprintf(respuesta, "Error en la consulta");
				} 
				else 
				{
					MYSQL_RES *res = mysql_store_result(conn);
					MYSQL_ROW row;
					
					if ((row = mysql_fetch_row(res))) 
					{
						printf("Consulta exitosa\n");
						sprintf(respuesta, "Nombre: %s, Password: %s", row[1], row[2]);
					} 
					else 
					{
						sprintf(respuesta, "No se encontraron datos para el usuario");
					}
					mysql_free_result(res);
				}
				write(sock_conn, respuesta, strlen(respuesta));
			} 
		}
		
		close(sock_conn);
}

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

void cerrarBD() {
	if (conn != NULL) {
		mysql_close(conn);
		printf("Conexion cerrada con la base de datos.\n");
	}
}

int main(int argc, char *argv[]) 
{
	int sock_conn, sock_listen;
	struct sockaddr_in serv_adr;
	
	
	
	// INICIALITZACIONS
	// Obrim el socket
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0)
		printf("Error creant socket");
	// Fem el bind al port
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(puerto);
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9050);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	
	int i;
	int sockets[100];
	pthread_t thread;
	i=0;
	// Bucle para atender a 5 clientes
	for (;;)
	{
		printf ("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		
		// Crear thead y decirle lo que tiene que hacer
		
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
	cerrarBD(); // Cierra la conexion a la base de datos
	return 0;
}
