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
    public partial class Abm_Visibilidad_Buscar : Form
    {
        private DataRow mobjDrResultado; // Variable para pasar a los formularios que llamen a la busqueda.

        public Abm_Visibilidad_Buscar()
        {
            InitializeComponent();
        }

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        private void Abm_Visibilidad_Buscar_Load(object sender, EventArgs e)
        {
            mobjDrResultado = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            //Solo numero por Copiar/Pegar
            TextBox oTxt = (TextBox)sender;

            oTxt.Text = Funciones.ValidaTextoSoloNumerosConFiltro(oTxt.Text, "");
        }

        private void dgvVisib_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            dgvVisib.DataSource = null;
        }

        private void Buscar()
        {
            try
            {
                //Cargamos el data_grid con el resultado de la busqueda
                dgvVisib.DataSource = InterfazBD.BuscarVisibilidades(txtCodigo.Text, txtDescripcion.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar()
        {
            DataGridViewSelectedRowCollection list = this.dgvVisib.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)dgvVisib.SelectedRows[0].DataBoundItem).Row;
            else
                MessageBox.Show("Seleccione una Visibilidad.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }
    }
}
