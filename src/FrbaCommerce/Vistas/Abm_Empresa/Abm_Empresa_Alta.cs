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
    public partial class Abm_Empresa_Alta : Form
    {
        private string usuario;
        private string pass;
        DateTime dteFecCreac;

        public Abm_Empresa_Alta()        //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            InitializeComponent();
        }

        public Abm_Empresa_Alta(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            InitializeComponent();
        }

        private void Abm_Empresa_Alta_Load(object sender, EventArgs e)
        {

        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecCreac = oFrm.FechaSeleccionada;
                tboxFechaCreacion.Text = oFrm.FechaSeleccionada.ToShortDateString();
        }
    }
}
