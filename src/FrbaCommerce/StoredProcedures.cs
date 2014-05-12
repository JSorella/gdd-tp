using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaCommerce.Vistas.Login;

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

        public static void setCantidadIntentos(Usuario usuario)
        {
            string query = "EXECUTE J2LA.setCantidadIntentos @idUsuario, @cantIntentos";
  
            SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());

            comando.Parameters.AddWithValue("@idUsuario", usuario.id);
            comando.Parameters.AddWithValue("@cantIntentos", usuario.cantidadIntentos);

            Singleton.conexion.execute_query_with_parameters(comando);
        }
    }
}


