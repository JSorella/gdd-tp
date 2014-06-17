USE GD1C2014
GO

/******************************* BORRA OBJETOS DE LA BD *******************************/
/**************************************************************************************/

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
IF OBJECT_ID('J2LA.setBajaCliente') IS NOT NULL
DROP PROCEDURE J2LA.setBajaCliente
GO
IF OBJECT_ID('J2LA.setBajaUsuario') IS NOT NULL
DROP PROCEDURE J2LA.setBajaUsuario
GO
IF OBJECT_ID('J2LA.setPreguntaRespuesta') IS NOT NULL
DROP PROCEDURE J2LA.setPreguntaRespuesta
GO
IF OBJECT_ID('J2LA.setCompra') IS NOT NULL
DROP PROCEDURE J2LA.setCompra
GO
IF OBJECT_ID('J2LA.validarComprasSinRendir') IS NOT NULL
DROP TRIGGER J2LA.validarComprasSinRendir
GO
IF OBJECT_ID('J2LA.updateStockPublicacion') IS NOT NULL
DROP TRIGGER J2LA.updateStockPublicacion
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
IF OBJECT_ID('J2LA.Publicaciones_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Insert
GO
IF OBJECT_ID('J2LA.Publicaciones_Update') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Update
GO
IF OBJECT_ID('J2LA.Publicaciones_Delete_Rubros') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Delete_Rubros
GO
IF OBJECT_ID('J2LA.Publicaciones_Insert_Rubros') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Insert_Rubros
GO
IF OBJECT_ID('J2LA.ObtenerRubrosPubli') IS NOT NULL
DROP FUNCTION J2LA.ObtenerRubrosPubli
GO
IF OBJECT_ID('J2LA.CantPubliGratis') IS NOT NULL
DROP FUNCTION J2LA.CantPubliGratis
GO
IF OBJECT_ID('J2LA.UsuarioInHabilitado') IS NOT NULL
DROP FUNCTION J2LA.UsuarioInHabilitado
GO
IF OBJECT_ID('J2LA.Roles_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Insert
GO
IF OBJECT_ID('J2LA.Roles_Insert_Funcionalidades') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Insert_Funcionalidades
GO
IF OBJECT_ID('J2LA.getFuncionalidadesPorRol') IS NOT NULL
DROP FUNCTION J2LA.getFuncionalidadesPorRol
GO
IF OBJECT_ID('J2LA.getRoles_Funcionalidades') IS NOT NULL
DROP FUNCTION J2LA.getRoles_Funcionalidades
GO
IF OBJECT_ID('J2LA.Roles_Update') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Update
GO
IF OBJECT_ID('J2LA.Roles_Delete_Funcionalidades') IS NOT NULL
DROP PROCEDURE J2LA.Roles_Delete_Funcionalidades
GO
IF OBJECT_ID('J2LA.Roles_BajaLogica') IS NOT NULL
DROP PROCEDURE J2LA.Roles_BajaLogica
GO
IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_Insert
GO
IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_Update') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_Update
GO
IF OBJECT_ID('J2LA.Publicaciones_Visibilidades_BajaLogica') IS NOT NULL
DROP PROCEDURE J2LA.Publicaciones_Visibilidades_BajaLogica
GO
IF OBJECT_ID('J2LA.Usuario_CambiarPass') IS NOT NULL
DROP PROCEDURE J2LA.Usuario_CambiarPass
GO
IF OBJECT_ID('J2LA.Facturas_Insert') IS NOT NULL
DROP PROCEDURE J2LA.Facturas_Insert
GO
IF OBJECT_ID('J2LA.Facturas_Insert_Detalle') IS NOT NULL
DROP PROCEDURE J2LA.Facturas_Insert_Detalle
GO
IF OBJECT_ID('J2LA.getPendientesFact') IS NOT NULL
DROP FUNCTION J2LA.getPendientesFact
GO
IF OBJECT_ID('J2LA.getOfertaGanadora') IS NOT NULL
DROP FUNCTION J2LA.getOfertaGanadora
GO
IF OBJECT_ID('J2LA.getCantFactxTipoVis') IS NOT NULL
DROP FUNCTION J2LA.getCantFactxTipoVis
GO

/******************************* BORRA TABLAS DE LA BD *******************************/
/*************************************************************************************/

Drop Table J2LA.Clientes
GO
Drop Table J2LA.Empresas
GO
Drop Table J2LA.TiposDoc
GO
Drop Table J2LA.FormasDePago
GO
Drop Table J2LA.Facturas_Det
GO
Drop Table J2LA.Facturas
GO
Drop Table J2LA.Preguntas
GO
Drop Table J2LA.Compras
GO
Drop Table J2LA.Calificaciones
GO
Drop Table J2LA.Ofertas
GO
Drop Table J2LA.Publicaciones_Rubros
GO
Drop Table J2LA.Rubros
GO
Drop Table J2LA.Publicaciones
GO
Drop Table J2LA.Usuarios_CantFactxTipoVis
GO
Drop Table J2LA.Publicaciones_Visibilidades
GO
Drop Table J2LA.Publicaciones_Tipos
GO
Drop Table J2LA.Publicaciones_Estados
GO
Drop Table J2LA.Usuarios_Roles
GO
Drop Table J2LA.Usuarios_Calificaciones
GO
Drop Table J2LA.Usuarios
GO
Drop Table J2LA.Roles_Funcionalidades
GO
Drop Table J2LA.Funcionalidades
GO
Drop Table J2LA.Roles
GO

/******************************* BORRA ESQUEMA DE LA BD *******************************/
/**************************************************************************************/

Drop Schema J2LA
GO