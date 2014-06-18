using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce
{
    /// <summary>
    /// Esta Clase hace de Interfaz con la Bas de Datos SQL SERVER 
    /// para Centralizar todas las Funciones que Obtienen o Modifican Datos de la BD.
    /// </summary>
    public static class InterfazBD
    {
        #region Tablas Completas del Sistema

        /// <summary>
        /// Trae todos los tipos de documento del Sistema
        /// </summary>
        public static DataTable getTiposDoc()
        {
            try
            {
                DataTable usuarioResult = Singleton.conexion.executeQueryTable(@"SELECT * FROM J2LA.TiposDoc", null, null);

                if (usuarioResult.Rows.Count == 0)
                {
                    throw new Exception("No hay registros en tabla TiposDoc!!!");
                }

                return usuarioResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las Funcionalidades del Sistema
        /// </summary>
        public static DataTable getFuncionalidades()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Funcionalidades " +
                                                                "Order By fun_nombre", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los Rubros del Sistema
        /// </summary>
        public static DataTable getRubros()
        {
            try
            {
                String query = "Select rub_id, rub_descripcion " +
                                "From J2LA.Rubros " +
                                "Where rub_Eliminado = 0 " +
                                "Order By rub_Descripcion";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los Tipos de Visibilidades del Sistema que no se hayan Eliminado.
        /// </summary>
        public static DataTable getVisibilidadesPubli()
        {
            try
            {
                String query = "Select * From J2LA.Publicaciones_Visibilidades " +
                                "Where pubvis_Eliminado = 0 " +
                                "Order By pubvis_Descripcion";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene una Tabla con los Años en los que se registran Compras
        /// Se utiliza en los Listados de Estadisticas
        /// </summary>
        public static DataTable getAnios()
        {
            try
            {
                String query = "Select distinct(YEAR(comp_Fecha)) Anio From J2LA.Compras";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene Todos los Estados Posibles para las Publicaciones
        /// </summary>
        public static DataTable getEstadosPubli()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Publicaciones_Estados Order By pubest_Descripcion", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene Todos los Tipos de Publicaciones del Sistema (Compra o Subasta)
        /// </summary>
        public static DataTable getTiposPubli()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Publicaciones_Tipos Order By pubtip_Nombre", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene los Tipos de Formas de Pago de Facturas disponibles en el Sistma
        /// </summary>
        public static DataTable getFormasDePago()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("SELECT * FROM J2LA.FormasDePago Order By fdp_Descripcion", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Estructuras de Tablas

        /// <summary>
        /// Trae un estructura Cliente-Usuario para el ABM de Cliente.
        /// Esta Alta genera un Usuario y un Cliente
        /// </summary>
        public static DataTable getDTClienteUsuario()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Clientes, J2LA.Usuarios Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Publicaciones_Visibilidades
        /// </summary>
        public static DataTable getDTVisibilidades()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Publicaciones_Visibilidades Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Roles
        /// </summary>
        public static DataTable getDTRol()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Roles Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Roles_Funcionalidades
        /// </summary>
        public static DataTable getDTRol_Fun()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Roles_Funcionalidades Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Publicaciones
        /// </summary>
        public static DataTable getDTPubli()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Publicaciones Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Publicaciones_Rubros
        /// </summary>
        public static DataTable getDTRubros()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Publicaciones_Rubros Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae un estructura Empresa-Usuario para el ABM de Empresa.
        /// Esta Alta genera un Usuario y un Cliente
        /// </summary>
        public static DataTable getDTEmpresaUsuario()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Empresas, J2LA.Usuarios Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Preguntas
        /// </summary>
        public static DataTable getDTPregunta()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Preguntas Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Compras
        /// </summary>
        public static DataTable getDTCompra()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Compras Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Ofertas
        /// </summary>
        public static DataTable getDTOferta()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Ofertas Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Facturas
        /// </summary>
        public static DataTable getDTFactEncab()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("SELECT * FROM J2LA.Facturas WHERE 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene la Estructura de la Tabla Facturas_Det
        /// </summary>
        public static DataTable getDTFactDet()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("SELECT * FROM J2LA.Facturas_Det WHERE 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Usuarios

        /// <summary>
        /// Trae un Usuario (sin los datos de los Roles asociados)
        /// </summary>
        public static Usuario getUsuarioSinRoles(String nombre)
        {
            String query = "SELECT * FROM J2LA.Usuarios " +
                            "WHERE usu_username = " + "'" + nombre + "' " +
                            "AND usu_eliminado = 0";
            try
            {

                DataTable usuarioResult = Singleton.conexion.executeQueryTable(query, null, null);

                if (usuarioResult.Rows.Count == 0)
                {
                    throw new Exception("Usuario Inexistente!");
                }

                if ((bool)usuarioResult.Rows[0]["usu_Inhabilitado"])
                {
                    string mensaje = "Usuario Inhabilitado!" + Environment.NewLine +
                                    @"Motivo: " + usuarioResult.Rows[0]["usu_Motivo"];
                    throw new Exception(mensaje);
                }

                Usuario usuario = new Usuario();         
                usuario.id = (int)usuarioResult.Rows[0]["usu_Id"];
                usuario.nombre = (string)usuarioResult.Rows[0]["usu_UserName"];
                usuario.pass = (string)usuarioResult.Rows[0]["usu_Pass"];
                usuario.cantidadIntentos = (int)usuarioResult.Rows[0]["usu_Cant_Intentos"];
                usuario.inhabilitado = (bool)(usuarioResult.Rows[0]["usu_Inhabilitado"]);
                usuario.motivo = (string)usuarioResult.Rows[0]["usu_Motivo"].ToString();
                return usuario;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        /// <summary>
        /// Trae un Usuario (con todos los datos de los Roles asociados)
        /// </summary>
        public static DataTable getUsuarioConRoles(String nombre)
        {
            try
            {
                String query = @"
                SELECT *
                FROM J2LA.Usuarios u
                    ,J2LA.Usuarios_Roles ur
                    ,J2LA.Roles r
                WHERE usu_username = " + "'" + nombre + @" '
                    AND u.usu_Id = ur.usurol_usu_id
                    AND ur.usurol_rol_id = r.rol_Id
                    AND r.rol_eliminado = 0
                    AND r.rol_Inhabilitado = 0
                    AND u.usu_Eliminado = 0";

                DataTable usuarioResult = Singleton.conexion.executeQueryTable(query, null, null);

                if (usuarioResult.Rows.Count == 0)
                {
                    throw new Exception("Usuario Inexistente / Sin Roles Asociados!");
                }

                return usuarioResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Guarda la cantidad de intentos de logins que fallo el Usuario
        /// </summary>
        public static void setCantidadIntentos(Usuario usuario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setCantidadIntentos", null,
                    new String[2, 2] { { "idUsuario", usuario.id.ToString() },
                                        {"cantIntentos", usuario.cantidadIntentos.ToString() }});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valido si UserName ya existe en la tabla Usuarios
        /// </summary>
        public static string existeUsuario(string userName)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeUsuario(@userName)", null,
                                        new String[1, 2] { { "userName", userName } }))
                {
                    throw new Exception("Ya existe un usuario con este nombre. Por Favor, ingrese uno distinto.");
                }

                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valido si es el primer Ingreso del Usuario
        /// </summary>
        public static bool validarPrimerIngreso(Int32 usu_Id)
        {
            try
            {
                return (bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.validarPrimerIngreso(@usu_Id)", null,
                                        new String[1, 2] { { "usu_Id", usu_Id.ToString() } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Setea el primer ingreso en 0
        /// </summary>
        public static void setPrimerIngresoValido(int usu_Id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setPrimerIngresoValido", null,
                       new String[1, 2] { { "usu_Id", usu_Id.ToString() } });

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida si un usuario esta Inhabilitado.
        /// </summary>
        private static bool UsuarioInHabilitado(int usu_id, String usu_username)
        {
            try
            {
                bool result = (bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.UsuarioInHabilitado(@usu_id)", null,
                                        new String[1, 2] { { "usu_id", usu_id.ToString() } });

                if (result)
                    throw new Exception("El usuario '" + usu_username + "' esta Inhabilitado para realizar esta operación.");

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los usuarios del sistema (que no esten eliminados)
        /// Permite Filtrar por UserName
        /// </summary>
        public static object BuscarUsuarios(string usu_userName)
        {
            try
            {
                String query = "Select usu_Id, [Usuario] = usu_UserName, usu_Pass, " +
                                "[Inhabilitado] = (Case When usu_Inhabilitado = 1 Then 'Si' Else 'No' End), " +
                                "[Motivo Inh.] = usu_Motivo " +
                                "From J2LA.Usuarios " +
                                "WHERE usu_Eliminado = 0 " +
                                "And usu_UserName like '%" + usu_userName + "%' " +
                                "Order By usu_UserName";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los datos de un usuario con un UserName especifico
        /// (Solo usuarios no eliminados)
        /// </summary>
        public static DataTable getUsuario(String nombre)
        {
            try
            {
                String query = "SELECT * FROM J2LA.Usuarios " +
                            "WHERE usu_username = " + "'" + nombre + "' " +
                            "AND usu_eliminado = 0";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Modificacion de la Contraseña de un usuario especifico en la BD
        /// </summary>
        public static bool CambiarPassUsuario(int usu_Id, string usu_pass)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Usuario_CambiarPass", null,
                        new String[2, 2] { { "usu_Id", usu_Id.ToString() }, 
                                            { "usu_pass", usu_pass .ToString()} });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Baja Logica de un Usuario desde la Funcionalidad Baja de Usuarios
        /// </summary>
        public static bool setBajaUsuario(int usu_Id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setBajaUsuario", null,
                    new String[1, 2] { { "usu_Id", usu_Id.ToString() } });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtengo los Datos de un Usuario como Vendedor de una Publicacion
        /// </summary>
        public static DataTable getVendedor(int idUsuario)
        {
            try
            {
                string query = "exec J2LA.getVendedor " + idUsuario;
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Roles

        /// <summary>
        /// Trae las funcionalidades asociadas a un Rol especifico
        /// </summary>
        public static DataTable getRoles_Funcionalidades(int rol_Id)
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.getRoles_Funcionalidades(@rol_id)", null,
                            new String[1, 2] { { "rol_Id", rol_Id.ToString() } });
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene el Nombre de un Rol especifico
        /// </summary>
        public static string getRolNombre(int rol_Id)
        {
            try
            {
                String query = "Select rol_Nombre From J2LA.Roles " +
                                "Where rol_Id = " + rol_Id;

                Console.Write(Singleton.conexion.executeQueryTable(query, null, null).Rows[0].ToString());

                return Singleton.conexion.executeQueryTable(query, null, null).Rows[0]["rol_Nombre"].ToString();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Valida si ya existe un Rol con un Nombre especifico en la Base 
        /// </summary>
        public static bool ExisteNombreRol(string rol_nombre)
        {
            bool existe_rol;

            string query = "SELECT rol_id FROM J2LA.Roles WHERE rol_nombre = '" + rol_nombre + "'";
            DataTable table_rol = Singleton.conexion.executeQueryTable(query, null, null);

            if (table_rol.Rows.Count > 0)
                existe_rol = true;
            else
                existe_rol = false;

            return existe_rol;
        }

        /// <summary>
        /// Obtiene todos los Roles que no esten Eliminados.
        /// Permite filtrar por el Campo Nombre del Rol.
        /// </summary>
        public static DataTable BuscarRoles(String rol_nombre)
        {
            try
            {
                String query = "Select [Id] = rol_Id, [Nombre] = rol_nombre, " +
                                "[Inhabilitado] = (Case When rol_Inhabilitado = 1 Then 'Si' Else 'No' End) " +
                                "From J2LA.Roles " +
                                "WHERE rol_Eliminado = 0 " +
                                "And rol_nombre like '%" + rol_nombre + "%' " +
                                "Order By rol_nombre";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los Datos de un Rol especifico
        /// </summary>
        public static DataTable getRol(String rol_nombre)
        {
            try
            {
                String query = "Select rol_Id, rol_nombre, rol_Inhabilitado From J2LA.Roles " +
                                "Where UPPER(rol_nombre) = '" + rol_nombre.ToUpper() + "'";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza el Alta de un Rol junto con sus Funcionalidades Asociadas
        /// </summary>
        public static bool NuevoRol(string rol_nombre, DataTable oDtRolFun)
        {
            int rol_Id;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                //Alta de Rol
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Insert", null, new String[2, 2] { { "rol_Id", "0" }, { "rol_nombre", rol_nombre } }, "rol_Id|");

                //Obtenemos el Rol_Id generado pra actualizar el DT de Roles_Funcionalidades
                rol_Id = Convert.ToInt32(cmd.Parameters["@rol_Id"].Value);

                //Actualizamos el valor del campo en todas las filas del DataTable
                oDtRolFun.AsEnumerable().All(c => { c["rolfun_rol_Id"] = rol_Id; return true; });

                //Alta Roles_Funcionalidades
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Insert_Funcionalidades", oDtRolFun, null, "");

                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Se detecto un error al Generar el Rol: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        /// <summary>
        /// Realiza la Modificacion de un Rol junto con sus Funcionalidades Asociadas.
        /// Si el Rol se InHabilita, se elimina la Relacion de los usuario que tenian este Rol.
        /// </summary>
        public static bool ModificarRol(DataTable oDtRol, DataTable oDtRolFun)
        {
            String rol_Id;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                rol_Id = oDtRol.Rows[0]["rol_Id"].ToString();

                //Update Roles - Si se Inhabilita se quitan las asignaciones de Usuarios.-
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Update", oDtRol, null, "");

                //Delete Roles_Funcionalidades - Las Borra todas.
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Delete_Funcionalidades", null, new String[1, 2] { { "rol_Id", rol_Id } }, "");

                //Insert Roles_Funcionalidades - Inserta todas las que configuro el usuario.
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Insert_Funcionalidades", oDtRolFun, null, "");

                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Se detecto un error al Modificar el Rol : " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        /// <summary>
        /// Realiza la Baja Logica de un Rol.
        /// Elimina la Relacion de los usuario que tenian este Rol.
        /// Elimina la Relacion de las Funcionalidades Asociadas.
        /// </summary>
        public static bool RealizarBajaRol(int rol_id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Roles_BajaLogica", null,
                    new String[1, 2] { { "rol_Id", rol_id.ToString() } });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Clientes

        /// <summary>
        /// Valido si existe un cuil en la tabla Clientes
        /// </summary>
        public static void existeCuil(string cli_cuil, int cli_usu_id)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeCuil(@cli_cuil, @cli_usu_id)", null,
                                        new String[2, 2] { { "cli_cuil", cli_cuil.ToString() },
                                                            {"cli_usu_id", cli_usu_id.ToString()} }))
                {
                    throw new Exception("Ya existe un cliente con este CUIL.");
                }

                return;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valido si existe un teléfono en la tabla Clientes
        /// </summary>
        public static string existeTelefono(String cli_tel)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeTelefono(@cli_tel)", null,
                                        new String[1, 2] { { "cli_tel", cli_tel.ToString() } }))
                {
                    throw new Exception("Ya existe un cliente con este Teléfono.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valido si existe un Tipo + Numero de Documento en la tabla Clientes
        /// </summary>
        public static string existeDni(int cli_Tipodoc_id, string cli_Nro_doc)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeDni(@cli_Tipodoc_id, @cli_Nro_doc)", null,
                                        new String[2, 2] { { "cli_Tipodoc_id", cli_Tipodoc_id.ToString() }, 
                                                           { "cli_Nro_doc", cli_Nro_doc } }))
                {
                    throw new Exception("Ya existe un cliente con este Dni.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de un Cliente con un Tipo + Numero de Documento diferente al de un Cliente especifico.
        /// </summary>
        public static string existeOtroDni(int cli_Tipodoc_Id, string cli_Nro_Doc, int cli_usu_Id)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeOtroDni(@cli_Tipodoc_Id,@cli_Nro_Doc,@cli_usu_Id)", null,
                                        new String[3, 2] { 
                                            { "cli_Tipodoc_Id", cli_Tipodoc_Id.ToString() }
                                            , { "cli_Nro_Doc", cli_Nro_Doc }
                                            , { "cli_usu_Id", cli_usu_Id.ToString() }
                                            }))
                {
                    throw new Exception("Ya existe un Cliente con este DNI.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de un Cliente con un Teléfono diferente al de un Cliente especifico.
        /// </summary>
        public static string existeOtroTelefono(string cli_Tel, int cli_usu_Id)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeOtroTelefono(@cli_Tel, @cli_usu_Id)", null,
                                        new String[2, 2] { 
                                            { "cli_Tel", cli_Tel.ToString() }
                                            , { "cli_usu_Id", cli_usu_Id.ToString() }
                                            }))
                {
                    throw new Exception("Ya existe un Cliente con este Teléfono.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Genera el Alata de un nuevo Cliente en la Base (Tambien crea y asigna un Usuario)
        /// </summary>
        public static void setNuevoCliente(DataTable clienteUsuario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setNuevoCliente", clienteUsuario, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae todos los datos de un Cliente, incluyendo los datos de Usuario
        /// Siempre y cuando el usuario no haya sido Eliminado.
        /// </summary>
        public static DataTable getClienteUsuario(int cli_Tipodoc_Id, string cli_Nro_Doc)
        {
            try
            {
                String query = @"SELECT * 
                                FROM 
                                    J2LA.Clientes C
                                    , J2LA.Usuarios U 
                                WHERE C.cli_usu_Id = U.usu_Id 
                                AND C.cli_Tipodoc_Id = " + cli_Tipodoc_Id + @"
                                AND C.cli_Nro_Doc = " + cli_Nro_Doc + @"
                                AND U.usu_Eliminado = 0";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Realiza la Baja Logica de un Cliente-Usuario desde Baja de Clientes
        /// </summary>
        public static bool setBajaCliente(int cli_Tipodoc_Id, string cli_Nro_Doc)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setBajaCliente", null, new String[2, 2] { 
                                                    { "cli_Tipodoc_Id", cli_Tipodoc_Id.ToString() }
                                                    ,{ "cli_Nro_Doc", cli_Nro_Doc }
                                                    });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtengo todos los Clientes del Sistema que no se hayan eliminado con un filtro dinamico
        /// </summary>
        public static DataTable BuscarClientes(String filtros)
        {
            try
            {
                String query = @"
                    SELECT 
                        C.cli_Nombre
                        , C.cli_Apellido 
                        , T.tipodoc_Descripcion
                        , C.cli_Tipodoc_Id
                        , C.cli_Nro_Doc
                        , C.cli_Mail 
                    FROM 
                        J2LA.Clientes C
                        , J2LA.TiposDoc T
                        , J2LA.Usuarios U" +
                    filtros + @" 
                    AND C.cli_Tipodoc_Id = T.tipodoc_Id
                    ORDER BY 
                        C.cli_Tipodoc_Id 
                        , C.cli_Nro_Doc 
                        ASC";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Modificacion de un Cliente
        /// </summary>
        public static void actualizarCliente(DataTable oDtClienteUsuario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.actualizarCliente", oDtClienteUsuario, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Empresas

        /// <summary>
        /// Obtengo todas las Empresas del Sistema que no se hayan eliminado con un filtro dinamico
        /// </summary>
        public static DataTable BuscarEmpresas(String filtros)
        {
            try
            {
                String query = @"
                    SELECT 
                        E.emp_CUIT
                        , E.emp_Razon_Social 
                        , E.emp_Mail
                    FROM 
                        J2LA.Empresas E
                        , J2LA.Usuarios U " +
                    filtros + @" 
                    ORDER BY E.emp_CUIT ASC";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae todos los datos de una Empresa, incluyendo los datos de Usuario
        /// Siempre y cuando el usuario no haya sido Eliminado.
        /// </summary>
        public static DataTable getEmpresaUsuario(string emp_CUIT)
        {
            try
            {
                String query = @"SELECT * 
                                FROM 
                                    J2LA.Empresas E
                                    , J2LA.Usuarios U 
                                WHERE E.emp_usu_Id = U.usu_Id 
                                AND E.emp_CUIT = '" + emp_CUIT + "'" + @"
                                AND U.usu_Eliminado = 0";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Genera el Alata de una nueva Empresa en la Base (Tambien crea y asigna un Usuario)
        /// </summary>
        public static void CargarEmpresa(DataTable oDtEmpresaUsuario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.CargarEmpresa", oDtEmpresaUsuario, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Modificacion de una Empresa
        /// </summary>
        public static void ActualizarEmpresa(DataTable oDtEmpresaUsuario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.ActualizarEmpresa", oDtEmpresaUsuario, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Baja Logica de una Empresa-Usuario desde Baja de Empresas
        /// </summary>
        public static bool RealizarBajaEmpresa(string emp_CUIT)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.BajaEmpresa", null,
                    new String[1, 2] { { "emp_CUIT", emp_CUIT } });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de una Empresa con un Cuit especifico en la BD
        /// </summary>
        public static string existeCUIT(string emp_CUIT)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeCUIT(@emp_Cuit)", null,
                                        new String[1, 2] { { "emp_CUIT", emp_CUIT.ToString() } }))
                {
                    throw new Exception("Ya existe una Empresa con este CUIT.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de una Empresa con una Razon Social especifica en la BD
        /// </summary>
        public static string existeRazonSocial(string emp_Razon_Social)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeCUIT(@emp_Razon_Social)", null,
                                        new String[1, 2] { { "emp_Razon_Social", emp_Razon_Social.ToString() } }))
                {
                    throw new Exception("Ya existe una Empresa con esta Razon Social.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de una Empresa con un Cuit diferente al de una Empresa especifica en la BD
        /// </summary>
        public static string existeOtroCUIT(string emp_CUIT, int emp_usu_Id)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeOtroCUIT(@emp_Cuit,@emp_usu_Id)", null,
                                        new String[2, 2] { { "emp_CUIT", emp_CUIT.ToString() }, 
                                                            { "emp_usu_Id", emp_usu_Id.ToString() } }))
                {
                    throw new Exception("Ya existe una Empresa con este CUIT.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Valida la existencia de una Empresa con una Razon Social diferente al de una Empresa especifica en la BD
        /// </summary>
        public static string existeOtraRazonSocial(string emp_Razon_Social, int emp_usu_Id)
        {
            try
            {
                if ((bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeOtraRazonSocial(@emp_Razon_Social,@emp_usu_Id)", null,
                                        new String[2, 2] { { "emp_Razon_Social", emp_Razon_Social.ToString() }, 
                                                            { "emp_usu_Id", emp_usu_Id.ToString() } }))
                {
                    throw new Exception("Ya existe una Empresa con esta Razon Social.");
                }
                return "";
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Visibilidades

        /// <summary>
        /// Genera el Alta de una Visibilidad en el Sistema
        /// </summary>
        public static bool NuevaVisibilidad(DataTable oDtVisib)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Publicaciones_Visibilidades_Insert", oDtVisib, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los Datos de una Visibilidad especifica, siempre que no este Eliminada
        /// </summary>
        public static DataTable getVisibilidad(int pubvis_Codigo)
        {
            try
            {
                String query = "Select * From J2LA.Publicaciones_Visibilidades " +
                                "Where pubvis_Eliminado = 0 And pubvis_Codigo = " + pubvis_Codigo.ToString();

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Modificacion de una Visibilidad en el Sistema
        /// </summary>
        public static bool ModificarVisibilidad(DataTable oDtVisib)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Publicaciones_Visibilidades_Update", oDtVisib, null);
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las Visibilidades del sistema (que no esten eliminadas)
        /// Permite filtrar por Codigo y Descripcion
        /// </summary>
        public static object BuscarVisibilidades(string pubvis_Codigo, string pubvis_Descripcion)
        {
            try
            {
                String query = "SELECT [Codigo] = pubvis_Codigo, [Descripcion] = pubvis_Descripcion, " +
                                "[Precio] = pubvis_Precio, [Porcentaje] = pubvis_Porcentaje, " +
                                "[Dias Vto.] = pubvis_Dias_Vto " +
                                "FROM J2LA.Publicaciones_Visibilidades " +
                                "WHERE pubvis_Eliminado = 0 " +
                                "And pubvis_Descripcion like '%" + pubvis_Descripcion + "%' ";

                if (pubvis_Codigo != "")
                    query = query + "AND pubvis_Codigo = 0 ";

                query = query + "Order By pubvis_Descripcion";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza la Baja Logica de una Visibilidad en el Sistema
        /// </summary>
        public static bool RealizarBajaVisibilidad(int pubvis_Id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Publicaciones_Visibilidades_BajaLogica", null,
                    new String[1, 2] { { "pubvis_Id", pubvis_Id.ToString() } });

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Publicaciones

        /// <summary>
        /// Obtiene los Rubros asociados a una Publicacion Existente.
        /// </summary>
        public static DataTable getPublicaciones_Rubros(int pub_codigo)
        {
            try
            {
                String query = "Select PR.*, R.rub_Descripcion " +
                                "From J2LA.Publicaciones_Rubros PR " +
                                "Inner Join J2LA.Rubros R On R.rub_id = PR.pubrub_rub_Id " +
                                "Where pubrub_pub_Codigo = " + pub_codigo;

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todos los datos de una Publicacion especifica.
        /// </summary>
        public static DataTable getPublicacion(int pub_codigo, bool edicion)
        {
            try
            {
                String query = "Select * From J2LA.Publicaciones " +
                                "Where pub_Codigo = " + pub_codigo;

                if (edicion)
                    query = query + " AND pub_usu_Id = " + Singleton.usuario["usu_Id"];

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae una Publicacion especifica con su tipo, su estado y su usuario asociado
        /// </summary>
        public static DataTable getPublicacion_Tipo_Estado_Usuario(int pub_codigo)
        {
            try
            {
                String query =
                    @"SELECT
                        P.pub_Codigo,
                        P.pub_Descripcion,
                        P.pub_Stock,
                        P.pub_Fecha_Vto,
                        P.pub_Fecha_Ini,
                        [Precio] = J2LA.getPrecioMax(P.pub_Codigo),
                        P.pub_Permite_Preg,
                        E.pubest_Descripcion,
                        T.pubtip_Nombre,
                        U.usu_UserName
                     FROM
                        J2LA.Publicaciones P,
                        J2LA.Publicaciones_Tipos T,
                        J2LA.Publicaciones_Estados E,
                        J2LA.Usuarios U
                     WHERE
                        pub_Codigo = " + pub_codigo + @"
                        AND P.pub_usu_Id = U.usu_id
                        AND P.pub_estado_Id = E.pubest_Id
                        AND P.pub_tipo_Id = T.pubtip_Id";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busca todas las Publicaciones mostrando ciertos datos especificos, y 
        /// utilizando un filtro dinamico generado por el usuario que
        /// llama a esta funcion. Se implementa en la Busqueda de Publicaciones para la Edicion.
        /// </summary>
        public static DataTable BuscarPublicaciones(String filtros)
        {
            try
            {
                String query = "Select Distinct [Codigo] = P.pub_Codigo, [Tipo] = T.pubtip_Nombre, " +
                                "[Descripcion] = P.pub_Descripcion, [Stock] = P.pub_Stock, " +
                                "[Fecha Inicial] = Convert(varchar, P.pub_Fecha_Ini, 103), " +
                                "[Fecha Vto.] = Convert(varchar,P.pub_Fecha_Vto, 103), " +
                                "[Precio] = P.pub_Precio, [Visibilidad] = V.pubvis_Descripcion, " +
                                "[Estado] = E.pubest_Descripcion, " +
                                "[Permite Preguntas] = (Case When P.pub_Permite_Preg = 1 Then 'Si' Else 'No' End), " +
                                "Rubros = J2LA.ObtenerRubrosPubli(P.pub_Codigo) " +
                                "From J2LA.Publicaciones P " +
                                "Inner Join J2LA.Publicaciones_Rubros PR On PR.pubrub_pub_Codigo = P.pub_Codigo " +
                                "Inner Join J2LA.Publicaciones_Tipos T On T.pubtip_Id = P.pub_tipo_Id " +
                                "Inner Join J2LA.Publicaciones_Estados E On E.pubest_Id = P.pub_estado_Id " +
                                "Inner Join J2LA.Publicaciones_Visibilidades V On V.pubvis_id = P.pub_visibilidad_Id " +
                                filtros +
                                " Order By pub_codigo desc";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Busqueda especial para Listar en una Grilla Paginada todas las Publicaciones
        /// disponibles para la visualizacion en la Funcionalidad Comprar/Ofertar
        /// </summary>
        public static PaginarGrilla BuscarPublicacionesOrdenadas(String filtros)
        {
            DataSet oDs = new DataSet();
            DataTable oDt = new DataTable();

            String query = "Select Distinct Top 10000 [Codigo] = P.pub_Codigo, [Tipo] = T.pubtip_Nombre, " +
                                "[Descripcion] = P.pub_Descripcion, [Stock] = P.pub_Stock, " +
                                "[Fecha Inicial] = Convert(varchar, P.pub_Fecha_Ini, 103), " +
                                "[Fecha Vto.] = Convert(varchar,P.pub_Fecha_Vto, 103), " +
                                "[Precio] = P.pub_Precio, [Visibilidad] = V.pubvis_Descripcion, " +
                                "[Estado] = E.pubest_Descripcion, " +
                                "[Permite Preguntas] = (Case When P.pub_Permite_Preg = 1 Then 'Si' Else 'No' End), " +
                                "[Publicación Precio] = V.pubvis_Precio " +
                                "From J2LA.Publicaciones P " +
                                "Inner Join J2LA.Publicaciones_Rubros PR On PR.pubrub_pub_Codigo = P.pub_Codigo " +
                                "Inner Join J2LA.Publicaciones_Tipos T On T.pubtip_Id = P.pub_tipo_Id " +
                                "Inner Join J2LA.Publicaciones_Estados E On E.pubest_Id = P.pub_estado_Id " +
                                "Inner Join J2LA.Publicaciones_Visibilidades V On V.pubvis_id = P.pub_visibilidad_Id " +
                                filtros +
                                " Order By V.pubvis_Precio desc";

            SqlDataAdapter o_adpter = Singleton.conexion.executeQueryAdapter(query, ref oDs, ref oDt, "Publicaciones", 0, 50);

            return new PaginarGrilla(o_adpter, oDs, oDt, "Publicaciones", 10);
        }

        /// <summary>
        /// Realiza validaciones antes de Grabar una Publicacion:
        /// 1) Verifica que el usuario no haya sido Inhabilitado
        /// 2) Verifica la cantidad de Publicaciones Gratuitas Activas
        ///     que posee el usuario.
        /// </summary>
        public static void ValidarPublicacion(DataTable oDT)
        {
            try
            {
                //Valido si el usuario fue Inhabilitado
                UsuarioInHabilitado(Convert.ToInt32(Singleton.usuario["usu_id"]), Singleton.usuario["usu_username"].ToString());

                //Valido Publicaciones Activas Gratis Antes de Grabar si es Activa y Gratuita.-
                if ((Convert.ToInt32(oDT.Rows[0]["pub_estado_Id"]) == 1) //Publicacion Activa
                        && (Convert.ToDecimal(oDT.Rows[0]["pub_vis_Precio"]) == Convert.ToDecimal(0))) //Es Gratuita
                {
                    //No puede tener mas de 3 Publicaciones Activas
                    if (getCantPubliGratis(Convert.ToInt32(oDT.Rows[0]["pub_codigo"])) >= 3)
                    {
                        throw new Exception("No puede tener mas de 3 Publicaciones Gratuitas Activas.");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza el Alta de una Publicacion y la relacion con sus Rubros Asociados
        /// </summary>
        public static String NuevaPublicacion(DataTable oDtPubli, DataTable oDTRubros)
        {
            int pub_Codigo;

            SqlTransaction tran = null;

            //Creo una conexion a la BD con el CS del App.Config
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);

            //Creo un comando SQL de tipo SP con la conexion creada
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                //Valido antes de Grabar.
                ValidarPublicacion(oDtPubli);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            try
            {
                conn.Open(); //Abro la Conexion a la BD
                tran = conn.BeginTransaction(); //Creo una Transaccion
                cmd.Transaction = tran; //indico al comando que utilice esta Transaccion

                //Alta de Publicacion - Parametro OutPut(pub_Codigo)
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert", oDtPubli, null, "pub_Codigo|");

                //Obtenemos el pub_Codigo generado pra actualizar el DT de Publicaciones_Rubros
                pub_Codigo = Convert.ToInt32(cmd.Parameters["@pub_Codigo"].Value);

                //Actualizo el valor generador en todas las filas del DataTable
                oDTRubros.AsEnumerable().All(c => { c["pubrub_pub_codigo"] = pub_Codigo; return true; });

                //Alta Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert_Rubros", oDTRubros, null, "");

                //Si llega a esta linea, no hubo errores entonces commiteo la Transaccion
                tran.Commit();

                //Devuelvo un string separado por "|" con el resultado de la Transaccion 
                //y el pub_Codigo generado para Informar en pantalla
                return "true|" + pub_Codigo.ToString();
            }
            catch (Exception ex)
            {
                //Si se produjo un error en la Transaccion realizo un Rollback e Informo
                tran.Rollback();
                throw new Exception("Se detecto un error al Generar la Publicacion: " + ex.Message);
            }
            finally
            {
                //Si finalizo todo bien me aseguro de cerrar la conexion
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        /// <summary>
        /// Realiza la Modificacion de una Publicacion y la relacion con sus Rubros Asociados
        /// </summary>
        public static bool EditarPublicacion(DataTable oDtPubli, DataTable oDtPubRubros)
        {
            String pub_Codigo;

            SqlTransaction tran = null;

            //Creo una conexion a la BD con el CS del App.Config
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);

            //Creo un comando SQL de tipo SP con la conexion creada
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                //Valido antes de Grabar.
                ValidarPublicacion(oDtPubli);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            try
            {
                conn.Open(); //Abro la Conexion a la BD
                tran = conn.BeginTransaction(); //Creo una Transaccion
                cmd.Transaction = tran; //indico al comando que utilice esta Transaccion

                //Obtengo el Codigo de la Publicacion
                pub_Codigo = oDtPubli.Rows[0]["pub_Codigo"].ToString();

                //Update Publicacion
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Update", oDtPubli, null, "");

                //Delete Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Delete_Rubros", null, new String[1, 2] { { "pub_Codigo", pub_Codigo } }, "");

                //Insert Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert_Rubros", oDtPubRubros, null, "");

                //Si es Subasta Finalizada (se vencio) y tiene Ofertas => Grabo una Compra por la Oferta Ganadora
                if ((Convert.ToInt32(oDtPubli.Rows[0]["pub_tipo_Id"]) == 2) //Subasta
                        && (Convert.ToInt32(oDtPubli.Rows[0]["pub_estado_Id"]) == 4)) //Finalizada
                {
                    //Obtengo la Oferta Ganadora.-
                    DataTable oDtOfer = getOfertaGanadora(pub_Codigo);

                    //Si existe una Oferta
                    if (oDtOfer.Rows.Count > 0)
                    {
                        DataTable oDtCompra = getDTCompra(); //Estructura a Grabar (Compra)
                        DataRow oDr = oDtCompra.NewRow();

                        //Calculo la comision por la Compra
                        decimal decComision = decimal.Multiply(decimal.Multiply(
                                                Convert.ToDecimal(oDtPubli.Rows[0]["pub_vis_Porcentaje"]),
                                                Convert.ToDecimal(oDtPubli.Rows[0]["pub_Precio"])),
                                                Convert.ToDecimal(oDtPubli.Rows[0]["pub_Stock"]));

                        //Cargo los Datos de la Compra
                        oDr["comp_Id"] = 0;
                        oDr["comp_pub_Codigo"] = pub_Codigo;
                        oDr["comp_usu_Id"] = oDtOfer.Rows[0]["ofer_usu_Id"]; //Usuario Ganador.
                        oDr["comp_Fecha"] = Singleton.FechaDelSistema; //Fecha de Confirmacion de la Compra
                        oDr["comp_Cantidad"] = oDtPubli.Rows[0]["pub_Stock"]; //Se lleva todo el Lote.
                        oDr["comp_Comision"] = decComision;
                        oDr["comp_cal_Codigo"] = 0;
                        oDr["comp_Facturada"] = false; //Pendiente de Facturacion

                        oDtCompra.Rows.Add(oDr);

                        //Grabo la Compra en el Sistema
                        Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.setCompra", oDtCompra, null, "");
                    }
                }

                //Si llega a esta linea, no hubo errores entonces commiteo la Transaccion
                tran.Commit();

                //Devuelvo el estado de la Transaccion
                return true;
            }
            catch (Exception ex)
            {
                //Si se produjo un error en la Transaccion realizo un Rollback e Informo
                tran.Rollback();
                throw new Exception("Se detecto un error al Modificar la Publicacion: " + ex.Message);
            }
            finally
            {
                //Si finalizo todo bien me aseguro de cerrar la conexion
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        /// <summary>
        /// Obtiene la Cantidad de Publicaciones Gratuitas y Activas del Usuario Logeado.
        /// Permite enviar por parametro el Codigo de la Publicacion que se esta Editando para ser exluida.
        /// </summary>
        public static int getCantPubliGratis(int pub_codigo)
        {
            try
            {
                return (int)Singleton.conexion.executeQueryFuncEscalar("J2LA.CantPubliGratis(@usu_id, @pub_codigo)", null,
                                        new String[2, 2] { { "usu_id", Singleton.usuario["usu_id"].ToString() },
                                                            { "pub_codigo", pub_codigo.ToString() } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Compras

        /// <summary>
        /// Genera el Alta de una Compra
        /// </summary>
        public static void setCompra(DataTable compra)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setCompra", compra, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Ofertas

        /// <summary>
        /// Obtengo la Oferta Ganadora de una Subasta Especifica.
        /// </summary>
        private static DataTable getOfertaGanadora(string pub_Codigo)
        {
            try
            {

                String query = "Select * From J2LA.getOfertaGanadora(@pub_Codigo)";
                return Singleton.conexion.executeQueryTable(query, null,
                    new String[1, 2] { { "pub_Codigo", pub_Codigo } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Genera el Alta de una Oferta
        /// </summary>
        public static void setOferta(DataTable oferta)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setOferta", oferta, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene el Maximo valor Ofertado para una Publicacion Especifica
        /// </summary>
        public static decimal getPrecioMax(int pub_codigo)
        {
            try
            {
                String query = "J2LA.getPrecioMax(@pub_Codigo)";
                return Convert.ToDecimal(Singleton.conexion.executeQueryFuncEscalar(query, null, new String[1, 2] { { "pub_codigo", pub_codigo.ToString() } }));
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        #endregion

        #region Preguntas y Respuestas

        /// <summary>
        /// Genera el Alta de una Pregunta o Respuesta (Tabla Preguntas)
        /// </summary>
        public static void setPreguntaRespuesta(DataTable pregunta)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setPreguntaRespuesta", pregunta, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }

        /// <summary>
        /// Obtiene las Preguntas y Respuestas asociadas a una Publicacion especifica
        /// </summary>
        public static DataTable getPreguntas_Publicacion(int preg_pub_codigo)
        {
            try
            {
                return Singleton.conexion.executeQueryTable(
                    @"Select [Tipo]=(CASE WHEN P.preg_tipo = 'R' THEN 'Respuesta' ELSE 'Pregunta' END), [Comentario]= P.preg_Comentario
                    From J2LA.Preguntas P
                    Where preg_pub_codigo = " + preg_pub_codigo + @" 
                    ORDER BY
                        P.preg_Id, P.preg_tipo
                    ", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las Preguntas sin Responder del Usuario Logueado
        /// </summary>
        public static DataTable getPreguntasSinRta()
        {
            try
            {
                String query = "SELECT [Codigo Publi] = PU.pub_Codigo, [Pregunta] = PR.preg_Comentario, " +
                                "[Fecha] = Convert(varchar, PR.preg_fecha, 103), " +
                                "[Usuario] = U.usu_UserName, " +
                                "[Descripcion Publi] = PU.pub_descripcion, PR.preg_pub_Codigo, PR.preg_Id " +
                                "FROM J2LA.Preguntas PR INNER JOIN J2LA.Publicaciones PU " +
                                    "On PR.preg_pub_Codigo = PU.pub_Codigo " +
                                "INNER JOIN J2LA.Usuarios U On U.usu_Id = PR.preg_usu_Id " +
                                "WHERE PU.pub_usu_Id = " + Singleton.usuario["usu_Id"] + " " +
                                "And Not Exists (Select 1 From J2LA.Preguntas PR1 WHERE PR1.preg_id = PR.preg_Id And PR1.preg_Tipo = 'R')" +
                                "ORDER BY PR.preg_fecha";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las Preguntas con o sin Respuesta que realizo el Usuario Logueado
        /// </summary>
        public static DataTable getPreguntasDelUsuario()
        {
            try
            {
                String query = "Select [Codigo Publi.] = PU.pub_Codigo, [Descripcion] = PU.pub_Descripcion, " +
                                "[Fecha Vto.] = Convert(varchar,PU.pub_Fecha_Vto, 103), " +
                                "[Precio] = PU.pub_Precio, [Stock] = PU.pub_Stock, " +
                                "[Pregunta] = P.preg_Comentario, " +
                                "[Fecha Preg] = Convert(varchar, P.preg_fecha, 103), " +
                                "[Respuesta] = ISNULL(R.preg_Comentario, ''), " +
                                "[Fecha Rta] = ISNULL(Convert(varchar, R.preg_fecha, 103), '') " +
                                "From J2LA.Preguntas P " +
                                "Inner Join J2LA.Publicaciones PU On PU.pub_Codigo = P.preg_pub_Codigo " +
                                "Left Join J2LA.Preguntas R On R.preg_Tipo = 'R' And R.preg_Id = P.preg_Id " +
                                "Where P.preg_usu_Id = " + Singleton.usuario["usu_Id"] +
                                "And P.preg_Tipo = 'P' " +
                                "Order By PU.pub_Codigo, P.preg_Fecha ";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtiene todas las Respuestas que realizo el Usuario Logueado
        /// a las preguntas realizadas por otros usuarios sobre sus Publicaciones
        /// </summary>
        public static DataTable getRespuestasDelUsuario()
        {
            try
            {
                String query = "Select [Codigo Publi.] = PU.pub_Codigo, [Descripcion] = PU.pub_Descripcion, " +
                                "[Fecha Vto.] = Convert(varchar,PU.pub_Fecha_Vto, 103), " +
                                "[Precio] = PU.pub_Precio, [Stock] = PU.pub_Stock, " +
                                "[Usuario] = U.usu_UserName, " +
                                "[Pregunta] = P.preg_Comentario, " +
                                "[Fecha Preg] = Convert(varchar, P.preg_fecha, 103), " +
                                "[Respuesta] = ISNULL(R.preg_Comentario, ''), " +
                                "[Fecha Rta] = ISNULL(Convert(varchar, R.preg_fecha, 103), '') " +
                                "From J2LA.Preguntas P " +
                                "Inner Join J2LA.Publicaciones PU On PU.pub_Codigo = P.preg_pub_Codigo " +
                                "Inner Join J2LA.Usuarios U On U.usu_Id = P.preg_usu_Id " +
                                "Left Join J2LA.Preguntas R On R.preg_Tipo = 'R' And R.preg_Id = P.preg_Id " +
                                "Where PU.pub_usu_Id = " + Singleton.usuario["usu_Id"] +
                                "And P.preg_Tipo = 'P' " +
                                "Order By PU.pub_Codigo, P.preg_Fecha ";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Calificacion de Usuarios

        /// <summary>
        /// Obtengo las Calificaciones Pendientes del Usuario Logueado
        /// </summary>
        public static DataTable getCalificacionesPendientes()
        {
            try
            {
                string query = "SELECT * FROM J2LA.getCalificacionesPendientes(" + Singleton.usuario["usu_id"] + ")";
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Tras una nueva Calificacion al usuario, Actualizamos el Historial Año/Trimestre del Usuario calificado
        /// </summary>
        public static void ActualizarReputacion(string usu_UserName, int comp_Id, int cal_Cant_Estrellas)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.ActualizarReputacion", null,
                       new String[3, 2] { { "usu_UserName", usu_UserName},
                                        {"comp_Id", comp_Id.ToString()},
                                        {"cal_Cant_Estrellas", cal_Cant_Estrellas.ToString()}});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Alta de una nueva Calificacion en el Sistema
        /// </summary>
        public static void CargarCalificacion(int comp_Id, int cal_Cant_Estrellas, string cal_Comentario)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.CargarCalificacion", null,
                        new String[3, 2] { { "comp_Id", comp_Id.ToString()},
                                            {"cal_Cant_Estrellas", cal_Cant_Estrellas.ToString()},
                                            {"cal_Comentario", cal_Comentario}});
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Facturacion

        /// <summary>
        /// Obtiene todos los Pendientes de Facturar de un Usuario especifico
        /// Pueden ser Costos por Publicar y/o Compras
        /// </summary>
        public static DataTable BuscarPendientesFact(int usu_Id)
        {
            try
            {
                String query = "Select * From J2LA.getPendientesFact(@usu_id) ORDER BY FechaDte";

                return Singleton.conexion.executeQueryTable(query, null,
                            new String[1, 2] { { "usu_Id", usu_Id.ToString() } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Realiza el Alta de una Factura con su Detalle en el Sistema
        /// </summary>
        public static String GenerarFactura(DataTable oDtFactEcab, DataTable oDtFactDet)
        {
            int fac_Numero;

            SqlTransaction tran = null;

            //Creo una conexion a la BD con el CS del App.Config
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);

            //Creo un comando SQL de tipo SP con la conexion creada
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                conn.Open(); //Abro la Conexion a la BD
                tran = conn.BeginTransaction(); //Creo una Transaccion
                cmd.Transaction = tran; //indico al comando que utilice esta Transaccion

                //Alta del Encabezado de Factura - Parametro OutPut(fac_Numero)
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Facturas_Insert", oDtFactEcab, null, "fac_Numero|");

                //Obtenemos el fac_Numero generado pra actualizar el DT de Facturas_Det
                fac_Numero = Convert.ToInt32(cmd.Parameters["@fac_Numero"].Value);

                //Actualizo el valor generado en todas las filas del DataTable
                oDtFactDet.AsEnumerable().All(c => { c["facdet_fac_Numero"] = fac_Numero; return true; });

                //Alta del Detalle de Factura
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Facturas_Insert_Detalle", oDtFactDet, null, "");

                //Si llega a esta linea, no hubo errores entonces commiteo la Transaccion
                tran.Commit();

                //Devuelvo un string separado por "|" con el resultado de la Transaccion 
                //y el fac_Numero generado para Informar en pantalla
                return "true|" + fac_Numero.ToString();
            }
            catch (Exception ex)
            {
                //Si se produjo un error en la Transaccion realizo un Rollback e Informo
                tran.Rollback();
                throw new Exception("Se detecto un error al Generar la Factura: " + ex.Message);
            }
            finally
            {
                //Si finalizo todo bien me aseguro de cerrar la conexion
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        /// <summary>
        /// Obtengo una Tabla de Contadores con el acumulado de Publicaciones Facturadas
        /// agrupadas por Usario y Tipo de Visibilidad de Publicaciones
        /// </summary>
        public static DataTable getCantFactxTipoVis(int usu_Id)
        {
            try
            {
                String query = "SELECT * FROM J2LA.getCantFactxTipoVis(@usu_Id) Order By Visibilidad";
                return Singleton.conexion.executeQueryTable(query, null,
                            new String[1, 2] { { "usu_Id", usu_Id.ToString() } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion

        #region Listados de Estadisticas

        /// <summary>
        /// Listado Estadistico:
        /// Top 5 de Vendedores con Mayor Cantidad de Productos No Vendidos
        /// </summary>
        public static DataTable getTop5VendedoresConMayorCantDeProdNoVendidos(int anio, int trimestre, int visibilidad, int mes)
        {
            try
            {
                string query = "exec J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos " + anio + ", " + trimestre + ", " + visibilidad + ", " + mes;
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Listado Estadistico:
        /// Top 5 de Vendedores Con Mayor Facturacion
        /// </summary>
        public static DataTable getTop5VendedoresConMayorFacturacion(int anio, int trimestre)
        {
            try
            {
                string query = "exec J2LA.getTop5VendedoresConMayorFacturacion " + anio + ", " + trimestre;
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Listado Estadistico:
        /// Top 5 de Vendedores Con Mayores Calificaciones
        /// </summary>
        public static DataTable getTop5VendedoresConMayoresCalificaciones(int anio, int trimestre)
        {
            try
            {
                string string_trimestre = null;

                //Obtengo el trismestr seleccionado para determinar que campos obtener en la Consulta.-
                switch (trimestre)
                {
                    case 1: string_trimestre = "Primero";
                        break;
                    case 2: string_trimestre = "Segundo";
                        break;
                    case 3: string_trimestre = "Tercero";
                        break;
                    case 4: string_trimestre = "Cuarto";
                        break;
                    default: break;
                }

                string query = "SELECT TOP 5 UserName,Reputacion_Trimestre_" + string_trimestre +
                                " FROM J2LA.ViewVendedoresConMayoresCalificaciones WHERE Anio=" + anio +
                                "ORDER BY Reputacion_Trimestre_" + string_trimestre + " DESC";
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        /// <summary>
        /// Listado Estadistico:
        /// Top 5 de Clientes Con Mayor Cant De Publicaciones Sin Calificar
        /// </summary>
        public static DataTable getTop5ClientesConMayorCantDePublicacionesSinCalificar(int anio, int trimestre)
        {
            try
            {
                string query = "exec J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar " + anio + ", " + trimestre;
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

        #endregion

        #region Historiales

        /// <summary>
        /// Obtengo el Historial de Compras del Usuario Logueado
        /// </summary>
        public static DataTable getHistorialCompras()
        {
            try
            {
                String query = "SELECT	[Comprador] = UC.usu_username, [Vendedor] = UV.usu_UserName, [Publicación] = P.pub_descripcion, " +
                    "[Precio] = P.pub_precio, [Fecha] = CO.comp_fecha, " +
                    "[Tipo de Publicacion] = PT.pubtip_nombre, " +
                    "[Calificación] = CA.cal_comentario, [Estrellas] = CA.cal_cant_estrellas, " +
                    "[Realizada/Recibida] = 'Realizada' " +
                    "FROM J2LA.COMPRAS CO " +
                    "Inner Join J2LA.USUARIOS UC on CO.comp_usu_id = UC.usu_id " +
                    "Inner Join J2LA.PUBLICACIONES P on CO.comp_pub_codigo = P.pub_codigo " +
                    "Inner Join J2LA.USUARIOS UV on P.pub_usu_Id = UV.usu_id " +
                    "Inner Join J2LA.PUBLICACIONES_TIPOS PT on P.pub_tipo_id = PT.pubtip_id " +
                    "Left Join J2LA.CALIFICACIONES CA on CO.comp_cal_codigo = CA.cal_codigo " +
                    "WHERE CO.comp_usu_id = " + Singleton.usuario["usu_Id"] +
                    " UNION ALL " +
                    "SELECT	[Comprador] = UC.usu_username, [Vendedor] = UV.usu_UserName, [Publicación] = P.pub_descripcion, " +
                    "[Precio] = P.pub_precio, [Fecha] = CO.comp_fecha, " +
                    "[Tipo de Publicacion] = PT.pubtip_nombre, " +
                    "[Calificación] = CA.cal_comentario, [Estrellas] = CA.cal_cant_estrellas, " +
                    "[Realizada/Recibida] = 'Recibida' " +
                    "FROM J2LA.COMPRAS CO " +
                    "Inner Join J2LA.USUARIOS UC on CO.comp_usu_id = UC.usu_id " +
                    "Inner Join J2LA.PUBLICACIONES P on CO.comp_pub_codigo = P.pub_codigo " +
                    "Inner Join J2LA.USUARIOS UV on P.pub_usu_Id = UV.usu_id " +
                    "Inner Join J2LA.PUBLICACIONES_TIPOS PT on P.pub_tipo_id = PT.pubtip_id " +
                    "Left Join J2LA.CALIFICACIONES CA on CO.comp_cal_codigo = CA.cal_codigo " +
                    "WHERE P.pub_usu_Id = " + Singleton.usuario["usu_Id"];


                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtengo el Historial de Ofertas del Usuario Logueado
        /// </summary>
        public static DataTable getHistorialOfertas()
        {
            try
            { 
                String query = "select [Monto Oferta] = O.ofer_monto, [Publicacion] = P.pub_descripcion, [Fecha] = O.ofer_fecha, " +
                               "[Ganada] = 'Si' from J2LA.OFERTAS O join J2LA.PUBLICACIONES P on O.ofer_pub_codigo = P.pub_codigo " +
                               "where O.ofer_usu_id =  " + Singleton.usuario["usu_Id"] +
                               " and O.ofer_pub_codigo in (select comp_pub_codigo from J2LA.Compras) " +
                               "union " +
                               "select [Monto Oferta] = O.ofer_monto, [Publicacion] = P.pub_descripcion, [Fecha] = O.ofer_fecha, " +
                               "[Ganada] = 'No' from J2LA.OFERTAS O join J2LA.PUBLICACIONES P on O.ofer_pub_codigo = P.pub_codigo " +
                               "where O.ofer_usu_id =  " + Singleton.usuario["usu_Id"] +
                               " and O.ofer_pub_codigo not in (select comp_pub_codigo from J2LA.Compras)";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Obtengo el Historial de Calificaciones del Usuario Logueado
        /// </summary>
        public static DataTable getHistorialCalificaciones()
        {
            try
            {
                String query = "select [COMPRADOR] = (select U.usu_username from J2LA.Usuarios U where U.usu_id = CO.comp_usu_id), [VENDEDOR] = (select U2.usu_username from J2LA.Usuarios U2 where U2.usu_id = P.pub_usu_id), " +
                                "[Publicación] = P.pub_descripcion, [Fecha] = CO.comp_fecha, [Calificación] = CA.cal_comentario, [Estrellas] = CA.cal_cant_estrellas " +
                                "from J2LA.COMPRAS CO join J2LA.PUBLICACIONES P on CO.comp_pub_codigo = P.pub_codigo " +
                                "join J2LA.CALIFICACIONES CA on CO.comp_cal_codigo = CA.cal_codigo " +
                                "where CO.comp_usu_id = " + Singleton.usuario["usu_Id"] + " or P.pub_usu_id = " + Singleton.usuario["usu_Id"];

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #endregion
    }
}