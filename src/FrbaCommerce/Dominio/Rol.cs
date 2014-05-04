using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Dominio
{
    public class Rol
    {
        public int id;
        public string nombre;
        public bool inhabilitado;

        public Rol(int _id)
        {
            this.id = _id;
        }
    }
}
