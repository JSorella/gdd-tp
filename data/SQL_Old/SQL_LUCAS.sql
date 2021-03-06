IF OBJECT_ID('J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos
GO
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos(@anio int, @trimestre int, @visibilidad int, @mes int)
AS
	SELECT b.usu_UserName Usuario,c.pubvis_Descripcion Visibilidad,MONTH(a.pub_Fecha_Ini) Mes, SUM(a.pub_Stock) Productos_No_Vendidos
	FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
	WHERE a.pub_usu_Id = b.usu_Id
	AND a.pub_visibilidad_Id = c.pubvis_id
	AND YEAR(a.pub_Fecha_Ini) = @anio
	AND (a.pub_visibilidad_Id = @visibilidad OR @visibilidad=0)
	AND (MONTH(a.pub_Fecha_Ini) = @mes OR @mes=0)
	AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
	AND b.usu_UserName IN (
		SELECT TOP 5 b.usu_UserName Usuario
		FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
		WHERE a.pub_usu_Id = b.usu_Id
		AND a.pub_visibilidad_Id = c.pubvis_id
		AND YEAR(a.pub_Fecha_Ini) = @anio
		AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
		GROUP BY b.usu_UserName
		ORDER BY SUM(a.pub_Stock)DESC)
	GROUP BY b.usu_UserName,c.pubvis_Descripcion,MONTH(a.pub_Fecha_Ini)
	ORDER BY MONTH(a.pub_Fecha_Ini),c.pubvis_Descripcion,SUM(a.pub_Stock) DESC
GO

IF OBJECT_ID('J2LA.getTop5VendedoresConMayorFacturacion') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion
GO
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.usu_UserName Usuario, SUM(b.fac_Total) Facturacion
	FROM  J2LA.Usuarios a, J2LA.Facturas b
	WHERE a.usu_Id = b.fac_usu_Id
	AND YEAR(b.fac_Fecha) = @anio
	AND MONTH(b.fac_Fecha)>(@trimestre-1)*3 AND MONTH(b.fac_Fecha)<= @trimestre*3
	GROUP BY a.usu_UserName
	ORDER BY Facturacion DESC
GO

IF OBJECT_ID('J2LA.ViewVendedoresConMayoresCalificaciones') IS NOT NULL
DROP VIEW J2LA.ViewVendedoresConMayoresCalificaciones
GO
CREATE VIEW J2LA.ViewVendedoresConMayoresCalificaciones(
	Username,
	Anio,
	Reputacion_Trimestre_Primero,
	Reputacion_Trimestre_Segundo,
	Reputacion_Trimestre_Tercero,
	Reputacion_Trimestre_Cuarto)
AS
	SELECT U.usu_UserName,
		   UC.usucal_Anio,
		   (CASE WHEN usucal_Cant_Ventas_Primero=0 THEN NULL ELSE CAST((usucal_Puntos_Primero*1.00/usucal_Cant_Ventas_Primero*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Segundo=0 THEN NULL ELSE CAST((usucal_Puntos_Segundo*1.00/usucal_Cant_Ventas_Segundo*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Tercero=0 THEN NULL ELSE CAST((usucal_Puntos_Tercero*1.00/usucal_Cant_Ventas_Tercero*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Cuarto=0 THEN NULL ELSE CAST((usucal_Puntos_Cuarto*1.00/usucal_Cant_Ventas_Cuarto*1.00) AS NUMERIC(18,2)) END)
	FROM J2LA.Usuarios_Calificaciones UC, J2LA.Usuarios U
	WHERE UC.usucal_usu_Id = U.usu_Id
GO

IF OBJECT_ID('J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar') IS NOT NULL
DROP PROCEDURE J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar
GO
CREATE PROCEDURE J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.cli_Nro_Doc Cliente, COUNT(*) Publicaciones_Sin_Calificar
	FROM J2LA.Clientes a, J2LA.Compras b
	WHERE a.cli_usu_Id = b.comp_usu_Id
	AND b.comp_cal_Codigo IS NULL
	AND YEAR(b.comp_Fecha) = @anio
	AND MONTH(b.comp_Fecha)>(@trimestre-1)*3 AND MONTH(b.comp_Fecha)<= @trimestre*3
	GROUP BY a.cli_Nro_Doc
	ORDER BY Publicaciones_Sin_Calificar DESC
GO

IF OBJECT_ID('J2LA.getCalificacionesPendientes') IS NOT NULL
DROP FUNCTION J2LA.getCalificacionesPendientes
GO
CREATE FUNCTION J2LA.getCalificacionesPendientes(@usu_Id int)
RETURNS TABLE
AS
	RETURN
		SELECT C.comp_Id Codigo, C.comp_Fecha Fecha, U.usu_userName Vendedor, P.pub_Descripcion Descripcion
		FROM J2LA.Compras C, J2LA.Publicaciones P, J2LA.Usuarios U
		WHERE C.comp_pub_Codigo = P.pub_Codigo
		AND P.pub_usu_Id = U.usu_Id
		AND C.comp_usu_Id = @usu_Id
		AND C.comp_cal_Codigo IS NULL
GO

IF OBJECT_ID('J2LA.ActualizarReputacion') IS NOT NULL
DROP PROCEDURE J2LA.ActualizarReputacion
GO
CREATE PROCEDURE J2LA.ActualizarReputacion(@usu_UserName nvarchar(255), @comp_Id int, @cal_Cant_Estrellas int)
As
	BEGIN
		DECLARE @comp_Fecha DATETIME
		DECLARE @usu_Id int
		SET @usu_Id = (SELECT usu_Id FROM J2LA.Usuarios WHERE usu_UserName = @usu_UserName)
		SET @comp_Fecha = (SELECT comp_Fecha FROM J2LA.Compras WHERE comp_Id = @comp_Id)
		IF (NOT EXISTS (SELECT * FROM J2LA.Usuarios_Calificaciones WHERE usucal_usu_Id = @usu_Id AND usucal_Anio = YEAR(@comp_Fecha)))
			BEGIN
				INSERT INTO J2LA.Usuarios_Calificaciones(usucal_usu_Id,usucal_Anio)
				VALUES (@usu_Id,YEAR(@comp_Fecha))
			END

		IF (MONTH(@comp_Fecha) IN (1,2,3))
			BEGIN
				UPDATE J2LA.Usuarios_Calificaciones
				SET usucal_Puntos_Primero = usucal_Puntos_Primero + @cal_Cant_Estrellas,
				    usucal_Cant_Ventas_Primero = usucal_Cant_Ventas_Primero + 1
				WHERE usucal_usu_Id = @usu_Id
				AND usucal_Anio = YEAR(@comp_Fecha)
			END
			ELSE IF (MONTH(@comp_Fecha) IN (4,5,6))
				BEGIN
					UPDATE J2LA.Usuarios_Calificaciones
					SET usucal_Puntos_Segundo = usucal_Puntos_Segundo + @cal_Cant_Estrellas,
					    usucal_Cant_Ventas_Segundo = usucal_Cant_Ventas_Segundo + 1
					WHERE usucal_usu_Id = @usu_Id
					AND usucal_Anio = YEAR(@comp_Fecha)
				END
				ELSE IF (MONTH(@comp_Fecha) IN (7,8,9))
					BEGIN
						UPDATE J2LA.Usuarios_Calificaciones
						SET usucal_Puntos_Tercero = usucal_Puntos_Tercero + @cal_Cant_Estrellas,
							usucal_Cant_Ventas_Tercero = usucal_Cant_Ventas_Tercero + 1
						WHERE usucal_usu_Id = @usu_Id
						AND usucal_Anio = YEAR(@comp_Fecha)
					END
				ELSE
					BEGIN
						UPDATE J2LA.Usuarios_Calificaciones
						SET usucal_Puntos_Cuarto = usucal_Puntos_Cuarto + @cal_Cant_Estrellas,
				    		usucal_Cant_Ventas_Cuarto = usucal_Cant_Ventas_Cuarto + 1
						WHERE usucal_usu_Id = @usu_Id
						AND usucal_Anio = YEAR(@comp_Fecha)
					END
	END
GO

IF OBJECT_ID('J2LA.CargarCalificacion') IS NOT NULL
DROP PROCEDURE J2LA.CargarCalificacion
GO
CREATE PROCEDURE J2LA.CargarCalificacion(@comp_Id int, @cal_Cant_Estrellas int, @cal_Comentario nvarchar(255))
AS
	BEGIN
		DECLARE @cal_Codigo INT
		SET @cal_Codigo = (SELECT MAX(cal_Codigo)+1 FROM J2LA.Calificaciones)
		INSERT INTO J2LA.Calificaciones(cal_Codigo,cal_Cant_Estrellas,cal_Comentario)
		VALUES (@cal_Codigo,@cal_Cant_Estrellas,@cal_Comentario)

		UPDATE J2LA.Compras
		SET comp_cal_Codigo = @cal_Codigo
		WHERE comp_Id = @comp_Id
	END
GO

IF OBJECT_ID('J2LA.triggerInhabilitarUsuarioPorNoCalificar') IS NOT NULL
DROP TRIGGER J2LA.triggerInhabilitarUsuarioPorNoCalificar
GO
CREATE TRIGGER J2LA.triggerInhabilitarUsuarioPorNoCalificar
ON J2LA.Compras
FOR INSERT, UPDATE
AS
	BEGIN
		DECLARE @cant_Compras_No_Calificadas INT
		DECLARE @comp_usu_Id INT
		DECLARE @usu_Inhabilitado_Comprar INT
		
		SET @comp_usu_Id = (SELECT comp_usu_Id FROM inserted)		
		SET @cant_Compras_No_Calificadas = (SELECT COUNT(*) FROM J2LA.Compras WHERE comp_cal_Codigo IS NULL AND comp_usu_Id = @comp_usu_Id)
		SET @usu_Inhabilitado_Comprar = (SELECT usu_Inhabilitado_Comprar FROM J2LA.Usuarios WHERE usu_Id = @comp_usu_Id)
		
		IF (@cant_Compras_No_Calificadas > 5)
			BEGIN
				UPDATE J2LA.Usuarios
				SET usu_Inhabilitado_Comprar = 1
				WHERE usu_Id = @comp_usu_Id
			END
		
		
		IF (@usu_Inhabilitado_Comprar = 1 AND @cant_Compras_No_Calificadas <= 5)
			BEGIN
				UPDATE J2LA.Usuarios
				SET usu_Inhabilitado_Comprar = 0
				WHERE usu_Id = @comp_usu_Id
			END
	END
GO
	
IF OBJECT_ID('J2LA.CargarEmpresa') IS NOT NULL
DROP PROCEDURE J2LA.CargarEmpresa
GO
CREATE PROCEDURE J2LA.CargarEmpresa(
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
		EXECUTE J2LA.setNuevoUsuario @usu_UserName, @usu_Pass, @usu_Primer_Ingreso
	
		INSERT INTO J2LA.Empresas(
			emp_Razon_Social,
			emp_CUIT,
			emp_Mail,
			emp_Tel,
			emp_Dom_Calle,
			emp_Nro_Calle,
			emp_Piso,
			emp_Dpto,
			emp_Localidad,
			emp_CP,
			emp_Ciudad,
			emp_Contacto,
			emp_Fecha_Creacion,
			emp_usu_Id)
			
		VALUES (
			@emp_Razon_Social,
			@emp_CUIT,
			@emp_Mail,
			@emp_Tel,
			@emp_Dom_Calle,
			@emp_Nro_Calle,
			@emp_Piso,
			@emp_Dpto,
			@emp_Localidad,
			@emp_CP,
			@emp_Ciudad,
			@emp_Contacto,
			@emp_Fecha_Creacion,
			J2LA.getUserId(@usu_UserName))
		
		INSERT INTO J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
		VALUES (J2LA.getUserId(@usu_UserName), J2LA.getRolId('Empresa'))
	END
GO

IF OBJECT_ID('J2LA.ActualizarEmpresa') IS NOT NULL
DROP PROCEDURE J2LA.ActualizarEmpresa
GO
CREATE PROCEDURE J2LA.ActualizarEmpresa(
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
		SET usu_Inhabilitado = @usu_Inhabilitado
		WHERE usu_Id = @usu_Id
	END
GO

IF OBJECT_ID('J2LA.BajaEmpresa') IS NOT NULL
DROP PROCEDURE J2LA.BajaEmpresa
GO
CREATE PROCEDURE J2LA.BajaEmpresa(@emp_CUIT nvarchar(50))
AS
	BEGIN
		DECLARE @emp_usu_Id int
		SET @emp_usu_Id = (SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT)
		
		EXEC J2LA.setBajaUsuario @emp_usu_Id
	END
GO

IF OBJECT_ID('J2LA.existeCUIT') IS NOT NULL
DROP FUNCTION J2LA.existeCUIT
GO
CREATE FUNCTION J2LA.existeCUIT(@emp_CUIT nvarchar(50))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(emp_Cuit) FROM J2LA.Empresas where emp_Cuit = @emp_CUIT) > 0)
		RETURN 1
	RETURN 0
END
GO

IF OBJECT_ID('J2LA.existeRazonSocial') IS NOT NULL
DROP FUNCTION J2LA.existeRazonSocial
GO
CREATE FUNCTION J2LA.existeRazonSocial(@emp_Razon_Social nvarchar(50))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(emp_Razon_Social) FROM J2LA.Empresas where emp_Razon_Social = @emp_Razon_Social) > 0)
		RETURN 1
	RETURN 0
END
GO

IF OBJECT_ID('J2LA.existeOtroCUIT') IS NOT NULL
DROP FUNCTION J2LA.existeOtroCUIT
GO
CREATE FUNCTION J2LA.existeOtroCUIT(@emp_CUIT nvarchar(50), @emp_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(emp_Cuit) FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT) > 0)
		BEGIN
			IF ((SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT) = @emp_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO

IF OBJECT_ID('J2LA.existeOtraRazonSocial') IS NOT NULL
DROP FUNCTION J2LA.existeOtraRazonSocial
GO
CREATE FUNCTION J2LA.existeOtraRazonSocial(@emp_Razon_Social nvarchar(255), @emp_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(emp_Razon_Social) FROM J2LA.Empresas WHERE emp_Razon_Social = @emp_Razon_Social) > 0)
		BEGIN
			IF ((SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Razon_Social = @emp_Razon_Social) = @emp_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO