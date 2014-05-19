CREATE PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos(@anio int, @trimestre int)
AS
	SELECT TOP 5 b.usu_UserName, a.pub_Stock, a.pub_Codigo, a.pub_Descripcion, c.pubvis_Descripcion , a.pub_Fecha_Ini
	FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
	WHERE a.pub_usu_Id = b.usu_Id
	AND a.pub_visibilidad_Id = c.pubvis_id
	AND YEAR(a.pub_Fecha_Ini) = @anio
	AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
	ORDER BY a.pub_Stock DESC, a.pub_Fecha_Ini ASC, a.pub_visibilidad_Id ASC
GO


CREATE PROCEDURE J2LA.getTop5VendedoresConMayor(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.usu_UserName, SUM(b.fac_Total) Facturacion
	FROM  J2LA.Usuarios a, J2LA.Facturas b
	WHERE a.usu_Id = b.fac_usu_Id
	AND YEAR(b.fac_Fecha) = @anio
	AND MONTH(b.fac_Fecha)>(@trimestre-1)*3 AND MONTH(b.fac_Fecha)<= @trimestre*3
	GROUP BY a.usu_UserName
	ORDER BY Facturacion DESC
GO

CREATE PROCEDURE J2LA.getVendedoresConMayoresCalificaciones(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.usu_UserName,AVG(d.cal_Cant_Estrellas) Reputacion
	FROM J2LA.Usuarios a, J2LA.Compras b, J2LA.Publicaciones c, J2LA.Calificaciones d
	WHERE b.comp_pub_Codigo = c.pub_Codigo
	AND c.pub_usu_Id = a.usu_Id
	AND b.comp_cal_Codigo = d.cal_Codigo
	AND YEAR(b.comp_Fecha) = @anio
	AND MONTH(b.comp_Fecha)>(@trimestre-1)*3 AND MONTH(b.comp_Fecha)<= @trimestre*3
	GROUP BY a.usu_UserName
	ORDER BY Reputacion DESC
GO

CREATE PROCEDURE J2LA.getClientesConMayorCantDePublicacionesSinCalificar(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.cli_Nro_Doc, COUNT(*) PublicacionesSinCalificar
	FROM J2LA.Clientes a, J2LA.Publicaciones b, J2LA.Compras c, J2LA.Calificaciones d
	WHERE a.cli_usu_Id = b.pub_usu_Id
	AND b.pub_Codigo = c.comp_pub_Codigo
	AND c.comp_cal_Codigo IS NULL
	AND YEAR(b.pub_Fecha_Ini) = @anio
	AND MONTH(b.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(b.pub_Fecha_Ini)<= @trimestre*3
	GROUP BY a.cli_Nro_Doc
	ORDER BY PublicacionesSinCalificar DESC
GO