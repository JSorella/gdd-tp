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
    public partial class Abm_Clientes_Busqueda : Form
    {
        private DataRow mobjDrResultado;

        public Abm_Clientes_Busqueda()
        {
            InitializeComponent();
        }

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        private void Abm_Clientes_Busqueda_Load(object sender, EventArgs e)
        {
            mobjDrResultado = null;

            this.comboDoc.DataSource = InterfazBD.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
            this.comboDoc.SelectedIndex = -1;
        }

        private string ArmarFiltros()
        {
            String cli_Nombre = txtNombre.Text;
            String cli_Apellido = this.txtApellido.Text;
            String cli_Nro_Doc = this.txtNroDoc.Text;
            String cli_Mail = this.txtMail.Text;

            String filtros = " Where C.cli_usu_id = U.usu_Id AND U.usu_Eliminado = 0";

            if (cli_Nombre != "")
                filtros = filtros + " AND cli_Nombre LIKE '%" + cli_Nombre + "%' ";

            if (cli_Apellido != "")
                filtros = filtros + " AND cli_Apellido LIKE '%" + cli_Apellido + "%' ";

            if (this.comboDoc.Text != "")
            {
                int cli_Tipodoc_Id = Convert.ToInt32(((DataRowView)this.comboDoc.SelectedItem).Row["tipodoc_Id"]);
                filtros = filtros + " AND cli_Tipodoc_Id = " + cli_Tipodoc_Id;
            }
            if (cli_Nro_Doc != "")
                filtros = filtros + " AND cli_Nro_Doc LIKE '%" + cli_Nro_Doc + "%' ";

            if (cli_Mail != "")
                filtros = filtros + " AND cli_Mail LIKE '%" + cli_Mail + "%' ";

            return filtros;
        }

        private void Seleccionar()
        {
            DataGridViewSelectedRowCollection list = this.gridClientes.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)gridClientes.SelectedRows[0].DataBoundItem).Row;
            else
                Funciones.mostrarAlert("Seleccione un Usuario", "Atención");

            this.Close();
        }

        private void Buscar()
        {
            try
            {
                gridClientes.DataSource = InterfazBD.BuscarClientes(ArmarFiltros());
                gridClientes.Columns["cli_Tipodoc_Id"].Visible = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            this.comboDoc.SelectedIndex = -1;
            this.txtNroDoc.Text = string.Empty;
            txtMail.Text = string.Empty;
            gridClientes.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void gridClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            txtNroDoc.Text = Funciones.ValidaTextoSoloNumerosConFiltro(txtNroDoc.Text, "");
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }
    }
}
