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
    /// clase que tiene metodos que hacen de interfaz con los objetos de la BD SQL SERVER.-
    /// </summary>
    public static class InterfazBD
    {
        /// <summary>
        /// Trae un Usuario (sin roles)
        /// </summary>
        public static Usuario getUsuarioSinRoles(String nombre)
        {
            String query = "SELECT * FROM J2LA.Usuarios " +
                            "WHERE usu_username = " + "'" + nombre + "' " +
                            "AND usu_eliminado = 0";

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

            try
            {
                usuario.id = (int)usuarioResult.Rows[0]["usu_Id"];
                usuario.nombre = (string)usuarioResult.Rows[0]["usu_UserName"];
                usuario.pass = (string)usuarioResult.Rows[0]["usu_Pass"];
                usuario.cantidadIntentos = (int)usuarioResult.Rows[0]["usu_Cant_Intentos"];
                usuario.inhabilitado = (bool)(usuarioResult.Rows[0]["usu_Inhabilitado"]);
                usuario.motivo = (string)usuarioResult.Rows[0]["usu_Motivo"].ToString();
            }
            catch (Exception e) //otro error
            {
                throw new Exception("Error en SP Usuario: " + e.Message);
            }

            return usuario;
        }

        /// <summary>
        /// Trae un Usuario
        /// </summary>
        public static DataTable getUsuarioConRoles(String nombre)
        {
            try
            {
                String query = @"SELECT *
                                    FROM J2LA.Usuarios u  
                                        ,J2LA.Usuarios_Roles ur
                                        ,J2LA.Roles r
                                    WHERE usu_username = " + "'" + nombre + @" '
                                    AND u.usu_Id = ur.usurol_usu_id 
                                    AND ur.usurol_rol_id = r.rol_Id
                                    AND r.rol_eliminado = 0
                                    AND r.rol_Inhabilitado = 0";

                DataTable usuarioResult = Singleton.conexion.executeQueryTable(query, null, null);

                if (usuarioResult.Rows.Count == 0)
                {
                    throw new Exception("Usuario sin Roles asociados!!!");
                }

                return usuarioResult;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Guarda la cantidad de intentos de logins
        /// </summary>
        public static void setCantidadIntentos(Usuario usuario)
        {
            string query = "EXECUTE J2LA.setCantidadIntentos @idUsuario, @cantIntentos";
            try
            {
                SqlCommand comando = new SqlCommand(query);

                comando.Parameters.AddWithValue("@idUsuario", usuario.id);
                comando.Parameters.AddWithValue("@cantIntentos", usuario.cantidadIntentos);

                Singleton.conexion.executeCommandConn(comando);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae las funcionalidades de un rol
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
        /// Pregunto si existe un username en la tabla Usuario
        /// </summary>
        public static bool existeUsuario(string userName)
        {
            //SqlCommand comando = new SqlCommand("SELECT J2LA.existeUsuario(@userName)", Singleton.conexion.connector());
            //comando.Parameters.AddWithValue("@userName", userName);
            //return (bool)comando.ExecuteScalar();

            try
            {
                return (bool)Singleton.conexion.executeQueryFuncEscalar("J2LA.existeUsuario(@userName)", null,
                                        new String[1, 2] { { "userName", userName } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }            
         }

        /// <summary>
        /// Trae todos los tipos de documento
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
        /// Crea un nuevo Cliente
        /// </summary>
        public static void setNuevoCliente(Cliente cliente)
        {
            //SI ESTA FUNCION RECIBIERA UN DATATABLE DE CLIENTE CON LOS CAMPOS DEL SP SE PODRIA USAR LA FUNCION Singleton.conexion.executeQuerySP("J2LA.setNuevoCliente", oDataTableCli);
            //SI ESTA FUNCION RECIBIERA UN DATATABLE DE CLIENTE CON LOS CAMPOS DEL SP SE PODRIA USAR LA FUNCION Singleton.conexion.executeQuerySP("J2LA.setNuevoCliente", oDataTableCli);
            //SI ESTA FUNCION RECIBIERA UN DATATABLE DE CLIENTE CON LOS CAMPOS DEL SP SE PODRIA USAR LA FUNCION Singleton.conexion.executeQuerySP("J2LA.setNuevoCliente", oDataTableCli);

            string query = @"J2LA.setNuevoCliente";
//                                @userName, 
//                                @password, 
//                                @nombre, 
//                                @apellido, 
//                                @dni, 
//                                @tipoDoc, 
//                                @mail, 
//                                @telefono, 
//                                @nomCalle, 
//                                @nroCalle, 
//                                @piso, 
//                                @depto, 
//                                @localidad, 
//                                @cp, 
//                                @fecnac,
//                                @cuil";

            //SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());

            SqlCommand comando = new SqlCommand(query);
            comando.CommandType = CommandType.StoredProcedure;

            //Console.WriteLine(cliente.userName);
            comando.Parameters.AddWithValue("@userName", cliente.userName);
            comando.Parameters.AddWithValue("@password", cliente.pass);
            comando.Parameters.AddWithValue("@nombre", cliente.nombre);
            comando.Parameters.AddWithValue("@apellido", cliente.apellido);
            comando.Parameters.AddWithValue("@dni", cliente.dni);
            comando.Parameters.AddWithValue("@tipoDoc", cliente.idTipoDoc);
            comando.Parameters.AddWithValue("@mail", cliente.mail);
            comando.Parameters.AddWithValue("@telefono", cliente.telefono);
            comando.Parameters.AddWithValue("@nomCalle", cliente.nomCalle);
            comando.Parameters.AddWithValue("@nroCalle", cliente.nroCalle);
            comando.Parameters.AddWithValue("@piso", cliente.piso);
            comando.Parameters.AddWithValue("@depto", cliente.depto);
            comando.Parameters.AddWithValue("@localidad", cliente.localidad);
            comando.Parameters.AddWithValue("@cp", cliente.cp);
            comando.Parameters.AddWithValue("@fecnac", cliente.fechaNacimiento);
            comando.Parameters.AddWithValue("@cuil", cliente.cuil);

            try
            {
                Singleton.conexion.executeCommandConn(comando);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable getDTCliente()
        {
            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.Clientes Where 1 = 0", null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

                //Delete Roles_Funcionalidades
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Roles_Delete_Funcionalidades", null, new String[1, 2] { { "rol_Id", rol_Id } }, "");

                //Insert Roles_Funcionalidades
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

        public static bool RealizarBajaRol(int rol_id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Roles_BajaLogica", null, new String[1, 2] { { "rol_Id", rol_id.ToString() }});
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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

        public static DataTable getPublicacion(int pub_codigo)
        {
            try
            {
                String query = "Select * From J2LA.Publicaciones " +
                                "Where pub_Codigo = " + pub_codigo;

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Trae una Publicación con su tipo, su estado y su usuario asociado
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
                        P.pub_Precio,
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
                        AND P.pub_usu_Id =  U.usu_id
                        AND P.pub_estado_Id = E.pubest_Id
                        AND P.pub_tipo_Id = T.pubtip_Id";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
                                "Inner Join J2LA.Publicaciones_Tipos   T On T.pubtip_Id = P.pub_tipo_Id " +
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

        public static DataTable BuscarPublicacionesOrdenadasPorPeso(String filtros)
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
                                "Rubros = J2LA.ObtenerRubrosPubli(P.pub_Codigo), " +
                                "[Publicación Precio] = V.pubvis_Precio " +
                                "From J2LA.Publicaciones P " +
                                "Inner Join J2LA.Publicaciones_Rubros PR On PR.pubrub_pub_Codigo = P.pub_Codigo " +
                                "Inner Join J2LA.Publicaciones_Tipos   T On T.pubtip_Id = P.pub_tipo_Id " +
                                "Inner Join J2LA.Publicaciones_Estados E On E.pubest_Id = P.pub_estado_Id " +
                                "Inner Join J2LA.Publicaciones_Visibilidades V On V.pubvis_id = P.pub_visibilidad_Id " +
                                filtros +
                                " Order By V.pubvis_Precio desc";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void ValidarPublicacion(DataTable oDT)
        {
            try
            {
                UsuarioInHabilitado(Convert.ToInt32(Singleton.usuario["usu_id"]), Singleton.usuario["usu_username"].ToString());

                //Valido Publicaciones Activas Gratis Antes de Grabar si es Activa y Gratuita.-
                if ((Convert.ToInt32(oDT.Rows[0]["pub_estado_Id"]) == 1)
                        && (Convert.ToDecimal(oDT.Rows[0]["pub_vis_Precio"]) == Convert.ToDecimal(0)))
                {
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

        public static String NuevaPublicacion(DataTable oDtPubli, DataTable oDTRubros)
        {
            int pub_Codigo;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                ValidarPublicacion(oDtPubli);
            }
            catch (Exception ex)
            {
                
                throw new Exception(ex.Message);
            }

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                //Alta Publicacion
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert", oDtPubli, null, "pub_Codigo|");

                pub_Codigo = Convert.ToInt32(cmd.Parameters["@pub_Codigo"].Value);

                oDTRubros.AsEnumerable().All(c => { c["pubrub_pub_codigo"] = pub_Codigo; return true; });

                //Alta Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert_Rubros", oDTRubros, null, "");

                tran.Commit();

                return "true|" + pub_Codigo.ToString();
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Se detecto un error al Generar la Publicacion: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

        public static bool EditarPublicacion(DataTable oDtPubli, DataTable oDtPubRubros)
        {
            String pub_Codigo;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

            try
            {
                ValidarPublicacion(oDtPubli);
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            try
            {
                conn.Open();
                tran = conn.BeginTransaction();
                cmd.Transaction = tran;

                pub_Codigo = oDtPubli.Rows[0]["pub_Codigo"].ToString();

                //Update Publicacion
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Update", oDtPubli, null, "");

                //Delete Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Delete_Rubros", null, new String[1, 2] { { "pub_Codigo", pub_Codigo } }, "");

                //Insert Publicacion_Rubros
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert_Rubros", oDtPubRubros, null, "");

                tran.Commit();

                return true;
            }
            catch (Exception ex)
            {
                tran.Rollback();
                throw new Exception("Se detecto un error al Modificar la Publicacion: " + ex.Message);
            }
            finally
            {
                if (conn.State != ConnectionState.Closed)
                    conn.Close();

                conn.Dispose();
            }
        }

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

        public static DataTable getTop5VendedoresConMayoresCalificaciones(int anio, int trimestre)
        {
            try
            {
                string string_trimestre = null;
                switch (trimestre) {
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

                string query = "SELECT TOP 5 UserName,Reputacion_Trimestre_"+string_trimestre+
                                " FROM J2LA.ViewVendedoresConMayoresCalificaciones WHERE Anio="+anio+
                                "ORDER BY Reputacion_Trimestre_"+string_trimestre+" DESC";
                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new DataTable();
            }
        }

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

        /// <summary>
        /// Trae DataTable Pregunta
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
        /// Inserta una nueva Pregunta
        /// </summary>
        public static void setPregunta(DataTable pregunta)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.setPregunta", pregunta, null);

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }

        /// <summary>
        /// Trae preguntas asociadas a una publicación
        /// </summary>
        public static DataTable getPreguntas_Publicacion(int preg_pub_codigo)
        {
            try
            {
                return Singleton.conexion.executeQueryTable(
                    @"Select  [Pregunta]= P.preg_Comentario
                    From J2LA.Preguntas P
                    Where preg_pub_codigo = " + preg_pub_codigo, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

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
                                //"Rubros = J2LA.ObtenerRubrosPubli(P.pub_Codigo), " +
                                //Con esta funcion tarda mas, y me parece que si no la usas, no pasa nada
                                "[Publicación Precio] = V.pubvis_Precio " +
                                "From J2LA.Publicaciones P " +
                                "Inner Join J2LA.Publicaciones_Rubros PR On PR.pubrub_pub_Codigo = P.pub_Codigo " +
                                "Inner Join J2LA.Publicaciones_Tipos   T On T.pubtip_Id = P.pub_tipo_Id " +
                                "Inner Join J2LA.Publicaciones_Estados E On E.pubest_Id = P.pub_estado_Id " +
                                "Inner Join J2LA.Publicaciones_Visibilidades V On V.pubvis_id = P.pub_visibilidad_Id " +
                                filtros +
                                " Order By V.pubvis_Precio desc";

            SqlDataAdapter o_adpter = Singleton.conexion.executeQueryAdapter(query, ref oDs, ref oDt, "Publicaciones", 0, 50);

            return new PaginarGrilla(o_adpter, oDs, oDt, "Publicaciones", 50);
        }

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

        public static bool ModificarVisibilidad(DataTable oDtVisib)
        {
            Singleton.conexion.executeQuerySP("J2LA.Publicaciones_Visibilidades_Update", oDtVisib, null);
            return true;
        }

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

        public static bool RealizarBajaVisibilidad(int pubvis_Id)
        {
            try
            {
                Singleton.conexion.executeQuerySP("J2LA.Publicaciones_Visibilidades_BajaLogica", null, new String[1, 2] { { "pubvis_Id", pubvis_Id.ToString() } });
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable getPreguntasSinRta()
        {
            try
            {
                string query = "SELECT [Texto] = PR.preg_Comentario, [Descripcion] = PU.pub_descripcion " +
                                    "FROM J2LA.Preguntas PR INNER JOIN J2LA.Publicaciones PU " +
                                    "On PR.preg_pub_Codigo = PU.pub_Codigo " +
                                    "WHERE PR.preg_usu_Id = " + Singleton.usuario["usu_Id"] + 
                                    " AND (SELECT COUNT(PR1.preg_id) FROM J2LA.Preguntas PR1 WHERE PR1.preg_id = PR.preg_Id) = 1 " +
                                    "ORDER BY PR.preg_Id, PR.preg_Tipo";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static DataTable getRespuestas()
        {
            try
            {
                string query = "SELECT top 20 [Texto] = PR.preg_Comentario, [Descripcion] = PU.pub_descripcion " +
                                    "FROM J2LA.Preguntas PR INNER JOIN J2LA.Publicaciones PU " +
                                    "ON PR.preg_pub_Codigo = PU.pub_Codigo " +
                                    "WHERE PR.preg_usu_Id = " + Singleton.usuario["usu_Id"] + 
                                    " AND (SELECT COUNT(PR1.preg_id) FROM J2LA.Preguntas PR1 WHERE PR1.preg_id = PR.preg_Id) > 1 " +
                                    "ORDER BY PR.preg_Id, PR.preg_Tipo";

                return Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}


