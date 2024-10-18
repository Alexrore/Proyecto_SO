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


MYSQL *conn;
int puerto = 9050;

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

int main(int argc, char *argv[]) {
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	char peticion[512];
	char respuesta[512];
	
	conectarBD(); // Conexion a la base de datos
	
	if ((sock_listen = socket(AF_INET, SOCK_STREAM, 0)) < 0) {
		printf("Error creando el socket\n");
		exit(1);
	}
	
	memset(&serv_adr, 0, sizeof(serv_adr));
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(puerto);
	
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0) {
		printf("Error en el bind\n");
		exit(1);
	}
	
	if (listen(sock_listen, 3) < 0) {
		printf("Error en el listen\n");
		exit(1);
	}
	
	for (;;) {
		printf("Escuchando\n");
		
		sock_conn = accept(sock_listen, NULL, NULL);
		printf("He recibido conexion\n");
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
	
	cerrarBD(); // Cierra la conexion a la base de datos
	return 0;
}
