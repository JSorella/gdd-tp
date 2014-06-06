IF OBJECT_ID('J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos
GO
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos(@anio int, @trimestre int, @visibilidad int, @mes int)
AS
	SELECT TOP 5 b.usu_UserName Usuario,c.pubvis_Descripcion Visibilidad,MONTH(a.pub_Fecha_Ini) Mes, SUM(a.pub_Stock) Productos_No_Vendidos
	FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
	WHERE a.pub_usu_Id = b.usu_Id
	AND a.pub_visibilidad_Id = c.pubvis_id
	AND YEAR(a.pub_Fecha_Ini) = @anio
	AND a.pub_visibilidad_Id = @visibilidad
	AND MONTH(a.pub_Fecha_Ini) = @mes
	AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
	GROUP BY b.usu_UserName,c.pubvis_Descripcion,MONTH(a.pub_Fecha_Ini)
	ORDER BY Productos_No_Vendidos DESC
GO

IF OBJECT_ID('J2LA.getTop5VendedoresConMayorFacturacion') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion
GO
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.usu_UserName, SUM(b.fac_Total) Facturacion
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
	SELECT TOP 5 a.cli_Nro_Doc, COUNT(*) PublicacionesSinCalificar
	FROM J2LA.Clientes a, J2LA.Compras b
	WHERE a.cli_usu_Id = b.comp_usu_Id
	AND b.comp_cal_Codigo IS NULL
	AND YEAR(b.comp_Fecha) = @anio
	AND MONTH(b.comp_Fecha)>(@trimestre-1)*3 AND MONTH(b.comp_Fecha)<= @trimestre*3
	GROUP BY a.cli_Nro_Doc
	ORDER BY PublicacionesSinCalificar DESC
GO