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
    public partial class HistorialCalificaciones : Form
    {
        public HistorialCalificaciones()
        {
            InitializeComponent();
        }

        private void cargarHistorialCalificaciones()
        {
            try
            {
                dgvHistorialCal.Visible = true;
                dgvHistorialCal.DataSource = InterfazBD.getHistorialCalificaciones();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void HistorialCalificaciones_Load_1(object sender, EventArgs e)
        {
            cargarHistorialCalificaciones();
        }
    }
}
