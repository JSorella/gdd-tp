/* Script para borrar solo los SPs, Functions, Triggers, etc */


/*-----------JAVIER------------*/

IF OBJECT_ID('J2LA.setCantidadIntentos') IS NOT NULL
DROP PROCEDURE J2LA.setCantidadIntentos
GO
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO

/*-----------LUCAS-------------*/

IF OBJECT_ID('J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos') IS NOT NULL
DROP FUNCTION J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos
GO
IF OBJECT_ID('J2LA.getTop5VendedoresConMayorFacturacion') IS NOT NULL
DROP FUNCTION J2LA.getTop5VendedoresConMayorFacturacion
GO
IF OBJECT_ID('J2LA.getTop5VendedoresConMayoresCalificaciones') IS NOT NULL
DROP FUNCTION J2LA.getTop5VendedoresConMayoresCalificaciones
GO
IF OBJECT_ID('J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar') IS NOT NULL
DROP FUNCTION J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar
GO