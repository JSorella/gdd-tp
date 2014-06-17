-- Cargamos los Rubros para las Publicaciones.-
Delete From J2LA.Publicaciones_Rubros
Delete From J2LA.Rubros

DBCC CHECKIDENT ('J2LA.Rubros', RESEED,0)

Insert Into J2LA.Rubros(rub_Codigo, rub_Descripcion, rub_Eliminado) 
Select Distinct Codigo = 0, M.Publicacion_Rubro_Descripcion, Eliminado = 0
From gd_esquema.Maestra M
Order by M.Publicacion_Rubro_Descripcion
GO

Insert Into J2LA.Publicaciones_Rubros(pubrub_pub_Codigo, pubrub_rub_Id)
Select Distinct M.Publicacion_Cod, R.rub_id
From gd_esquema.Maestra M
Inner Join J2LA.Rubros R On R.rub_Descripcion = M.Publicacion_Rubro_Descripcion
GO

Update J2LA.Rubros
Set rub_Codigo = rub_id
GO