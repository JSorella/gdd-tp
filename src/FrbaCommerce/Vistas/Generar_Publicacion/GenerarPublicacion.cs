﻿using System;
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
        DataTable oDTPubli;
        DataTable oDTRubros;

        DateTime dteFecIni;
        DateTime dteFecVto;

        int CantGratis = 0;
        bool cerrarForm = false;

        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
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
                oDTRubros = InterfazBD.getDTRubros();
                CantGratis = InterfazBD.getCantPubliGratis(0);
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
                listRubros.DataSource = InterfazBD.getRubros();
                listRubros.ValueMember = "rub_id";
                listRubros.DisplayMember = "rub_Descripcion";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarRubros: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void Limpiar()
        {
            if (cerrarForm) return;

            txtDesc.Text = string.Empty;
            cmbEstado.SelectedIndex = -1;
            cmbTipoVis.SelectedIndex = -1;
            nudPrecio.Value = 0;
            nudStock.Value = 0;
            txtFechaIni.Text = string.Empty;
            txtFechaVto.Text = string.Empty;
            chkPreguntas.Checked = false;

            if (!cerrarForm)
            {
                oDTPubli.Rows.Clear();
                oDTRubros.Rows.Clear();
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

            pnlParam.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGenerar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;

            if (Convert.ToInt32(cmbTipoPubli.SelectedValue) == 2) //Subasta
            {
                nudStock.Value = 1;
                nudStock.Enabled = false;
            }
            else
            {
                nudStock.Value = 0;
                nudStock.Enabled = true;
            }

        }

        private void CargarCombos()
        {
            if (cerrarForm) return;

            try
            {
                oDTVis = InterfazBD.getVisibilidadesPubli();
                DataTable oDtEstado = InterfazBD.getEstadosPubli();
                oDtEstado = oDtEstado.Select("pubest_id not in (3,4)").CopyToDataTable();

                cmbTipoVis.ValueMember = "pubvis_Id";
                cmbTipoVis.DisplayMember = "pubvis_Descripcion";
                cmbTipoVis.DataSource = oDTVis;

                cmbTipoPubli.ValueMember = "pubtip_Id";
                cmbTipoPubli.DisplayMember = "pubtip_Nombre";
                cmbTipoPubli.DataSource = InterfazBD.getTiposPubli();

                cmbEstado.ValueMember = "pubest_Id";
                cmbEstado.DisplayMember = "pubest_Descripcion";
                cmbEstado.DataSource = oDtEstado;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarCombos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
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
            if (MessageBox.Show("Confirma que desea generar la Publicación?", "Nueva Publicación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            String[] result;

            try
            {
                CargarDTPubli();
                CargarDtRubros(0);

                result = InterfazBD.NuevaPublicacion(oDTPubli, oDTRubros).Split('|');

                MessageBox.Show("Su Publicación fue grabada con exito." + System.Environment.NewLine + "Codigo de Publicación: " + result[1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return Convert.ToBoolean(result[0]);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDtRubros(int pub_codigo)
        {
            oDTRubros.Rows.Clear();
            DataRow oDr;

            foreach (int x in listRubros.CheckedIndices)
            {
                oDr = oDTRubros.NewRow();

                listRubros.SelectedIndex = x;

                oDr["pubrub_pub_codigo"] = pub_codigo;
                oDr["pubrub_rub_id"] = listRubros.SelectedValue;

                oDTRubros.Rows.Add(oDr);
            }
        }

        private void CargarDTPubli()
        {
            DataRowView vrow = (DataRowView)cmbTipoVis.SelectedItem;
            DataRow rowVis = vrow.Row;

            oDTPubli.Rows.Clear();

            DataRow oDr = oDTPubli.NewRow();

            oDr["pub_codigo"] = 0;
            oDr["pub_tipo_Id"] = cmbTipoPubli.SelectedValue;
            oDr["pub_Descripcion"] = txtDesc.Text;
            oDr["pub_Stock"] = nudStock.Value;
            oDr["pub_Fecha_Vto"] = dteFecVto;
            oDr["pub_Fecha_Ini"] = dteFecIni;
            oDr["pub_Precio"] = nudPrecio.Value;
            oDr["pub_visibilidad_Id"] = cmbTipoVis.SelectedValue;
            oDr["pub_estado_Id"] = cmbEstado.SelectedValue;
            oDr["pub_Permite_Preg"] = chkPreguntas.Checked;
            oDr["pub_usu_id"] = Singleton.usuario["usu_id"];
            oDr["pub_vis_Precio"] = rowVis["pubvis_Precio"];
            oDr["pub_vis_Porcentaje"] = rowVis["pubvis_Porcentaje"];
            oDr["pub_Facturada"] = false;

            oDTPubli.Rows.Add(oDr);
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

            DataRowView vrow = (DataRowView)cmbTipoVis.SelectedItem;

            if (vrow != null)
            {
                if ((Convert.ToInt32(cmbEstado.SelectedValue) == 1) //Activa
                        && (Convert.ToDecimal(vrow.Row["pubvis_precio"]) == Convert.ToDecimal(0))) // Gratis
                    ValidarPubliGratuitas();
            }
        }

        private void ValidarPubliGratuitas()
        {
            if (CantGratis >= 3)
            {
                MessageBox.Show("No puede tener mas de 3 Publicaciones Gratuitas Activas.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoVis.SelectedIndex = -1;
            }
        }

        private void GenerarPublicacion_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm)
                this.Close();
        }
    }
}
