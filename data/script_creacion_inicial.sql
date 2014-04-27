--TODO: Migracion de Clientes
--TODO: Migracion de Empresas
--TODO: Migracion de Rubros
--TODO: Migracion de Publicaciones_Visibilidades
--TODO: Migracion de Publicaciones_Tipos
--TODO: Migracion de Publicaciones_Estados
--TODO: Migracion de Publicaciones
--TODO: Migracion de Publicaciones_Rubros
--TODO: Migracion de Preguntas
--TODO: Migracion de Calificaciones
--TODO: Migracion de Ofertas
--TODO: Migracion de Compras
--TODO: Migracion de Facturas
--TODO: Migracion de Facturas_detalles


USE [GD1C2014]
GO 

CREATE SCHEMA J2LA AUTHORIZATION [gd]
GO

/********************************CREACION DE TABLAS********************************/
/**********************************************************************************/

CREATE TABLE J2LA.Funcionalidades(
	func_id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	func_nombre varchar(255)NOT NULL
)
GO

CREATE TABLE J2LA.Roles(
	rol_id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	rol_nombre varchar(255) NOT NULL,
	rol_inhabilitado bit NOT NULL DEFAULT 0
)
GO

CREATE TABLE J2LA.Roles_Funcionalidades(
	rolfun_rol_id int NOT NULL,
	rolfun_func_id int NOT NULL
	PRIMARY KEY (rolfun_rol_id, rolfun_func_id),
	FOREIGN KEY (rolfun_rol_id) REFERENCES J2LA.Roles(rol_id),
	FOREIGN KEY (rolfun_func_id) REFERENCES J2LA.Funcionalidades(func_id)
)
GO

CREATE TABLE J2LA.Usuarios(
	usu_id int IDENTITY (1,1) PRIMARY KEY NOT NULL,
	usu_username varchar(255) UNIQUE NOT NULL,
	usu_pass varchar(255) NOT NULL,
	usu_cant_intentos int NOT NULL DEFAULT 0,
	usu_inhabilitado bit NOT NULL DEFAULT 0,
	usu_motivo varchar(255)
)
GO

CREATE TABLE J2LA.Usuarios_Roles(
	usurol_usu_id int NOT NULL,
	usurol_rol_id int NOT NULL
	PRIMARY KEY (usurol_usu_id, usurol_rol_id),
	FOREIGN KEY (usurol_usu_id) REFERENCES J2LA.Usuarios(usu_id),
	FOREIGN KEY (usurol_rol_id) REFERENCES J2LA.Roles(rol_id)
)
GO

CREATE TABLE J2LA.Tipos_Doc(
	tipodoc_id int PRIMARY KEY NOT NULL,
	tipodoc_descripcion varchar(255) NOT NULL
)
GO

CREATE TABLE J2LA.Clientes(
	cli_nombre varchar(255) NOT NULL,
	cli_apellido varchar(255) NOT NULL,
	cli_tipodoc_id int NOT NULL,
	cli_doc numeric(18,0) NOT NULL,
	cli_mail varchar(255),
	cli_tel varchar(50),
	cli_localidad varchar(255),
	cli_dom_calle varchar(255),
	cli_nro_calle numeric(18,0),
	cli_piso numeric(18,0),
	cli_dpto varchar(50),
	cli_cp varchar(50),
	cli_fecha_nac datetime,
	cli_usu_id int --todos los clientes van a tener usuario
	PRIMARY KEY (cli_tipodoc_id, cli_doc),
	FOREIGN KEY (cli_usu_id) REFERENCES J2LA.Usuarios(usu_id),
	FOREIGN KEY (cli_tipodoc_id) REFERENCES J2LA.Tipos_Doc(tipodoc_id)
)
GO

CREATE TABLE J2LA.Empresas(
	emp_razon_social varchar(255) NOT NULL,
	emp_cuit varchar(50) PRIMARY KEY NOT NULL,
	emp_mail varchar(50),
	emp_tel varchar(50),
	emp_localidad varchar(255),
	emp_calle varchar(255),
	emp_piso numeric(18,0),
	emp_dpto varchar(255),
	emp_cp varchar(50),
	emp_ciudad varchar(255),
	emp_contacto varchar(255),
	emp_fecha_creacion datetime,
	emp_usu_id int
	FOREIGN KEY (emp_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Rubros(
	rubro_id numeric(18,0) PRIMARY KEY NOT NULL,
	rubro_descripcion varchar(255) NOT NULL
)
GO

CREATE TABLE J2LA.Publicaciones_Visibilidades(
	pubvis_id numeric(18,0) PRIMARY KEY NOT NULL,
	pubvis_descripcion varchar(255) NOT NULL,
	pubvis_precio numeric(18,2) NOT NULL,
	pubvis_porcentaje numeric(18,2) NOT NULL
)
GO

CREATE TABLE J2LA.Publicaciones_Tipos(
	pubtipo_id int PRIMARY KEY NOT NULL,
	pubtipo_nombre varchar(255) NOT NULL
)
GO
	
CREATE TABLE J2LA.Publicaciones_Estados(
	pubest_id int PRIMARY KEY NOT NULL,
	pubest_descripcion varchar(255) NOT NULL
)
GO

CREATE TABLE J2LA.Publicaciones(
	pub_id numeric(18,0) PRIMARY KEY NOT NULL,
	pub_descripcion varchar(255) NOT NULL,
	pub_stock numeric(18,0) NOT NULL,
	pub_fecha_vto datetime NOT NULL,
	pub_fecha_ini datetime NOT NULL,
	pub_precio numeric(18,2) NOT NULL,
	pub_visibilidad_id numeric(18,0) NOT NULL,
	pub_usu_id int NOT NULL,
	pub_estado_id int NOT NULL,
	pub_tipo_id int NOT NULL,
	pub_permite_preg bit NOT NULL,
	FOREIGN KEY (pub_visibilidad_id) REFERENCES J2LA.Publicaciones_Visibilidades(pubvis_id),
	FOREIGN KEY (pub_usu_id) REFERENCES J2LA.Usuarios(usu_id),
	FOREIGN KEY (pub_estado_id) REFERENCES J2LA.Publicaciones_Estados(pubest_id),
	FOREIGN KEY (pub_tipo_id) REFERENCES J2LA.Publicaciones_Tipos(pubtipo_id)
)
GO

CREATE TABLE J2LA.Publicaciones_Rubros(
	pubrub_pub_id numeric(18,0) NOT NULL,
	pubrub_rubro_id numeric(18,0) NOT NULL
	PRIMARY KEY (pubrub_pub_id, pubrub_rubro_id),
	FOREIGN KEY (pubrub_pub_id) REFERENCES J2LA.Publicaciones(pub_id),
	FOREIGN KEY (pubrub_rubro_id) REFERENCES J2LA.Rubros(rubro_id)
)
GO

CREATE TABLE J2LA.Preguntas(
	preg_pub_id numeric(18,0) NOT NULL,
	preg_id int NOT NULL,
	preg_tipo char(1) NOT NULL, -- P o R
	preg_comentario varchar(255) NOT NULL,
	preg_usu_id int NOT NULL
	PRIMARY KEY (preg_id, preg_tipo),
	FOREIGN KEY (preg_pub_id) REFERENCES J2LA.Publicaciones(pub_id),
	FOREIGN KEY (preg_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Calificaciones(
	cali_pub_id numeric(18,0) NOT NULL,
	cali_cant_estrellas numeric(18,0) NOT NULL,
	cali_comentario varchar(255),
	cali_usu_id int NOT NULL
	PRIMARY KEY (cali_pub_id, cali_usu_id),
	FOREIGN KEY (cali_pub_id) REFERENCES J2LA.Publicaciones(pub_id),
	FOREIGN KEY (cali_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Ofertas( --PK?
	ofer_pub_id numeric(18,0) NOT NULL,
	ofer_usu_id int NOT NULL,
	ofer_fecha datetime NOT NULL,
	ofer_monto numeric(18,2)  NOT NULL
	FOREIGN KEY (ofer_pub_id) REFERENCES J2LA.Publicaciones(pub_id),
	FOREIGN KEY (ofer_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Compras(
	comp_pub_id numeric(18,0),
	comp_usu_id int NOT NULL,
	comp_fecha datetime NOT NULL,
	comp_cantidad numeric(18,0) NOT NULL,
	comp_comision numeric(18,1) -- Esto es por si tiene que rendir o no comision(Punto7-Pagina10)
	PRIMARY KEY (comp_pub_id, comp_usu_id),
	FOREIGN KEY (comp_pub_id) REFERENCES J2LA.Publicaciones(pub_id),
	FOREIGN KEY (comp_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Facturas(
	fac_numero numeric(18,0) PRIMARY KEY NOT NULL,
	fac_usu_id int NOT NULL,
	fac_fecha datetime NOT NULL,
	fac_total numeric(18,2) NOT NULL,
	fac_forma_pago_desc varchar(255) NOT NULL
	FOREIGN KEY (fac_usu_id) REFERENCES J2LA.Usuarios(usu_id)
)
GO

CREATE TABLE J2LA.Facturas_Detalles(
	facdet_numero numeric(18,0) PRIMARY KEY NOT NULL,
	facdet_item_numero numeric(18,0) NOT NULL,
	facdet_pub_id numeric(18,0) NOT NULL,
	facdet_cantidad numeric(18,0) NOT NULL,
	facdet_importe numeric(18,2) NOT NULL
	FOREIGN KEY (facdet_pub_id) REFERENCES J2LA.Publicaciones(pub_id)
)
GO


/********************************MIGRACIÓN DE DATOS********************************/
/**********************************************************************************/


/*Cargamos las funcionalidades del TP*/
INSERT INTO J2LA.Funcionalidades(func_nombre)
VALUES ('ABM de Rol'), ('Registro de Usuario'), ('ABM de Cliente'), ('ABM de Empresa'), ('ABM de visibilidad de publicacion'), ('Generar Publicacion'), ('Editar Publicacion'), ('Gestión de Preguntas'), ('Comprar/Ofertar'), ('Historial de Cliente'), ('Facturar Publicaciones'), ('Listado Estadístico')
GO

/*Cargamos los roles*/
INSERT INTO J2LA.Roles(rol_nombre)
VALUES ('Administrativo'), ('Empresa'), ('Cliente')
GO

/*Asignamos todas las funcionalidades al rol Administrativo*/
INSERT INTO J2LA.Roles_Funcionalidades(rolfun_rol_id, rolfun_func_id)
VALUES (1,1), (1,2), (1,3), (1,4), (1,5), (1,6), (1,7), (1,8), (1,9), (1,10), (1,11), (1,12)
GO

/*Creamos el usuario admin*/
INSERT INTO J2LA.Usuarios(usu_username, usu_pass)
VALUES ('admin', 'e6b87050bfcb8143fcb8db0170a4dc9ed00d904ddd3e2a4ad1b1e8dc0fdc9be7')
GO

INSERT INTO J2LA.Usuarios_Roles(usurol_usu_id, usurol_rol_id)
VALUES (1,1)
GO

INSERT INTO J2LA.Tipos_Doc(tipodoc_id, tipodoc_descripcion)
VALUES (1, 'DNI')
GO