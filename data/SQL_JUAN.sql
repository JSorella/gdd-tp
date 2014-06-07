Use [GD1C2014]
Go 

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Insert
GO
CREATE PROCEDURE J2LA.Publicaciones_Insert
	@pub_Codigo numeric(18,0) OUTPUT,
	@pub_tipo_Id int,
	@pub_Descripcion nvarchar(255),
	@pub_Stock numeric(18,0),
	@pub_Fecha_Vto datetime,
	@pub_Fecha_Ini datetime,
	@pub_Precio numeric(18,2),
	@pub_visibilidad_Id int,
	@pub_estado_Id int,
	@pub_Permite_Preg bit,
	@pub_usu_Id int,
	@pub_vis_Precio numeric(18,2),
	@pub_vis_Porcentaje numeric(18,2)
AS
BEGIN

	SELECT @pub_Codigo = MAX(pub_Codigo) + 1 FROM J2LA.Publicaciones

	INSERT INTO J2LA.Publicaciones
		([pub_Codigo],[pub_tipo_Id],[pub_Descripcion],[pub_Stock],[pub_Fecha_Vto]
		,[pub_Fecha_Ini],[pub_Precio],[pub_visibilidad_Id],[pub_estado_Id]
		,[pub_Permite_Preg],[pub_usu_Id],[pub_vis_Precio],[pub_vis_Porcentaje])
	VALUES(
		@pub_Codigo,@pub_tipo_Id,@pub_Descripcion,@pub_Stock,@pub_Fecha_Vto,
		@pub_Fecha_Ini,@pub_Precio,@pub_visibilidad_Id,@pub_estado_Id,
		@pub_Permite_Preg,@pub_usu_Id,@pub_vis_Precio,@pub_vis_Porcentaje)
		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Update') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Update
GO
CREATE PROCEDURE J2LA.Publicaciones_Update
	@pub_Codigo numeric(18,0),
	@pub_tipo_Id int,
	@pub_Descripcion nvarchar(255),
	@pub_Stock numeric(18,0),
	@pub_Fecha_Vto datetime,
	@pub_Fecha_Ini datetime,
	@pub_Precio numeric(18,2),
	@pub_visibilidad_Id int,
	@pub_estado_Id int,
	@pub_Permite_Preg bit,
	@pub_usu_Id int,
	@pub_vis_Precio numeric(18,2),
	@pub_vis_Porcentaje numeric(18,2)
AS
BEGIN

UPDATE J2LA.Publicaciones
   SET	pub_Descripcion = @pub_Descripcion,
		pub_Stock = @pub_Stock,
		pub_Fecha_Vto = @pub_Fecha_Vto,
		pub_Fecha_Ini = @pub_Fecha_Ini,
		pub_Precio = @pub_Precio,
		pub_visibilidad_Id = @pub_visibilidad_Id,
		pub_estado_Id = @pub_estado_Id,
		pub_Permite_Preg = @pub_Permite_Preg,
		pub_vis_Precio = @pub_vis_Precio,
		pub_vis_Porcentaje = @pub_vis_Porcentaje
 WHERE pub_Codigo = @pub_Codigo

		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Delete_Rubros') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Delete_Rubros
GO
CREATE PROCEDURE J2LA.Publicaciones_Delete_Rubros
	@pub_Codigo numeric(18,0)
AS
BEGIN

	DELETE FROM J2LA.Publicaciones_Rubros
	WHERE pubrub_pub_Codigo = @pub_Codigo
		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Insert_Rubros') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Insert_Rubros
GO
CREATE PROCEDURE J2LA.Publicaciones_Insert_Rubros
	@pubrub_pub_Codigo numeric(18,0),
	@pubrub_rub_Id int
AS
BEGIN

	INSERT INTO J2LA.Publicaciones_Rubros
		(pubrub_pub_Codigo,pubrub_rub_Id)
	VALUES(
		@pubrub_pub_Codigo,@pubrub_rub_Id)
		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/
IF OBJECT_ID('J2LA.ObtenerRubrosPubli') IS NOT NULL
DROP FUNCTION J2LA.ObtenerRubrosPubli
GO
CREATE FUNCTION J2LA.ObtenerRubrosPubli(@pub_Codigo numeric(18,0))
	RETURNS VARCHAR(7000)
AS
BEGIN

DECLARE @Rubros Varchar(7000)
SET @Rubros = ''

	SELECT @Rubros = (CASE WHEN @Rubros = '' THEN @Rubros + R.rub_Descripcion
					   ELSE @Rubros + ' - ' + R.rub_Descripcion END)
	FROM J2LA.Publicaciones_Rubros PR
	INNER JOIN J2LA.Rubros R On R.rub_id = PR.pubrub_rub_Id
	WHERE PR.pubrub_pub_Codigo = @pub_Codigo

	RETURN @Rubros

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/
IF OBJECT_ID('J2LA.CantPubliGratis') IS NOT NULL
DROP FUNCTION J2LA.CantPubliGratis
GO
CREATE FUNCTION J2LA.CantPubliGratis(@usu_id int, @pub_codigo int)
RETURNS INT
AS
BEGIN

DECLARE @CantPubli INT

		SELECT @CantPubli = COUNT(*)
		FROM J2LA.Publicaciones P
		INNER JOIN J2LA.Publicaciones_Visibilidades V 
			On	V.pubvis_id = P.pub_visibilidad_Id 
				And V.pubvis_Precio = 0 --Gratis
		WHERE P.pub_usu_Id = @usu_id
		AND P.pub_estado_Id = 1 --Activas
		And P.pub_codigo <> @pub_codigo --Que no sea la que estoy grabando (En editar.-)
		
RETURN @CantPubli

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/
IF OBJECT_ID('J2LA.UsuarioInHabilitado') IS NOT NULL
DROP FUNCTION J2LA.UsuarioInHabilitado
GO
CREATE FUNCTION J2LA.UsuarioInHabilitado(@usu_id int)
RETURNS BIT
AS
BEGIN

DECLARE @Result BIT

	SELECT @Result = U.usu_Inhabilitado
	FROM J2LA.Usuarios U
	Where U.usu_Id = @usu_id
		
RETURN @Result

END
GO