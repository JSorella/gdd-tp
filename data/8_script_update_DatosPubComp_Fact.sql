Update J2LA.Publicaciones
Set pub_Facturada = 1
where pub_Codigo between 12353 and 68380

IF OBJECT_ID('J2LA.triggerInhabilitarUsuarioPorNoCalificar') IS NOT NULL
DROP TRIGGER J2LA.triggerInhabilitarUsuarioPorNoCalificar
GO -- EJECUTAR EL SQL_LUCAS!!!!!!!!!!

Update J2LA.Compras
Set comp_Facturada = 1
where comp_pub_Codigo between 12353 and 68380