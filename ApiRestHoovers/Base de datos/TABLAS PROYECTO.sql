IF NOT EXISTS (SELECT * FROM master..sysdatabases WHERE (name = 'HOOVERS'))
BEGIN
CREATE DATABASE HOOVERS
END
GO
USE HOOVERS
GO


IF OBJECT_ID('HOOVERS..VIAJE') IS NOT NULL
BEGIN
DROP TABLE VIAJE
END
CREATE TABLE VIAJE(
ID INT IDENTITY(1,1),
ID_CLIENTE INT,
ID_VEHICULO INT,
FECHA_VIAJE DATE,
FECHA_FIN DATE DEFAULT(GETDATE()),
PRECIO_VIAJE NUMERIC(16,2),
ID_DEPTO_VIAJE INT DEFAULT(1),
DESCRIPCION_VIAJE VARCHAR(250) DEFAULT('VIAJE DE NEGOCIO'),
VIAJE_REALIZADO INT DEFAULT(0),
CONSTRAINT PK_VIAJE PRIMARY KEY(ID)
)

IF OBJECT_ID('HOOVERS..CLIENTE') IS NOT NULL
BEGIN
DROP TABLE CLIENTE
END
CREATE TABLE CLIENTE(
ID INT IDENTITY(1,1),
NOMBRE VARCHAR(250),
APELLIDO VARCHAR(250),
TELEFONO VARCHAR(20),
ESTADO INT DEFAULT(1),
FECHA_CREACION DATETIME DEFAULT(GETDATE()),
FECHA_ACTUALIZACION DATETIME DEFAULT(GETDATE())
CONSTRAINT PK_CLIENTE PRIMARY KEY(ID)
)


IF OBJECT_ID('HOOVERS..VEHICULO') IS NOT NULL
BEGIN
DROP TABLE VEHICULO
END
CREATE TABLE VEHICULO(
ID INT IDENTITY(1,1),
MODELO INT,
NOMBRE VARCHAR(250), 
DESCRIPCION VARCHAR(250), 
ID_TIPO INT DEFAULT(1),
ESTADO INT DEFAULT(1),
FECHA_CREACION DATETIME DEFAULT(GETDATE()),
FECHA_ACTUALIZACION DATETIME DEFAULT(GETDATE())
CONSTRAINT PK_VEHICULO PRIMARY KEY(ID)
)

IF OBJECT_ID('HOOVERS..TIPO_VEHICULO') IS NOT NULL
BEGIN
DROP TABLE TIPO_VEHICULO
END
CREATE TABLE TIPO_VEHICULO(
ID INT IDENTITY(1,1),
NOMBRE VARCHAR(100),
DESCRIPCION VARCHAR(100),
ESTADO INT DEFAULT(1),
FECHA_CREACION DATETIME DEFAULT(GETDATE()),
FECHA_ACTUALIZACION DATETIME DEFAULT(GETDATE())
CONSTRAINT PK_TIPO_VEHICULO PRIMARY KEY(ID)
)

IF OBJECT_ID('HOOVERS..DEPARTAMENTO') IS NOT NULL
BEGIN
DROP TABLE DEPARTAMENTO
END
CREATE TABLE DEPARTAMENTO(
ID INT IDENTITY(1,1),
NOMBRE VARCHAR(100),
ESTADO INT DEFAULT(1),
FECHA_CREACION DATETIME DEFAULT(GETDATE()),
FECHA_ACTUALIZACION DATETIME DEFAULT(GETDATE())
CONSTRAINT PK_DEPTO PRIMARY KEY(ID)
)

ALTER TABLE VEHICULO
ADD 
CONSTRAINT FK_TIPO FOREIGN KEY(ID_TIPO) REFERENCES TIPO_VEHICULO(ID)

ALTER TABLE VIAJE
ADD 
CONSTRAINT FK_CLIENTE FOREIGN KEY(ID_CLIENTE) REFERENCES CLIENTE(ID),
CONSTRAINT FK_VEHICULO FOREIGN KEY(ID_VEHICULO) REFERENCES VEHICULO(ID),
CONSTRAINT FK_DEPARTAMENTO FOREIGN KEY(ID_DEPTO_VIAJE) REFERENCES DEPARTAMENTO(ID)
