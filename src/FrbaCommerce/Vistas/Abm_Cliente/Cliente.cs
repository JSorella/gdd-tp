using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FrbaCommerce.Vistas.Abm_Cliente
{
    /// <summary>
    /// clase de uso LOCAL en Alta de Cliente para mapear un Cliente en un objeto.
    /// </summary>
    public class Cliente
    {
        public string userName;
        public string pass; // YA ENCRIPTADO!
        public string nombre;
        public string apellido;
        public long dni;
        public int idTipoDoc;
        public string mail;
        public long telefono;
        public string nomCalle;
        public int nroCalle;
        public int piso;
        public string depto;
        public string localidad;
        public string cp;
        public DateTime fechaNacimiento;
        public long cuil;

        public Cliente(string _userName, string _pass, string _nombre, string _apellido, long _dni, int _idTipoDoc, string _mail, long _telefono, string _nomCalle, int _nroCalle, int _piso, string _depto, string _localidad, string _cp, DateTime _fechaNacimiento, long _cuil)
        {
            this.userName = _userName;
            this.pass = Funciones.get_hash(_pass);  //Encripto el Password
            this.nombre = _nombre;
            this.apellido = _apellido;
            this.dni = _dni;
            this.idTipoDoc = _idTipoDoc;
            this.mail = _mail;
            this.telefono = _telefono;
            this.nomCalle = _nomCalle;
            this.nroCalle = _nroCalle;
            this.piso = _piso;
            this.depto = _depto;
            this.localidad = _localidad;
            this.cp = _cp;
            this.fechaNacimiento = _fechaNacimiento;
            this.cuil = _cuil;
        }
    }
}
