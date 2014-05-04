using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce
{
    /// <summary>
    /// Clase donde conviven todas las variables "globales" de la sesión.
    /// </summary>

    public sealed class Singleton
    {
        private static readonly Singleton instance = new Singleton();
        public static Connection conexion = new Connection();

        //El constructor del Singleton siempre debe ser privado para evitar ser instanciado
        private Singleton() { }

        public static Singleton Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
