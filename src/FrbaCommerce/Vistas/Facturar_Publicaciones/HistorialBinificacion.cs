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
    public partial class HistorialBinificacion : Form
    {
        DataTable oDatos;

        public HistorialBinificacion()
        {
            InitializeComponent();
        }

        public DataTable _Datos
        {
            set { oDatos = value; }
        }

        private void HistorialBinificacion_Load(object sender, EventArgs e)
        {
            dgvDetalle.DataSource = oDatos;

            dgvDetalle.Columns["ucftv_usu_Id"].Visible = false;
            dgvDetalle.Columns["ucftv_vis_Id"].Visible = false;
            dgvDetalle.Columns["ucftv_Cantidad"].Visible = false;
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
