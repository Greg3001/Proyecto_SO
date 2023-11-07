DROP DATABASE IF EXISTS CuttlefishBBDD;
CREATE DATABASE CuttlefishBBDD;
USE CuttlefishBBDD;
CREATE TABLE Jugadores (			
						id_Jugadores INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
						Username VARCHAR(50) NOT NULL,
						Contrasena VARCHAR(50)
						);

CREATE TABLE Personajes (
						 id_Personajes INT NOT NULL AUTO_INCREMENT PRIMARY KEY,
						 nombre VARCHAR(50),
						 salud FLOAT(5, 2),
						 ataques VARCHAR(200),
						 debilidades VARCHAR(200),
						 aspecto BLOB
						 );
CREATE TABLE Backgrounds (
						  id_Background INT AUTO_INCREMENT PRIMARY KEY,
						  imagen BLOB,
						  musica BLOB
						  );
CREATE TABLE Partidas (
					   id_Partidas INT PRIMARY KEY NOT NULL,
					   Nickname INT,
					   Personaje INT,
					   Background INT,
					   result INT,
					   FOREIGN KEY (Nickname) REFERENCES Jugadores(id_Jugadores),
					   FOREIGN KEY (Personaje) REFERENCES Personajes(id_Personajes),
					   FOREIGN KEY (Background) REFERENCES Backgrounds(id_Background)
					   );
CREATE TABLE Historiales (
                          id_Jugador INT,
						  resultado INT,
						  XP INT,
                          FOREIGN KEY (id_Jugador) REFERENCES Jugadores(id_Jugadores)
						  );


INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Kame_House.jpg','KHMusica.mp3');
INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'NAMEK.jpg','NMKMusica.mp3');
INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Ciudad.jpg','CITY_Musica.mp3');
INSERT INTO Backgrounds ( imagen, musica)
VALUES( 'Dojo_Pelea.jpg','Dojo_Musica.mp3');

INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Goku',25.5,'kamehameha','Genkidama','Goku_8bit.jpg');

INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Vegetta',24.0,'Genkidama','kamehameha','Vegetta_8bit.jpg');



INSERT INTO Personajes (nombre, salud, ataques, debilidades, aspecto)
VALUES('Freezer',23.5,'Dath Ball','kamehameha','Freeezer_8bit.jpg');


