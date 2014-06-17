USE [GD1C2014] /* Seleccionamos una BD EXTERNA, a la cual se dirigiran los proximos Comandos SQL. */
GO 

/******************************** CREACION DE ESQUEMA *******************************
	Creamos un Schema J2LA (Modelo de Datos/contiene las estructuras de negocio) 
	El usuario que poseera el schema (OWNER) sera: gd
************************************************************************************/

CREATE SCHEMA J2LA AUTHORIZATION [gd]
GO

/******************************** CREACION DE TABLAS ********************************
	Creamos las Tablas de Negocio.-
************************************************************************************/

-- Creamos la Tabla con las Funcionalidades del Sistema.-
CREATE TABLE J2LA.Funcionalidades (
	fun_Id int IDENTITY (1,1) NOT NULL,
	fun_Nombre nvarchar(255) UNIQUE NOT NULL,
CONSTRAINT PK_fun_Id PRIMARY KEY (fun_Id))

GO

-- Creamos la Tabla con los Roles para los usuarios (Admin, Cliente y Empresa).-
CREATE TABLE J2LA.Roles (
	rol_Id int IDENTITY (1,1) NOT NULL,
	rol_Nombre nvarchar(255) UNIQUE NOT NULL,
	rol_Inhabilitado bit NOT NULL,
	rol_Eliminado bit NOT NULL,
CONSTRAINT PK_rol_Id PRIMARY KEY (rol_Id))

GO

-- Creamos la Tabla con las Funcionalidades disponibles para cada Rol.-
CREATE TABLE J2LA.Roles_Funcionalidades (
	rolfun_rol_Id int NOT NULL,
	rolfun_fun_Id int NOT NULL,
CONSTRAINT FK_rolfun_rol_Id FOREIGN KEY(rolfun_rol_Id) REFERENCES J2LA.Roles (rol_Id),
CONSTRAINT FK_rolfun_fun_Id FOREIGN KEY(rolfun_fun_Id) REFERENCES J2LA.Funcionalidades (fun_Id),
CONSTRAINT PK_rolfun_rolId_funId PRIMARY KEY (rolfun_rol_Id, rolfun_fun_Id))

GO

-- Creamos la Tabla de Usuarios.-
CREATE TABLE J2LA.Usuarios (
	usu_Id int IDENTITY (1,1) NOT NULL,
	usu_UserName nvarchar(255) UNIQUE NOT NULL,
	usu_Pass nvarchar(255) NOT NULL,
	usu_Cant_Intentos int NOT NULL DEFAULT 0,
	usu_Inhabilitado bit NOT NULL DEFAULT 0,
	usu_Inhabilitado_Comprar bit NOT NULL DEFAULT 0,
	usu_Motivo nvarchar(255) NULL,
	usu_Eliminado bit NOT NULL DEFAULT 0,
	usu_Primer_Ingreso bit NOT NULL DEFAULT 1,
CONSTRAINT PK_usu_Id PRIMARY KEY (usu_Id),
CONSTRAINT UQ_usu_UserName UNIQUE (usu_UserName))

GO

-- Creamos la Tabla con los Roles asignados a cada Usuario.-
CREATE TABLE J2LA.Usuarios_Roles (
	usurol_usu_Id int NOT NULL,
	usurol_rol_Id int NOT NULL,
CONSTRAINT FK_usurol_usu_Id FOREIGN KEY(usurol_usu_Id) REFERENCES J2LA.Usuarios(usu_Id),
CONSTRAINT FK_usurol_rol_Id FOREIGN KEY(usurol_rol_Id) REFERENCES J2LA.Roles(rol_Id),
CONSTRAINT PK_usurol_usuId_rolId PRIMARY KEY (usurol_usu_Id, usurol_rol_Id))

GO

-- Creamos la Tabla con las Calificaicones y Ventas del Usuario
-- Acumuladas por Anio y Trimestre
CREATE TABLE J2LA.Usuarios_Calificaciones(
	usucal_usu_Id int,
	usucal_Anio int,
	usucal_Puntos_Primero int,
	usucal_Cant_Ventas_Primero int,
	usucal_Puntos_Segundo int,
	usucal_Cant_Ventas_Segundo int,
	usucal_Puntos_Tercero int,
	usucal_Cant_Ventas_Tercero int,
	usucal_Puntos_Cuarto int,
	usucal_Cant_Ventas_Cuarto int,
CONSTRAINT FK_usucal_usu_Id FOREIGN KEY(usucal_usu_Id) REFERENCES J2LA.Usuarios(usu_Id)
)
GO

-- Creamos la Tabla que almacena los Tipos de Documento para Clientes.-
CREATE TABLE J2LA.TiposDoc (
	tipodoc_Id int IDENTITY (1,1) NOT NULL,
	tipodoc_Descripcion nvarchar(255) UNIQUE NOT NULL,
CONSTRAINT PK_tipodoc_Id PRIMARY KEY (tipodoc_Id))

GO

-- Creamos la Tabla para los Usuarios Clientes.-
CREATE TABLE J2LA.Clientes (
	cli_Nombre nvarchar(255) NOT NULL,
	cli_Apellido nvarchar(255) NOT NULL,
	cli_Tipodoc_Id int NOT NULL,
	cli_Nro_Doc numeric(18,0) NOT NULL,
	cli_Mail nvarchar(255) NULL,
	cli_Tel nvarchar(50) NULL,
	cli_Dom_Calle nvarchar(255) NULL,
	cli_Nro_Calle numeric(18,0) NULL,
	cli_Piso numeric(18,0) NULL,
	cli_Dpto nvarchar(50) NULL,
	cli_Localidad nvarchar(255) NULL,
	cli_CP nvarchar(50) NULL,
	cli_Fecha_Nac datetime NULL,
	cli_Cuil nvarchar(50) NOT NULL,
	cli_usu_Id Int NOT NULL,
CONSTRAINT FK_cli_usu_Id FOREIGN KEY(cli_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_cli_Tipodoc_Id FOREIGN KEY(cli_Tipodoc_Id) REFERENCES J2LA.TiposDoc (tipodoc_Id),
CONSTRAINT PK_cli_Tipo_Numero_Doc PRIMARY KEY (cli_Tipodoc_Id, cli_Nro_Doc))

GO

-- Creamos la Tabla para los Usuarios Empresas.-
CREATE TABLE J2LA.Empresas (
	emp_Razon_Social nvarchar(255) UNIQUE NOT NULL,
	emp_Cuit nvarchar(50) UNIQUE NOT NULL,
	emp_Mail nvarchar(50) NULL,
	emp_Tel nvarchar(50) NULL,
	emp_Dom_Calle nvarchar(255) NULL,
	emp_Nro_Calle numeric(18,0) NULL,
	emp_Piso numeric(18,0) NULL,
	emp_Dpto nvarchar(255) NULL,
	emp_Localidad nvarchar(255) NULL,
	emp_CP nvarchar(50) NULL,
	emp_Ciudad nvarchar(255) NULL,
	emp_Contacto nvarchar(255) NULL,
	emp_Fecha_Creacion DateTime NULL,
	emp_usu_Id Int NOT NULL,
CONSTRAINT FK_emp_usu_Id FOREIGN KEY(emp_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_emp_Cuit PRIMARY KEY (emp_Cuit))

GO

-- Creamos la Tabla con los Rubros (Categorias) para las Publicaciones.-
CREATE TABLE J2LA.Rubros (
	rub_id int IDENTITY (1,1) NOT NULL,
	rub_Codigo numeric(18,0) NOT NULL,
	rub_Descripcion nvarchar(255) NOT NULL,
	rub_Eliminado bit NOT NULL,
CONSTRAINT PK_rub_id PRIMARY KEY (rub_Id))

GO

-- Creamos la Tabla con las Visibilidades para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Visibilidades (
	pubvis_id int IDENTITY (1,1) NOT NULL,
	pubvis_Codigo numeric(18,0) NOT NULL,
	pubvis_Descripcion nvarchar(255) NOT NULL,
	pubvis_Precio numeric(18,2) NOT NULL,
	pubvis_Porcentaje numeric(18,2) NOT NULL,
	pubvis_Dias_Vto numeric(18,0) NOT NULL,
	pubvis_Eliminado bit NOT NULL,
CONSTRAINT PK_pubvis_id PRIMARY KEY (pubvis_id))

GO

-- Creamos la Tabla con los Tipos de Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Tipos (
	pubtip_Id int IDENTITY (1,1) NOT NULL,
	pubtip_Nombre nvarchar(255) NOT NULL,
CONSTRAINT PK_pubtip_Id PRIMARY KEY (pubtip_Id))

GO

-- Creamos la Tabla con los Estados para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Estados (
	pubest_Id int IDENTITY (1,1) NOT NULL,
	pubest_Descripcion nvarchar(255) NOT NULL,
CONSTRAINT PK_pubest_Id PRIMARY KEY (pubest_Id))

GO

-- Creamos la Tabla para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones (
	pub_Codigo numeric(18,0) NOT NULL,
	pub_tipo_Id int NOT NULL,
	pub_Descripcion nvarchar(255) NOT NULL,
	pub_Stock numeric(18,0) NOT NULL,
	pub_Fecha_Vto datetime NOT NULL,
	pub_Fecha_Ini datetime NOT NULL,
	pub_Precio numeric(18,2) NOT NULL,
	pub_visibilidad_Id int NOT NULL,
	pub_estado_Id int NOT NULL,
	pub_Permite_Preg bit NOT NULL,
	pub_usu_Id int NOT NULL,
	pub_vis_Precio numeric(18, 2) NULL,
	pub_vis_Porcentaje numeric(18, 2) NULL,
	pub_Facturada Bit Not Null Default 0,
CONSTRAINT FK_pub_tipo_Id FOREIGN KEY(pub_tipo_Id) REFERENCES J2LA.Publicaciones_Tipos (pubtip_Id),	
CONSTRAINT FK_pub_visibilidad_Id FOREIGN KEY(pub_visibilidad_Id) REFERENCES J2LA.Publicaciones_Visibilidades (pubvis_id),
CONSTRAINT FK_pub_estado_Id FOREIGN KEY(pub_estado_Id) REFERENCES J2LA.Publicaciones_Estados (pubest_Id),
CONSTRAINT FK_pub_usu_Id FOREIGN KEY(pub_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_pub_Codigo PRIMARY KEY (pub_Codigo))

GO

-- Creamos la Tabla con los Rubros asignados a cada Publicacion.-
CREATE TABLE J2LA.Publicaciones_Rubros (
	pubrub_pub_Codigo numeric(18,0) NOT NULL,
	pubrub_rub_Id int NOT NULL,
CONSTRAINT FK_pubrub_pub_Codigo FOREIGN KEY(pubrub_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_pubrub_rub_Id FOREIGN KEY(pubrub_rub_Id) REFERENCES J2LA.Rubros (rub_Id),
CONSTRAINT PK_pubrub_CodPub_CodRub PRIMARY KEY (pubrub_pub_Codigo, pubrub_rub_Id))

GO

-- Creamos la Tabla para las Preguntas y Respuestas de cada Publicacion.-
CREATE TABLE J2LA.Preguntas (
	preg_pub_Codigo numeric(18,0) NOT NULL,
	preg_Id int NOT NULL,
	preg_Tipo Char(1) NOT NULL,
	preg_Fecha DateTime NOT NULL,
	preg_Comentario nvarchar(255) NOT NULL,
	preg_usu_Id int  NOT NULL,
CONSTRAINT FK_preg_pub_Codigo FOREIGN KEY(preg_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_preg_usu_Id FOREIGN KEY(preg_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_preg_Id_Tipo PRIMARY KEY(preg_Id, preg_Tipo))

GO

-- Creamos la Tabla con las Ofertas de las Publicaciones.-
CREATE TABLE J2LA.Ofertas (
	ofer_Id	int IDENTITY (1,1) NOT NULL,
	ofer_pub_Codigo numeric(18,0) NOT NULL,
	ofer_usu_Id int NOT NULL,
	ofer_Fecha datetime NOT NULL,
	ofer_Monto numeric(18,2) NOT NULL,
CONSTRAINT FK_ofer_pub_Codigo FOREIGN KEY(ofer_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_ofer_usu_Id FOREIGN KEY(ofer_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_ofer_Id PRIMARY KEY (ofer_Id))

GO

-- Creamos la Tabla con las Calificaciones de las Compras.-
CREATE TABLE J2LA.Calificaciones (
	cal_Codigo numeric(18,0) NOT NULL,
	cal_Cant_Estrellas numeric(18,0) NOT NULL,
	cal_Comentario nvarchar(255) NOT NULL,
CONSTRAINT PK_cal_Codigo PRIMARY KEY (cal_Codigo))

GO

-- Creamos la Tabla con las Compras de las Publicaciones.-
CREATE TABLE J2LA.Compras (
	comp_Id	int IDENTITY (1,1) NOT NULL,
	comp_pub_Codigo numeric(18,0) NOT NULL,
	comp_usu_Id int NOT NULL,
	comp_Fecha datetime NOT NULL,
	comp_Cantidad numeric(18,0) NOT NULL,
	comp_Comision numeric(18,1) NOT NULL,
	comp_cal_Codigo numeric(18,0) NULL,
	comp_Facturada Bit Not Null Default 0,
CONSTRAINT FK_comp_pub_Codigo FOREIGN KEY(comp_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_comp_usu_Id FOREIGN KEY(comp_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_comp_cal_Codigo FOREIGN KEY(comp_cal_Codigo) REFERENCES J2LA.Calificaciones (cal_Codigo),
CONSTRAINT PK_comp_Id PRIMARY KEY (comp_Id))

GO

-- Creamos la Tabla con las Formas de Pago disponibles para la Facturacion 
CREATE TABLE J2LA.FormasDePago (
	fdp_Id	Int	Identity(1,1),
	fdp_Descripcion Nvarchar(100)
CONSTRAINT PK_fdp_Id PRIMARY KEY (fdp_Id))
GO

-- Creamos la Tabla con la Cabecera de Facturas emitidas.-
CREATE TABLE J2LA.Facturas (
	fac_Numero numeric(18,0) NOT NULL,
	fac_usu_Id int NOT NULL,
	fac_Fecha datetime NOT NULL,
	fac_Total numeric(18,2) NOT NULL,
	fac_fdp_Id int NOT NULL,
	fac_Forma_Pago_Desc nvarchar(255) NOT NULL,
	fac_usu_id_gen INT NOT NULL,
CONSTRAINT FK_fac_usu_Id FOREIGN KEY(fac_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_fac_usu_id_gen FOREIGN KEY(fac_usu_id_gen) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_fac_fdp_Id FOREIGN KEY(fac_fdp_Id) REFERENCES J2LA.FormasDePago (fdp_Id),
CONSTRAINT PK_fac_numero PRIMARY KEY (fac_numero))

GO

-- Creamos la Tabla con el Detalle de las Facturas emitidas.-
CREATE TABLE J2LA.Facturas_Det (
	facdet_fac_Numero numeric(18,0) NOT NULL,
	facdet_pub_Codigo numeric(18,0) NOT NULL,
	facdet_comp_Id Int NOT NULL,
	facdet_Concepto Nvarchar(255) NOT NULL,
	facdet_Cantidad numeric(18,0) NOT NULL,
	facdet_Importe numeric(18,2) NOT NULL,
CONSTRAINT FK_facdet_pub_Codigo FOREIGN KEY(facdet_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_facdet_fac_Numero FOREIGN KEY(facdet_fac_Numero) REFERENCES J2LA.Facturas (fac_numero))

GO

CREATE TABLE J2LA.Usuarios_CantFactxTipoVis (
	ucftv_usu_Id Int,
	ucftv_vis_Id Int,
	ucftv_Cantidad Int,
CONSTRAINT FK_ucftv_usu_Id FOREIGN KEY(ucftv_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_ucftv_vis_Id FOREIGN KEY(ucftv_vis_Id) REFERENCES J2LA.Publicaciones_Visibilidades (pubvis_id))
GO
	
/************************** INSERCION DE DATOS DE CONFIGURACION **************************/
/****************************************************************************************/

-- Cargamos las Funcionalidades del Sistema.-
Insert Into J2LA.Funcionalidades(fun_nombre)
	Values ('Cambiar Contraseña'), ('Baja Usuario'), ('ABM de Rol'), ('ABM de Cliente'), ('ABM de Empresa'), 
	('ABM de Visibilidad de Publicacion'), ('Generar Publicacion'), ('Editar Publicacion'), 
	('Gestión de Preguntas'), ('Comprar/Ofertar'), ('Calificar Vendedor'),
	('Historial de Cliente'), ('Facturar Publicaciones'), ('Listado Estadístico')
GO

-- Cargamos los Roles del Sistema.-
Insert Into J2LA.Roles 
	Values	('Administrador General', 0, 0),
			('Cliente', 0, 0),
			('Empresa', 0, 0)
GO

/* ==================== Cargamos la Relacion Rol<>Funcionalidades ==================== */

-- Funcionalidades del Rol Adminitrador
Insert Into J2LA.Roles_Funcionalidades
	Select RolId = 1, F.fun_Id
	From J2LA.Funcionalidades F
GO

-- Funcionalidades del Rol Cliente
-- (Cambiar Pass, Gen/Edit Publi, Preguntas, Comp/Ofer, Calificar, Historial)
Insert Into J2LA.Roles_Funcionalidades
	Values (2,1), (2,7), (2,8), (2,9), (2,10), (2,11), (2,12)
GO

-- Funcionalidades del Rol Empresa
-- (Cambiar Pass, Gen/Edit Publi, Preguntas, Historial)
Insert Into J2LA.Roles_Funcionalidades
	Values (3,1), (3,7), (3,8), (3,9), (3,12)
GO

/* ====================================================================================*/

-- Cargamos los Tipos de Documentos para Clientes.-
Insert Into J2LA.TiposDoc 
	Values ('D.N.I'),('L.C'),('L.E')
GO

-- Cargamos los Estados para las Publicaciones.-
Insert Into J2LA.Publicaciones_Estados 
	Values ('Activa'),('Borrador'),('Pausada'),('Finalizada')
GO

-- Cargamos los Tipos para las Publicaciones.-
Insert Into J2LA.Publicaciones_Tipos 
	Values ('Compra Inmediata'),('Subasta')
GO

-- Cargamos las Formas de Pago para las Facturas.-
Insert Into J2LA.FormasDePago 
	Values ('Efectivo'), ('Tarjeta de Crédito')
GO

-- Cargamos el Usuario admin/w23e para la puesta en marcha del Sistema.-
Insert Into J2LA.Usuarios(usu_username, usu_pass, usu_Cant_Intentos, 
		usu_Inhabilitado, usu_Inhabilitado_Comprar, usu_Motivo, 
		usu_Eliminado, usu_Primer_Ingreso)
	Values ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',
		0, 0, 0, '', 0, 0)
GO

/********************************** MIGRACION DE DATOS **********************************/
/****************************************************************************************/

-- Agregamos 2 Columnas Temporales para Optimizar la Migración.-
Alter Table J2LA.Usuarios Add
	Publ_Cli_Dni numeric(18, 0),
	Publ_Empresa_Cuit nvarchar(50)
GO

-- Asignamos el Rol 'Administrador General' a todos los Usuarios Administradores.-
Insert Into J2LA.Usuarios_Roles(usurol_usu_Id, usurol_rol_Id)
	Select U.usu_Id, RolId = 1
	From J2LA.Usuarios U
	Where U.Publ_Cli_Dni Is Null
		And U.Publ_Empresa_Cuit Is Null
GO

-- Creamos los usuarios para los Clientes como 'NroDni+TipoDoc_Id'/1234.-
Insert Into J2LA.Usuarios(usu_UserName, usu_Pass, usu_Cant_Intentos, 
		usu_Inhabilitado, usu_Inhabilitado_Comprar, usu_Motivo, 
		usu_Eliminado, usu_Primer_Ingreso, Publ_Cli_Dni, Publ_Empresa_Cuit)
	Select Distinct 
		UserName = (LTRIM(RTRIM(CONVERT(nvarchar, Publ_Cli_Dni))) + '1'),
		Pass = '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',
		CantIntentos = 2, Inhabilitado = 0, usu_Inhabilitado_Comprar = 0,
		Motivo = '', Eliminado = 0, Primer_Ingreso = 1,
		M.Publ_Cli_Dni, Cuit_Empre = Null
	From gd_esquema.Maestra M
	Where M.Publ_Cli_Dni Is Not Null
GO

-- Creamos los usuarios para las Empresas como 'Cuit'/5678.-
Insert Into J2LA.Usuarios(usu_UserName, usu_Pass, usu_Cant_Intentos, 
		usu_Inhabilitado, usu_Inhabilitado_Comprar, usu_Motivo, 
		usu_Eliminado, usu_Primer_Ingreso, Publ_Cli_Dni, Publ_Empresa_Cuit)
	Select Distinct 
		UserName = LTRIM(RTRIM(REPLACE(M.Publ_Empresa_Cuit, '-', ''))),
		Pass = 'f8638b979b2f4f793ddb6dbd197e0ee25a7a6ea32b0ae22f5e3c5d119d839e75',
		CantIntentos = 2, Inhabilitado = 0, usu_Inhabilitado_Comprar = 0, 
		Motivo = '', Eliminado = 0, Primer_Intento = 1, 
		Dni_Cli = Null, Cuit_Empre = M.Publ_Empresa_Cuit
	From gd_esquema.Maestra M
	Where M.Publ_Empresa_Cuit Is Not Null
GO

-- Asignamos el Rol 'Cliente' a todos los Usuarios Clientes.-
Insert Into J2LA.Usuarios_Roles(usurol_usu_Id, usurol_rol_Id)
	Select U.usu_Id, RolId = 2
	From J2LA.Usuarios U
	Where U.Publ_Cli_Dni Is Not Null
Go

-- Asignamos el Rol 'Empresa' a todos los Usuarios Empresas.-
Insert Into J2LA.Usuarios_Roles(usurol_usu_Id, usurol_rol_Id)
	Select U.usu_Id, RolId = 3
	From J2LA.Usuarios U
	Where U.Publ_Empresa_Cuit Is Not Null
GO

-- Migramos los Clientes de la Tabla Maestra y asignamos el usuario del nuevo sistema.-
Insert Into J2LA.Clientes (cli_Nombre,cli_Apellido,cli_Tipodoc_Id,cli_Nro_Doc,
		cli_Mail,cli_Tel,cli_Dom_Calle,cli_Nro_Calle,cli_Piso,cli_Dpto,
		cli_Localidad,cli_CP,cli_Fecha_Nac, cli_Cuil, cli_usu_Id)
	Select Distinct Publ_Cli_Nombre, Publ_Cli_Apeliido, TipoDocId = 1, M.Publ_Cli_Dni,
		Publ_Cli_Mail, Tel = '', Publ_Cli_Dom_Calle, Publ_Cli_Nro_Calle, Publ_Cli_Piso, 
		Publ_Cli_Depto,	Localidad = '', Publ_Cli_Cod_Postal, Publ_Cli_Fecha_Nac, 
		Cuil = '', IdUsuario = U.usu_Id
	From gd_esquema.Maestra M
	Inner Join J2LA.Usuarios U On U.Publ_Cli_Dni = M.Publ_Cli_Dni
	Where M.Publ_Cli_Dni Is Not Null
GO

-- Migramos las Empresas de la Tabla Maestra y asignamos el usuario del nuevo sistema.-
Insert Into J2LA.Empresas (emp_Razon_Social,emp_Cuit,emp_Mail,emp_Tel,
		emp_Dom_Calle,emp_Nro_Calle,emp_Piso,emp_Dpto,emp_Localidad,emp_CP,
		emp_Ciudad,emp_Contacto,emp_Fecha_Creacion,emp_usu_Id)
	Select Distinct 
		Publ_Empresa_Razon_Social, M.Publ_Empresa_Cuit, Publ_Empresa_Mail,
		Tel = '', Publ_Empresa_Dom_Calle, Publ_Empresa_Nro_Calle,
		Publ_Empresa_Piso, Publ_Empresa_Depto, Localidad = '', 
		Publ_Empresa_Cod_Postal, Cuidad = '', Contacto = '',
		Publ_Empresa_Fecha_Creacion, IdUsuario = U.usu_Id
	From gd_esquema.Maestra M
	Inner Join J2LA.Usuarios U On U.Publ_Empresa_Cuit = M.Publ_Empresa_Cuit
	Where M.Publ_Empresa_Cuit Is Not Null
GO

-- Migramos las Visibilidades de la Tabla Maestra.-
Insert Into J2LA.Publicaciones_Visibilidades (pubvis_Codigo, pubvis_Descripcion,
		pubvis_Precio, pubvis_Porcentaje, pubvis_Dias_Vto, pubvis_Eliminado)
	Select Distinct M.Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, 
		Publicacion_Visibilidad_Precio, Publicacion_Visibilidad_Porcentaje, 
		Dias_Vto = 7, Eliminado = 0 
	From gd_esquema.Maestra M
GO

-- Migramos las Publicaciones de la Tabla Maestra actualizando su estado.-
-- Estados: 1 = Activa // 4 = Finalizada
DECLARE @FechaTP DateTime
SET @FechaTP = '20140618' -- Fecha Inicio Nvo Sistema = Fecha 1er Entrega TP.-

Insert Into J2LA.Publicaciones (pub_Codigo, pub_tipo_Id, pub_Descripcion, pub_Stock,
		pub_Fecha_Vto, pub_Fecha_Ini, pub_Precio, pub_visibilidad_Id, pub_estado_Id,
		pub_Permite_Preg, pub_usu_Id, pub_vis_Precio, pub_vis_Porcentaje, pub_Facturada)
	Select Distinct
		Publicacion_Cod,T.pubtip_Id,Publicacion_Descripcion,Publicacion_Stock,
		Publicacion_Fecha_Venc,Publicacion_Fecha,Publicacion_Precio,PV.pubvis_id,
		pubest_Id = (Case When (Publicacion_Fecha_Venc < @FechaTP)
					Then 4 Else 1 
				 End),
		Permite_Preguntas = 0, Usuario_Id = U.usu_Id,
		pubvis_Precio = PV.pubvis_Precio,
		pubvis_Porcentaje = PV.pubvis_Porcentaje,
		Facturada = 1
	From gd_esquema.Maestra M
	Inner Join J2LA.Usuarios U On ISNULL(U.Publ_Cli_Dni, 0) = ISNULL(M.Publ_Cli_Dni,0) 
		AND ISNULL(U.Publ_Empresa_Cuit,'') = ISNULL(M.Publ_Empresa_Cuit,'')
	Inner Join J2LA.Publicaciones_Visibilidades PV On PV.pubvis_Codigo = M.Publicacion_Visibilidad_Cod
	Inner Join J2LA.Publicaciones_Tipos T On T.pubtip_Nombre = M.Publicacion_Tipo
	Where M.Publicacion_Cod Is Not Null
GO

-- Migramos los Rubros para las Publicaciones / Sin Codigo.-
Insert Into J2LA.Rubros(rub_Codigo, rub_Descripcion, rub_Eliminado) 
Select Distinct Codigo = 0, M.Publicacion_Rubro_Descripcion, Eliminado = 0
From gd_esquema.Maestra M
Order by M.Publicacion_Rubro_Descripcion
GO

-- Actualizamos el Codigo del Rubro con el Id Autogenerado
Update J2LA.Rubros
Set rub_Codigo = rub_id
GO

-- Migramos los Rubros asignados a cada Publicacion.-
Insert Into J2LA.Publicaciones_Rubros(pubrub_pub_Codigo, pubrub_rub_Id)
Select Distinct M.Publicacion_Cod, R.rub_id
From gd_esquema.Maestra M
Inner Join J2LA.Rubros R On R.rub_Descripcion = M.Publicacion_Rubro_Descripcion
GO

-- Migramos las Ofertas realizadas a las Publicaciones.-
Insert Into J2LA.Ofertas (ofer_pub_Codigo, ofer_usu_Id, ofer_Fecha, ofer_Monto)
	Select M.Publicacion_Cod, C.cli_usu_Id,
		M.Oferta_Fecha, M.Oferta_Monto
	From gd_esquema.Maestra M
	Inner Join J2LA.Clientes C On C.cli_Nro_Doc = M.Cli_Dni
	where M.Oferta_Monto is not null
		And M.Compra_Cantidad is null
		And M.Calificacion_Codigo is null 
		And M.Factura_Total is null
GO

-- Migramos las Calificaciones de las Compras de la Tabla Maestra.-
Insert Into J2LA.Calificaciones(cal_Codigo,cal_Cant_Estrellas, cal_Comentario)
	Select M.Calificacion_Codigo, M.Calificacion_Cant_Estrellas, 
		M.Calificacion_Descripcion
	From gd_esquema.Maestra M
	Where M.Calificacion_Codigo is not null
GO

-- Migramos las Compras de la Tabla Maestra.-
Insert Into J2LA.Compras (comp_pub_Codigo, comp_usu_Id,
		comp_Fecha, comp_Cantidad, comp_Comision, 
		comp_cal_codigo, comp_Facturada)
	Select	M.Publicacion_Cod, C.cli_usu_Id,
			M.Compra_Fecha, M.Compra_Cantidad,
			Comision = 0, M.Calificacion_Codigo,
			Facturada = 1
	From gd_esquema.Maestra M
	Inner Join J2LA.Clientes C On C.cli_Nro_Doc = M.Cli_Dni
	where M.Compra_Cantidad is not null
		And M.Calificacion_Codigo is not null 
		And M.Factura_Total is null
GO

-- Migramos las Calificaciones por Usuario 
-- agrupadas por Usuario Anio y Trimestre
INSERT INTO J2LA.Usuarios_Calificaciones
SELECT P.pub_usu_Id,
	   Anio = YEAR(Co.comp_Fecha), 
	   usucal_Puntos_Primero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (1,2,3) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Primero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (1,2,3) THEN 1 ELSE 0 END),
	   usucal_Puntos_Segundo = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (4,5,6) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Segundo = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (4,5,6) THEN 1 ELSE 0 END),
	   usucal_Puntos_Tercero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (7,8,9) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Tercero = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (7,8,9) THEN 1 ELSE 0 END),
	   usucal_Puntos_Cuarto = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (10,11,12) THEN Ca.cal_Cant_Estrellas ELSE 0 END),
	   usucal_Cant_Ventas_Cuarto = SUM(CASE WHEN MONTH(Co.comp_Fecha) IN (10,11,12) THEN 1 ELSE 0 END)
FROM J2LA.Publicaciones P, J2LA.Compras Co, J2LA.Calificaciones Ca
WHERE P.pub_Codigo = Co.comp_pub_Codigo
AND Co.comp_cal_Codigo = Ca.cal_Codigo
GROUP BY P.pub_usu_Id, YEAR(Co.comp_Fecha)
GO

-- Migramos el Encabezado de las Facuras de la Tabla Maestra.-
Insert Into J2LA.Facturas(fac_Numero, fac_usu_Id, fac_Fecha, 
	fac_Total, fac_fdp_Id, fac_Forma_Pago_Desc, fac_usu_id_gen)
Select Distinct M.Factura_Nro, P.pub_usu_id,
	M.Factura_Fecha, M.Factura_Total, fac_fdp_Id = 1, --Efectivo
	M.Forma_Pago_Desc, fac_usu_id_gen = 1 -- Usuario admin (datos migrados)
From gd_esquema.Maestra M
Inner Join J2LA.Publicaciones P On P.pub_codigo = M.Publicacion_Cod
Where M.Factura_Nro is not null
GO

-- Migramos el Detalle de las Facuras de la Tabla Maestra.-
Insert Into J2LA.Facturas_Det(facdet_fac_Numero, facdet_pub_Codigo, 
	facdet_comp_Id, facdet_Concepto, facdet_Cantidad, facdet_Importe)
Select M.Factura_Nro, M.Publicacion_Cod,
	facdet_comp_Id = 0, 
	facdet_Concepto = 'Facturacion Publicacion Nro. ' + LTRIM(RTRIM(STR(M.Publicacion_Cod))),
	M.Item_Factura_Cantidad, M.Item_Factura_Monto
From gd_esquema.Maestra M
Where M.Factura_Nro is not null
GO

-- Eliminamos las 2 Columnas Temporales utilizadas para Optimizar la Migración.-
Alter Table J2LA.Usuarios Drop Column
	Publ_Cli_Dni,
	Publ_Empresa_Cuit
GO

/******************************* OBJETOS DE BASE DE DATOS *******************************/
/****************************************************************************************/

/*--------------------------------------------------------------------------*/
-- SP - Actualiza la Cantidad de Intentos que fallo el Usuario en el LogIn.
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setCantidadIntentos @idUsuario INT, @cantIntentos INT
AS
BEGIN
	UPDATE 
		J2LA.Usuarios
    SET
		usu_Cant_Intentos = @cantIntentos,
		usu_Inhabilitado = CASE WHEN @cantIntentos >= 3 THEN 1 ELSE 0 END,
		usu_Motivo = CASE WHEN @cantIntentos >= 3 THEN 'Tres Intentos Fallidos en Login' ELSE '' END
	WHERE
		usu_Id = @idUsuario
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene las Funcionalidades asociadas a un Rol
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.getFuncionalidadesPorRol( @nombreRol nvarchar(255) )
RETURNS TABLE
AS
RETURN 
	(SELECT f.fun_Id, f.fun_Nombre
	FROM J2LA.Roles r, 
		 J2LA.Funcionalidades f, 
		 J2LA.Roles_Funcionalidades rf
	WHERE rol_Id = rolfun_rol_Id
	AND fun_Id = rolfun_fun_Id
	AND rol_Nombre = @nombreRol
	AND rol_Inhabilitado = 0
	AND rol_Eliminado = 0)
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe un usuario (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeUsuario(@userName nvarchar(255))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(usu_userName) FROM J2LA.Usuarios where usu_Username = @userName) > 0 )
		RETURN 1
	RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe un Cliente con un Telefono (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeTelefono(@cli_tel nvarchar(50))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(C.cli_tel) 
			FROM J2LA.Clientes C
			Inner Join J2LA.Usuarios U On
				U.usu_Id = C.cli_usu_Id
				And U.usu_Eliminado = 0
			WHERE cli_tel = @cli_tel) > 0)
		RETURN 1
	RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe un Cliente con un Tipo+Num Doc (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeDni(@cli_Tipodoc_Id int, @cli_Nro_Doc numeric(18,0))
RETURNS BIT
AS
BEGIN
	IF( (	SELECT COUNT(C.cli_Nro_Doc) 
			FROM J2LA.Clientes C
			Inner Join J2LA.Usuarios U On
				U.usu_Id = C.cli_usu_Id
				And U.usu_Eliminado = 0
			WHERE C.cli_Nro_Doc = @cli_Nro_Doc
			AND	C.cli_Tipodoc_Id = @cli_Tipodoc_Id
		) > 0 )
		RETURN 1
	RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe otro Cliente con un Tipo+Num Doc (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeOtroDni(@cli_Tipodoc_Id int , @cli_Nro_Doc numeric(18,0), @cli_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(C.cli_Nro_Doc) 
		FROM J2LA.Clientes C
		Inner Join J2LA.Usuarios U On
			U.usu_Id = C.cli_usu_Id
			And U.usu_Eliminado = 0
		WHERE C.cli_Nro_Doc = @cli_Nro_Doc 
			AND C.cli_Tipodoc_Id = @cli_Tipodoc_Id) > 0)
		BEGIN
			IF ((SELECT cli_usu_Id FROM J2LA.Clientes WHERE cli_Nro_Doc = @cli_Nro_Doc AND cli_Tipodoc_Id = @cli_Tipodoc_Id) = @cli_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO
/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe otro Cliente con un Cuil (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeCuil(@cli_cuil nvarchar(50), @cli_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(C.cli_Nro_Doc) 
		FROM J2LA.Clientes C
		Inner Join J2LA.Usuarios U On
			U.usu_Id = C.cli_usu_Id
			And U.usu_Eliminado = 0
		WHERE C.cli_cuil = @cli_cuil) > 0)
		BEGIN
			IF ((SELECT cli_usu_Id FROM J2LA.Clientes WHERE cli_cuil = @cli_cuil) = @cli_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO
/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe otro Cliente con un Telefono (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeOtroTelefono(@cli_Tel nvarchar(50) , @cli_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(C.cli_Tel) 
		FROM J2LA.Clientes C
		Inner Join J2LA.Usuarios U On
			U.usu_Id = C.cli_usu_Id
			And U.usu_Eliminado = 0
		WHERE C.cli_Tel = @cli_Tel) > 0)
		BEGIN
			IF ((SELECT cli_usu_Id FROM J2LA.Clientes WHERE cli_Tel = @cli_Tel) = @cli_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si es el primer ingreso al sistema (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.validarPrimerIngreso(@usu_Id int)
RETURNS BIT
AS
BEGIN

	DECLARE @primer_intento BIT
	
	SET @primer_intento = (
		SELECT usu_Primer_Ingreso 
		FROM J2LA.Usuarios 
		WHERE usu_Id = @usu_Id
		)

	RETURN @primer_intento
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Actualiza el campo usu_Primer_Ingreso para un Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setPrimerIngresoValido @usu_Id int
AS
BEGIN
		UPDATE J2LA.Usuarios
		SET usu_Primer_Ingreso = 0
		WHERE usu_Id = @usu_Id
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setNuevoUsuario 
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Primer_Ingreso bit
AS
BEGIN
	INSERT INTO J2LA.Usuarios (usu_UserName, usu_Pass, usu_Cant_Intentos, 
			usu_Inhabilitado, usu_Inhabilitado_Comprar, usu_Motivo, 
			usu_Eliminado, usu_Primer_Ingreso)
	VALUES (@usu_UserName, @usu_Pass, 0, 0, 0, '', 0, @usu_Primer_Ingreso)
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene el usu_Id de un Usuario por el UserName
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.getUserId(@userName nvarchar(255))
RETURNS INT
AS
BEGIN
	DECLARE @usuarioId INT
	SET @usuarioId = (SELECT usu_Id FROM J2LA.Usuarios WHERE usu_UserName = @userName)
	
	RETURN @usuarioId
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene el rol_Id de un Rol por el rol_Nombre
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.getRolId(@nombre nvarchar(255))
RETURNS INT
AS
BEGIN
	DECLARE @rol_Id INT
	SET @rol_Id = (SELECT rol_Id FROM J2LA.Roles WHERE  rol_Nombre = @nombre)
	
	RETURN @rol_Id
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de Cliente + Usuario + Rol del Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setNuevoCliente 
	@cli_Nombre nvarchar(255), 
	@cli_Apellido nvarchar(255), 
	@cli_Tipodoc_Id int, 
	@cli_Nro_Doc numeric(18,0), 
	@cli_Mail nvarchar(255), 
	@cli_Tel nvarchar(255), 
	@cli_Dom_Calle nvarchar(255), 
	@cli_Nro_Calle numeric(18,0), 
	@cli_Piso numeric(28,0), 
	@cli_Dpto nvarchar(50), 
	@cli_Localidad nvarchar(255), 
	@cli_CP nvarchar(50), 
	@cli_Fecha_Nac datetime, 
	@cli_Cuil nvarchar(50),
	@cli_usu_Id int,
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit,
	@usu_Inhabilitado_Comprar bit
	
AS
BEGIN

	-- Alta del Usuario
	EXECUTE J2LA.setNuevoUsuario @usu_UserName, @usu_Pass, @usu_Primer_Ingreso
	
	-- Alta del Cliente
	INSERT INTO J2LA.Clientes ( cli_Nombre, cli_Apellido, cli_Tipodoc_Id, cli_Nro_Doc, 
			cli_Mail, cli_Tel, cli_Dom_Calle, cli_Nro_Calle, cli_Piso, cli_Dpto, 
			cli_Localidad, cli_CP, cli_Fecha_Nac, cli_Cuil, cli_usu_Id)
	VALUES( @cli_Nombre, @cli_Apellido, @cli_Tipodoc_Id, @cli_Nro_Doc, 
			@cli_Mail , @cli_Tel , @cli_Dom_Calle , @cli_Nro_Calle , @cli_Piso , 
			@cli_Dpto, @cli_Localidad, @cli_CP , @cli_Fecha_Nac , @cli_Cuil ,
			J2LA.getUserId(@usu_UserName))

	-- Alta Rol del Usuario
	INSERT INTO
		J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
	VALUES
		(J2LA.getUserId(@usu_UserName), 2) /*Donde 2 es Cliente*/

END
GO

/*--------------------------------------------------------------------------*/
-- SP - Actualizacion de los datos de un Cliente + Inhabilitacion de Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.actualizarCliente(
	@cli_Nombre nvarchar(255), 
	@cli_Apellido nvarchar(255), 
	@cli_Tipodoc_Id int, 
	@cli_Nro_Doc numeric(18,0), 
	@cli_Mail nvarchar(255), 
	@cli_Tel nvarchar(255), 
	@cli_Dom_Calle nvarchar(255), 
	@cli_Nro_Calle numeric(18,0), 
	@cli_Piso numeric(28,0), 
	@cli_Dpto nvarchar(50), 
	@cli_Localidad nvarchar(255), 
	@cli_CP nvarchar(50), 
	@cli_Fecha_Nac datetime, 
	@cli_Cuil nvarchar(50),
	@cli_usu_Id int,
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Inhabilitado_Comprar bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit)
AS
	BEGIN
		UPDATE J2LA.Clientes
		SET
			cli_Nombre = @cli_Nombre, 
			cli_Apellido = @cli_Apellido,  
			cli_Tipodoc_Id = @cli_Tipodoc_Id,  
			cli_Nro_Doc = @cli_Nro_Doc,  
			cli_Mail = @cli_Mail, 
			cli_Tel = @cli_Tel,
			cli_Dom_Calle = @cli_Dom_Calle,  
			cli_Nro_Calle = @cli_Nro_Calle, 
			cli_Piso = @cli_Piso, 
			cli_Dpto = @cli_Dpto, 
			cli_Localidad = @cli_Localidad,
			cli_CP = @cli_CP, 
			cli_Fecha_Nac = @cli_Fecha_Nac, 
			cli_Cuil = @cli_Cuil
		WHERE 
			cli_usu_Id = @cli_usu_Id
			
		--Inhabilitacion de Usuario
		UPDATE J2LA.Usuarios
		SET usu_Inhabilitado = @usu_Inhabilitado,
			usu_Motivo = (Case When @usu_Inhabilitado = 0
							Then ''
							Else 'Inhabilitacion por parte del Administrador'
						End)
		WHERE usu_Id = @usu_Id
	END
GO

/*--------------------------------------------------------------------------*/
-- SP - Baja Logica del Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setBajaUsuario @usu_Id int
AS
	BEGIN
		UPDATE J2LA.Usuarios
		SET usu_Eliminado = 1
		WHERE usu_Id = @usu_Id
		
		UPDATE J2LA.Publicaciones
		SET	pub_estado_Id = 3 /* Pausada */
		WHERE pub_usu_Id = @usu_Id
	END
GO

/*--------------------------------------------------------------------------*/
-- Baja Logica del Usuario por Baja de Cliente
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setBajaCliente(@cli_Tipodoc_Id int, @cli_Nro_Doc numeric(18,0))
AS
	BEGIN
		DECLARE @usu_Id int
		SET @usu_Id = (
			SELECT cli_usu_Id 
			FROM J2LA.Clientes 
			WHERE cli_Tipodoc_Id = @cli_Tipodoc_Id
			AND cli_Nro_Doc = @cli_Nro_Doc
			)
		
		EXEC J2LA.setBajaUsuario @usu_Id
	END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de Preguntas y Respuestas
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setPreguntaRespuesta 
	@preg_pub_codigo numeric(18,0), 
	@preg_Id int, 
	@preg_Tipo char(1), 
	@preg_Fecha datetime,
	@preg_Comentario nvarchar(255), 
	@preg_usu_Id int
AS
BEGIN

	/* Si preg_tipo = 'R', entonces tomo el preg_Id por referencia*/
	IF (@preg_Tipo = 'P')
	BEGIN
		DECLARE @maxId INT
		SET @maxId = (SELECT MAX(preg_Id)FROM J2LA.Preguntas)
		SET @preg_Id = CASE WHEN @maxId IS NULL THEN 1 ELSE (@maxId + 1) END
	END

	INSERT INTO J2LA.Preguntas (preg_Id, preg_pub_codigo, preg_Tipo, 
		preg_Fecha, preg_Comentario, preg_usu_Id)
	VALUES(@preg_Id, @preg_pub_codigo, @preg_Tipo, 
		@preg_Fecha, @preg_Comentario, @preg_usu_Id)
END
GO


/*--------------------------------------------------------------------------*/
-- SP - Alta de Compras
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setCompra 
	@comp_Id int,
	@comp_pub_Codigo numeric(18,0), 
	@comp_usu_Id int,
	@comp_Fecha datetime,
	@comp_Cantidad numeric(18,0),
	@comp_Comision numeric(18,1),
	@comp_cal_Codigo numeric(18,0),
	@comp_Facturada bit
AS
BEGIN

	DECLARE @maxId INT
	SET @maxId = (SELECT MAX(comp_Id)FROM J2LA.Compras)
	SET @comp_Id = CASE WHEN @maxId IS NULL THEN 1 ELSE (@comp_Id + 1) END

	INSERT INTO
		J2LA.Compras ( comp_pub_Codigo, comp_usu_Id, comp_Fecha, comp_Cantidad, comp_Comision, comp_Facturada)
	VALUES
		( @comp_pub_Codigo, @comp_usu_Id, @comp_Fecha, @comp_Cantidad, @comp_Comision, @comp_Facturada)

END
GO

/*--------------------------------------------------------------------------*/
-- TRIGGER - Por cada Nueva Compra Actualiza el Stock.
-- Si el stock llega a 0 (cero) entonces se finaliza la Publicacion
/*--------------------------------------------------------------------------*/
CREATE TRIGGER J2LA.updateStockPublicacion 
ON J2LA.Compras
AFTER INSERT
AS
BEGIN
	/* Debo decrementar el Stock en la publicación */
	DECLARE @comp_Cantidad numeric(18,0)
	DECLARE	@comp_pub_Codigo numeric(18,0)
	SET @comp_Cantidad = (SELECT comp_Cantidad FROM inserted)
	SET @comp_pub_Codigo = (SELECT comp_pub_Codigo FROM inserted)
	
	-- 4 = Finalizada // Sino Estado Actual
	UPDATE J2LA.Publicaciones
		SET	pub_estado_Id = (CASE WHEN (pub_Stock - @comp_Cantidad = 0) 
								THEN 4
								ELSE pub_estado_Id
							END),
			pub_Stock = (pub_Stock - @comp_Cantidad)
		WHERE pub_Codigo = @comp_pub_Codigo
END
GO

/*--------------------------------------------------------------------------*/
-- TRIGGER - Para cad Nueva Compra, valida la cantidad de Compras sin rendir
-- Si llego a 10 entonces se Inhabilita al Usuario y se Pausan su Publicaciones
/*--------------------------------------------------------------------------*/
CREATE TRIGGER J2LA.validarComprasSinRendir 
ON J2LA.Compras
AFTER INSERT
AS
BEGIN
	DECLARE @pub_usu_Id int
	DECLARE @cantComprasSinRendir int
	DECLARE @comp_pub_Codigo int
	SET @comp_pub_Codigo = (SELECT comp_pub_Codigo FROM inserted)
	SET @pub_usu_Id = (
		SELECT pub_usu_Id 
		FROM J2LA.Publicaciones 
		WHERE pub_Codigo = @comp_pub_Codigo)
	
	SET @cantComprasSinRendir = (
		SELECT COUNT(*)	
		FROM 
			J2LA.Compras C
			, J2LA.Publicaciones P
		WHERE
			C.comp_pub_Codigo = P.pub_Codigo
		AND
			P.pub_usu_Id = @pub_usu_Id
		AND 
			C.comp_Facturada = 0
		)
	
	
	IF (@cantComprasSinRendir >= 10)
	BEGIN
		UPDATE J2LA.Publicaciones
		SET	pub_estado_Id = 3 /* Pausada */
		WHERE pub_usu_Id = @pub_usu_Id
		
		UPDATE J2LA.Usuarios
		SET	
			usu_Inhabilitado = 1
			, usu_Motivo = 'Debe rendir 10 o más Compras pendientes'
		WHERE 
			usu_Id = @pub_usu_Id
	END
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene el Maximo valor ofrecido a una Publicacion
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.getPrecioMax(@pub_Codigo numeric(18,0))
RETURNS numeric(18,2)
AS
BEGIN
	DECLARE @precio_max numeric(18,2)
	SET @precio_max = 
			(CASE 
			WHEN (SELECT COUNT(*) FROM J2LA.Ofertas WHERE @pub_Codigo = ofer_pub_Codigo) > 0 
            THEN (SELECT MAX(ofer_Monto) FROM J2LA.Ofertas WHERE @pub_Codigo = ofer_pub_Codigo)
            ELSE (SELECT P.pub_precio FROM J2LA.Publicaciones P WHERE P.pub_Codigo = @pub_Codigo) END)
	
	RETURN @precio_max
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de una Oferta
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.setOferta 
	@ofer_Id int,
	@ofer_pub_Codigo numeric(18,0), 
	@ofer_usu_Id int,
	@ofer_Fecha datetime,
	@ofer_Monto numeric(18,2)
AS
BEGIN
	INSERT INTO
		J2LA.Ofertas 
		(ofer_pub_Codigo, ofer_usu_Id, ofer_Fecha, ofer_Monto)
	VALUES
		( @ofer_pub_Codigo, @ofer_usu_Id, @ofer_Fecha, @ofer_Monto)
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene los datos del Usuario Vendedor de una Publicacion
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.getVendedor @idUsuario int
AS

	IF (( SELECT COUNT(*) FROM J2LA.Clientes  WHERE cli_usu_Id = @idUsuario ) > 0 )
	BEGIN
		
		 SELECT
			 [Nombre] = cli_Nombre,
			 [Apellido] = cli_Apellido,
			 [Mail] = cli_Mail, 
			 [Teléfono] = cli_Tel , 
			 [Calle] = cli_Dom_Calle, 
			 [Altura] = cli_Nro_Calle , 
			 [Piso] = cli_Piso, 
			 [Depto] = cli_Dpto, 
			 [Localidad] = cli_Localidad, 
			 [CP] = cli_CP
		 FROM 
			J2LA.Clientes 
		 WHERE 
			cli_usu_Id = @idUsuario
		
	END
	IF ((SELECT COUNT(*) FROM J2LA.Empresas WHERE emp_usu_Id = @idUsuario ) > 0)
	BEGIN
		
		SELECT 
			[Razón Social] = emp_Razon_Social,
			[CUIT] = emp_CUIT,
			[Mail] = emp_Mail,
			[Telefono] = emp_Tel,
			[Calle] = emp_Dom_Calle,
			[Altura] = emp_Nro_Calle,
			[Piso] = emp_Piso,
			[Depto] = emp_Dpto,
			[Localidad] = emp_Localidad,
			[CP] = emp_CP,
			[Ciudad] = emp_Ciudad,
			[Contacto] = emp_Contacto
		FROM 
			J2LA.Empresas 
		WHERE 
			emp_usu_Id = @idUsuario
		
	END

GO

/*--------------------------------------------------------------------------*/
-- SP - Listado de Estadisticas
-- Informa Top 5 de Vendedores Con Mayor Cantidad De Productos No Vendidos
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos(@anio int, @trimestre int, @visibilidad int, @mes int)
AS
	SELECT b.usu_UserName Usuario,c.pubvis_Descripcion Visibilidad,MONTH(a.pub_Fecha_Ini) Mes, SUM(a.pub_Stock) Productos_No_Vendidos
	FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
	WHERE a.pub_usu_Id = b.usu_Id
	AND a.pub_visibilidad_Id = c.pubvis_id
	AND YEAR(a.pub_Fecha_Ini) = @anio
	AND (a.pub_visibilidad_Id = @visibilidad OR @visibilidad=0)
	AND (MONTH(a.pub_Fecha_Ini) = @mes OR @mes=0)
	AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
	AND b.usu_UserName IN (
		SELECT TOP 5 b.usu_UserName Usuario
		FROM J2LA.Publicaciones a, J2LA.Usuarios b, J2LA.Publicaciones_Visibilidades c
		WHERE a.pub_usu_Id = b.usu_Id
		AND a.pub_visibilidad_Id = c.pubvis_id
		AND YEAR(a.pub_Fecha_Ini) = @anio
		AND MONTH(a.pub_Fecha_Ini)>(@trimestre-1)*3 AND MONTH(a.pub_Fecha_Ini)<= @trimestre*3
		GROUP BY b.usu_UserName
		ORDER BY SUM(a.pub_Stock)DESC)
	GROUP BY b.usu_UserName,c.pubvis_Descripcion,MONTH(a.pub_Fecha_Ini)
	ORDER BY MONTH(a.pub_Fecha_Ini),c.pubvis_Descripcion,SUM(a.pub_Stock) DESC
GO

/*--------------------------------------------------------------------------*/
-- SP - Listado de Estadisticas
-- Informa Top 5 de Vendedores Con Mayor Facturacion
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.getTop5VendedoresConMayorFacturacion(@anio int, @trimestre int)
AS
	SELECT TOP 5 a.usu_UserName Usuario, SUM(b.fac_Total) Facturacion
	FROM  J2LA.Usuarios a, J2LA.Facturas b
	WHERE a.usu_Id = b.fac_usu_Id
	AND YEAR(b.fac_Fecha) = @anio
	AND MONTH(b.fac_Fecha)>(@trimestre-1)*3 AND MONTH(b.fac_Fecha)<= @trimestre*3
	GROUP BY a.usu_UserName
	ORDER BY Facturacion DESC
GO

/*--------------------------------------------------------------------------*/
-- VISTA - Listado de Estadisticas
-- Se utiliza para Informar Vendedores Con Mayores Calificaciones
/*--------------------------------------------------------------------------*/
CREATE VIEW J2LA.ViewVendedoresConMayoresCalificaciones(
	Username,
	Anio,
	Reputacion_Trimestre_Primero,
	Reputacion_Trimestre_Segundo,
	Reputacion_Trimestre_Tercero,
	Reputacion_Trimestre_Cuarto)
AS
	SELECT U.usu_UserName,
		   UC.usucal_Anio,
		   (CASE WHEN usucal_Cant_Ventas_Primero=0 THEN NULL ELSE CAST((usucal_Puntos_Primero*1.00/usucal_Cant_Ventas_Primero*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Segundo=0 THEN NULL ELSE CAST((usucal_Puntos_Segundo*1.00/usucal_Cant_Ventas_Segundo*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Tercero=0 THEN NULL ELSE CAST((usucal_Puntos_Tercero*1.00/usucal_Cant_Ventas_Tercero*1.00) AS NUMERIC(18,2)) END),
		   (CASE WHEN usucal_Cant_Ventas_Cuarto=0 THEN NULL ELSE CAST((usucal_Puntos_Cuarto*1.00/usucal_Cant_Ventas_Cuarto*1.00) AS NUMERIC(18,2)) END)
	FROM J2LA.Usuarios_Calificaciones UC, J2LA.Usuarios U
	WHERE UC.usucal_usu_Id = U.usu_Id
GO

/*--------------------------------------------------------------------------*/
-- SP - Listado de Estadisticas
-- Informa Top 5 de Clientes Con Mayor Cantidad De Publicaciones Sin Calificar
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar(@anio int, @trimestre int)
AS
	SELECT TOP 5 Cliente = a.cli_Nombre + ' ' + a.cli_Apellido,
				[Nro. Doc.] = a.cli_Nro_Doc, 
				[Publicaciones Sin Calificar] = COUNT(*)
	FROM J2LA.Clientes a, J2LA.Compras b
	WHERE a.cli_usu_Id = b.comp_usu_Id
	AND b.comp_cal_Codigo IS NULL
	AND YEAR(b.comp_Fecha) = @anio
	AND MONTH(b.comp_Fecha)>(@trimestre-1)*3 AND MONTH(b.comp_Fecha)<= @trimestre*3
	GROUP BY a.cli_Nombre + ' ' + a.cli_Apellido, a.cli_Nro_Doc
	ORDER BY [Publicaciones Sin Calificar] DESC
GO

/*--------------------------------------------------------------------------*/
-- Funcion - Obtiene las Compras pendientes de Calificar para un Usuario
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.getCalificacionesPendientes(@usu_Id int)
RETURNS TABLE
AS
	RETURN(
		SELECT C.comp_Id Codigo, C.comp_Fecha Fecha, U.usu_userName Vendedor, P.pub_Descripcion Descripcion
		FROM J2LA.Compras C, J2LA.Publicaciones P, J2LA.Usuarios U
		WHERE C.comp_pub_Codigo = P.pub_Codigo
		AND P.pub_usu_Id = U.usu_Id
		AND C.comp_usu_Id = @usu_Id
		AND C.comp_cal_Codigo IS NULL)
GO

/*--------------------------------------------------------------------------*/
-- SP - Actualiza la Estadistica de Calificaciones y Ventas por el Usuario
-- agrupadas por Anio y Trimestre
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.ActualizarReputacion
	@usu_UserName nvarchar(255), 
	@comp_Id int, 
	@cal_Cant_Estrellas int
AS
BEGIN
		DECLARE @comp_Fecha DATETIME
		DECLARE @usu_Id int
		
		SET @usu_Id = (SELECT usu_Id FROM J2LA.Usuarios WHERE usu_UserName = @usu_UserName)
		SET @comp_Fecha = (SELECT comp_Fecha FROM J2LA.Compras WHERE comp_Id = @comp_Id)
		
		-- Agrego registro para la Estadistica
		IF (NOT EXISTS (SELECT * FROM J2LA.Usuarios_Calificaciones WHERE usucal_usu_Id = @usu_Id AND usucal_Anio = YEAR(@comp_Fecha)))
		BEGIN
			INSERT INTO J2LA.Usuarios_Calificaciones(usucal_usu_Id,usucal_Anio)
			VALUES (@usu_Id,YEAR(@comp_Fecha))
		END

		IF (MONTH(@comp_Fecha) IN (1,2,3))
			BEGIN
				UPDATE J2LA.Usuarios_Calificaciones
				SET usucal_Puntos_Primero = usucal_Puntos_Primero + @cal_Cant_Estrellas,
				    usucal_Cant_Ventas_Primero = usucal_Cant_Ventas_Primero + 1
				WHERE usucal_usu_Id = @usu_Id
				AND usucal_Anio = YEAR(@comp_Fecha)
			END
			ELSE IF (MONTH(@comp_Fecha) IN (4,5,6))
				BEGIN
					UPDATE J2LA.Usuarios_Calificaciones
					SET usucal_Puntos_Segundo = usucal_Puntos_Segundo + @cal_Cant_Estrellas,
					    usucal_Cant_Ventas_Segundo = usucal_Cant_Ventas_Segundo + 1
					WHERE usucal_usu_Id = @usu_Id
					AND usucal_Anio = YEAR(@comp_Fecha)
				END
				ELSE IF (MONTH(@comp_Fecha) IN (7,8,9))
					BEGIN
						UPDATE J2LA.Usuarios_Calificaciones
						SET usucal_Puntos_Tercero = usucal_Puntos_Tercero + @cal_Cant_Estrellas,
							usucal_Cant_Ventas_Tercero = usucal_Cant_Ventas_Tercero + 1
						WHERE usucal_usu_Id = @usu_Id
						AND usucal_Anio = YEAR(@comp_Fecha)
					END
				ELSE
					BEGIN
						UPDATE J2LA.Usuarios_Calificaciones
						SET usucal_Puntos_Cuarto = usucal_Puntos_Cuarto + @cal_Cant_Estrellas,
				    		usucal_Cant_Ventas_Cuarto = usucal_Cant_Ventas_Cuarto + 1
						WHERE usucal_usu_Id = @usu_Id
						AND usucal_Anio = YEAR(@comp_Fecha)
					END
	END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de una nueva Calificacion
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.CargarCalificacion
	@comp_Id int, 
	@cal_Cant_Estrellas int, 
	@cal_Comentario nvarchar(255)
AS
BEGIN

	DECLARE @cal_Codigo INT
	
	SET @cal_Codigo = (SELECT MAX(cal_Codigo) + 1 FROM J2LA.Calificaciones)
	
	INSERT INTO J2LA.Calificaciones(cal_Codigo,cal_Cant_Estrellas,cal_Comentario)
	VALUES (@cal_Codigo,@cal_Cant_Estrellas,@cal_Comentario)

	UPDATE J2LA.Compras
	SET comp_cal_Codigo = @cal_Codigo
	WHERE comp_Id = @comp_Id
END
GO

/*--------------------------------------------------------------------------*/
-- TRIGGER - Si el usuario acumula mas de 5 compras sin calificar 
-- se lo inhabilita para realizar mas compras.
/*--------------------------------------------------------------------------*/
CREATE TRIGGER J2LA.triggerInhabilitarUsuarioPorNoCalificar
ON J2LA.Compras
FOR INSERT, UPDATE
AS
	BEGIN
		DECLARE @cant_Compras_No_Calificadas INT
		DECLARE @comp_usu_Id INT
		DECLARE @usu_Inhabilitado_Comprar INT
		
		SET @comp_usu_Id = (SELECT comp_usu_Id FROM inserted)		
		SET @cant_Compras_No_Calificadas = (SELECT COUNT(*) FROM J2LA.Compras WHERE comp_cal_Codigo IS NULL AND comp_usu_Id = @comp_usu_Id)
		SET @usu_Inhabilitado_Comprar = (SELECT usu_Inhabilitado_Comprar FROM J2LA.Usuarios WHERE usu_Id = @comp_usu_Id)
		
		IF (@cant_Compras_No_Calificadas > 5)
			BEGIN
				UPDATE J2LA.Usuarios
				SET usu_Inhabilitado_Comprar = 1
				WHERE usu_Id = @comp_usu_Id
			END
		
		
		IF (@usu_Inhabilitado_Comprar = 1 AND @cant_Compras_No_Calificadas <= 5)
			BEGIN
				UPDATE J2LA.Usuarios
				SET usu_Inhabilitado_Comprar = 0
				WHERE usu_Id = @comp_usu_Id
			END
	END
GO
	
/*--------------------------------------------------------------------------*/
-- SP - Alta de Empresa + Usuario + Rol de Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.CargarEmpresa(
	@emp_Razon_Social nvarchar(255),
	@emp_CUIT nvarchar(50),
	@emp_Mail nvarchar(50),
	@emp_Tel nvarchar(50),
	@emp_Dom_Calle nvarchar(255),
	@emp_Nro_Calle numeric(18,0),
	@emp_Piso numeric(18,0),
	@emp_Dpto nvarchar(255),
	@emp_Localidad nvarchar(255),
	@emp_CP nvarchar(50),
	@emp_Ciudad nvarchar(255),
	@emp_Contacto nvarchar(255),
	@emp_Fecha_Creacion datetime,
	@emp_usu_Id int,
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Inhabilitado_Comprar bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit)
AS
	BEGIN
	
		--Nuevo Usuario
		EXECUTE J2LA.setNuevoUsuario @usu_UserName, @usu_Pass, @usu_Primer_Ingreso
	
		--Nueva Empresa
		INSERT INTO J2LA.Empresas(emp_Razon_Social,emp_CUIT,emp_Mail,emp_Tel,
			emp_Dom_Calle,emp_Nro_Calle,emp_Piso,emp_Dpto,emp_Localidad,
			emp_CP,emp_Ciudad,emp_Contacto,emp_Fecha_Creacion,emp_usu_Id)
		VALUES (@emp_Razon_Social,@emp_CUIT,@emp_Mail,@emp_Tel,
			@emp_Dom_Calle,@emp_Nro_Calle,@emp_Piso,@emp_Dpto,@emp_Localidad,
			@emp_CP,@emp_Ciudad,@emp_Contacto,@emp_Fecha_Creacion,
			J2LA.getUserId(@usu_UserName))
		
		--Alta del Rol del Usuario
		INSERT INTO J2LA.Usuarios_Roles (usurol_usu_Id, usurol_rol_Id)
		VALUES (J2LA.getUserId(@usu_UserName), J2LA.getRolId('Empresa'))
	END
GO

/*--------------------------------------------------------------------------*/
-- SP - Modificar de Empresa + Inhabilitar Usuario
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.ActualizarEmpresa(
	@emp_Razon_Social nvarchar(255),
	@emp_CUIT nvarchar(50),
	@emp_Mail nvarchar(50),
	@emp_Tel nvarchar(50),
	@emp_Dom_Calle nvarchar(255),
	@emp_Nro_Calle numeric(18,0),
	@emp_Piso numeric(18,0),
	@emp_Dpto nvarchar(255),
	@emp_Localidad nvarchar(255),
	@emp_CP nvarchar(50),
	@emp_Ciudad nvarchar(255),
	@emp_Contacto nvarchar(255),
	@emp_Fecha_Creacion datetime,
	@emp_usu_Id int,
	@usu_Id int,
	@usu_UserName nvarchar(255), 
	@usu_Pass nvarchar(255), 
	@usu_Cant_Intentos int,
	@usu_Inhabilitado bit,
	@usu_Inhabilitado_Comprar bit,
	@usu_Motivo nvarchar,
	@usu_Eliminado bit,
	@usu_Primer_Ingreso bit)
AS
BEGIN
	UPDATE J2LA.Empresas
	SET
		emp_Razon_Social = @emp_Razon_Social,
		emp_CUIT = @emp_CUIT,
		emp_Mail = @emp_Mail,
		emp_Tel = @emp_Tel,
		emp_Dom_Calle = @emp_Dom_Calle,
		emp_Nro_Calle = @emp_Nro_Calle,
		emp_Piso = @emp_Piso,
		emp_Dpto = @emp_Dpto,
		emp_Localidad = @emp_Localidad,
		emp_CP = @emp_CP,
		emp_Ciudad = @emp_Ciudad,
		emp_Contacto = @emp_Contacto,
		emp_Fecha_Creacion = @emp_Fecha_Creacion
	WHERE emp_usu_Id = @emp_usu_Id
	
	UPDATE J2LA.Usuarios
	SET usu_Inhabilitado = @usu_Inhabilitado,
		usu_Motivo = (Case When @usu_Inhabilitado = 0
					Then ''
					Else 'Inhabilitacion por parte del Administrador'
				End)
	WHERE usu_Id = @usu_Id
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Baja Logica de Usuario por Baja de Empresa
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.BajaEmpresa(@emp_CUIT nvarchar(50))
AS
BEGIN

	DECLARE @emp_usu_Id int
	
	SET @emp_usu_Id = (SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT)
	
	EXEC J2LA.setBajaUsuario @emp_usu_Id
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe un Cuit en Empresas (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeCUIT(@emp_CUIT nvarchar(50))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(E.emp_Cuit) 
		FROM J2LA.Empresas E
		Inner Join J2LA.Usuarios U On
			U.usu_Id = E.emp_usu_Id
			And U.usu_Eliminado = 0
		WHERE E.emp_Cuit = @emp_CUIT) > 0)
		RETURN 1
	RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe una Razon Social en Empresas (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeRazonSocial(@emp_Razon_Social nvarchar(50))
RETURNS BIT
AS
BEGIN
	IF( (SELECT COUNT(E.emp_Razon_Social) 
		FROM J2LA.Empresas E
		Inner Join J2LA.Usuarios U On
			U.usu_Id = E.emp_usu_Id
			And U.usu_Eliminado = 0
		WHERE E.emp_Razon_Social = @emp_Razon_Social) > 0)
		RETURN 1
	RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe otra Empresa con el mismo Cuit (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeOtroCUIT(@emp_CUIT nvarchar(50), @emp_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(E.emp_Cuit) 
		FROM J2LA.Empresas E
		Inner Join J2LA.Usuarios U On
			U.usu_Id = E.emp_usu_Id
			And U.usu_Eliminado = 0
		WHERE E.emp_Cuit = @emp_CUIT) > 0)
		BEGIN
			IF ((SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Cuit = @emp_CUIT) = @emp_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Valida si existe otra Empresa con la misma 
-- Razon social (True= 1 || False=0)
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.existeOtraRazonSocial(@emp_Razon_Social nvarchar(255), @emp_usu_Id int)
RETURNS BIT
AS
BEGIN
	IF ((SELECT COUNT(E.emp_Razon_Social) 
		FROM J2LA.Empresas E
		Inner Join J2LA.Usuarios U On
			U.usu_Id = E.emp_usu_Id
			And U.usu_Eliminado = 0
		WHERE E.emp_Razon_Social = @emp_Razon_Social) > 0)
		BEGIN
			IF ((SELECT emp_usu_Id FROM J2LA.Empresas WHERE emp_Razon_Social = @emp_Razon_Social) = @emp_usu_Id)
				RETURN 0
			ELSE
				RETURN 1
		END

		RETURN 0
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de Publicaciones + Alta Historial para Bonificaciones
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Modificacion de Publicaciones
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Elimina los Rubros asociados a una Publicacion
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.Publicaciones_Delete_Rubros
	@pub_Codigo numeric(18,0)
AS
BEGIN

	DELETE FROM J2LA.Publicaciones_Rubros
	WHERE pubrub_pub_Codigo = @pub_Codigo
		
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Alta de los Rubros asociados a una Publicacion
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- Funcion - Obtiene los Rubros asociados a una Publicacion como una cadena
/*--------------------------------------------------------------------------*/
CREATE FUNCTION J2LA.ObtenerRubrosPubli(@pub_Codigo numeric(18,0))
	RETURNS VARCHAR(7000)
AS
BEGIN

DECLARE @Rubros VARCHAR(7000)
SET @Rubros = ''

	SELECT @Rubros = (CASE WHEN @Rubros = '' THEN @Rubros + R.rub_Descripcion
					   ELSE @Rubros + ' - ' + R.rub_Descripcion END)
	FROM J2LA.Publicaciones_Rubros PR
	INNER JOIN J2LA.Rubros R On R.rub_id = PR.pubrub_rub_Id
	WHERE PR.pubrub_pub_Codigo = @pub_Codigo

	RETURN @Rubros

END
GO

/*--------------------------------------------------------------------------*/
-- Funcion - Obtiene la Cantidad de Publicaciones Gratuitas Activas de un Usuario
-- sin contar la publicacion actual (puede ser cero para alta de publicaciones)
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- Funcion - Devuelve el valor del campo usu_Inhabilitado de un Usuario
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Alta de Roles
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Alta de Funcionalidades Por Rol
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- Funcion - Obtiene las Funcionalidades asociadas a un Rol
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Modificacion de Roles. 
-- Si se Inhabilita un Rol, se elimina la relacion de los usuarios asociados
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Elimina todas las funcionalidades asociadas a un Rol
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.Roles_Delete_Funcionalidades
	@rol_Id int
AS
BEGIN

	DELETE FROM J2LA.Roles_Funcionalidades
	WHERE rolfun_rol_Id = @rol_Id
	
END
GO

/*--------------------------------------------------------------------------*/
-- SP - Baja Logica de Roles + Elminacion de la Relacion de las 
-- funcionalidades y usuarios asociados
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Alta de una Visibilidad
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Modificacion de una Visibilidad
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Baja Logica de una Visibilidad
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.Publicaciones_Visibilidades_BajaLogica
	@pubvis_id Int
AS
BEGIN

	UPDATE J2LA.Publicaciones_Visibilidades 
	SET	[pubvis_Eliminado] = 1
	WHERE pubvis_id = @pubvis_id

END
GO

/*--------------------------------------------------------------------------*/
-- SP - Modificacion de la Contraseña de un usuario
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- SP - Alta de Facturas
/*--------------------------------------------------------------------------*/
CREATE PROCEDURE J2LA.Facturas_Insert
	@fac_Numero numeric(18,0) OUTPUT,
	@fac_usu_Id int,
	@fac_Fecha datetime,
	@fac_Total numeric(18,2),
	@fac_fdp_Id int,
	@fac_Forma_Pago_Desc nvarchar(255),
	@fac_usu_Id_gen int
AS
BEGIN

	SELECT @fac_Numero = MAX(fac_Numero) + 1 FROM J2LA.Facturas

	INSERT INTO J2LA.Facturas
		([fac_Numero],[fac_usu_Id],[fac_Fecha],[fac_Total], [fac_fdp_Id], 
			[fac_Forma_Pago_Desc],[fac_usu_Id_gen])
	VALUES(@fac_Numero, @fac_usu_Id, @fac_Fecha, @fac_Total, @fac_fdp_Id,
		@fac_Forma_Pago_Desc, @fac_usu_Id_gen)
		
END
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

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene los Publicaciones y Compras NO Facturadas
/*--------------------------------------------------------------------------*/
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
		[Cantidad] = 1, --Siempre es uno porque es el valor por una Publicacion
		[Importe] = P.pub_vis_Precio,
		P.pub_visibilidad_Id,
		[FechaDte] = P.pub_Fecha_Ini
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
		[Cantidad] = C.comp_Cantidad,
		[Importe] = C.comp_Comision,
		P.pub_visibilidad_Id,
		[FechaDte] = C.comp_Fecha
From J2LA.Compras C
Inner Join J2LA.Publicaciones P On P.pub_Codigo = C.comp_pub_Codigo
Inner Join J2LA.Usuarios U On U.usu_Id = C.comp_usu_Id
Where P.pub_usu_Id = @usu_id
AND C.comp_Facturada = 0
)
GO

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene los datos de la Oferta Ganadora
/*--------------------------------------------------------------------------*/
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

/*--------------------------------------------------------------------------*/
-- FUNCION - Obtiene el Historico para Bonificacion
/*--------------------------------------------------------------------------*/
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

/********************************* FIN DEL SCRIPT *********************************/
/**********************************************************************************/