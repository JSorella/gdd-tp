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
    public partial class BuscarPublicaciones : Form
    {
        private DataRow mobjDrResultado;

        public BuscarPublicaciones()
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

        private void BuscarPublicaciones_Load(object sender, EventArgs e)
        {
            CargarCombos();
            Limpiar();
        }

        private void CargarCombos()
        {
            try
            {
                cmbRubros.SetearDatosLista(InterfazBD.getRubros(), "rub_id", "rub_Descripcion");
                cmbEstados.SetearDatosLista(InterfazBD.getEstadosPubli(), "pubest_Id", "pubest_Descripcion");
                cmbTipoVis.SetearDatosLista(InterfazBD.getVisibilidadesPubli(), "pubvis_Id", "pubvis_Descripcion");
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
            cmbEstados.TildeEnNinguno();
            cmbTipoVis.TildeEnNinguno();
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
                dgvPubli.DataSource = InterfazBD.BuscarPublicaciones(ArmarFiltros());
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
            String estados = cmbEstados.ObtenerstrChequeados("pubest_Id");
            String visib = cmbTipoVis.ObtenerstrChequeados("pubvis_Id");

            String filtros = "Where P.pub_usu_id = " + Singleton.usuario["usu_id"].ToString();

            if (txtDescripcion.Text != "")
                filtros = filtros + " And P.pub_Descripcion like '%" + txtDescripcion.Text + "%' ";

            if(rubros != "")
                filtros = filtros + " And PR.pubrub_rub_Id IN (" + rubros + ")";

            if (estados != "")
                filtros = filtros + " And P.pub_estado_Id IN (" + estados + ")";

            if (visib != "")
                filtros = filtros + " And P.pub_visibilidad_Id IN (" + visib + ")";

            return filtros;
        }


        private void btnSeleccionar_Click(object sender, EventArgs e)
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
                this.Close();
            }
            else
                MessageBox.Show("Seleccione una Publicación.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
