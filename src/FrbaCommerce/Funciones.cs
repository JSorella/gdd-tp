using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCommerce
{
    /// <summary>
    /// Funciones que no necesitan instanciarse (se usan globalmente).
    /// </summary>
    class Funciones
    {
        Connection connect = new Connection();
        private string query;

        static public string get_hash(string pass_ingresada)
        {
            byte[] pass_hash;
            //convierto pass en un array de bytes para poder usarla en las funciones de encriptacion
            byte[] pass_en_bytes = Encoding.UTF8.GetBytes(pass_ingresada);
            SHA256 shaManag = new SHA256Managed();
            //calculamos valor hash de la contraseña
            pass_hash = shaManag.ComputeHash(pass_en_bytes);

            //convertimos hash en string
            StringBuilder pass_string = new StringBuilder();

            //concatenamos bytes
            for (int i = 0; i < pass_hash.Length; i++)
                pass_string.Append(pass_hash[i].ToString("x2").ToLower()); //toLower me convierte todo a minuscula

            return pass_string.ToString();
        }

        public bool existe_nombre_rol(string nombre_rol_ingresado)
        {
            bool existe_rol;
            connection conexion = new connection();
            string query = "SELECT rol_id FROM DATACENTER.Rol WHERE rol_nombre='" + nombre_rol_ingresado + "'";
            DataTable table_rol = conexion.execute_query(query);
            if (table_rol.Rows.Count > 0)
            {
                existe_rol = true;
            }
            else
            {
                existe_rol = false;
            }
            return existe_rol;
        }

    }
}
