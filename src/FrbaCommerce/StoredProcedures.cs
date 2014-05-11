using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using FrbaCommerce.Dominio;

namespace FrbaCommerce
{
    public static class StoredProcedures
    {
        /*clase que tiene metodos que hacen de interfaz con los stored procedures que estan en la BD sql server*/


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
                        usu_username = " + "'" + nombre + "'");

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
        public static Usuario getUsuarioConRoles(String nombre)
        {
            DataTable usuarioResult = Singleton.conexion.execute_query( //TODO: transformar en SP
                    @"SELECT 
                        *
                    FROM 
                        J2LA.Usuarios u  
                    JOIN
                        J2LA.Usuarios_Roles r
                    ON
                        (u.usu_Id = r.usurol_usu_id)
                    WHERE 
                        usu_username = " + "'" + nombre + "'");

            if (usuarioResult.Rows.Count == 0)
            {
                throw new Exception("Usuario Inexistente!");
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

                foreach (DataRow registro in usuarioResult.Rows)
                {
                    usuario.roles.Add(new Rol((int)registro["usurol_rol_id"]));
                }
            }
            catch (Exception e) //otro error
            {
                throw new Exception("Error en HomeUsuario: " + e.Message);
            }

            return usuario;
        }

        public static void setCantidadIntentos(Usuario usuario)
        {
            string query = "EXECUTE J2LA.setCantidadIntentos '" + usuario.id + "', '"+ usuario.cantidadIntentos + "'";
            Singleton.conexion.execute_query_only(query);
        }
    }
}


