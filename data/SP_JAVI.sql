Use [GD1C2014]    /* Utilizamos una base de datos EXTERNA,la base a la cual se dirigiran las proximas consultas SQL en el proceso actual. */
Go 
/* Signo de finalizacion de lotes de sentencia*/



/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setCantidadIntentos') IS NOT NULL
DROP PROCEDURE J2LA.setCantidadIntentos
GO
CREATE PROCEDURE J2LA.setCantidadIntentos @idUsuario INT, @cantIntentos INT
AS
BEGIN
	UPDATE 
		J2LA.Usuarios
    SET
		usu_Cant_Intentos = @cantIntentos,
		usu_Inhabilitado = CASE WHEN @cantIntentos >= 3 THEN 1 ELSE 0 END,
		usu_Motivo = CASE WHEN @cantIntentos >= 3 THEN 'Intentos' ELSE '' END
	WHERE
		usu_Id = @idUsuario
END
GO


/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
CREATE FUNCTION J2LA.getFuncionalidadesPorRol( @nombreRol varchar(255) )
RETURNS TABLE
AS
RETURN 
	(SELECT
			f.fun_Id,
			f.fun_Nombre
	FROM 
		J2LA.Roles r, 
		J2LA.Funcionalidades f, 
		J2LA.Roles_Funcionalidades rf
	WHERE
		rol_Id = rolfun_rol_Id
	AND
		fun_Id = rolfun_fun_Id
	AND
		rol_Nombre = @nombreRol
	AND
		rol_Inhabilitado = 0
	AND
		rol_Eliminado = 0
	)
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.existeUsuario') IS NOT NULL
DROP FUNCTION J2LA.existeUsuario
GO
CREATE FUNCTION J2LA.existeUsuario(@userName varchar(255))
RETURNS BIT
AS
BEGIN
	IF( (SELECT usu_userName FROM J2LA.Usuarios where usu_Username = @userName) IS NOT NULL)
		RETURN 1
	RETURN 0
END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setNuevoUsuario') IS NOT NULL
DROP PROCEDURE J2LA.setNuevoUsuario
GO
CREATE PROCEDURE J2LA.setNuevoUsuario @userName varchar(255), @password varchar(255)
AS
BEGIN
	INSERT INTO
		J2LA.Usuarios (usu_UserName, usu_Pass, usu_Cant_Intentos, usu_Inhabilitado, usu_Eliminado, usu_Primer_Ingreso)
	VALUES
		(@userName, @password, 0, 0, 0, 0)
END
GO


/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getUserId') IS NOT NULL
DROP FUNCTION J2LA.getUserId
GO
CREATE FUNCTION J2LA.getUserId(@userName varchar(255))
RETURNS INT
AS
BEGIN
	DECLARE @usuarioId INT
	SET @usuarioId = (SELECT usu_Id FROM J2LA.Usuarios WHERE usu_UserName = @userName)
	
	RETURN @usuarioId
END
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getRolId') IS NOT NULL
DROP FUNCTION J2LA.getRolId
GO
CREATE FUNCTION J2LA.getRolId(@nombre varchar(255))
RETURNS INT
AS
BEGIN
	DECLARE @rol_Id INT
	SET @rol_Id = (SELECT rol_Id FROM J2LA.Roles WHERE  rol_Nombre = @nombre)
	
	RETURN @rol_Id
END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setNuevoCliente') IS NOT NULL
DROP PROCEDURE J2LA.setNuevoCliente
GO
CREATE PROCEDURE J2LA.setNuevoCliente @userName varchar(255), @password varchar(255), @nombre varchar(255), @apellido varchar(255), @dni numeric(18,0), @tipoDoc int, @mail varchar(255), @telefono varchar(255), @nomCalle varchar(255), @nroCalle numeric(18,0), @piso numeric(28,0), @depto varchar(50), @localidad varchar(255), @cp varchar(50), @fecnac datetime, @cuil varchar(50)
AS
BEGIN
	EXECUTE J2LA.setNuevoUsuario @userName, @password
	
	INSERT INTO
		J2LA.Clientes (cli_Nombre, cli_Apellido, cli_Nro_Doc, cli_Tipodoc_Id, cli_Mail, cli_Tel, cli_Dom_Calle, cli_Nro_Calle, cli_Piso, cli_Dpto, cli_Localidad, cli_CP, cli_Fecha_Nac, cli_Cuil, cli_usu_Id)
	VALUES
		(@nombre, @apellido, @dni, @tipoDoc, @mail, @telefono, @nomCalle, @nroCalle, @piso, @depto, @localidad, @cp, @fecnac, @cuil, J2LA.getUserId(@userName))

	INSERT INTO
		J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
	VALUES
		(J2LA.getUserId(@userName), J2LA.getRolId('Cliente'))
	
END
GO




