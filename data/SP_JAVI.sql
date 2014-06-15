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
		usu_Motivo = CASE WHEN @cantIntentos >= 3 THEN 'Tres Intentos Fallidos en Login' ELSE '' END
	WHERE
		usu_Id = @idUsuario
END
GO


/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
CREATE FUNCTION J2LA.getFuncionalidadesPorRol( @nombreRol nvarchar(255) )
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
CREATE FUNCTION J2LA.existeUsuario(@userName nvarchar(255))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(usu_userName) FROM J2LA.Usuarios where usu_Username = @userName) > 0 )
		RETURN 1
	RETURN 0
END
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.existeTelefono') IS NOT NULL
DROP FUNCTION J2LA.existeTelefono
GO
CREATE FUNCTION J2LA.existeTelefono(@cli_tel nvarchar(255))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(cli_tel) FROM J2LA.Clientes where cli_tel = @cli_tel) > 0)
		RETURN 1
	RETURN 0
END
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.existeDni') IS NOT NULL
DROP FUNCTION J2LA.existeDni
GO
CREATE FUNCTION J2LA.existeDni(@cli_Tipodoc_Id int, @cli_Nro_Doc numeric(18,0))
RETURNS BIT
AS
BEGIN
	IF( (	SELECT COUNT(cli_Nro_Doc) 
			FROM J2LA.Clientes 
			WHERE 
				cli_Nro_Doc = @cli_Nro_Doc
			AND	
				cli_Tipodoc_Id = @cli_Tipodoc_Id
		) > 0 )
		RETURN 1
	RETURN 0
END
GO

/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.validarPrimerIngreso') IS NOT NULL
DROP FUNCTION J2LA.validarPrimerIngreso
GO
CREATE FUNCTION J2LA.validarPrimerIngreso(@usu_Id int)
RETURNS BIT
AS
BEGIN

	DECLARE @primer_intento BIT
	
	SET @primer_intento = (
		SELECT usu_Primer_Ingreso 
		FROM J2LA.Usuarios 
		WHERE usu_Id = @usu_Id
		)

	RETURN @primer_intento
END
GO


/*-------------------------PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setPrimerIngresoValido') IS NOT NULL
DROP PROCEDURE J2LA.setPrimerIngresoValido
GO
CREATE PROCEDURE J2LA.setPrimerIngresoValido @usu_Id int
AS
BEGIN
		UPDATE J2LA.Usuarios
		SET usu_Primer_Ingreso = 0
		WHERE usu_Id = @usu_Id
END
GO



/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setNuevoUsuario') IS NOT NULL
DROP PROCEDURE J2LA.setNuevoUsuario
GO
CREATE PROCEDURE J2LA.setNuevoUsuario @usu_UserName nvarchar(255), @usu_Pass nvarchar(255), @usu_Primer_Ingreso bit
AS
BEGIN
	INSERT INTO
		J2LA.Usuarios (usu_UserName, usu_Pass, usu_Cant_Intentos, usu_Inhabilitado, usu_Eliminado, usu_Primer_Ingreso)
	VALUES
		(@usu_UserName, @usu_Pass, 0, 0, 0, @usu_Primer_Ingreso)
END
GO


/*-------------------------FUNCTION (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.getUserId') IS NOT NULL
DROP FUNCTION J2LA.getUserId
GO
CREATE FUNCTION J2LA.getUserId(@userName nvarchar(255))
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
CREATE FUNCTION J2LA.getRolId(@nombre nvarchar(255))
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
	@cli_Nombre nvarchar(255), 
	@cli_Apellido nvarchar(255), 
	@cli_Tipodoc_Id int, 
	@cli_Nro_Doc numeric(18,0), 
	@cli_Mail nvarchar(255), 
	@cli_Tel nvarchar(255), 
	@cli_Dom_Calle nvarchar(255), 
	@cli_Nro_Calle numeric(18,0), 
	@cli_Piso numeric(28,0), 
	@cli_Dpto nvarchar(50), 
	@cli_Localidad nvarchar(255), 
	@cli_CP nvarchar(50), 
	@cli_Fecha_Nac datetime, 
	@cli_Cuil nvarchar(50),
	@cli_usu_Id int,
	
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit,
	@usu_Inhabilitado_Comprar bit
	
AS
BEGIN
	EXECUTE J2LA.setNuevoUsuario @usu_UserName, @usu_Pass, @usu_Primer_Ingreso
	
	INSERT INTO
		J2LA.Clientes (
			cli_Nombre, 
			cli_Apellido, 
			cli_Tipodoc_Id, 
			cli_Nro_Doc, 
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
	VALUES(
		@cli_Nombre, 
		@cli_Apellido, 
		@cli_Tipodoc_Id , 
		@cli_Nro_Doc, 
		@cli_Mail , 
		@cli_Tel , 
		@cli_Dom_Calle , 
		@cli_Nro_Calle , 
		@cli_Piso , 
		@cli_Dpto, 
		@cli_Localidad, 
		@cli_CP , 
		@cli_Fecha_Nac , 
		@cli_Cuil ,
		J2LA.getUserId(@usu_UserName))

	INSERT INTO
		J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
	VALUES
		(J2LA.getUserId(@usu_UserName), 2) /*Donde 2 es Cliente*/
	
END
GO


/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.actualizarCliente') IS NOT NULL
DROP PROCEDURE J2LA.actualizarCliente
GO
CREATE PROCEDURE J2LA.actualizarCliente(
	@emp_Razon_Social nvarchar(255),
	@emp_CUIT nvarchar(50),
	@emp_Mail nvarchar(50),
	@emp_Tel nvarchar(50),
	@emp_Dom_Calle nvarchar(255),
	@emp_Nro_Calle numeric(18,0),
	@emp_Piso numeric(18,0),
	@emp_Dpto nvarchar(255),
	@emp_Localidad nvarchar(255),
	@emp_CP nvarchar(50),
	@emp_Ciudad nvarchar(255),
	@emp_Contacto nvarchar(255),
	@emp_Fecha_Creacion datetime,
	@emp_usu_Id int,
	
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Inhabilitado_Comprar bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit)
AS
	BEGIN
		UPDATE J2LA.Empresas
		SET
			emp_Razon_Social = @emp_Razon_Social,
			emp_CUIT = @emp_CUIT,
			emp_Mail = @emp_Mail,
			emp_Tel = @emp_Tel,
			emp_Dom_Calle = @emp_Dom_Calle,
			emp_Nro_Calle = @emp_Nro_Calle,
			emp_Piso = @emp_Piso,
			emp_Dpto = @emp_Dpto,
			emp_Localidad = @emp_Localidad,
			emp_CP = @emp_CP,
			emp_Ciudad = @emp_Ciudad,
			emp_Contacto = @emp_Contacto,
			emp_Fecha_Creacion = @emp_Fecha_Creacion
		WHERE emp_usu_Id = @emp_usu_Id
		
		UPDATE J2LA.Usuarios
		SET usu_Eliminado = @usu_Eliminado
		WHERE usu_Id = @usu_Id
	END
GO

/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.bajaCliente') IS NOT NULL
DROP PROCEDURE J2LA.bajaCliente
GO
CREATE PROCEDURE J2LA.bajaCliente(@emp_CUIT nvarchar(50))
AS
	BEGIN
		DECLARE @emp_usu_Id int
		SET @emp_usu_Id = (SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT)
		
		UPDATE J2LA.Usuarios
		SET usu_Eliminado = 1
		WHERE usu_Id = @emp_usu_Id
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
	@preg_Comentario nvarchar(255), 
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

/*-------------------------TRIGGER (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.validarComprasSinRendir') IS NOT NULL
DROP TRIGGER J2LA.validarComprasSinRendir
GO
CREATE TRIGGER J2LA.validarComprasSinRendir 
ON J2LA.Compras
AFTER INSERT
AS
BEGIN
	DECLARE @pub_usu_Id int
	DECLARE @cantComprasSinRendir int
	DECLARE @comp_pub_Codigo int
	SET @comp_pub_Codigo = (SELECT comp_pub_Codigo FROM inserted)
	SET @pub_usu_Id = (
		SELECT pub_usu_Id 
		FROM J2LA.Publicaciones 
		WHERE pub_Codigo = @comp_pub_Codigo)
	
	SET @cantComprasSinRendir = (
		SELECT COUNT(*)	
		FROM 
			J2LA.Compras C
			, J2LA.Publicaciones P
		WHERE
			C.comp_pub_Codigo = P.pub_Codigo
		AND
			P.pub_usu_Id = @pub_usu_Id
		AND 
			C.comp_Facturada = 0
		)
	
	
	IF (@cantComprasSinRendir >= 10)
	BEGIN
		UPDATE J2LA.Publicaciones
		SET	pub_estado_Id = 3 /* Pausada */
		WHERE pub_usu_Id = @pub_usu_Id
		
		UPDATE J2LA.Usuarios
		SET	
			usu_Inhabilitado = 1
			, usu_Motivo = 'Debe rendir 10 o más Compras pendientes'
		WHERE 
			usu_Id = @pub_usu_Id
	END
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
