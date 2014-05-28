using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace FrbaCommerce
{
    public partial class GenerarPublicacion : Form
    {
        DataTable oDTVis;

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        // Evento KeyPress del TextBox => e.Handled = SoloNumeros(e.KeyChar);
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
            listRubros.DataSource = Singleton.conexion.execute_query("Select rub_id, rub_descripcion " +
                                                                        "From J2LA.Rubros " +
                                                                        "Where rub_Eliminado = 0" +
                                                                        "Order By rub_Descripcion");
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
            oDTVis = Singleton.conexion.execute_query("Select * From J2LA.Publicaciones_Visibilidades Where pubvis_Eliminado = 0 Order By pubvis_Descripcion");

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
            if (ValidaAceptar())
            {
                HabilitarMod(true);
                txtDesc.Focus();
            }
        }

        private bool ValidaAceptar()
        {
            if (cmbTipoPubli.SelectedIndex < 0)
            {
                MessageBox.Show("Debe seleccionar el Tipo de Publicación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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

            ActualizarVto();
        }

        private void ActualizarVto()
        {
            DataRowView vrow = (DataRowView)cmbTipoVis.SelectedItem;
            DataRow row;

            if (vrow != null)
            { 
                row = vrow.Row;
                txtFechaVto.Text = Convert.ToDateTime(txtFechaIni.Text).AddDays(Convert.ToDouble(row["pubvis_Dias_Vto"])).ToString();
            }            
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea generar la Publicación?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidaGenerar())
                {
                    Generar();
                    Limpiar();
                    HabilitarMod(false);
                }
            }
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (txtDesc.Text == "")
            {
                mensaje = mensaje + "Debe indicar una Descripcion." + System.Environment.NewLine;
                datosOk = false;
            }

            if (cmbTipoVis.SelectedIndex < 0)
            {
                mensaje = mensaje + "Debe indicar una Visibilidad." + System.Environment.NewLine;
                datosOk = false;
            }

            if (cmbEstado.SelectedIndex < 0)
            {
                mensaje = mensaje + "Debe indicar un Estado." + System.Environment.NewLine;
                datosOk = false;
            }

            if (nudStock.Value <= 0)
            {
                mensaje = mensaje + "Debe indicar el Stock." + System.Environment.NewLine;
                datosOk = false;
            }

            if (nudPrecio.Value <= 0)
            {
                mensaje = mensaje + "Debe indicar un Precio." + System.Environment.NewLine;
                datosOk = false;
            }

            if (txtFechaIni.Text == "")
            {
                mensaje = mensaje + "Debe indicar la Fecha de Inicio." + System.Environment.NewLine;
                datosOk = false;
            }

            if (txtFechaVto.Text == "")
            {
                mensaje = mensaje + "Debe indicar la Fecha de Vencimiento." + System.Environment.NewLine;
                datosOk = false;
            }

            if (listRubros.CheckedIndices.Count <= 0)
            {
                mensaje = mensaje + "Debe seleccionar al menos un Rubro." + System.Environment.NewLine;
                datosOk = false;
            }

            if (!datosOk)
                MessageBox.Show(mensaje, "Validaciones - Nueva Publicación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return datosOk;
        }

        private void Generar()
        {
            string query = "J2LA.Publicaciones_Insert";
            string pub_codigo = "";
            try
            {
                SqlCommand comando = new SqlCommand(query, Singleton.conexion.connector());
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@pub_codigo", SqlDbType.Decimal).Direction = ParameterDirection.Output;
                comando.Parameters.AddWithValue("@pub_descripcion", txtDesc.Text);

                comando.ExecuteNonQuery();

                pub_codigo = comando.Parameters["@pub_codigo"].Value.ToString();

                foreach (int x in listRubros.CheckedIndices)
                {
                    listRubros.SelectedIndex = x;
                    MessageBox.Show(listRubros.SelectedValue.ToString());
                }

                MessageBox.Show(pub_codigo);
            }
            catch(Exception)
            {
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar();
                HabilitarMod(false);
            }
        }

        private void cmbTipoVis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(txtFechaIni.Text != "")
                ActualizarVto();
        }

    }
}
