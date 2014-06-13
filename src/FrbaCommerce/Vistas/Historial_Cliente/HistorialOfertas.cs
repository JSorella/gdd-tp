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
    public partial class HistorialOfertas : Form
    {
        public HistorialOfertas()
        {
            InitializeComponent();
        }

        private void cargarHistorialOfertas()
        {
            try
            {
                dgvHistorialO.Visible = true;
                dgvHistorialO.DataSource = InterfazBD.getHistorialOfertas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HistorialOfertas_Load_1(object sender, EventArgs e)
        {
            cargarHistorialOfertas();
        }
    }
}
