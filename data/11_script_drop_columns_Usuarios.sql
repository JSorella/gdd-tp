ALTER TABLE J2LA.Usuarios
DROP COLUMN Publ_Cli_Dni, Publ_Empresa_Cuit
GO

DELETE FROM J2LA.TiposDoc
WHERE tipodoc_Descripcion = 'C.U.I.T.'
GO