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
    public partial class CalificarBusqueda : Form
    {
        public static DataRow drCompra;

        public static System.Data.DataRow Compra
        {
            get { return drCompra; }
        }

        public CalificarBusqueda()
        {
            InitializeComponent();
        }

        private void CalificarVendedor_Load(object sender, EventArgs e)
        {
            cargarCalificacionesPendientes();
        }

        public void cargarCalificacionesPendientes()
        {
            gridCalificacionesPendientes.DataSource = InterfazBD.getCalificacionesPendientes();
        }

        private void SeleccionarCalificacion()
        {
            DataGridViewSelectedRowCollection list = this.gridCalificacionesPendientes.SelectedRows;

            if (list.Count > 0)
            {
                drCompra = ((DataRowView)gridCalificacionesPendientes.SelectedRows[0].DataBoundItem).Row;
                CalificarVendedor calificar = new CalificarVendedor();
                calificar.ShowDialog();
                cargarCalificacionesPendientes();
            }
            else
                MessageBox.Show("Seleccione una compra para calificar.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void gridCalificacionesPendientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarCalificacion();
        }

        private void SeleccionarCompra_Click(object sender, EventArgs e)
        {
            SeleccionarCalificacion();
        }
    }
}
