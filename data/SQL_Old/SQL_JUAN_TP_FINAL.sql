Use [GD1C2014]
Go 

/*============================== STORED PROCEDURE JUAN ==============================*/

IF OBJECT_ID('J2LA.Facturas_Insert_Detalle') IS NOT NULL
DROP PROCEDURE J2LA.Facturas_Insert_Detalle
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta del los Items del Detalle de una Factura
-- Tambien actualiza las Publicaciones o Compras como Facturadas, junto con
-- la tabla de Historicos para Bonificacion
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.Facturas_Insert_Detalle
	@facdet_fac_Numero numeric(18,0),
	@facdet_pub_Codigo numeric(18,0),
	@facdet_comp_Id int,
	@facdet_Concepto nvarchar(255),
	@facdet_Cantidad numeric(18,0),
	@facdet_Importe numeric(18,2)
AS
BEGIN

	DECLARE @pub_visibilidad_Id INT
	DECLARE @pub_usu_Id INT

	--Alta del Item
	INSERT INTO J2LA.Facturas_Det
		([facdet_fac_Numero],[facdet_pub_Codigo],[facdet_Cantidad],
		[facdet_Importe],[facdet_Concepto], [facdet_comp_Id])
	VALUES(@facdet_fac_Numero, @facdet_pub_Codigo, @facdet_Cantidad, 
		@facdet_Importe, @facdet_Concepto, @facdet_comp_Id)
		
	-- Es Compra o Publicacion
	IF(@facdet_comp_Id = 0)
	BEGIN
		--Marco como Facturada
		UPDATE J2LA.Publicaciones 
		SET pub_Facturada = 1
		WHERE pub_Codigo = @facdet_pub_Codigo
		
		IF(@facdet_Importe > 0) --No es Bonificacion
		BEGIN
			SELECT @pub_visibilidad_Id = pub_visibilidad_Id,
			@pub_usu_Id = pub_usu_Id
			FROM J2LA.Publicaciones 
			Where pub_Codigo = @facdet_pub_Codigo

			--Actualizo Historico para Bonificacion en Facturacion
			Update J2LA.Usuarios_CantFactxTipoVis
			Set	ucftv_Cantidad = ucftv_Cantidad + 1
			Where ucftv_usu_Id = @pub_usu_Id
			And ucftv_vis_Id = @pub_visibilidad_Id
		END
	END
	ELSE
	BEGIN
		--Marco como Facturada
		UPDATE J2LA.Compras
		SET comp_Facturada = 1
		WHERE comp_Id = @facdet_comp_Id
	END

END
GO