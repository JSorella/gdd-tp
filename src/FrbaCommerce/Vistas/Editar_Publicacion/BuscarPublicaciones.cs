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
    public partial class BuscarPublicaciones : Form
    {
        public BuscarPublicaciones()
        {
            InitializeComponent();
        }

        private void BuscarPublicaciones_Load(object sender, EventArgs e)
        {
            cmbRubros.SetearDatosLista(InterfazBD.getRubros(), "rub_id", "rub_Descripcion");
        }

        private void ArmarFiltros()
        { 
            String strFiltro = cmbRubros.ObtenerstrChequeados("rub_id");

            String query = strFiltro;

            MessageBox.Show(query);
        }
    }
}
