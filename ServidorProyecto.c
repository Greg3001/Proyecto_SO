#include <string.h>
#include <unistd.h>
#include <stdlib.h>
#include <sys/types.h>
#include <sys/socket.h>
#include <netinet/in.h>
#include <stdio.h>
#include <pthread.h>
#include <ctype.h>
#include <mysql/mysql.h>
int contador;
//Estructura necesaria para acceso excluyente
pthread_mutex_t mutex = PTHREAD_MUTEX_INITIALIZER;
int i, j;
int sockets[100];
void *AtenderCliente (void *socket)
{
	int sock_conn, sock_listen, ret;
	struct sockaddr_in serv_adr;
	int *s;
	s= (int *) socket;
	sock_conn= *s;
	//int socket_conn = * (int *) socket;
	char peticion[512];
	char respuesta[512];
	int terminar =0;

	
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	// Entramos en un bucle para atender todas las peticiones de este cliente
	//hasta que se desconecte
	while (terminar ==0)
	{
		// Ahora recibimos la petici?n
		ret=read(sock_conn,peticion, sizeof(peticion));
		printf ("Recibido\n");
		// Tenemos que a?adirle la marca de fin de string 
		// para que no escriba lo que hay despues en el buffer
		peticion[ret]='\0';
		printf ("Peticion: %s\n",peticion);
		// vamos a ver que quieren
		char *p = strtok( peticion, "/");
		int codigo =  atoi (p);
		int numForm;
		// Ya tenemos el c?digo de la petici?n
		char Usuario[20];
		char Contrasena[20];
		char nombre[20];
		if (codigo ==1 ||codigo == 2)
		{
			p = strtok( NULL, "/");
			numForm =  atoi (p);
			p = strtok( NULL, "/");
			strcpy (Usuario, p);
			p = strtok( NULL, "/");
			strcpy (Contrasena, p);
			// Ya tenemos la información del usuario
			printf ("Codigo: %d, Usuario: %s, Contraseña: %s\n", codigo, Usuario, Contrasena);
		}
		else if (codigo ==3 ||codigo == 4||codigo == 5)
		{
			p = strtok( NULL, "/");
			numForm =  atoi (p);
			p = strtok( NULL, "/");
			strcpy (nombre, p);

			// Ya tenemos la información del usuario
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		else if (codigo != 0){
			p = strtok( NULL, "/");
			
			strcpy (nombre, p);
			// Ya tenemos el nombre
			printf ("Codigo: %d, Nombre: %s\n", codigo, nombre);
		}
		else if (codigo ==0) //petici?n de desconexi?n
			terminar=1;
		else if (codigo ==1) { //SIGN UP
			MYSQL *conn = mysql_init(NULL);
			mysql_real_connect(conn, "localhost", "root", "", "ProyectoBBDD", 0, NULL, 0);
			// Crea una sentencia SQL para insertar el usuario
			char *sql = printf("INSERT INTO usuarios (nombre, contraseña) VALUES ('%s', '%s')", Usuario, Contrasena);
			// Ejecuta la sentencia SQL
			int ret = mysql_query(conn, sql);
			if (ret) {
				fprintf(stderr, "Error al insertar el usuario: %s\n", mysql_error(conn));
			}
			// Imprime un mensaje de éxito
			printf("Usuario insertado correctamente.\n");
			sprintf (respuesta,"1/%d/Usuario registrado correctamente.", numForm);
			// Cierra la conexión con la base de datos
			mysql_close(conn);
		}
		else if (codigo ==2){ //LOG IN
			// Conecta con la base de datos
			MYSQL *conn = mysql_init(NULL);
			mysql_real_connect(conn, "localhost", "root", "", "ProyectoBBDD", 0, NULL, 0);
			// Crea una sentencia SQL para comprobar si el usuario existe
			char *sql = printf("SELECT COUNT(*) FROM usuarios WHERE nombre = '%s' AND contraseña = '%s'", Usuario, Contrasena); 
			// Ejecuta la sentencia SQL
			int ret = mysql_query(conn, sql);
			if (ret) {
				fprintf(stderr, "Error al comprobar si el usuario existe: %s\n", mysql_error(conn));
			}
			// Obtiene el número de filas de la consulta
			MYSQL_RES *result = mysql_store_result(conn);
			int num_filas = mysql_num_rows(result);
			// Cierra el resultado de la consulta
			mysql_free_result(result);
			// Comprueba si el usuario existe
			if (num_filas == 1) {
				// El usuario existe
				printf("Usuario logeado correctamente.\n");
				sprintf (respuesta,"2/%d/Usuario logeado correctamente.", numForm);
			} else {
				// El usuario no existe
				printf("Error: el usuario no existe.\n");
				sprintf (respuesta,"2/%d/Error: el usuario no existe.", numForm);
			}
			// Cierra la conexión con la base de datos
			mysql_close(conn);
		}
		else if (codigo == 3){
			strcpy (respuesta,strlen (nombre));
			printf (respuesta,"%d",strlen (nombre));
		}
		else if (codigo == 5){
			strcpy (respuesta,strlen (nombre));
			sprintf (respuesta,toupper(nombre));
		}
		else if (codigo == 4){
			if((nombre[0]=='M') || (nombre[0]=='S'))
				strcpy (respuesta,"SI");
			else
				strcpy (respuesta,"NO");
		}
		
		if (codigo !=0)
		{
			printf ("Respuesta: %s\n", respuesta);
			// Enviamos respuesta
			write (sock_conn,respuesta, strlen(respuesta));
		}
		if ((codigo ==1)||(codigo==2))
		{
			pthread_mutex_lock( &mutex ); //No me interrumpas ahora
			contador = contador +1;
			pthread_mutex_unlock( &mutex); //ya puedes interrumpirme
			// notificar a todos los clientes conectados
			char notificacion[20];
			sprintf (notificacion, "6/%d",contador);
			int j;
			for (j=0; j< i; j++)
				write (sockets[j],notificacion, strlen(notificacion));
		}
		
		
	}
	// Se acabo el servicio para este cliente
	close(sock_conn); 
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
	memset(&serv_adr, 0, sizeof(serv_adr));// inicialitza a zero serv_addr
	serv_adr.sin_family = AF_INET;
	// asocia el socket a cualquiera de las IP de la m?quina. 
	//htonl formatea el numero que recibe al formato necesario
	serv_adr.sin_addr.s_addr = htonl(INADDR_ANY);
	// establecemos el puerto de escucha
	serv_adr.sin_port = htons(9070);
	if (bind(sock_listen, (struct sockaddr *) &serv_adr, sizeof(serv_adr)) < 0)
		printf ("Error al bind");
	if (listen(sock_listen, 3) < 0)
		printf("Error en el Listen");
	contador =0;
	pthread_t thread;
	i=0;
	for (;;){
		printf ("Escuchando\n");
		sock_conn = accept(sock_listen, NULL, NULL);
		printf ("He recibido conexion\n");
		sockets[i] =sock_conn;
		//sock_conn es el socket que usaremos para este cliente
		// Crear thead y decirle lo que tiene que hacer
		pthread_create (&thread, NULL, AtenderCliente,&sockets[i]);
		i=i+1;
	}
}
