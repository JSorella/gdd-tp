-- ATENCION!! -- ATENCION!! -- ATENCION!!
-- ATENCION!! -- ATENCION!! -- ATENCION!!

-- Este Script tarda 10 segundos aprox. 
--		no se asusten...

ALTER TABLE J2LA.Publicaciones ADD
	pub_Facturada Bit Not Null Default 0
GO

ALTER TABLE J2LA.Compras ADD
	comp_Facturada Bit Not Null Default 0
GO

ALTER TABLE J2LA.Facturas_Det ADD
	facdet_Concepto Nvarchar(255)
GO

ALTER TABLE J2LA.Facturas_Det ADD
	facdet_comp_Id Int
GO

CREATE TABLE J2LA.FormasDePago (
	fdp_Id	Int	Identity(1,1),
	fdp_Descripcion Nvarchar(100)
)
Go

Delete From J2LA.FormasDePago

Go

Insert Into J2LA.FormasDePago Values ('Efectivo'), ('Tarjeta de Crédito')