--Creamos una Tabla Auxiliar de Calificaciones para ir actualizando la reputacion de los vendedores

CREATE TABLE J2LA.Usuarios_Calificaciones(
	usucal_usu_Id nvarchar(255),
	usucal_Anio int,
	usucal_Puntos_Primero int,
	usucal_Cant_Ventas_Primero int,
	usucal_Puntos_Segundo int,
	usucal_Cant_Ventas_Segundo int,
	usucal_Puntos_Tercero int,
	usucal_Cant_Ventas_Tercero int,
	usucal_Puntos_Cuarto int,
	usucal_Cant_Ventas_Cuarto int,
)

INSERT INTO J2LA.Usuarios_Calificaciones
SELECT P.pub_usu_Id,
	   Anio = YEAR(Co.comp_Fecha), 
	   usucal_Puntos_Primero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (1,2,3) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Primero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (1,2,3) THEN 1 ELSE 0 END),
	   usucal_Puntos_Segundo = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (4,5,6) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Segundo = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (4,5,6) THEN 1 ELSE 0 END),
	   usucal_Puntos_Tercero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (7,8,9) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Tercero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (7,8,9) THEN 1 ELSE 0 END),
	   usucal_Puntos_Cuarto = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (10,11,12) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Cuarto = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (10,11,12) THEN 1 ELSE 0 END)
FROM J2LA.Publicaciones P, J2LA.Compras Co, J2LA.Calificaciones Ca
WHERE P.pub_Codigo = Co.comp_pub_Codigo
AND Co.comp_cal_Codigo = Ca.cal_Codigo
GROUP BY P.pub_usu_Id, YEAR(Co.comp_Fecha)