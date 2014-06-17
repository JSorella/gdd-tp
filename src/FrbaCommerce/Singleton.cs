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
        private static readonly Singleton instance = new Singleton(); //Instancia Propia de la Clase.

        public static Connection conexion = new Connection(); //Variable que instancia a la Clase de Conexion con la BD.

        public static String ConnectionString; //Cadena de Conexion a la BD - App.Config.
        public static DateTime FechaDelSistema; //Fecha del Sistema (Reemplaza al DateTime.Now) - App.Config.

        public static DataRow usuario; // DataRow con todos los datos del Usuario.
        public static int sessionRol_Id = 0; //Id del Rol con el que se Logueo al Sistema.
        public static string sessionRol_Nombre = ""; //Nombre del Rol con el que se Logueo al Sistema.
        public static bool debeCambiarPass = false; //Nos permite controlar si el Usuario realiza el Primer Ingreso y debe CambiarPass.

        /// <summary>
        /// El constructor del Singleton siempre debe ser privado para evitar ser instanciado.
        /// </summary>
        private Singleton() { }

        /// <summary>
        /// Metodo estatico para interactuar con la Clase.
        /// </summary>
        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }

        /// <summary>
        /// Obtiene todos los datos del Usuario que inicia la Sesion para operar en el Sistema.
        /// </summary>
        public static void cargarUsuario(string nombre)
        {
            DataTable oDTRolesxUsuario = InterfazBD.getUsuarioConRoles(nombre);
            Singleton.usuario = oDTRolesxUsuario.NewRow();
            Singleton.usuario.ItemArray = oDTRolesxUsuario.Rows[0].ItemArray;
            Singleton.sessionRol_Id = Convert.ToInt32(Singleton.usuario["usurol_rol_id"]);
        }
    }
}
