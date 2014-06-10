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
    public partial class BuscarUsuario : Form
    {
        private DataRow mobjDrResultado; // Variable para pasar a los formularios que llamen a la busqueda.

        public BuscarUsuario()
        {
            InitializeComponent();
        }

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        private void BuscarUsuario_Load(object sender, EventArgs e)
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

        private void dgvUsu_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            dgvUsu.DataSource = null;
        }

        private void Buscar()
        {
            try
            {
                //Cargamos el data_grid con el resultado de la busqueda
                //dgvUsu.DataSource = InterfazBD.BuscarUsuarios(txtNombre.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Seleccionar()
        {
            DataGridViewSelectedRowCollection list = dgvUsu.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)dgvUsu.SelectedRows[0].DataBoundItem).Row;
            else
                MessageBox.Show("Seleccione un Usuario.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }
    }
}
