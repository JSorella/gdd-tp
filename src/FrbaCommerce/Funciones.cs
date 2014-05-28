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
            Connection conexion = new Connection();
            string query = "SELECT rol_id FROM J2LA.Roles WHERE rol_nombre='" + nombre_rol_ingresado + "'";
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

        public bool check_func_activa(int id_rol, int id_func)
        {
            bool func_activa = false;
            Connection conexion = new Connection();
            string query = "SELECT rolfun_fun_id FROM J2LA.Roles_Funcionalidades WHERE rolfun_rol_id = " + id_rol + " and rolfun_fun_id = " + id_func;
            DataTable table_rol = conexion.execute_query(query);
            if (table_rol.Rows.Count > 0)
                func_activa = true;
            return func_activa;
        }

        public bool check_cambio_nomb_est_rol(int id_rol, bool estado_actual_rol, string nomb_rol_ingresado, string nomb_rol_BD)
        {

            if (!(this.check_estado_rol(id_rol, estado_actual_rol) & nomb_rol_BD == nomb_rol_ingresado))
            {
                return true; //devuelve true si existen cambios
            }
            return false;
        }


        public bool check_estado_rol(int id_rol, bool estado_actual_rol) //devuelve TRUE si el estado del ROL en la
        {                                                                   //BD es igual al seleccionado
            bool estado_rol = false;
            if (this.get_estado_BD(id_rol) == estado_actual_rol)
                estado_rol = true;
            return estado_rol;
        }

        public bool get_estado_BD(int rol_id)
        {
            Connection conexion = new Connection();
            string query = "SELECT rol_inhabilitado FROM J2LA.Roles WHERE rol_id =" + rol_id;
            DataTable table_rol = conexion.execute_query(query);
            return (Convert.ToBoolean(table_rol.Rows[0]["rol_Inhabilitado"]));

        }

        static public bool mostrarAlert(string mensaje)
        {
            MessageBox.Show(mensaje, "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }

        static public bool mostrarInformacion(string mensaje)
        {
            MessageBox.Show(mensaje, "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
