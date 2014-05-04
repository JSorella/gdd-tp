using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using FrbaCommerce.Dominio;


namespace FrbaCommerce.Homes
{
    public class HomeUsuarios
    {
        public HomeUsuarios()
        {

        }

        public Usuario getUsuario(String nombre)
        {
            DataTable usuarioResult = Singleton.conexion.execute_query(
                @"SELECT 
                        *
                    FROM 
                        J2LA.Usuarios u  
                    JOIN
                        J2LA.Usuarios_Roles r
                    ON
                        (u.usu_Id = r.usurol_usu_id)
                    WHERE 
                        usu_UserName = " + "'" + nombre + "'");

            if (usuarioResult.Rows.Count == 0)
            {
                throw new Exception("Usuario Inexistente!");
            }

            Usuario usuario = new Usuario();

            try
            {
                usuario.id = (int) usuarioResult.Rows[0]["usu_Id"];
                usuario.nombre = (string)usuarioResult.Rows[0]["usu_UserName"];
                usuario.pass = (string)usuarioResult.Rows[0]["usu_Pass"];
                usuario.cantidadIntentos = (int)usuarioResult.Rows[0]["usu_Cant_Intentos"];
                usuario.inhabilitado = (bool) (usuarioResult.Rows[0]["usu_Inhabilitado"].ToString() == "1") ? true :  false;
                usuario.motivo = (string)usuarioResult.Rows[0]["usu_Motivo"].ToString();  
            }
            catch (Exception e) //otro error
            {
                throw new Exception("Error en HomeUsuario: " + e.Message);
            }

            return usuario;
        }

        public void setCantidadIntentos(Usuario usuario)
        {
            string query = @"
                UPDATE 
                    J2LA.Usuarios
                SET
                    usu_Cant_Intentos = " + usuario.cantidadIntentos + @"
                WHERE
                    usu_Id=" + usuario.id;

            Singleton.conexion.execute_query_only(query);
        }


    }
}
