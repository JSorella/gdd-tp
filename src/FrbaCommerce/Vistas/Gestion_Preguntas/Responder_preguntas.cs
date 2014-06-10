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
    public partial class Responder_preguntas : Form
    {
        public Responder_preguntas()
        {
            InitializeComponent();
            cargarPreguntas();
        }

        private void cargarPreguntas()
        {
            this.cargarGrid(InterfazBD.preguntas());
        }

        private void cargarGrid(DataTable dataTable)
        {
            gridPreguntas.Visible = true;
            gridPreguntas.DataSource = dataTable;
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection list = this.gridPreguntas.SelectedRows;
            Respuesta oFrm = new Respuesta();
            oFrm.ShowDialog();
        }

        private void gridPreguntas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection list = this.gridPreguntas.SelectedRows;
            Respuesta oFrm = new Respuesta();
            oFrm.ShowDialog();
        }
    }
}
