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
        DataRow oDrSeleccion;

        public Responder_preguntas()
        {
            InitializeComponent();
        }

        private void Responder_preguntas_Load(object sender, EventArgs e)
        {
            cargarPreguntas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            oDrSeleccion = null;
            this.Close();
        }

        private void cargarPreguntas()
        {
            try
            {
                dgvPreguntas.Visible = true;
                dgvPreguntas.DataSource = InterfazBD.getPreguntasSinRta();

                dgvPreguntas.Columns["preg_pub_Codigo"].Visible = false;
                dgvPreguntas.Columns["preg_Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection list = dgvPreguntas.SelectedRows;
            if (list.Count > 0)
            {
                oDrSeleccion = ((DataRowView)dgvPreguntas.SelectedRows[0].DataBoundItem).Row;
                Respuesta oFrm = new Respuesta();
                oFrm.PreguntaDr = oDrSeleccion; //Le paso los datos de la Pregunta.
                oFrm.ShowDialog();

                cargarPreguntas(); //Refresco la grilla
            }
            else
                MessageBox.Show("Seleccione una pregunta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void dgvPreguntas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection list = dgvPreguntas.SelectedRows;
            if (list.Count > 0)
            {
                oDrSeleccion = ((DataRowView)dgvPreguntas.SelectedRows[0].DataBoundItem).Row;
                Respuesta oFrm = new Respuesta();
                oFrm.PreguntaDr = oDrSeleccion; //Le paso los datos de la Pregunta.
                oFrm.ShowDialog();

                cargarPreguntas(); //Refresco la grilla
            }
            else
                MessageBox.Show("Seleccione una pregunta.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarPreguntas();
        }
    }
}
