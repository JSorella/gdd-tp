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
CREATE PROCEDURE J2LA.setNuevoCliente 
	@userName varchar(255), 
	@password varchar(255), 
	@nombre varchar(255), 
	@apellido varchar(255), 
	@dni numeric(18,0), 
	@tipoDoc int, 
	@mail varchar(255), 
	@telefono varchar(255), 
	@nomCalle varchar(255), 
	@nroCalle numeric(18,0), 
	@piso numeric(28,0), 
	@depto varchar(50), 
	@localidad varchar(255), 
	@cp varchar(50), 
	@fecnac datetime, 
	@cuil varchar(50)
AS
BEGIN
	EXECUTE J2LA.setNuevoUsuario @userName, @password
	
	INSERT INTO
		J2LA.Clientes (
			cli_Nombre, 
			cli_Apellido, 
			cli_Nro_Doc, 
			cli_Tipodoc_Id, 
			cli_Mail, 
			cli_Tel, 
			cli_Dom_Calle, 
			cli_Nro_Calle, 
			cli_Piso, 
			cli_Dpto, 
			cli_Localidad, 
			cli_CP, 
			cli_Fecha_Nac, 
			cli_Cuil, 
			cli_usu_Id)
	VALUES
		(@nombre, 
		@apellido, 
		@dni, 
		@tipoDoc, 
		@mail, 
		@telefono, 
		@nomCalle, 
		@nroCalle, 
		@piso, 
		@depto, 
		@localidad, 
		@cp, 
		@fecnac, 
		@cuil, 
		J2LA.getUserId(@userName))

	INSERT INTO
		J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
	VALUES
		(J2LA.getUserId(@userName), J2LA.getRolId('Cliente'))
	
END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setPreguntaRespuesta') IS NOT NULL
DROP PROCEDURE J2LA.setPreguntaRespuesta
GO
CREATE PROCEDURE J2LA.setPreguntaRespuesta 
	@preg_pub_codigo numeric(18,0), 
	@preg_Id int, 
	@preg_Tipo char(1), 
	@preg_Comentario varchar(255), 
	@preg_usu_Id int,
	@preg_Fecha datetime
AS
BEGIN

	IF (@preg_Tipo = 'P')
	BEGIN
		DECLARE @maxId INT
		SET @maxId = (SELECT MAX(preg_Id)FROM J2LA.Preguntas)
		SET @preg_Id = CASE WHEN @maxId IS NULL THEN 1 ELSE (@maxId + 1) END
	END
	/* si preg_tipo = 'R', entonces tomo el preg_Id por referencia*/ 

	INSERT INTO
		J2LA.Preguntas (preg_Id, preg_pub_codigo, preg_Tipo, preg_Comentario, preg_usu_Id, preg_Fecha)
	VALUES
		(@preg_Id, @preg_pub_codigo, @preg_Tipo, @preg_Comentario, @preg_usu_Id, @preg_Fecha)
END
GO


/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setCompra') IS NOT NULL
DROP PROCEDURE J2LA.setCompra
GO
CREATE PROCEDURE J2LA.setCompra 
	@comp_Id int,
	@comp_pub_Codigo numeric(18,0), 
	@comp_usu_Id int,
	@comp_Fecha datetime,
	@comp_Cantidad numeric(18,0),
	@comp_Comision numeric(18,1),
	@comp_cal_Codigo numeric(18,0),
	@comp_Facturada bit
AS
BEGIN
	DECLARE @maxId INT
	SET @maxId = (SELECT MAX(comp_Id)FROM J2LA.Compras)
	SET @comp_Id = CASE WHEN @maxId IS NULL THEN 1 ELSE (@comp_Id + 1) END

	INSERT INTO
		J2LA.Compras ( comp_pub_Codigo, comp_usu_Id, comp_Fecha, comp_Cantidad, comp_Comision, comp_Facturada)
	VALUES
		( @comp_pub_Codigo, @comp_usu_Id, @comp_Fecha, @comp_Cantidad, @comp_Comision, @comp_Facturada)
END
GO

/*-------------------------TRIGGER (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.updateStockPublicacion') IS NOT NULL
DROP TRIGGER J2LA.updateStockPublicacion
GO
CREATE TRIGGER J2LA.updateStockPublicacion 
ON J2LA.Compras
AFTER INSERT
AS
BEGIN
	/* Debo decrementar el Stock en la publicación */
	DECLARE @comp_Cantidad numeric(18,0)
	DECLARE	@comp_pub_Codigo numeric(18,0)
	SET @comp_Cantidad = (SELECT comp_Cantidad FROM inserted)
	SET @comp_pub_Codigo = (SELECT comp_pub_Codigo FROM inserted)
	
	UPDATE J2LA.Publicaciones
		SET	pub_estado_Id = CASE WHEN (pub_Stock - @comp_Cantidad = 0) THEN 4 ELSE pub_estado_Id END,
			pub_Stock = (pub_Stock - @comp_Cantidad)
		WHERE pub_Codigo = @comp_pub_Codigo
END
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getPrecioMax') IS NOT NULL
DROP FUNCTION J2LA.getPrecioMax
GO
CREATE FUNCTION J2LA.getPrecioMax(@pub_Codigo numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @precio_max numeric(18,2)
	SET @precio_max = 
			(CASE 
			WHEN (SELECT COUNT(*) FROM J2LA.Ofertas WHERE @pub_Codigo = ofer_pub_Codigo) > 0 
            THEN (SELECT MAX(ofer_Monto) FROM J2LA.Ofertas WHERE @pub_Codigo = ofer_pub_Codigo)
            ELSE (SELECT P.pub_precio FROM J2LA.Publicaciones P WHERE P.pub_Codigo = @pub_Codigo) END)
	
	RETURN @precio_max
END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setOferta') IS NOT NULL
DROP PROCEDURE J2LA.setOferta
GO
CREATE PROCEDURE J2LA.setOferta 
	@ofer_Id int,
	@ofer_pub_Codigo numeric(18,0), 
	@ofer_usu_Id int,
	@ofer_Fecha datetime,
	@ofer_Monto numeric(18,2)
AS
BEGIN
	INSERT INTO
		J2LA.Ofertas 
		(ofer_pub_Codigo, ofer_usu_Id, ofer_Fecha, ofer_Monto)
	VALUES
		( @ofer_pub_Codigo, @ofer_usu_Id, @ofer_Fecha, @ofer_Monto)
END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getVendedor') IS NOT NULL
DROP PROCEDURE J2LA.getVendedor
GO
CREATE PROCEDURE J2LA.getVendedor @idUsuario int
AS

	IF (( SELECT COUNT(*) FROM J2LA.Clientes  WHERE cli_usu_Id = @idUsuario ) > 0 )
	BEGIN
		
		 SELECT
			 [Nombre] = cli_Nombre,
			 [Apellido] = cli_Apellido,
			 [Documento] =  (cli_Tipodoc_Id +' '+cli_Nro_Doc),
			 [Mail] = cli_Mail, 
			 [Teléfono] = cli_Tel , 
			 [Calle] = cli_Dom_Calle, 
			 [Altura] = cli_Nro_Calle , 
			 [Piso] = cli_Piso, 
			 [Depto] = cli_Dpto, 
			 [Localidad] = cli_Localidad, 
			 [CP] = cli_CP, 
			 [CUIL] = cli_Cuil 
		 FROM 
			J2LA.Clientes 
		 WHERE 
			cli_usu_Id = @idUsuario
		
	END
	IF ((SELECT COUNT(*) FROM J2LA.Empresas WHERE emp_usu_Id = @idUsuario ) > 0)
	BEGIN
		
		SELECT 
			[Razón Social] = emp_Razon_Social,
			[CUIT] = emp_CUIT,
			[Mail] = emp_Mail,
			[Telefono] = emp_Tel,
			[Calle] = emp_Dom_Calle,
			[Altura] = emp_Nro_Calle,
			[Piso] = emp_Piso,
			[Depto] = emp_Dpto,
			[Localidad] = emp_Localidad,
			[CP] = emp_CP,
			[Ciudad] = emp_Ciudad,
			[Contacto] = emp_Contacto
		FROM 
			J2LA.Empresas 
		WHERE 
			emp_usu_Id = @idUsuario
		
	END

GO
