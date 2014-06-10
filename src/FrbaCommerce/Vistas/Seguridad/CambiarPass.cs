using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class CambiarPass : Form
    {
        public CambiarPass()
        {
            InitializeComponent();
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BuscarUsuario oFrm = new BuscarUsuario();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                //oDtRol = InterfazBD.getRol(oFrm.Resultado["Nombre"].ToString());

                txtRolName.Text = oFrm.Resultado["Usuario"].ToString();

                //Aplicar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }
    }
}
