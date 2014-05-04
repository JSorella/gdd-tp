using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Dominio
{
    public class Usuario
    {
        public int id;
        public string nombre;
        public string pass;
        public int cantidadIntentos;
        public bool inhabilitado;
        public string motivo;
        List<Rol> roles;
        List<Publicacion> publicaciones;

        public Usuario(int _id, string _nombre, string _pass, int _cantidadIntentos, bool _inhabilitado, string _motivo)
        {
            this.id = _id;
            this.nombre = _nombre;
            this.pass = _pass;
            this.cantidadIntentos = _cantidadIntentos;
            this.inhabilitado = _inhabilitado;
            this.motivo = _motivo;
        }

        public Usuario()
        { }

        public void update_cant_intentos_fallidos(int cant_intentos)
        {
            string query = @"
                UPDATE 
                    J2LA.Usuarios
                SET
                    usu_Cant_Intentos = " + cant_intentos + @"
                WHERE
                    usu_Id=" + this.id;

            Singleton.conexion.execute_query_only(query);
        }

    }
}
