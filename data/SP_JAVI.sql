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


/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
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



