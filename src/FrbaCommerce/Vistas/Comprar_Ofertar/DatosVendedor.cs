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
    public partial class DatosVendedor : Form
    {
        private Int32 codigoVendedor;
        private DataTable oDTVendedor;

        public DatosVendedor(int _codigoVendedor)
        {
            this.codigoVendedor = _codigoVendedor;
            InitializeComponent();
        }

        private void DatosVendedor_Load(object sender, EventArgs e)
        {
            try
            {
                oDTVendedor = InterfazBD.getVendedor(this.codigoVendedor);
                dgVendedor.DataSource = oDTVendedor;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Datos Vendedor: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void DatosVendedor_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }


    }
}
