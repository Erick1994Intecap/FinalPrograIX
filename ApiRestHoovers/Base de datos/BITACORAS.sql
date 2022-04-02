USE HOOVERS
GO


CREATE TABLE METODO_HTTP(
ID INT IDENTITY(1,1),
NOMBRE VARCHAR(20),
CONSTRAINT PK_METODO PRIMARY KEY (ID)
)


CREATE TABLE MODULO(
ID INT IDENTITY(1,1),
NOMBRE VARCHAR(20),
CONSTRAINT PK_MODULO PRIMARY KEY (ID)
)

CREATE TABLE BITACORA(
ID INT IDENTITY(1,1), 
ID_MODULO INT, 
ID_METODO INT, 
DESCRIPCION VARCHAR(max),
FECHA_REGISTRO DATETIME DEFAULT(GETDATE()),
USUARIO VARCHAR(50) DEFAULT(@@SERVERNAME),
CONSTRAINT PK_BITACORA PRIMARY KEY(ID),
CONSTRAINT FK_BITA_MODULO FOREIGN KEY(ID_MODULO) REFERENCES MODULO(ID),
CONSTRAINT FK_BITA_METODO FOREIGN KEY(ID_METODO) REFERENCES METODO_HTTP(ID)
)


INSERT INTO METODO_HTTP(NOMBRE)
VALUES 
('GET'),
('POST'),
('PUT'),
('DELETE')


INSERT INTO MODULO(NOMBRE)
VALUES 
('CLIENTE'),
('VEHICULO'),
('VIAJE'),
('DEPARTAMENTO')