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
    public partial class GenerarPublicacion : Form
    {
        DataTable oDTVis;

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        // e.Handled = SoloNumeros(e.KeyChar);
        private bool SoloNumeros(Char chrKey)
        {
            //Para obligar a que sólo se introduzcan números enteros
            if (Char.IsNumber(chrKey)) //e.KeyChar
            {
                return false; // e.Handled = false;
            }
            else
                if (Char.IsControl(chrKey)) //permitir teclas de control como retroceso
                {
                    return false; // e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    return true; // e.Handled = true;
                }
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {
            CargarCombos();
            CargarRubros();
            Limpiar();
            HabilitarMod(false);
        }

        private void CargarRubros()
        {
            listRubros.DataSource = Singleton.conexion.execute_query("Select * From J2LA.Rubros Order By rub_Descripcion");
            listRubros.ValueMember = "rub_id";
            listRubros.DisplayMember = "rub_Descripcion";
        }

        private void Limpiar()
        {
            txtDesc.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
            cmbTipoVis.SelectedIndex = -1;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            txtFechaIni.Text = string.Empty;
            txtFechaVto.Text = string.Empty;
            chkPreguntas.Checked = false;

            //destildamos los rubros
            int i;
            for (i = 0; i < (this.listRubros.Items.Count); i++)
            {
                this.listRubros.SetItemChecked(i, false);
            }
        }

        private void HabilitarMod(bool habilitado)
        {
            pnlParam.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGenerar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
        }

        private void CargarCombos()
        {
            oDTVis = Singleton.conexion.execute_query("Select * From J2LA.Publicaciones_Visibilidades Order By pubvis_Descripcion");

            cmbTipoPubli.ValueMember = "pubtip_Id";
            cmbTipoPubli.DisplayMember = "pubtip_Nombre";
            cmbTipoPubli.DataSource = Singleton.conexion.execute_query("Select * From J2LA.Publicaciones_Tipos Order By pubtip_Nombre");

            cmbEstado.ValueMember = "pubest_Id";
            cmbEstado.DisplayMember = "pubest_Descripcion";
            cmbEstado.DataSource = Singleton.conexion.execute_query("Select * From J2LA.Publicaciones_Estados Order By pubest_Descripcion");

            cmbTipoVis.ValueMember = "pubvis_Id";
            cmbTipoVis.DisplayMember = "pubvis_Descripcion";
            cmbTipoVis.DataSource = oDTVis;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            HabilitarMod(true);
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            int posx = this.Location.X + pnlDatos.Location.X + this.btnSelFec.Location.X + this.btnSelFec.Size.Width + 10;
            int posy = this.Location.Y + pnlDatos.Location.Y + this.btnSelFec.Location.Y - 50;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(posx, posy);
            oFrm.ShowDialog();

            if(!oFrm.Cancelado)
                txtFechaIni.Text = oFrm.FechaSeleccionada.ToString();

            this.Enabled = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            Generar();
            Limpiar();
            HabilitarMod(false);
        }

        private void Generar()
        {
            foreach (int x in listRubros.CheckedIndices)
            {
                listRubros.SelectedIndex = x;
                MessageBox.Show(listRubros.SelectedValue.ToString());
            }


        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Limpiar();
            HabilitarMod(false);
        }

    }
}
