CREATE DATABASE DBPAuto
USE DBPAuto

CREATE TABLE Automovil
	(idAut nvarchar(100) NOT NULL PRIMARY KEY, 
	marca nvarchar (100),
	submarca nvarchar (100),
	AnioModelo int,
	emisionCO2 float,
	emisionNOx float,
	emisionAnualCO2 float)

CREATE TABLE Usuario
	(idUsu int NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombreP nvarchar(100),
	aP nvarchar(50),
	aM nvarchar (50),
	domicilio nvarchar(150),
	correo nvarchar (50),
	contrasenia nvarchar(25))

CREATE TABLE Registro
	(idRegistro int NOT NULL PRIMARY KEY IDENTITY(1,1),
	emisionesCO2Tot float,
	emisionesNOxTot float,
	aniosAntiguedad int,
	idAut nvarchar(100) REFERENCES Automovil)

CREATE TABLE RegistroUsuario
	(idUsu int references Usuario, 
	idRegistro int references Registro, 
	primary key (idUsu,idRegistro))

CREATE TABLE Viaje
	(idViaje int NOT NULL PRIMARY KEY IDENTITY(1,1),
	tipo nvarchar(50),
	fecha varchar(10),
	emisionCO2 float,
	emisionNOx float,
	idRegistro int REFERENCES Registro)

CREATE TABLE porDia
	(idViaje int REFERENCES Viaje PRIMARY KEY,
	velocidadProm int,
	horasViajadas int)

CREATE TABLE porSem
	(idViaje int REFERENCES Viaje PRIMARY KEY,
	horasPorDia int,
	velocidadProm int,
	numDiasAuto int)

CREATE TABLE porMes 
	(idViaje int REFERENCES Viaje PRIMARY KEY,
	kmPorDia int,
	numDiasConAuto int)

CREATE TABLE usuarioAdmin
	(idUsuario int NOT NULL PRIMARY KEY IDENTITY(1,1),
	nombreUsu nvarchar(30),
	contrasenia nvarchar(40))
