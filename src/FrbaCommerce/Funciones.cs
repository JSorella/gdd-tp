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

        // Para llamar a esta Funcion:
        // Crear el Evento KeyPress del TextBox y poner el siguiente codigo => e.Handled = Funciones.SoloNumeros(e.KeyChar);
        static public bool SoloNumeros(Char chrKey)
        {
            //Para obligar a que sólo se introduzcan números enteros
            if (Char.IsNumber(chrKey)) //seria el e.KeyChar en el Form
            {
                return false; //seria el e.Handled = false; en el Form
            }
            else
                if (Char.IsControl(chrKey)) //permitir teclas de control como retroceso
                {
                    return false; //seria el e.Handled = false; en el Form
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    return true; //seria el e.Handled = true; en el Form
                }
        }

        public static bool mostrarAlert(string mensaje, string caption)
        {
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK, MessageBoxIcon.Error);
            return true;
        }

        public static bool mostrarInformacion(string mensaje, string caption)
        {
            MessageBox.Show(mensaje, caption, MessageBoxButtons.OK, MessageBoxIcon.Information);
            return true;
        }
    }
}
