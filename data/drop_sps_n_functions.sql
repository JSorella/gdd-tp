/* Script para borrar solo los SPs, Functions, Triggers, etc */


/*-----------JAVIER------------*/

IF OBJECT_ID('J2LA.setCantidadIntentos') IS NOT NULL
DROP PROCEDURE J2LA.setCantidadIntentos
GO
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
IF OBJECT_ID('J2LA.existeUsuario') IS NOT NULL
DROP FUNCTION J2LA.existeUsuario
GO
IF OBJECT_ID('J2LA.existeTelefono') IS NOT NULL
DROP FUNCTION J2LA.existeTelefono
GO
IF OBJECT_ID('J2LA.existeDni') IS NOT NULL
DROP FUNCTION J2LA.existeDni
GO
IF OBJECT_ID('J2LA.validarPrimerIngreso') IS NOT NULL
DROP FUNCTION J2LA.validarPrimerIngreso
GO
IF OBJECT_ID('J2LA.setPrimerIngresoValido') IS NOT NULL
DROP PROCEDURE J2LA.setPrimerIngresoValido
GO
IF OBJECT_ID('J2LA.setNuevoUsuario') IS NOT NULL
DROP PROCEDURE J2LA.setNuevoUsuario
GO
IF OBJECT_ID('J2LA.getUserId') IS NOT NULL
DROP FUNCTION J2LA.getUserId
GO
IF OBJECT_ID('J2LA.getRolId') IS NOT NULL
DROP FUNCTION J2LA.getRolId
GO
IF OBJECT_ID('J2LA.setNuevoCliente') IS NOT NULL
DROP PROCEDURE J2LA.setNuevoCliente
GO
IF OBJECT_ID('J2LA.actualizarCliente') IS NOT NULL
DROP PROCEDURE J2LA.actualizarCliente
GO
IF OBJECT_ID('J2LA.bajaCliente') IS NOT NULL
DROP PROCEDURE J2LA.bajaCliente
GO
IF OBJECT_ID('J2LA.setPreguntaRespuesta') IS NOT NULL
DROP PROCEDURE J2LA.setPreguntaRespuesta
GO
IF OBJECT_ID('J2LA.setCompra') IS NOT NULL
DROP PROCEDURE J2LA.setCompra
GO
IF OBJECT_ID('J2LA.updateStockPublicacion') IS NOT NULL
DROP PROCEDURE J2LA.updateStockPublicacion
GO
IF OBJECT_ID('J2LA.validarComprasSinRendir') IS NOT NULL
DROP TRIGGER J2LA.validarComprasSinRendir
GO
IF OBJECT_ID('J2LA.getPrecioMax') IS NOT NULL
DROP FUNCTION J2LA.getPrecioMax
GO
IF OBJECT_ID('J2LA.setOferta') IS NOT NULL
DROP PROCEDURE J2LA.setOferta
GO
IF OBJECT_ID('J2LA.getVendedor') IS NOT NULL
DROP PROCEDURE J2LA.getVendedor
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