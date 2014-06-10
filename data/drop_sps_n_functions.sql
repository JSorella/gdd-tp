/* Script para borrar solo los SPs, Functions, Triggers, etc */


/*-----------JAVIER------------*/

IF OBJECT_ID('J2LA.setCantidadIntentos') IS NOT NULL
DROP PROCEDURE J2LA.setCantidadIntentos
GO
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
IF OBJECT_ID('J2LA.setPreguntaRespuesta') IS NOT NULL
DROP PROCEDURE J2LA.setPreguntaRespuesta
GO



/*-----------LUCAS-------------*/

IF OBJECT_ID('J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos
GO
IF OBJECT_ID('J2LA.getTop5VendedoresConMayorFacturacion') IS NOT NULL
DROP PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion
GO
IF OBJECT_ID('J2LA.ViewVendedoresConMayoresCalificaciones') IS NOT NULL
DROP VIEW J2LA.ViewVendedoresConMayoresCalificaciones
GO
IF OBJECT_ID('J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar') IS NOT NULL
DROP PROCEDURE J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar
GO
IF OBJECT_ID('J2LA.getCalificacionesPendientes') IS NOT NULL
DROP FUNCTION J2LA.getCalificacionesPendientes
GO
IF OBJECT_ID('J2LA.ActulizarReputacion') IS NOT NULL
DROP PROCEDURE J2LA.ActualizarReputacion
GO
IF OBJECT_ID('J2LA.CargarCalificacion') IS NOT NULL
DROP PROCEDURE J2LA.CargarCalificacion
GO
IF OBJECT_ID('J2LA.triggerInhabilitarUsuarioPorNoCalificar') IS NOT NULL
DROP TRIGGER J2LA.triggerInhabilitarUsuarioPorNoCalificar
GO