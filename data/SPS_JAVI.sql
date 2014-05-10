Use [GD1C2014]    /* Utilizamos una base de datos EXTERNA,la base a la cual se dirigiran las proximas consultas SQL en el proceso actual. */
Go 
/* Signo de finalizacion de lotes de sentencia*/



/*-------------------------STORED PROCEDURE (JAVI)--------------------------*/
IF OBJECT_ID('J2LA.setCantidadIntentos') IS NOT NULL
DROP PROCEDURE J2LA.setCantidadIntentos
GO
CREATE PROCEDURE J2LA.setCantidadIntentos @idUsuario INT
AS
BEGIN
	DECLARE @cantIntentos NVARCHAR(255)

	SELECT 
		@cantIntentos = usu_cant_intentos
	FROM 
		J2LA.Usuarios
	WHERE
		usu_Id = @idUsuario
		
	SET @cantIntentos = @cantIntentos + 1
	/*-----------------------------------*/
	UPDATE 
		J2LA.Usuarios
    SET
		usu_Cant_Intentos = @cantIntentos,
		usu_Inhabilitado = CASE WHEN @cantIntentos >= 3 THEN 1 ELSE 0 END
	WHERE
		usu_Id = @idUsuario
END
GO


