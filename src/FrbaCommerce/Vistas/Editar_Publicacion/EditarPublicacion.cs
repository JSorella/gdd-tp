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
        DataTable oDTVis; //Tabla de Visibilidades
        DataTable oDTEstados; //Tabla de Estados
        DataTable oDTRubros; //Tabla de Rubros

        DataTable oDTPubli = new DataTable(); //Tabla de la Publicacion
        DataTable oDtPubRubros = new DataTable(); //Tabla de los Rubros de la Publicacion

        DateTime dteFecIni;
        DateTime dteFecVto;

        bool cerrarForm = false;

        public EditarPublicacion()
        {
            InitializeComponent();
        }

        private void EditarPublicacion_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            CargarCombos();
            CargarRubros();
            Limpiar(true);
            HabilitarMod(false);
        }

        private void ArmarDataTables()
        {
            if (cerrarForm) return;

            try
            {
                oDTPubli = InterfazBD.getDTPubli();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ArmarDataTables: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void CargarRubros()
        {
            if (cerrarForm) return;

            try
            {
                oDTRubros = InterfazBD.getRubros();

                listRubros.DataSource = oDTRubros.Copy();
                listRubros.ValueMember = "rub_id";
                listRubros.DisplayMember = "rub_Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarRubros: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void Limpiar(bool cancel)
        {
            if (cerrarForm) return;

            txtCodPubli.Text = string.Empty;
            txtDesc.Text = string.Empty;
            if(cancel) cmbTipoPubli.SelectedIndex = -1;
            cmbEstado.SelectedIndex = -1;
            cmbTipoVis.SelectedIndex = -1;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            txtFechaIni.Text = string.Empty;
            txtFechaVto.Text = string.Empty;
            chkPreguntas.Checked = false;

            oDTPubli.Rows.Clear();
            oDtPubRubros.Rows.Clear();

            if (cancel)
            {
                cmbEstado.DataSource = oDTEstados.Copy();
                cmbEstado.SelectedIndex = -1;

                listRubros.DataSource = oDTRubros.Copy();
                listRubros.ValueMember = "rub_id";
                listRubros.DisplayMember = "rub_Descripcion";
            }

            //destildamos los rubros
            for (int i = 0; i < (this.listRubros.Items.Count); i++)
            {
                this.listRubros.SetItemChecked(i, false);
            }
        }

        private void HabilitarMod(bool habilitado)
        {
            if (cerrarForm) return;

            txtDesc.ReadOnly = false;
            txtDesc.Enabled = true;
            cmbEstado.Enabled = true;
            cmbTipoVis.Enabled = true;
            nudPrecio.ReadOnly = false;
            nudPrecio.Enabled = true;
            nudStock.ReadOnly = false;
            nudStock.Enabled = true;
            btnSelFec.Enabled = true;
            chkPreguntas.Enabled = true;
            listRubros.Enabled = true;

            btnSelFec.Visible = true;

            pnlParam.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGenerar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
        }

        private void CargarCombos()
        {
            if (cerrarForm) return;

            try
            {
                oDTVis = InterfazBD.getVisibilidadesPubli();
                oDTEstados = InterfazBD.getEstadosPubli();

                cmbTipoVis.ValueMember = "pubvis_Id";
                cmbTipoVis.DisplayMember = "pubvis_Descripcion";
                cmbTipoVis.DataSource = oDTVis;

                cmbTipoPubli.ValueMember = "pubtip_Id";
                cmbTipoPubli.DisplayMember = "pubtip_Nombre";
                cmbTipoPubli.DataSource = InterfazBD.getTiposPubli();

                cmbEstado.ValueMember = "pubest_Id";
                cmbEstado.DisplayMember = "pubest_Descripcion";
                cmbEstado.DataSource = oDTEstados.Copy();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarCombos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void btnSelPubli_Click(object sender, EventArgs e)
        {
            BuscarPublicaciones oFrm = new BuscarPublicaciones();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDTPubli = InterfazBD.getPublicacion(Convert.ToInt32(oFrm.Resultado["Codigo"]));

                txtCodPubli.Text = oFrm.Resultado["Codigo"].ToString();
                oDtPubRubros = InterfazBD.getPublicaciones_Rubros(Convert.ToInt32(oFrm.Resultado["Codigo"]));

                Aplicar();
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
            oDtPubRubros = InterfazBD.getPublicaciones_Rubros(Convert.ToInt32(txtCodPubli.Text));

            int index = 0;

            foreach (DataRow oDr in oDtPubRubros.Rows)
            {
                index = listRubros.FindStringExact(oDr["rub_Descripcion"].ToString());
                listRubros.SetItemChecked(index, true);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                Aplicar();
            }
        }

        private void Aplicar()
        {
            CargarDatosPubli();
            HabilitarMod(true);
            HabilitarSegunEstadoTipo();
            txtDesc.Focus();
        }

        private void HabilitarSegunEstadoTipo()
        {
            if ((Convert.ToInt32(cmbEstado.SelectedValue) != 4) //Si no esta Finalizada 
                    && (dteFecVto < Singleton.FechaDelSistema)) //Y esta vencida.
            {
                MessageBox.Show("Esta Publicacion esta venció el dia: " + dteFecVto.ToShortDateString() + " - No podrá realizar cambios en ella.-",
                    this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                ActivarVistaFinalizada(); //Sin Modificaciones en la Publicacion
                return;
            }

            if (Convert.ToInt32(cmbTipoPubli.SelectedValue) == 2) //Subasta
            {
                nudStock.Enabled = false; //Si es Borrador el Stock no cambia es 1.-

                if (Convert.ToInt32(cmbEstado.SelectedValue) == 1) //Activa
                {
                    ActivarVistaFinalizada(); //Sin Modificaciones en la Publicacion
                }
            }
            else
            {
                switch (Convert.ToInt32(cmbEstado.SelectedValue))
                {
                    case 1:
                        ActivarVistaActiva();
                        break;
                    case 2:
                        ActivarVistaBorrador();
                        break;
                    case 3:
                        ActivarVistaPausada();
                        break;
                    case 4:
                        ActivarVistaFinalizada();
                        break;
                    default:
                        break;
                }
            }
        }

        private void ActivarVistaFinalizada()
        {
            txtDesc.ReadOnly = true;
            txtDesc.Enabled = false;
            cmbEstado.Enabled = false;
            cmbTipoVis.Enabled = false;
            nudPrecio.ReadOnly = true;
            nudPrecio.Enabled = false;
            nudStock.ReadOnly = true;
            nudStock.Enabled = false;
            btnSelFec.Enabled = false;
            chkPreguntas.Enabled = false;
            listRubros.Enabled = false;
            listRubros.DataSource = oDtPubRubros.Copy();
            listRubros.ValueMember = "pubrub_rub_Id";
            //Tildamos los rubros
            for (int i = 0; i < (this.listRubros.Items.Count); i++)
            {
                this.listRubros.SetItemChecked(i, true);
            }

            btnGenerar.Enabled = false;
            btnLimpiar.Enabled = false;
        }

        private void ActivarVistaPausada()
        {
            ActivarVistaFinalizada(); //Sin Modificaciones en la Publicacion

            if (dteFecVto > Singleton.FechaDelSistema) //Si no esta vencida puede cambiar a Activa.
            {
                //Solo puede volver a Activa.
                cmbEstado.DataSource = oDTEstados.Select("pubest_id in (1)").CopyToDataTable();
                cmbEstado.SelectedValue = oDTPubli.Rows[0]["pub_estado_Id"];
                cmbEstado.Enabled = true;
            }
        }

        private void ActivarVistaActiva()
        {
            nudStock.Enabled = true;
            nudStock.ReadOnly = false;
            txtDesc.ReadOnly = false;
            txtDesc.Enabled = true;

            //No puede volver a Borrador.
            cmbEstado.DataSource = oDTEstados.Select("pubest_id not in (2)").CopyToDataTable();
            cmbEstado.SelectedValue = oDTPubli.Rows[0]["pub_estado_Id"];
            cmbEstado.Enabled = true;

            cmbTipoVis.Enabled = false;
            nudPrecio.ReadOnly = true;
            nudPrecio.Enabled = false;
            btnSelFec.Enabled = false;
            chkPreguntas.Enabled = false;

            listRubros.Enabled = false;
            listRubros.DataSource = oDtPubRubros.Copy();
            listRubros.ValueMember = "pubrub_rub_Id";
            //Tildamos los rubros
            for (int i = 0; i < (this.listRubros.Items.Count); i++)
            {
                this.listRubros.SetItemChecked(i, true);
            }
        }

        private void ActivarVistaBorrador()
        {
            cmbTipoPubli.Enabled = false;
            //Solo Borrador  o Activa
            cmbEstado.DataSource = oDTEstados.Select("pubest_id not in (3,4)").CopyToDataTable();
            cmbEstado.SelectedValue = oDTPubli.Rows[0]["pub_estado_Id"];
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
            oFrm.FechaSeleccionada = dteFecIni;
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
                        Limpiar(true);
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

            if (nudStock.Value < 1)
            {
                mensaje = mensaje + "Debe indicar un Stock Mayor o Igual a 1." + System.Environment.NewLine;
                datosOk = false;
            }

            if (nudPrecio.Value < 1)
            {
                mensaje = mensaje + "Debe indicar un Precio Mayor o Igual a $1,00." + System.Environment.NewLine;
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

                result = InterfazBD.EditarPublicacion(oDTPubli, oDtPubRubros);

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
                oDtPubRubros = InterfazBD.getDTRubros();

                foreach (int x in listRubros.CheckedIndices)
                {
                    oDr = oDtPubRubros.NewRow();

                    listRubros.SelectedIndex = x;

                    oDr["pubrub_pub_codigo"] = pub_codigo;
                    oDr["pubrub_rub_id"] = listRubros.SelectedValue;

                    oDtPubRubros.Rows.Add(oDr);
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

            DataRow oDr = oDTPubli.Rows[0];

            oDr.BeginEdit();

            oDr["pub_Descripcion"] = txtDesc.Text;
            oDr["pub_Stock"] = nudStock.Value;
            oDr["pub_Fecha_Vto"] = dteFecIni;
            oDr["pub_Fecha_Ini"] = dteFecVto;
            oDr["pub_Precio"] = nudPrecio.Value;
            oDr["pub_visibilidad_Id"] = cmbTipoVis.SelectedValue;
            oDr["pub_estado_Id"] = cmbEstado.SelectedValue;
            oDr["pub_Permite_Preg"] = chkPreguntas.Checked;
            oDr["pub_vis_Precio"] = rowVis["pubvis_Precio"];
            oDr["pub_vis_Porcentaje"] = rowVis["pubvis_Porcentaje"];

            oDr.EndEdit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(true);
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

        private void EditarPublicacion_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
        }
    }
}
