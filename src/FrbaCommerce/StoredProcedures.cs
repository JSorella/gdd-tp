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
    /// clase que tiene metodos que hacen de interfaz con los stored procedures que estan en la BD sql server
    /// </summary>
    public static class StoredProcedures
    {
        /// <summary>
        /// Trae un Usuario (sin roles)
        /// </summary>
        public static Usuario getUsuarioSinRoles(String nombre)
        {
            DataTable usuarioResult = Singleton.conexion.execute_query( //TODO: transformar en SP
                    @"SELECT 
                        *
                    FROM 
                        J2LA.Usuarios u  
                    WHERE 
                        usu_username = " + "'" + nombre + @"' 
                    AND
                        usu_eliminado = 0");

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
                usuario.inhabilitado = (bool)(usuarioResult.Rows[0]["usu_Inhabilitado"].ToString() == "1") ? true : false;
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
            DataTable usuarioResult = Singleton.conexion.execute_query( //TODO: transformar en SP
                    @"SELECT 
                        *
                    FROM 
                        J2LA.Usuarios u  
                        ,J2LA.Usuarios_Roles ur
                        ,J2LA.Roles r
                    WHERE 
                        usu_username = " + "'" + nombre + @" '
                    AND
                        u.usu_Id = ur.usurol_usu_id 
                    AND
                        ur.usurol_rol_id = r.rol_Id
                    AND
                        r.rol_eliminado = 0
                    AND
                        r.rol_Inhabilitado = 0");

            if (usuarioResult.Rows.Count == 0)
            {
                throw new Exception("Usuario sin Roles asociados!!!");
            }
            return usuarioResult;
        }

        /// <summary>
        /// Guarda la cantidad de intentos de logins
        /// </summary>
        public static void setCantidadIntentos(Usuario usuario)
        {
            string query = "EXECUTE J2LA.setCantidadIntentos @idUsuario, @cantIntentos";
  
            SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());

            comando.Parameters.AddWithValue("@idUsuario", usuario.id);
            comando.Parameters.AddWithValue("@cantIntentos", usuario.cantidadIntentos);

            Singleton.conexion.execute_query_with_parameters(comando);
        }

        /// <summary>
        /// Trae las funcionalidades de un rol
        /// </summary>
        public static DataTable getFuncionalidadesPorRol(string nombreRol)
        {
            SqlDataAdapter da;
            Console.WriteLine(nombreRol);
            da = new SqlDataAdapter("SELECT * FROM J2LA.getFuncionalidadesPorRol(@nombreRol)", Singleton.conexion.connector());
            da.SelectCommand.Parameters.AddWithValue("@nombreRol", nombreRol);
            var dt = new DataTable();
            da.Fill(dt);

            return dt;
        }

        /// <summary>
        /// Pregunto si existe un username en la tabla Usuario
        /// </summary>
        public static void existeUsuario(string userName)
        {
            SqlCommand comando = new SqlCommand("SELECT J2LA.existeUsuario(@userName)", Singleton.conexion.connector());
            comando.Parameters.AddWithValue("@userName", userName);

            if ((bool)comando.ExecuteScalar())
            {
                throw new Exception("Nombre de usuario ya existe!!!");
            }
            
         }


        

        /// <summary>
        /// Trae todos los tipos de documento
        /// </summary>
        public static DataTable getTiposDoc()
        {
            DataTable usuarioResult = Singleton.conexion.execute_query( //TODO: transformar en SP
                    @"SELECT 
                        *
                    FROM 
                        J2LA.TiposDoc");

            if (usuarioResult.Rows.Count == 0)
            {
                throw new Exception("No hay registros en tabla TiposDoc!!!");
            }
            return usuarioResult;
        }

        /// <summary>
        /// Crea un nuevo Cliente
        /// </summary>
        public static void setNuevoCliente(Cliente cliente)
        {
            string query = @"EXECUTE J2LA.setNuevoCliente 
                                @userName, 
                                @password, 
                                @nombre, 
                                @apellido, 
                                @dni, 
                                @tipoDoc, 
                                @mail, 
                                @telefono, 
                                @nomCalle, 
                                @nroCalle, 
                                @piso, 
                                @depto, 
                                @localidad, 
                                @cp, 
                                @fecnac,
                                @cuil";

            SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());

            Console.WriteLine(cliente.userName);
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

            Singleton.conexion.execute_query_with_parameters(comando);
        }

        public static void insert_Rol(string nombre_rol)
        {
            string query;
            query = "EXECUTE J2LA.insert_Rol '" + nombre_rol + "'";

            Singleton.conexion.execute_query_only(query);
        }

        public static void insert_funcxrol(string nombre_rol, int func_id)
        {
            string query;
            //hallamos Id_Rol
            query = "SELECT rol_id FROM J2LA.Roles WHERE rol_nombre = '" + nombre_rol + "'";
            DataTable table_rol = Singleton.conexion.execute_query(query);
            string rol_id = table_rol.Rows[0].ItemArray[0].ToString();

            query = "EXECUTE J2LA.insert_rolfun " + rol_id + ", " + func_id.ToString();
            Singleton.conexion.execute_query_only(query);

        }

        public static void delete_funcxrol(int rol_id, string func_id)
        {
            string query;
            query = "EXECUTE J2LA.delete_rolfun " + rol_id + ", " + func_id;
            Singleton.conexion.execute_query_only(query);
        }

        public static void update_rol(int rol_id, string rol_nombre, bool rol_estado)
        {
            string query;
            query = "EXECUTE J2LA.update_rol " + rol_id + ", '" + rol_nombre + "', '" + rol_estado + "'";
            Singleton.conexion.execute_query_only(query);
        }

        public static void baja_rol(string rol_nombre, int rol_id) //PONER UN INT FUNCIONA????
        {
            string query;
            query = "EXECUTE J2LA.baja_rol " + rol_id + ", '" + rol_nombre;
            Singleton.conexion.execute_query_only(query);
        }
    }
}


