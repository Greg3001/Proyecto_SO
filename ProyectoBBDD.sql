CREATE DATABASE Proyecto;
USE Proyecto;

CREATE TABLE Jugadores (
						id_Jugadores INT  PRIMARY KEY,
						Nickname VARCHAR(50),
						Username VARCHAR(50) NOT NULL,
						Contrasena VARCHAR(50),
						historiales_id INT,
						FOREIGN KEY (historiales_id) REFERENCES Historiales(id_Historial)
						);

CREATE TABLE Personajes (
						 id_Personajes INT AUTO_INCREMENT  PRIMARY KEY,
						 nombre VARCHAR(50),
						 salud FLOAT(5, 2),
						 ataques VARCHAR(200),
						 debilidades VARCHAR(200),
						 aspecto BLOB
						 );

CREATE TABLE Historiales (
						  id_Historial INT  PRIMARY KEY,
						  victorias INT,
						  derrotas INT,
						  n_Partidas INT,
						  resultado VARCHAR(50),
						  jugador INT,
						  FOREIGN KEY (resultado) REFERENCES Partidas(result),
						  );

CREATE TABLE Partidas (
					   Nickname VARCHAR(50),
					   Personaje INT,
					   Background INT,
					   result VARCHAR(50),
					   FOREIGN KEY (Nickname) REFERENCES Jugadores(Nickname),
					   FOREIGN KEY (Personaje) REFERENCES Personajes(id_Personajes),
					   FOREIGN KEY (Background) REFERENCES Backgrounds(id_Background)
					   );

CREATE TABLE Backgrounds (
						  id_Background INT AUTO_INCREMENT PRIMARY KEY,
						  imagen BLOB,
						  musica BLOB
						  );

INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Kame_House.jpg','KHMusica.mp3');

INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'NAMEK.jpg','NMKMusica.mp3');

INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Ciudad.jpg','CITY_Musica.mp3');

INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Dojo_Pelea.jpg','Dojo_Musica.mp3');



INSERT INTO Jugadores ( id_Jugadores, Nickname, Username, Contrasena,historiales_id)
VALUES(1,'Braais','BraisArrieta','Contr_Prueba',1);





INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Goku',25.5,'kamehameha','Genkidama','Goku_8bit.jpg');

INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Vegetta',24.0,'Genkidama','kamehameha','Vegetta_8bit.jpg');

INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Freezer',23.5,'Dath Ball','kamehameha','Freeezer_8bit.jpg');



INSERT INTO Historiales (id_Historial,victorias, derrotas, n_Partidas,resultado,jugador)
VALUES (1,3, 3, 6,'Victoria',1 );



INSERT INTO Partidas (Nickname, Personaje, Background, result)
	VALUES ('Braais', 1, 1, 'Victoria');
