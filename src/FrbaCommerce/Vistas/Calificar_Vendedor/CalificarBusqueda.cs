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
        DataRow drCompraSeleccionada;

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
            if (this.gridCalificacionesPendientes.RowCount == 0)
            {
                MessageBox.Show("¡Buen trabajo! Usted no posee calificaciones pendientes.", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void SeleccionarCalificacion()
        {
            DataGridViewSelectedRowCollection list = this.gridCalificacionesPendientes.SelectedRows;

            if (list.Count > 0)
            {
                drCompraSeleccionada = ((DataRowView)gridCalificacionesPendientes.SelectedRows[0].DataBoundItem).Row;
                CalificarVendedor calificar = new CalificarVendedor();
                calificar.Compra = drCompraSeleccionada;
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