USE Master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'PROYECTO')
begin
	DROP DATABASE PROYECTO
end
GO

CREATE DATABASE PROYECTO
USE PROYECTO

CREATE TABLE ENTIDAD_PUBLICA
(
NOMBRE VARCHAR(30) PRIMARY KEY,
DIRECION VARCHAR(50)
)  

CREATE TABLE TELEFONO
(
NUMERO INT NOT NULL,
NOMBRE VARCHAR(30) FOREIGN KEY REFERENCES ENTIDAD_PUBLICA(NOMBRE) NOT NULL,
PRIMARY KEY (NUMERO,NOMBRE)
)

CREATE TABLE TRAMITE 
(
DESCRIPCION VARCHAR(100) NOT NULL,
CODIGO INT NOT NULL,
NOMBRE_ENTIDAD VARCHAR(30) FOREIGN KEY  REFERENCES ENTIDAD_PUBLICA(NOMBRE)NOT NULL,
NOMBRETRAM VARCHAR(30) NOT NULL,
PRIMARY KEY (CODIGO, NOMBRE_ENTIDAD)
)

CREATE TABLE USUARIO
(
CI INT PRIMARY  KEY ,
CONTRASENIA VARCHAR(15) NOT NULL,
NOMBRE_COMPLETO VARCHAR(100) NOT NULL
)

CREATE TABLE SOLICITUD_TRAMITE
(
ID INT PRIMARY KEY IDENTITY(100,1),
EMPLEADO  INT FOREIGN KEY REFERENCES USUARIO(CI)  NOT NULL,
CODIGO_TRAMITE INT NOT NULL,
FECHA_HORA DATETIME ,
NOMBRE_SOLICITA VARCHAR(30) ,
ESTADO VARCHAR(30) ,
NOMBRE_ENT VARCHAR(30),
FOREIGN KEY(CODIGO_TRAMITE, NOMBRE_ENT) REFERENCES TRAMITE(CODIGO, NOMBRE_ENTIDAD)
)

INSERT INTO ENTIDAD_PUBLICA VALUES('UTE','POCITOS'),
                                  ('OSE','MILLAN'),
                                  ('ANTEL', 'BULEVAR'),
                                  ('REGISTRO', 'AV. URUGUAY')
                                  
INSERT INTO TELEFONO VALUES ('27078400', 'ANTEL'),
							('24088600', 'ANTEL'),
							('12341156', 'OSE'),
							('26003124', 'REGISTRO')
							
INSERT INTO TRAMITE VALUES	('ATENCION AL PUBLICO', 155, 'ANTEL', 'MOSTRADOR'),
							('CONEXION FIBRA OPTICA', 143, 'ANTEL', 'CONEXION'),
							('ATENCION AL PUBLICO', 155, 'OSE', 'MOSTRADOR'),
							('CONEXION SANEAMIENTO', 145, 'OSE', 'CONEXION'),
							('PARTIDA DE NACIMIENTO', 105, 'REGISTRO', 'MOSTRADOR')
							
INSERT INTO SOLICITUD_TRAMITE VALUES (1111111, 143, GETDATE(), 'MARTIN', 'ALTA', 'ANTEL'),
									(1111111, 155, GETDATE(), 'PEPE', 'ALTA', 'OSE'),
									(1111111, 105, GETDATE(), 'JUAN', 'EJECUTADA', 'REGISTRO'),
									(1111111, 105, GETDATE(), 'JOAQUIN', 'ANULADA', 'REGISTRO')

INSERT INTO USUARIO VALUES(1111111, '123','JOAQUIN TORRES GARCIA'),
							(4830678, '1234', 'BRYAN FORMENTO')

SELECT * FROM USUARIO
SELECT * FROM ENTIDAD_PUBLICA
SELECT * FROM TELEFONO
SELECT * FROM SOLICITUD_TRAMITE
SELECT * FROM TRAMITE
select * from USUARIO where  CI = 1111111

--BUSCAR EMPLEADO EN SOLICITUD DE TRAMITE
GO
CREATE PROC SP_BUSCAREMPLEADOENTRAMITE
@CI INT
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE EMPLEADO = @CI
END
--SOLICITUDES ANULADAS
GO
CREATE PROC SP_LISTADOSOLICITUDTRAMITEANULADA
@NOMBRE VARCHAR(30),
@CODE INT
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE CODIGO_TRAMITE = @CODE AND  NOMBRE_ENT = @NOMBRE AND  ESTADO = 'ANULADA'
END
--SOLICITUDES EJECUTADAS
GO
CREATE PROC SP_LISTADOSOLICITUDTRAMITEEJECUTADA
@NOMBRE VARCHAR(30),
@CODE INT
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE CODIGO_TRAMITE = @CODE AND  NOMBRE_ENT = @NOMBRE AND  ESTADO  = 'EJECUTADA'
END
--TODAS LAS SOLICITUDES
GO
CREATE PROC SP_VERTODASLASSOLICITUDES
@NOMBRE VARCHAR(30),
@CODIGO INT
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE CODIGO_TRAMITE = @CODIGO AND NOMBRE_ENT = @NOMBRE
END
--LISTADO DE SOLICITUDES
GO
CREATE PROC SP_LISTADOSOLICITUDTRAMITE_ALTAS
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE ESTADO = 'ALTA'
END
GO
--VER TRAMITE SELECCIONADO TRAMITES
CREATE PROC SP_VER_TRAMITE
@CODIGO INT,
@NOMBRE_ENTIDAD VARCHAR(30)
AS 
BEGIN
SELECT TRAMITE.* FROM TRAMITE WHERE CODIGO = @CODIGO AND NOMBRE_ENTIDAD = @NOMBRE_ENTIDAD
END
GO
--LISTA DE NOMBRE DE TRAMITES 
CREATE PROC SP_LISTADO_NOMBRE_TRAMITES 
AS 
BEGIN 
SELECT DISTINCT NOMBRETRAM FROM TRAMITE  ORDER BY NOMBRETRAM
END
GO
--LISTA DE ENTIDADES
CREATE PROC SP_LISTADOENTIDADES
AS
BEGIN
SELECT DISTINCT * FROM ENTIDAD_PUBLICA 
END
GO
--VER TRAMITE SELECCIONADO TRAMITES
CREATE PROC SP_VER_TRAMITEXNOMBRE
@NOMBRE_ENTIDAD VARCHAR(30)
AS 
BEGIN
SELECT TRAMITE.* FROM TRAMITE WHERE NOMBRE_ENTIDAD = @NOMBRE_ENTIDAD
END
GO
--CONSULTA ESTADO SOLICITUD
CREATE PROC SP_BUSCAR_ESTADO_SOLICITUD
@ID INT
AS
BEGIN 
   SELECT SOLICITUD_TRAMITE.ESTADO FROM SOLICITUD_TRAMITE WHERE  ID = @ID
END
GO
--BUSCAR CODIGO EN TRAMITE
CREATE PROC SP_BUSCAR_CODIGO_TRAMITE
@CODIGO INT
AS
BEGIN
SELECT CODIGO FROM TRAMITE WHERE CODIGO = @CODIGO
END
GO
CREATE PROC SP_LISTADO_ALTAS
@FECHAINICIO DATETIME,
@FECHAFINAL DATETIME
AS
BEGIN
SELECT * FROM SOLICITUD_TRAMITE WHERE ESTADO = 'ALTA'
AND FECHA_HORA BETWEEN @FECHAINICIO AND @FECHAFINAL ORDER BY FECHA_HORA, ID
END
GO
--INGRESO DE USUARIO
CREATE PROC SP_INGRESOUSUARIO
@CI INT,
@CONTRASENIA VARCHAR(15),
@NOMBRECOMP VARCHAR(100)
AS
BEGIN

IF (EXISTS (SELECT USUARIO.* FROM USUARIO WHERE CI = @CI ))
          RETURN 1 --YA EXISTE USUARIO CON ESA CEDULA 
		  BEGIN TRAN 
		  INSERT USUARIO VALUES (@CI, @CONTRASENIA, @NOMBRECOMP)
		  IF @@ERROR != 0
		  BEGIN
		  ROLLBACK TRAN 
		  RETURN -1--ERROR DE INSERCION 
		  END
          COMMIT TRAN
		   RETURN 1 --SE INGRESO CORRECTAMENTE EL USUARIO 
END
GO
--LOGUEO USUARIO
CREATE PROC SP_LOGUEO_USUARIO
@CI INT,
@CONTRASENIA VARCHAR(15)
AS
BEGIN
SELECT CI, CONTRASENIA FROM USUARIO WHERE CI = @CI AND CONTRASENIA = @CONTRASENIA
END
GO
--BUSCO USUARIO
CREATE PROC SP_BUSCAR_USUARIO
@CI INT
AS
BEGIN
SELECT CI, CONTRASENIA, NOMBRE_COMPLETO FROM USUARIO WHERE CI = @CI
END
GO
--BUSCAR TRAMITE 
CREATE PROC SP_BUSCARTTRAMITE 
@NOMBRE VARCHAR(30),
@CODIGO INT
AS
BEGIN
SELECT * FROM TRAMITE WHERE NOMBRE_ENTIDAD = @NOMBRE AND CODIGO = @CODIGO
END
GO
--MODIFICAR TRAMITE 
CREATE PROC SP_MODIFICARTRAMITE
@DESCRIPCION VARCHAR(100) ,
@CODIGO INT ,
@NOMBRE_ENTIDAD VARCHAR(30),
@NOMBRETRAM VARCHAR(30)
AS
BEGIN
IF (NOT (EXISTS (SELECT NOMBRE_ENTIDAD FROM TRAMITE WHERE NOMBRE_ENTIDAD = @NOMBRE_ENTIDAD) ))
RETURN -2 --LA ENTIDAD NO EXISTE
BEGIN TRAN
UPDATE TRAMITE SET DESCRIPCION = @DESCRIPCION, NOMBRE_ENTIDAD = @NOMBRE_ENTIDAD, NOMBRETRAM = @NOMBRETRAM WHERE CODIGO = @CODIGO
   IF @@ERROR != 0 
   BEGIN
   ROLLBACK TRAN 
   RETURN -1 
   END
   COMMIT TRAN 
   RETURN 1
END
GO
--ELIMINAR TRAMITE
CREATE PROC SP_ELIMINARTRAMITE
@CODIGO INT
AS
BEGIN
IF NOT (EXISTS (SELECT * FROM  TRAMITE   WHERE CODIGO = @CODIGO))
                RETURN -1--NO EXISTE NO SE ELIMINA 
	  BEGIN TRAN
	  DELETE SOLICITUD_TRAMITE FROM SOLICITUD_TRAMITE WHERE CODIGO_TRAMITE = @CODIGO
	  IF @@ERROR != 0 
	  BEGIN
	  ROLLBACK TRAN
	  RETURN -2
	  END
	  DELETE TRAMITE FROM TRAMITE WHERE  CODIGO = @CODIGO
	  IF  @@ERROR != 0
	     BEGIN 
		 ROLLBACK TRAN
		 RETURN -3
		 END
		 COMMIT TRAN
		 RETURN 1
END
GO
--AGREGAR TRAMITE
CREATE PROC SP_AGREGARTRAMITE
@DESCRIPCION VARCHAR(100) ,
@CODIGO INT ,
@NOMBRE_ENTIDAD VARCHAR(30) ,
@NOMBRETRAM VARCHAR(30)
AS
BEGIN
  BEGIN TRAN
  INSERT INTO TRAMITE VALUES(@DESCRIPCION, @CODIGO, @NOMBRE_ENTIDAD, @NOMBRETRAM)
  IF @@ERROR != 0 
  BEGIN 
  ROLLBACK TRAN
  RETURN -2 -- ERROR DE INSERCION
  END
  COMMIT TRAN 
  RETURN 1
END
GO
--BUSCAR ENTIDAD
CREATE PROC SP_BUSCARENTIDAD
@NOMBRE VARCHAR(30)
AS
BEGIN
SELECT * FROM ENTIDAD_PUBLICA WHERE NOMBRE = @NOMBRE
END
GO
--ELIMINAR ENTIDADES 
CREATE PROC SP_ELIMINAR_ENTIDAD
@NOMBRE VARCHAR(30)
AS
BEGIN
IF (EXISTS (SELECT ENTIDAD_PUBLICA.* FROM  ENTIDAD_PUBLICA JOIN SOLICITUD_TRAMITE 
	  ON ENTIDAD_PUBLICA.NOMBRE = @NOMBRE AND  SOLICITUD_TRAMITE.NOMBRE_ENT = ENTIDAD_PUBLICA.NOMBRE))
      RETURN -1-- NO SE ELIMINA  POR QUE TIENE SOLICITUD ASOCIADA 
	  BEGIN TRAN
	  DELETE TELEFONO FROM TELEFONO  WHERE NOMBRE = @NOMBRE
	  IF @@ERROR != 0 
	  BEGIN
	  ROLLBACK TRAN
	  RETURN -2--ERROR EN ELIMINAR TELEFONO
	  END
	  DELETE TRAMITE FROM TRAMITE WHERE NOMBRE_ENTIDAD = @NOMBRE
	   IF @@ERROR != 0 
	  BEGIN
	  ROLLBACK TRAN
	  RETURN -3--ERROR EN ELIMINAR TRAMITE
	  END
	  DELETE ENTIDAD_PUBLICA FROM ENTIDAD_PUBLICA WHERE  NOMBRE = @NOMBRE
	  IF  @@ERROR != 0
	  BEGIN 
	  ROLLBACK TRAN
	  RETURN -4--ERROR EN ELIMINAR ENTIDAD
	  END
	  COMMIT TRAN
	  RETURN 1
END
GO
--MODIFICAR ENTIDADES PUBLICAS 
CREATE PROC SP_MODIFICARENTIDAD
@NOMBRE VARCHAR(30),
@DIRECCION VARCHAR(50)
AS
BEGIN
BEGIN TRAN 
UPDATE ENTIDAD_PUBLICA SET DIRECION = @DIRECCION WHERE NOMBRE  = @NOMBRE
   IF @@ERROR != 0 
   BEGIN
   ROLLBACK TRAN 
   RETURN -1 --ERROR DE EDICION
   END
   COMMIT TRAN 
   RETURN 1
END
GO
--AGREGAR ENTIDAD 
CREATE PROC SP_AGREGARENTIDAD
@NOMBRE VARCHAR(30),
@DIRECION VARCHAR(50)
AS
BEGIN
  BEGIN TRAN
  INSERT INTO ENTIDAD_PUBLICA VALUES( @NOMBRE ,@DIRECION)
  IF @@ERROR != 0 
  BEGIN 
  ROLLBACK TRAN
  RETURN -2 -- ERROR DE INSERCION
  END
  COMMIT TRAN 
  RETURN 1
END
GO
--ELIMINAR EMPLEADO 
CREATE PROC SP_ELIMINAR_USUARIO
@CI INT
AS
BEGIN
IF EXISTS(SELECT * FROM SOLICITUD_TRAMITE WHERE EMPLEADO = @CI)
RETURN -1 --EXISTE SOICITUD ASOCIADA NO SE ELIMINA 
 DELETE USUARIO WHERE CI = @CI
 IF @@ERROR != 0 
 RETURN -2
 ELSE 
 RETURN 1
 END
GO
 --MODIFICAR USUARIO 
CREATE PROC SP_MODIFICAR_USUARIO
 @CI INT,
 @CONTRASENIA VARCHAR(15),
 @NOMBRE_COMPLETO VARCHAR(100)
 AS
 BEGIN
 BEGIN TRAN
 UPDATE USUARIO SET CONTRASENIA = @CONTRASENIA, NOMBRE_COMPLETO = @NOMBRE_COMPLETO WHERE CI = @CI
 IF @@ERROR != 0 
 BEGIN 
 ROLLBACK TRAN
 RETURN -1-- ERROR DE EDICION 
 END
 COMMIT TRAN 
 RETURN 1
 END
 
GO
--AGREGAR TELEFONO
CREATE PROC SP_AGREGARTELEFONO
@NOMBRE VARCHAR(30),
@NUMERO INT
AS
BEGIN
IF EXISTS(SELECT NUMERO FROM TELEFONO WHERE NUMERO=@NUMERO AND NOMBRE=@NOMBRE)
RETURN -1--TELEFONO REPETIDO
--EMPIEZO A AGREGAR TELEFONOS
INSERT TELEFONO(NOMBRE, NUMERO) VALUES (@NOMBRE, @NUMERO)
RETURN 1
END
GO
--CARGAR TELEFONOS
CREATE PROC SP_LISTARTELEFONOS
@NOMBRE VARCHAR (30)
AS
BEGIN
SELECT NUMERO, NOMBRE FROM TELEFONO WHERE NOMBRE = @NOMBRE
END
GO
--MODIFICAR TELEFONOS
CREATE PROC SP_ELIMINARTELEFONOS
@NOMBRE VARCHAR(30),
@NUMERO INT
AS
BEGIN
BEGIN TRAN 
DELETE TELEFONO WHERE NOMBRE  = @NOMBRE
   IF @@ERROR != 0 
   BEGIN
   ROLLBACK TRAN 
   RETURN -1 --ERROR DE EDICION
   END
   COMMIT TRAN 
   RETURN 1
END
GO
--AGREGAR SOLICITUD DE TRAMITES 
CREATE PROC SP_AGREGAR_SOLICITUD_TRAMITES 
@EMP  INT,
@TIPO_TRAMITE INT,
@FECHA_HORA DATETIME,
@NOMBRE_SOLICITA VARCHAR(30),
@ESTADO VARCHAR(30),
@NOMBREENT VARCHAR(30)
AS
BEGIN 
IF (EXISTS(SELECT * FROM SOLICITUD_TRAMITE WHERE NOMBRE_SOLICITA = @NOMBRE_SOLICITA AND CODIGO_TRAMITE = @TIPO_TRAMITE AND FECHA_HORA = @FECHA_HORA))
RETURN -1 --YA HAY UNA SOLICITUD DE ESTE USUARIO PARA ESTE TRAMITE
INSERT INTO SOLICITUD_TRAMITE VALUES(@EMP, @TIPO_TRAMITE, @FECHA_HORA, @NOMBRE_SOLICITA, @ESTADO, @NOMBREENT)
IF @@ERROR != 0
RETURN -2 --ERROR DE INSERCION
ELSE
RETURN IDENT_CURRENT('SOLICITUD_TRAMITE')--NUMERO DE SOLICITUD
END
GO
--LISTAR TRAMITES
CREATE PROC SP_LISTAR_TRAMITES
AS
BEGIN
SELECT DISTINCT * FROM TRAMITE
END
GO
--CAMBIAR ESTADO DE SOLICITUD
CREATE PROC SP_MODIFICAR_ESTADO
@ID INT,
@ESTADO VARCHAR(30)
AS
BEGIN
UPDATE SOLICITUD_TRAMITE SET ESTADO = @ESTADO WHERE ID = @ID
IF @@ERROR != 0
RETURN -1
ELSE
RETURN 1
END
GO


--Select * from SOLICITUD_TRAMITE where estado= 'ALTA' order by FECHA_HORA,ID desc

--2020-11-16 00:00:00.000