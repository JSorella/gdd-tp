using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

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
                //SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());
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
        public static DataTable getFuncionalidadesPorRol(string nombreRol)
        {
            //SqlDataAdapter da;
            //Console.WriteLine(nombreRol);
            //da = new SqlDataAdapter("SELECT * FROM J2LA.getFuncionalidadesPorRol(@nombreRol)", Singleton.conexion.connector());
            //da.SelectCommand.Parameters.AddWithValue("@nombreRol", nombreRol);
            //var dt = new DataTable();
            //da.Fill(dt);
            //return dt;

            try
            {
                return Singleton.conexion.executeQueryTable("Select * From J2LA.getFuncionalidadesPorRol(@nombreRol)", null, new String[1, 2] { { "nombreRol", nombreRol } });
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

            string query = @"EXECUTE J2LA.setNuevoCliente";
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

        public static bool existe_nombre_rol(string rol_nombre)
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
                String query = "Select * From J2LA.Roles " +
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

        public static void insert_Rol(string nombre_rol)
        {
            try
            {
                //string query = "EXECUTE J2LA.insert_Rol" +nombre_rol + "'";

                // ESTE SP PODRIA TENER UN PARAMETRO OUTPUT PARA EL ID DE ROL, ASI SE LO PASAS A LA FUNCION insert_funcxrol - Ver Generacion Publi
                // ESTE SP PODRIA TENER UN PARAMETRO OUTPUT PARA EL ID DE ROL, ASI SE LO PASAS A LA FUNCION insert_funcxrol - Ver Generacion Publi
                // ESTE SP PODRIA TENER UN PARAMETRO OUTPUT PARA EL ID DE ROL, ASI SE LO PASAS A LA FUNCION insert_funcxrol - Ver Generacion Publi
                // ESTE SP PODRIA TENER UN PARAMETRO OUTPUT PARA EL ID DE ROL, ASI SE LO PASAS A LA FUNCION insert_funcxrol - Ver Generacion Publi
                Singleton.conexion.executeQuerySP("J2LA.insert_Rol", null, new String[1, 2] { { "@nombre_rol", nombre_rol } });
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void insert_funcxrol(string nombre_rol, int func_id)
        {
            try
            {
                // ESTA FUNCION DEBERIA RECIBIR EL ID_ROL Y NO EL NOMBRE. EN CASO DE RECIBIR EL NOMBRE, EL SELECT PARA EL ID DEBERIA HACERLO DENTRO DEL SP DE INSERT Y NO DESDE AFUERA.
                //OTRA OPCION SERIA LA DE IR A BUSCARLO UNA SOLA VEZ Y DESPUES EJECUTAR EL SP DE INSERT CON UNA TABLA UTILIZANDO Singleton.conexion.executeQuerySPMasivo

                // ESTA FUNCION DEBERIA RECIBIR EL ID_ROL Y NO EL NOMBRE. EN CASO DE RECIBIR EL NOMBRE, EL SELECT PARA EL ID DEBERIA HACERLO DENTRO DEL SP DE INSERT Y NO DESDE AFUERA.
                //OTRA OPCION SERIA LA DE IR A BUSCARLO UNA SOLA VEZ Y DESPUES EJECUTAR EL SP DE INSERT CON UNA TABLA UTILIZANDO Singleton.conexion.executeQuerySPMasivo


                string query = "SELECT rol_id FROM J2LA.Roles WHERE rol_nombre = '" + nombre_rol + "'";

                DataTable table_rol = Singleton.conexion.executeQueryTable(query, null, null);

                string rol_id = table_rol.Rows[0].ItemArray[0].ToString();

                query = "EXECUTE J2LA.insert_rolfun " + rol_id + ", " + func_id.ToString();

                Singleton.conexion.executeQueryTable(query, null, null);

                // ESTA FUNCION DEBERIA RECIBIR EL ID_ROL Y NO EL NOMBRE. EN CASO DE RECIBIR EL NOMBRE, EL SELECT PARA EL ID DEBERIA HACERLO DENTRO DEL SP DE INSERT Y NO DESDE AFUERA.
                //OTRA OPCION SERIA LA DE IR A BUSCARLO UNA SOLA VEZ Y DESPUES EJECUTAR EL SP DE INSERT CON UNA TABLA UTILIZANDO Singleton.conexion.executeQuerySPMasivo

                // ESTA FUNCION DEBERIA RECIBIR EL ID_ROL Y NO EL NOMBRE. EN CASO DE RECIBIR EL NOMBRE, EL SELECT PARA EL ID DEBERIA HACERLO DENTRO DEL SP DE INSERT Y NO DESDE AFUERA.
                //OTRA OPCION SERIA LA DE IR A BUSCARLO UNA SOLA VEZ Y DESPUES EJECUTAR EL SP DE INSERT CON UNA TABLA UTILIZANDO Singleton.conexion.executeQuerySPMasivo


            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void delete_funcxrol(int rol_id, string func_id)
        {
            try
            {
                string query = "EXECUTE J2LA.delete_rolfun " + rol_id + ", " + func_id;
                Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void update_rol(int rol_id, string rol_nombre, bool rol_estado)
        {
            try
            {
                //VALIDAR NOMBRE DE PARAMETROS
                //VALIDAR NOMBRE DE PARAMETROS
                //VALIDAR NOMBRE DE PARAMETROS
                String[,] aPram = new String[3, 2] { { "@rol_id", rol_id.ToString() }, { "@rol_nombre", rol_nombre }, { "@rol_estado", rol_estado.ToString() } };
                Singleton.conexion.executeQueryTable("J2LA.update_rol", null, aPram);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void baja_rol(string rol_nombre, int rol_id) 
        {
            try
            {
                //EL SP DE BAJA SOLO DEBERIA TENER COMO PARAMETRO EL ID.-
                //EL SP DE BAJA SOLO DEBERIA TENER COMO PARAMETRO EL ID.-
                //EL SP DE BAJA SOLO DEBERIA TENER COMO PARAMETRO EL ID.-
                //EL SP DE BAJA SOLO DEBERIA TENER COMO PARAMETRO EL ID.-

                string query = "EXECUTE J2LA.baja_rol " + rol_id + ", '" + rol_nombre;
                Singleton.conexion.executeQueryTable(query, null, null);
            }
            catch (Exception)
            {
                
                throw;
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

        public static String NuevaPublicacion(DataTable oDtPubli, DataTable oDTRubros)
        {
            int pub_Codigo;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

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

        public static bool EditarPublicacion(DataTable oDtPubli, DataTable oDTRubros)
        {
            String pub_Codigo;

            SqlTransaction tran = null;
            SqlConnection conn = new SqlConnection(Singleton.ConnectionString);
            SqlCommand cmd = new SqlCommand("", conn);
            cmd.CommandType = CommandType.StoredProcedure;

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
                Singleton.conexion.executeCommandMasivo(ref cmd, "J2LA.Publicaciones_Insert_Rubros", oDTRubros, null, "");

                tran.Commit();

                return true;
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
    }
}


