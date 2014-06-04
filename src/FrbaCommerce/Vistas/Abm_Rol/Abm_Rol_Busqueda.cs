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
    public partial class Abm_Rol_Busqueda : Form
    {
        private DataRow mobjDrResultado; // Variable para pasar a los formularios que llamen a la busqueda.

        public Abm_Rol_Busqueda()
        {
            InitializeComponent();
        }

        private void limpiar()
        {
            this.rol_a_buscarTBox.Clear();
            this.roles_dataGrid.DataSource = null;
        }

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        private void buscar_boton_Click(object sender, EventArgs e)
        {
            try
            {
                //cargamos el data_grid con el resultado de la busqueda
                this.roles_dataGrid.DataSource = InterfazBD.BuscarRoles(rol_a_buscarTBox.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void limpiar_boton_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void selec_rol_boton_Click(object sender, EventArgs e)
        {
            DataGridViewSelectedRowCollection list = this.roles_dataGrid.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)roles_dataGrid.SelectedRows[0].DataBoundItem).Row;
            else
                MessageBox.Show("Seleccione un Rol.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }

        private void roles_dataGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewSelectedRowCollection list = this.roles_dataGrid.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)roles_dataGrid.SelectedRows[0].DataBoundItem).Row;
            else
                MessageBox.Show("Seleccione un Rol.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }

        private void Abm_Rol_Busqueda_Load(object sender, EventArgs e)
        {

        }
    }
}
