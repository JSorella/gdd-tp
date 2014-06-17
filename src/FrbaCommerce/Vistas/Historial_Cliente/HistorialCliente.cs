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
    public partial class HistorialCliente : Form
    {
        public HistorialCliente()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cargarHistorialCompras();
        }

        private void cargarHistorialCompras()
        {
            try
            {
                dgvHistorialC.Visible = true;
                dgvHistorialC.DataSource = InterfazBD.getHistorialCompras();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
