using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Abm_Rol
{
    public partial class Abm_Rol_Baja : Form
    {
        public string rol_nomb_mod;
        public int id_rol_a_mod;

        public Abm_Rol_Baja()
        {
            InitializeComponent();
        }

        private void select_boton_Click(object sender, EventArgs e)
        {

            Abm_Rol_Busqueda buscar_rol = new Abm_Rol_Busqueda();
            buscar_rol.ShowDialog();
            if ((buscar_rol.Resultado != null)) //Resultado es el DataRow.-
            {
                id_rol_a_mod = Convert.ToInt32(buscar_rol.Resultado["rol_id"]);
                rol_nomb_mod = buscar_rol.Resultado["rol_nombre"].ToString();

            }
        }

        private void baja_boton_Click(object sender, EventArgs e)
        {
            StoredProcedures.baja_rol(this.rol_nomb_mod, this.id_rol_a_mod);
        }
    }
}
