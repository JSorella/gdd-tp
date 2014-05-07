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
	fun_Nombre varchar(255) NOT NULL,
CONSTRAINT PK_fun_Id PRIMARY KEY (fun_Id))

GO

-- Creamos la Tabla con los Roles para los usuarios (Admin, Cliente y Empresa).-
CREATE TABLE J2LA.Roles (
	rol_Id int IDENTITY (1,1) NOT NULL,
	rol_Nombre varchar(255) NOT NULL,
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
	usu_UserName varchar(255) NOT NULL,
	usu_Pass varchar(255) NOT NULL,
	usu_Cant_Intentos int NOT NULL DEFAULT 0,
	usu_Inhabilitado bit NOT NULL DEFAULT 0,
	usu_Motivo varchar(255) NULL,
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

-- Creamos la Tabla que almacena los Tipos de Documento para Clientes.-
CREATE TABLE J2LA.TiposDoc (
	tipodoc_Id int IDENTITY (1,1) NOT NULL,
	tipodoc_Descripcion varchar(255) NOT NULL,
CONSTRAINT PK_tipodoc_Id PRIMARY KEY (tipodoc_Id))

GO

-- Creamos la Tabla para los Usuarios Clientes.-
CREATE TABLE J2LA.Clientes (
	cli_Nombre varchar(255) NOT NULL,
	cli_Apellido varchar(255) NOT NULL,
	cli_Tipodoc_Id int NOT NULL,
	cli_Nro_Doc numeric(18,0) NOT NULL,
	cli_Mail varchar(255) NULL,
	cli_Tel varchar(50) NULL,
	cli_Dom_Calle varchar(255) NULL,
	cli_Nro_Calle numeric(18,0) NULL,
	cli_Piso numeric(18,0) NULL,
	cli_Dpto varchar(50) NULL,
	cli_Localidad varchar(255) NULL,
	cli_CP varchar(50) NULL,
	cli_Fecha_Nac datetime NULL,
	cli_Cuil varchar(50) NOT NULL,
	cli_usu_Id Int NOT NULL,
CONSTRAINT FK_cli_usu_Id FOREIGN KEY(cli_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_cli_Tipodoc_Id FOREIGN KEY(cli_Tipodoc_Id) REFERENCES J2LA.TiposDoc (tipodoc_Id),
CONSTRAINT PK_cli_Tipo_Numero_Doc PRIMARY KEY (cli_Tipodoc_Id, cli_Nro_Doc))

GO

-- Creamos la Tabla para los Usuarios Empresas.-
CREATE TABLE J2LA.Empresas (
	emp_Razon_Social varchar(255) NOT NULL,
	emp_Cuit varchar(50) NOT NULL,
	emp_Mail varchar(50) NULL,
	emp_Tel varchar(50) NULL,
	emp_Dom_Calle varchar(255) NULL,
	emp_Nro_Calle numeric(18,0) NULL,
	emp_Piso numeric(18,0) NULL,
	emp_Dpto varchar(255) NULL,
	emp_Localidad varchar(255) NULL,
	emp_CP varchar(50) NULL,
	emp_Ciudad varchar(255) NULL,
	emp_Contacto varchar(255) NULL,
	emp_Fecha_Creacion DateTime NULL,
	emp_usu_Id Int NOT NULL,
CONSTRAINT FK_emp_usu_Id FOREIGN KEY(emp_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_emp_Cuit PRIMARY KEY (emp_Cuit))

GO

-- Creamos la Tabla con los Rubros (Categorias) para las Publicaciones.-
CREATE TABLE J2LA.Rubros (
	rub_id int IDENTITY (1,1) NOT NULL,
	rub_Codigo numeric(18,0) NOT NULL,
	rub_Descripcion varchar(255) NOT NULL,
	rub_Eliminado bit NOT NULL,
CONSTRAINT PK_rub_id PRIMARY KEY (rub_Id))

GO

-- Creamos la Tabla con las Visibilidades para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Visibilidades (
	pubvis_id int IDENTITY (1,1) NOT NULL,
	pubvis_Codigo numeric(18,0) NOT NULL,
	pubvis_Descripcion varchar(255) NOT NULL,
	pubvis_Precio numeric(18,2) NOT NULL,
	pubvis_Porcentaje numeric(18,2) NOT NULL,
	pubvis_Dias_Vto numeric(18,0) NOT NULL,
	pubvis_Eliminado bit NOT NULL,
CONSTRAINT PK_pubvis_id PRIMARY KEY (pubvis_id))

GO

-- Creamos la Tabla con los Tipos de Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Tipos (
	pubtip_Id int IDENTITY (1,1) NOT NULL,
	pubtip_Nombre varchar(255) NOT NULL,
CONSTRAINT PK_pubtip_Id PRIMARY KEY (pubtip_Id))

GO

-- Creamos la Tabla con los Estados para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones_Estados (
	pubest_Id int IDENTITY (1,1) NOT NULL,
	pubest_Descripcion varchar(255) NOT NULL,
CONSTRAINT PK_pubest_Id PRIMARY KEY (pubest_Id))

GO

-- Creamos la Tabla para las Publicaciones.-
CREATE TABLE J2LA.Publicaciones (
	pub_Codigo numeric(18,0) NOT NULL,
	pub_Tipo varchar(50) NOT NULL,
	pub_Descripcion varchar(255) NOT NULL,
	pub_Stock numeric(18,0) NOT NULL,
	pub_Fecha_Vto datetime NOT NULL,
	pub_Fecha_Ini datetime NOT NULL,
	pub_Precio numeric(18,2) NOT NULL,
	pub_visibilidad_Id int NOT NULL,
	pub_estado_Id int NOT NULL,
	pub_Permite_Preg bit NOT NULL,
	pub_usu_Id int NOT NULL,
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
	preg_Comentario varchar(255) NOT NULL,
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
	cal_Comentario varchar(255) NOT NULL,
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
CONSTRAINT FK_comp_pub_Codigo FOREIGN KEY(comp_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_comp_usu_Id FOREIGN KEY(comp_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT FK_comp_cal_Codigo FOREIGN KEY(comp_cal_Codigo) REFERENCES J2LA.Calificaciones (cal_Codigo),
CONSTRAINT PK_comp_Id PRIMARY KEY (comp_Id))

GO

-- Creamos la Tabla con la Cabecera de Facturas emitidas.-
CREATE TABLE J2LA.Facturas (
	fac_Numero numeric(18,0) NOT NULL,
	fac_usu_Id int NOT NULL,
	fac_Fecha datetime NOT NULL,
	fac_Total numeric(18,2) NOT NULL,
	fac_Forma_Pago_Desc varchar(255) NOT NULL,
CONSTRAINT FK_fac_usu_Id FOREIGN KEY(fac_usu_Id) REFERENCES J2LA.Usuarios (usu_Id),
CONSTRAINT PK_fac_numero PRIMARY KEY (fac_numero))

GO

-- Creamos la Tabla con el Detalle de las Facturas emitidas.-
CREATE TABLE J2LA.Facturas_Det (
	facdet_fac_Numero numeric(18,0) NOT NULL,
	facdet_pub_Codigo numeric(18,0) NOT NULL,
	facdet_Cantidad numeric(18,0) NOT NULL,
	facdet_Importe numeric(18,2) NOT NULL,
CONSTRAINT FK_facdet_pub_Codigo FOREIGN KEY(facdet_pub_Codigo) REFERENCES J2LA.Publicaciones (pub_Codigo),
CONSTRAINT FK_facdet_fac_Numero FOREIGN KEY(facdet_fac_Numero) REFERENCES J2LA.Facturas (fac_numero))

GO

/************************** INSERCION DE DATOS DE CONFIGURACION **************************/
/****************************************************************************************/

-- Cargamos las Funcionalidades del Sistema.-
Insert Into J2LA.Funcionalidades(fun_nombre)
	Values ('ABM de Rol'), ('Registro de Usuario'), ('ABM de Cliente'), ('ABM de Empresa'), 
	('ABM de visibilidad de publicacion'), ('Generar Publicacion'), ('Editar Publicacion'), 
	('Gestión de Preguntas'), ('Comprar/Ofertar'), ('Historial de Cliente'), 
	('Facturar Publicaciones'), ('Listado Estadístico')
GO

-- Cargamos los Roles del Sistema.-
Insert Into J2LA.Roles 
	Values	('Administrador General', 0, 0),
			('Cliente', 0, 0),
			('Empresa', 0, 0)
GO

/* ==================== Cargamos la relacion Rol<>Funcionalidades ==================== */

Insert Into J2LA.Roles_Funcionalidades
	Select RolId = 1, F.fun_Id
	From J2LA.Funcionalidades F
GO

Insert Into J2LA.Roles_Funcionalidades
	Values (2,6), (2,7), (2,8), (2,9), (2,10)
GO

Insert Into J2LA.Roles_Funcionalidades
	Values (3,6), (3,7), (3,8), (3,9), (3,10)
GO
/* ====================================================================================*/

-- Cargamos los Tipos de Documentos para Clientes.-
Insert Into J2LA.TiposDoc 
	Values ('D.N.I'),('L.C'),('L.E'),('C.U.I.T.')
GO

-- Cargamos los Estados para las Publicaciones.-
Insert Into J2LA.Publicaciones_Estados 
	Values ('Activa'),('Borrador'),('Pausada'),('Finalizada')
GO

-- Cargamos los Tipos para las Publicaciones.-
Insert Into J2LA.Publicaciones_Tipos 
	Values ('Compra Inmediata'),('Subasta')
GO

-- Cargamos los Rubros para las Publicaciones.-
Insert Into J2LA.Rubros(rub_Codigo, rub_Descripcion, rub_Eliminado) 
	Values (1, 'Otros', 0)
GO

-- Cargamos el Usuario admin/w23e para la puesta en marcha del Sistema.-
Insert Into J2LA.Usuarios(usu_username, usu_pass, usu_Cant_Intentos, 
		usu_Inhabilitado, usu_Motivo, usu_Eliminado, usu_Primer_Ingreso)
	Values ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7',
		0, 0, '', 0, 0)
GO

/********************************** MIGRACION DE DATOS **********************************/
/****************************************************************************************/

-- Agregamos 2 Columnas Temporales para Optimizar la Migración.-
Alter Table J2LA.Usuarios Add
	Publ_Cli_Dni numeric(18, 0),
	Publ_Empresa_Cuit varchar(50)
	
GO

-- Asignamos el Rol 'Administrador General' a todos los usuarios administradores.-
Insert Into J2LA.Usuarios_Roles(usurol_usu_Id, usurol_rol_Id)
	Select U.usu_Id, RolId = 1
	From J2LA.Usuarios U
	Where U.Publ_Cli_Dni Is Null
		And U.Publ_Empresa_Cuit Is Null

GO

-- Creamos los usuarios para los Clientes como 'dni'/1234.-
Insert Into J2LA.Usuarios(usu_UserName, usu_Pass, usu_Cant_Intentos, usu_Inhabilitado,
		usu_Motivo, usu_Eliminado, usu_Primer_Ingreso, Publ_Cli_Dni, Publ_Empresa_Cuit)
	Select Distinct 
		UserName = LTRIM(RTRIM(CONVERT(Varchar, Publ_Cli_Dni))),
		Pass = '03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4',
		CantIntentos = 2, Inhabilitado = 0, Motivo = '', Eliminado = 0, Primer_Ingreso = 1,
		M.Publ_Cli_Dni, Cuit_Empre = Null
	From gd_esquema.Maestra M
	Where M.Publ_Cli_Dni Is Not Null

GO

-- Creamos los usuarios para las Empresas como 'cuit'/5678.-
Insert Into J2LA.Usuarios(usu_UserName, usu_Pass, usu_Cant_Intentos, usu_Inhabilitado,
		usu_Motivo, usu_Eliminado, usu_Primer_Ingreso, Publ_Cli_Dni, Publ_Empresa_Cuit)
	Select Distinct 
		UserName = LTRIM(RTRIM(REPLACE(M.Publ_Empresa_Cuit, '-', ''))),
		Pass = 'f8638b979b2f4f793ddb6dbd197e0ee25a7a6ea32b0ae22f5e3c5d119d839e75',
		CantIntentos = 2, Inhabilitado = 0, Motivo = '', Eliminado = 0, 
		Primer_Intento = 1, Dni_Cli = Null, Cuit_Empre = M.Publ_Empresa_Cuit
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
		pubvis_Porcentaje, pubvis_Precio, pubvis_Dias_Vto, pubvis_Eliminado)
	Select Distinct M.Publicacion_Visibilidad_Cod, Publicacion_Visibilidad_Desc, 
		Publicacion_Visibilidad_Porcentaje, Publicacion_Visibilidad_Precio, 
		Dias_Vto = 7, Eliminado = 0 
	From gd_esquema.Maestra M
	
GO

-- Migramos las Publicaciones de la Tabla Maestra actualizando su estado.-
-- Estados: 1 = Activa // 2 = Finalizada
DECLARE @FechaTP DateTime
SET @FechaTP = '20140618' -- Fecha Inicio Nvo Sistema = Fecha 1er Entrega TP.-

Insert Into J2LA.Publicaciones (pub_Codigo,pub_Tipo,pub_Descripcion,pub_Stock,pub_Fecha_Vto,
		pub_Fecha_Ini,pub_Precio,pub_visibilidad_Id,pub_estado_Id,pub_Permite_Preg,pub_usu_Id)
	Select Distinct
		Publicacion_Cod,Publicacion_Tipo,Publicacion_Descripcion,Publicacion_Stock,
		Publicacion_Fecha_Venc,Publicacion_Fecha,Publicacion_Precio,PV.pubvis_id,
		pubest_Id = (Case When (Publicacion_Fecha_Venc < @FechaTP)
					Then 4 Else 1 
				 End),
		Permite_Preguntas = 1,Usuario_Id = U.usu_Id
	From gd_esquema.Maestra M
	Inner Join J2LA.Usuarios U On ISNULL(U.Publ_Cli_Dni, 0) = ISNULL(M.Publ_Cli_Dni,0) 
		AND ISNULL(U.Publ_Empresa_Cuit,'') = ISNULL(M.Publ_Empresa_Cuit,'')
	Inner Join J2LA.Publicaciones_Visibilidades PV On PV.pubvis_Codigo = M.Publicacion_Visibilidad_Cod
	Where M.Publicacion_Cod Is Not Null

GO

-- Migramos los Rubros asignados a cada Publicacion.-
-- Como no tienen un rubro en el sistema anterior, se asigna el Rubro Otros del Nvo Sistema.-
Insert Into J2LA.Publicaciones_Rubros(pubrub_pub_Codigo, pubrub_rub_Id)
	Select pub_Codigo, rubro_id = 1
	From J2LA.Publicaciones
	
GO

-- Migramos las Ofertas realizadas a las Publicaciones.-
Insert Into J2LA.Ofertas (ofer_pub_Codigo, ofer_usu_Id,ofer_Fecha, ofer_Monto)
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
		comp_Fecha, comp_Cantidad, comp_Comision, comp_cal_codigo)
	Select	M.Publicacion_Cod, C.cli_usu_Id,
			M.Compra_Fecha, M.Compra_Cantidad,
			Comision = 0, M.Calificacion_Codigo
	From gd_esquema.Maestra M
	Inner Join J2LA.Clientes C On C.cli_Nro_Doc = M.Cli_Dni
	where M.Compra_Cantidad is not null
		And M.Calificacion_Codigo is not null 
		And M.Factura_Total is null

GO

-- Migramos el Encabezado de las Facuras de la Tabla Maestra.-
Insert Into J2LA.Facturas(fac_Numero, fac_usu_Id,
	fac_Fecha, fac_Total, fac_Forma_Pago_Desc )
Select Distinct M.Factura_Nro, P.pub_usu_id,
	M.Factura_Fecha, M.Factura_Total, M.Forma_Pago_Desc
From gd_esquema.Maestra M
Inner Join J2LA.Publicaciones P On P.pub_codigo = M.Publicacion_Cod
Where M.Factura_Nro is not null

GO

-- Migramos el Detalle de las Facuras de la Tabla Maestra.-
Insert Into J2LA.Facturas_Det(facdet_fac_Numero, 
	facdet_pub_Codigo, facdet_Cantidad, facdet_Importe)
Select M.Factura_Nro, M.Publicacion_Cod,
	M.Item_Factura_Cantidad, M.Item_Factura_Monto
From gd_esquema.Maestra M
Where M.Factura_Nro is not null

GO