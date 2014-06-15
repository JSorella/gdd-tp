using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace FrbaCommerce
{
    /// <summary>
    /// Clase donde conviven todas las variables "globales" de la sesión.
    /// </summary>

    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();

        public static Connection conexion = new Connection();

        public static String ConnectionString;
        public static DateTime FechaDelSistema;

        public static DataRow usuario; //= new DataTable();
        public static int sessionRol_Id = 0;
        public static string sessionRol_Nombre = "";
        public static bool debeCambiarPass = false;

        //El constructor del Singleton siempre debe ser privado para evitar ser instanciado
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        public static void cargarUsuario(string nombre)
        {
            DataTable oDTRolesxUsuario = InterfazBD.getUsuarioConRoles(nombre);
            Singleton.usuario = oDTRolesxUsuario.NewRow();
            Singleton.usuario.ItemArray = oDTRolesxUsuario.Rows[0].ItemArray;
            Singleton.sessionRol_Id = Convert.ToInt32(Singleton.usuario["usurol_rol_id"]);
        }
    }
}
