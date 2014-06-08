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
    public partial class ComprarOfertar : Form
    {

        private DataRow mobjDrResultado;

        public ComprarOfertar()
        {
            InitializeComponent();
            cmbRubros.LostFocus += new EventHandler(cmbRubros_LostFocus);
        }

        void cmbRubros_LostFocus(object sender, EventArgs e)
        {
            cmbRubros.OcultarElPanel();
        }

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        private void ComprarOfertar_Load(object sender, EventArgs e)
        {
            CargarCombos();
            Limpiar();
        }

        private void CargarCombos()
        {
            try
            {
                cmbRubros.SetearDatosLista(InterfazBD.getRubros(), "rub_id", "rub_Descripcion");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarCombos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Limpiar()
        {
            txtDescripcion.Text = string.Empty;
            cmbRubros.TildeEnNinguno();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvPubli.DataSource = null;
                dgvPubli.DataSource = InterfazBD.BuscarPublicacionesOrdenadasPorPeso(ArmarFiltros());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Obtener Datos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private string ArmarFiltros()
        {
            String rubros = cmbRubros.ObtenerstrChequeados("rub_id");

            String filtros = "Where E.pubest_Descripcion = 'Activa' ";

            if (txtDescripcion.Text != "")
                filtros = filtros + " And P.pub_Descripcion like '%" + txtDescripcion.Text + "%' ";

            if(rubros != "")
                filtros = filtros + " And PR.pubrub_rub_Id IN (" + rubros + ")";

            return filtros;
        }

        private void btnSeleccionar_Click_1(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            mobjDrResultado = null;
            this.Close();
        }

        private void dgvPubli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void Seleccionar()
        {
            DataGridViewSelectedRowCollection list = this.dgvPubli.SelectedRows;

            if (list.Count > 0)
            {
                mobjDrResultado = ((DataRowView)dgvPubli.SelectedRows[0].DataBoundItem).Row;
                DetallesPublicacion oFrm = new DetallesPublicacion(Convert.ToInt32(mobjDrResultado["Codigo"]));
                oFrm.ShowDialog();
                
            }
            else
                MessageBox.Show("Seleccione una Publicación.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }





    }
}
