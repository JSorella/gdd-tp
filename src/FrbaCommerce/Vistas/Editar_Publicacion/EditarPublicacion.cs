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
    public partial class EditarPublicacion : Form
    {
        DataTable oDTVis;
        DataTable oDTPubli = new DataTable();
        DataTable oDTRubros = new DataTable();

        DateTime dteFecIni;
        DateTime dteFecVto;

        public EditarPublicacion()
        {
            InitializeComponent();
        }

        private void EditarPublicacion_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            CargarCombos();
            CargarRubros();
            Limpiar();
            HabilitarMod(false);
        }

        private void ArmarDataTables()
        {
            try
            {
                oDTPubli = InterfazBD.getDTPubli();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ArmarDataTables: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CargarRubros()
        {
            try
            {
                listRubros.DataSource = InterfazBD.getRubros();
                listRubros.ValueMember = "rub_id";
                listRubros.DisplayMember = "rub_Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarRubros: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void Limpiar()
        {
            txtCodPubli.Text = string.Empty;
            txtDesc.Text = string.Empty;
            cmbTipoPubli.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbTipoVis.SelectedIndex = -1;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            txtFechaIni.Text = string.Empty;
            txtFechaVto.Text = string.Empty;
            chkPreguntas.Checked = false;

            oDTPubli.Rows.Clear();
            oDTRubros.Rows.Clear();

            //destildamos los rubros
            for (int i = 0; i < (this.listRubros.Items.Count); i++)
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
            try
            {
                oDTVis = InterfazBD.getVisibilidadesPubli();

                cmbTipoVis.ValueMember = "pubvis_Id";
                cmbTipoVis.DisplayMember = "pubvis_Descripcion";
                cmbTipoVis.DataSource = oDTVis;

                cmbTipoPubli.ValueMember = "pubtip_Id";
                cmbTipoPubli.DisplayMember = "pubtip_Nombre";
                cmbTipoPubli.DataSource = InterfazBD.getTiposPubli();

                cmbEstado.ValueMember = "pubest_Id";
                cmbEstado.DisplayMember = "pubest_Descripcion";
                cmbEstado.DataSource = InterfazBD.getEstadosPubli();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarCombos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void btnSelPubli_Click(object sender, EventArgs e)
        {
            BuscarPublicaciones oFrm = new BuscarPublicaciones();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                DataRow oDr = oDTPubli.NewRow();
                oDr.ItemArray = oFrm.Resultado.ItemArray;
                oDTPubli.Rows.Add(oDr);

                txtCodPubli.Text = oDr["pub_Codigo"].ToString();
                oDTRubros = InterfazBD.getPublicaciones_Rubros((int)oDr["pub_Codigo"]);

                CargarDatosPubli();
                HabilitarMod(true);
                txtDesc.Focus();
            }
        }

        private void CargarDatosPubli()
        {
            DataRow oDr = oDTPubli.Rows[0];

            cmbTipoPubli.SelectedValue = oDr["pub_tipo_Id"];
            txtDesc.Text = oDr["pub_Descripcion"].ToString();
            nudStock.Value = Convert.ToDecimal(oDr["pub_Stock"]);
            dteFecIni = Convert.ToDateTime(oDr["pub_Fecha_Ini"]);
            dteFecVto = Convert.ToDateTime(oDr["pub_Fecha_Vto"]);
            nudPrecio.Value = Convert.ToDecimal(oDr["pub_Precio"]);
            cmbTipoVis.SelectedValue = oDr["pub_visibilidad_Id"];
            cmbEstado.SelectedValue = oDr["pub_estado_Id"];
            chkPreguntas.Checked = Convert.ToBoolean(oDr["pub_Permite_Preg"]);

            txtFechaIni.Text = dteFecIni.ToShortDateString();
            txtFechaVto.Text = dteFecVto.ToShortDateString();

            MarcarRubros();
        }

        private void MarcarRubros()
        {
            oDTRubros = InterfazBD.getPublicaciones_Rubros(Convert.ToInt32(txtCodPubli.Text));

            int index = 0;

            foreach (DataRow oDr in oDTRubros.Rows)
            {
                index = listRubros.FindStringExact(oDr["rub_Descripcion"].ToString());
                listRubros.SetItemChecked(index, true);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                CargarDatosPubli();
                HabilitarMod(true);
                txtDesc.Focus();
            }
        }

        private bool ValidaAceptar()
        {
            if (txtCodPubli.Text == "")
            {
                MessageBox.Show("Debe indicar un Codigo de Publicación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDTPubli = InterfazBD.getPublicacion(Convert.ToInt32(txtCodPubli.Text));

                if (oDTPubli != null)
                {
                    if (oDTPubli.Rows.Count <= 0)
                    {
                        MessageBox.Show("Publicación Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Publicación Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecIni = oFrm.FechaSeleccionada;
            txtFechaIni.Text = oFrm.FechaSeleccionada.ToShortDateString();

            ActualizarVto();
        }

        private void ActualizarVto()
        {
            DataRowView vrow = (DataRowView)cmbTipoVis.SelectedItem;
            DataRow row;

            if (vrow != null)
            {
                row = vrow.Row;
                dteFecVto = dteFecIni.AddDays(Convert.ToDouble(row["pubvis_Dias_Vto"]));
                txtFechaVto.Text = dteFecVto.ToShortDateString();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Guardar los cambios en la Publicación?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidaGenerar())
                {
                    if (Generar())
                    {
                        Limpiar();
                        HabilitarMod(false);
                    }
                }
            }
        }

        //VEEEEEEEEEEEEEEEEEEER
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

        private bool Generar()
        {
            bool result;

            try
            {
                CargarDTPubli();
                CargarDtRubros(Convert.ToInt32(txtCodPubli.Text));

                result = InterfazBD.EditarPublicacion(oDTPubli, oDTRubros);

                MessageBox.Show("Su Publicación fue grabada con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDtRubros(int pub_codigo)
        {
            DataRow oDr;

            try
            {
                oDTRubros = InterfazBD.getDTRubros();

                foreach (int x in listRubros.CheckedIndices)
                {
                    oDr = oDTRubros.NewRow();

                    listRubros.SelectedIndex = x;

                    oDr["pubrub_pub_codigo"] = pub_codigo;
                    oDr["pubrub_rub_id"] = listRubros.SelectedValue;

                    oDTRubros.Rows.Add(oDr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarDTPubli()
        {
            DataRowView vrow = (DataRowView)cmbTipoVis.SelectedItem;
            DataRow rowVis = vrow.Row;

            //oDTPubli.Rows.Clear();
            //DataRow oDr = oDTPubli.NewRow();

            DataRow oDr = oDTPubli.Rows[0];

            oDr.BeginEdit();

            //oDr["pub_codigo"] = 0;
            //oDr["pub_tipo_Id"] = cmbTipoPubli.SelectedValue;
            oDr["pub_Descripcion"] = txtDesc.Text;
            oDr["pub_Stock"] = nudStock.Value;
            oDr["pub_Fecha_Vto"] = dteFecIni;
            oDr["pub_Fecha_Ini"] = dteFecVto;
            oDr["pub_Precio"] = nudPrecio.Value;
            oDr["pub_visibilidad_Id"] = cmbTipoVis.SelectedValue;
            oDr["pub_estado_Id"] = cmbEstado.SelectedValue;
            oDr["pub_Permite_Preg"] = chkPreguntas.Checked;
            //oDr["pub_usu_id"] = Singleton.usuario["usu_id"];
            oDr["pub_vis_Precio"] = rowVis["pubvis_Precio"];
            oDr["pub_vis_Porcentaje"] = rowVis["pubvis_Porcentaje"];

            oDr.EndEdit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void txtCodPubli_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void cmbTipoVis_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtFechaIni.Text != "")
                ActualizarVto();
        }
    }
}
