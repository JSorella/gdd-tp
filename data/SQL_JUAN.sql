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
	@pub_vis_Porcentaje numeric(18,2),
	@pub_Facturada Bit
AS
BEGIN

	SELECT @pub_Codigo = MAX(pub_Codigo) + 1 FROM J2LA.Publicaciones

	INSERT INTO J2LA.Publicaciones
		([pub_Codigo],[pub_tipo_Id],[pub_Descripcion],[pub_Stock],[pub_Fecha_Vto]
		,[pub_Fecha_Ini],[pub_Precio],[pub_visibilidad_Id],[pub_estado_Id],[pub_Permite_Preg],
		[pub_usu_Id],[pub_vis_Precio],[pub_vis_Porcentaje], [pub_Facturada])
	VALUES(
		@pub_Codigo,@pub_tipo_Id,@pub_Descripcion,@pub_Stock,@pub_Fecha_Vto,
		@pub_Fecha_Ini,@pub_Precio,@pub_visibilidad_Id,@pub_estado_Id,@pub_Permite_Preg,
		@pub_usu_Id,@pub_vis_Precio,@pub_vis_Porcentaje,@pub_Facturada)
		
	--Si es una Publicacion No Gratuita
	IF( @pub_Precio > 0)
	BEGIN
		-- Si ya No existe un regitros en la Tabla
		IF NOT EXISTS ( SELECT * FROM J2LA.Usuarios_CantFactxTipoVis
						WHERE ucftv_usu_Id = @pub_usu_Id
						AND ucftv_vis_Id = @pub_visibilidad_Id)
		BEGIN
			-- Agrego un Registro para controlar la Facturacion por Visibilidad
			-- Para un Bonificacion cada 10 Publicidades Rendidas
			INSERT INTO J2LA.Usuarios_CantFactxTipoVis
				([ucftv_usu_Id], [ucftv_vis_Id], [ucftv_Cantidad])
			VALUES (@pub_usu_Id, @pub_visibilidad_Id, 0)
		END
	END
	
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
	@pub_vis_Porcentaje numeric(18,2),
	@pub_Facturada Bit
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

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Roles_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Insert
GO
CREATE PROCEDURE J2LA.Roles_Insert
	@rol_Id INT OUTPUT,
	@rol_Nombre NVARCHAR(255)
AS
BEGIN

	INSERT INTO J2LA.Roles ([rol_Nombre], [rol_Inhabilitado],[rol_Eliminado])
	VALUES(@rol_Nombre, 0, 0)
	
	SELECT @rol_Id = @@IDENTITY		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Roles_Insert_Funcionalidades') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Insert_Funcionalidades
GO
CREATE PROCEDURE J2LA.Roles_Insert_Funcionalidades
	@rolfun_rol_Id int,
	@rolfun_fun_Id int
AS
BEGIN

	INSERT INTO J2LA.Roles_Funcionalidades
		(rolfun_rol_Id,rolfun_fun_Id)
	VALUES(
		@rolfun_rol_Id,@rolfun_fun_Id)
		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
IF OBJECT_ID('J2LA.getRoles_Funcionalidades') IS NOT NULL
DROP FUNCTION J2LA.getRoles_Funcionalidades
GO
CREATE FUNCTION J2LA.getRoles_Funcionalidades( @rol_Id int )
RETURNS TABLE
AS
RETURN 
	(SELECT RF.rolfun_rol_Id, RF.rolfun_fun_Id, f.fun_Nombre
		FROM J2LA.Roles_Funcionalidades RF
		INNER JOIN J2LA.Funcionalidades F On F.fun_Id = RF.rolfun_fun_Id
		WHERE RF.rolfun_rol_Id = @rol_Id
	)
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Roles_Update') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Update
GO
CREATE PROCEDURE J2LA.Roles_Update
	@rol_Id INT,
	@rol_Nombre NVARCHAR(255),
	@rol_Inhabilitado BIT
AS
BEGIN

	UPDATE J2LA.Roles
	SET rol_Nombre = @rol_Nombre,
		rol_Inhabilitado = @rol_Inhabilitado
	WHERE rol_Id = @rol_Id
	
	-- Si se Inhabilita se quitan las asignaciones de Usuarios
	IF(@rol_Inhabilitado = 1)
	BEGIN
		DELETE FROM J2LA.Usuarios_Roles
		WHERE usurol_rol_Id = @rol_Id
	END
	
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Roles_Delete_Funcionalidades') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Delete_Funcionalidades
GO
CREATE PROCEDURE J2LA.Roles_Delete_Funcionalidades
	@rol_Id int
AS
BEGIN

	DELETE FROM J2LA.Roles_Funcionalidades
	WHERE rolfun_rol_Id = @rol_Id
	
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Roles_BajaLogica') IS NOT NULL
DROP PROCEDURE J2LA.Roles_BajaLogica
GO
CREATE PROCEDURE J2LA.Roles_BajaLogica
	@rol_Id int
AS
BEGIN

	-- Baja Logica del Rol
	UPDATE J2LA.Roles
	SET rol_Eliminado = 1
	WHERE rol_Id = @rol_Id
	
	-- Elimino las Funcionalidades del Rol
	DELETE FROM J2LA.Roles_Funcionalidades
	WHERE rolfun_rol_Id = @rol_Id
	
	-- Elimino las asignaciones de Usuarios
	DELETE FROM J2LA.Usuarios_Roles
	WHERE usurol_rol_Id = @rol_Id
	
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_Insert
GO
CREATE PROCEDURE J2LA.Publicaciones_Visibilidades_Insert
	@pubvis_id Int,
	@pubvis_Codigo numeric(18,0),
	@pubvis_Descripcion NVARCHAR(255),
	@pubvis_Precio numeric(18,2),
	@pubvis_Porcentaje numeric(18,2),
	@pubvis_Dias_Vto numeric(18,0),
	@pubvis_Eliminado bit
AS
BEGIN

	INSERT INTO J2LA.Publicaciones_Visibilidades 
		([pubvis_Codigo], [pubvis_Descripcion],[pubvis_Precio], 
		[pubvis_Porcentaje], [pubvis_Dias_Vto], [pubvis_Eliminado])
	VALUES(@pubvis_Codigo, @pubvis_Descripcion, @pubvis_Precio,
		@pubvis_Porcentaje, @pubvis_Dias_Vto, @pubvis_Eliminado)

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_Update') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_Update
GO
CREATE PROCEDURE J2LA.Publicaciones_Visibilidades_Update
	@pubvis_id Int,
	@pubvis_Codigo numeric(18,0),
	@pubvis_Descripcion NVARCHAR(255),
	@pubvis_Precio numeric(18,2),
	@pubvis_Porcentaje numeric(18,2),
	@pubvis_Dias_Vto numeric(18,0),
	@pubvis_Eliminado bit
AS
BEGIN

	UPDATE J2LA.Publicaciones_Visibilidades 
	SET	[pubvis_Codigo] = @pubvis_Codigo, 
		[pubvis_Descripcion] = @pubvis_Descripcion,
		[pubvis_Precio] = @pubvis_Precio, 
		[pubvis_Porcentaje] = @pubvis_Porcentaje, 
		[pubvis_Dias_Vto] = @pubvis_Dias_Vto, 
		[pubvis_Eliminado] = @pubvis_Eliminado
	WHERE pubvis_id = @pubvis_id

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_BajaLogica') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_BajaLogica
GO
CREATE PROCEDURE J2LA.Publicaciones_Visibilidades_BajaLogica
	@pubvis_id Int
AS
BEGIN

	UPDATE J2LA.Publicaciones_Visibilidades 
	SET	[pubvis_Eliminado] = 1
	WHERE pubvis_id = @pubvis_id

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Usuario_CambiarPass') IS NOT NULL
DROP PROCEDURE J2LA.Usuario_CambiarPass
GO
CREATE PROCEDURE J2LA.Usuario_CambiarPass
	@usu_Id Int,
	@usu_Pass nvarchar(255)
AS
BEGIN

	UPDATE J2LA.Usuarios
	SET	[usu_Pass] = @usu_Pass
	WHERE usu_Id = @usu_Id
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Facturas_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Facturas_Insert
GO
CREATE PROCEDURE J2LA.Facturas_Insert
	@fac_Numero numeric(18,0) OUTPUT,
	@fac_usu_Id int,
	@fac_Fecha datetime,
	@fac_Total numeric(18,2),
	@fac_Forma_Pago_Desc nvarchar(255),
	@fac_usu_Id_gen int
AS
BEGIN

	SELECT @fac_Numero = MAX(fac_Numero) + 1 FROM J2LA.Facturas

	INSERT INTO J2LA.Facturas
		([fac_Numero],[fac_usu_Id],[fac_Fecha],[fac_Total],[fac_Forma_Pago_Desc],[fac_usu_Id_gen])
	VALUES(@fac_Numero, @fac_usu_Id, @fac_Fecha, @fac_Total, @fac_Forma_Pago_Desc, @fac_usu_Id_gen)
		
END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Facturas_Insert_Detalle') IS NOT NULL
DROP PROCEDURE J2LA.Facturas_Insert_Detalle
GO
CREATE PROCEDURE J2LA.Facturas_Insert_Detalle
	@facdet_fac_Numero numeric(18,0),
	@facdet_pub_Codigo numeric(18,0),
	@facdet_Cantidad numeric(18,0),
	@facdet_Importe numeric(18,2),
	@facdet_Concepto nvarchar(255),
	@facdet_comp_Id int
AS
BEGIN

	DECLARE @pub_visibilidad_Id INT
	DECLARE @pub_usu_Id INT

	INSERT INTO J2LA.Facturas_Det
		([facdet_fac_Numero],[facdet_pub_Codigo],[facdet_Cantidad],
		[facdet_Importe],[facdet_Concepto], [facdet_comp_Id])
	VALUES(@facdet_fac_Numero, @facdet_pub_Codigo, @facdet_Cantidad, 
		@facdet_Importe, @facdet_Concepto, @facdet_comp_Id)
		
	-- La marco como Facturada.
	IF(@facdet_comp_Id = 0)
	BEGIN
		UPDATE J2LA.Publicaciones 
		SET pub_Facturada = 1
		WHERE pub_Codigo = @facdet_pub_Codigo
	END
	ELSE
	BEGIN
		UPDATE J2LA.Compras
		SET comp_Facturada = 1
		WHERE comp_Id = @facdet_comp_Id
	END

	SELECT @pub_visibilidad_Id = pub_visibilidad_Id,
			@pub_usu_Id = pub_usu_Id
	FROM J2LA.Publicaciones 
	Where pub_Codigo = @facdet_pub_Codigo

	Update J2LA.Usuarios_CantFactxTipoVis
	Set	ucftv_Cantidad = ucftv_Cantidad + 1
	Where ucftv_usu_Id = @pub_usu_Id
	And ucftv_vis_Id = @pub_visibilidad_Id

END
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.getPendientesFact') IS NOT NULL
DROP FUNCTION J2LA.getPendientesFact
GO
CREATE FUNCTION J2LA.getPendientesFact( @usu_id int )
RETURNS TABLE
AS
RETURN 
	(
Select	P.pub_Codigo, comp_Id = 0, [Facturar] = CONVERT(Bit, 0),
		[Codigo Publi] = P.pub_Codigo, [Tipo] = 'P',
		[Fecha] = Convert(varchar, P.pub_Fecha_Ini, 103),
		[Concepto] = 'Costo por Publicacion Nro. ' + LTRIM(RTRIM(STR(P.pub_Codigo))) +
				' - Visib.: ' + PV.pubvis_Descripcion,
		[Cantidad] = 1,
		[Importe] = P.pub_vis_Precio,
		P.pub_visibilidad_Id
From J2LA.Publicaciones P
Inner Join J2LA.Publicaciones_Visibilidades PV On PV.pubvis_id = P.pub_visibilidad_Id
Where P.pub_usu_Id = @usu_id
AND P.pub_Facturada = 0

Union All

Select	P.pub_Codigo, C.comp_Id, [Facturar] = CONVERT(Bit, 0),
		[Codigo Publi] = P.pub_Codigo, [Tipo] = 'C',
		[Fecha] = Convert(varchar, C.comp_Fecha, 103),
		[Concepto] = 'Comision por Compra en Publicacion Nro. ' + LTRIM(RTRIM(STR(P.pub_Codigo))) +
				' - Fecha: ' + Convert(varchar, C.comp_Fecha, 103) +
				' - Usuario: ' + U.usu_UserName,
		[Cantidad] = 1,
		[Importe] = P.pub_vis_Precio,
		P.pub_visibilidad_Id
From J2LA.Compras C
Inner Join J2LA.Publicaciones P On P.pub_Codigo = C.comp_pub_Codigo
Inner Join J2LA.Usuarios U On U.usu_Id = C.comp_usu_Id
Where P.pub_usu_Id = @usu_id
AND C.comp_Facturada = 0
)
GO

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.getOfertaGanadora') IS NOT NULL
DROP FUNCTION J2LA.getOfertaGanadora
GO
CREATE FUNCTION J2LA.getOfertaGanadora( @pub_Codigo int )
RETURNS TABLE
AS
RETURN 
	(
Select *
From J2LA.Ofertas O
Where O.ofer_pub_Codigo = @pub_Codigo
And O.ofer_Monto = (Select MAX(O.ofer_Monto)
					From J2LA.Ofertas O
					Where O.ofer_pub_Codigo = @pub_Codigo)
)
GO
/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.getCantFactxTipoVis') IS NOT NULL
DROP FUNCTION J2LA.getCantFactxTipoVis
GO
CREATE FUNCTION J2LA.getCantFactxTipoVis( @usu_Id int )
RETURNS TABLE
AS
RETURN 
	(
Select ucftv_usu_Id, ucftv_vis_Id, 
		[Visibilidad] = pubvis_Descripcion,
		[Cantidad] = ucftv_Cantidad,
		ucftv_Cantidad
From J2LA.Usuarios_CantFactxTipoVis U
Inner Join J2LA.Publicaciones_Visibilidades V On V.pubvis_id = U.ucftv_vis_Id
Where ucftv_usu_Id = @usu_Id
)
GO