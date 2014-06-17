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
    public partial class Abm_Rubro_Modif : Form
    {
        public Abm_Rubro_Modif()
        {
            InitializeComponent();
        }

        private void Abm_Rubro_Modif_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Esta funcionalidad no esta Disponible en esta Version. Gracias.", "Informacón", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Abm_Rubro_Modif_VisibleChanged(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
