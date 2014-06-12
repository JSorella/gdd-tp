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
    public partial class FacturarPublicaciones : Form
    {
        int usu_Id = 0;
        decimal decTotal = 0;

        DataTable oDtFactEcab;
        DataTable oDtFactDet;
        DataTable oDtCobrar;

        bool cerrarForm = false;

        public FacturarPublicaciones()
        {
            InitializeComponent();
        }

        private void FacturarPublicaciones_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            CargarCombos();
            Limpiar(true);
            HabilitarMod(false);
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BuscarUsuario oFrm = new BuscarUsuario();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                usu_Id = Convert.ToInt32(oFrm.Resultado["usu_Id"]);
                txtUsuName.Text = oFrm.Resultado["Usuario"].ToString();

                Aplicar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                Aplicar();
            }
        }

        private void cmbFormaPago_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox oCmb = (ComboBox)sender;

            if (Convert.ToInt32(oCmb.SelectedValue) == 2)
            {
                lblInfoTarjeta.Visible = true;
                txtTarjeta.Visible = true;
            }
            else
            {
                lblInfoTarjeta.Visible = false;
                txtTarjeta.Visible = false;
                txtTarjeta.Text = "";
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Generar la Factura?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(true);
                HabilitarMod(false);
            }
        }

        private void ArmarDataTables()
        {
            if (cerrarForm) return;

            try
            {
                oDtFactEcab = InterfazBD.getDTFactEncab();
                oDtFactDet = InterfazBD.getDTFactDet();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ArmarDataTables: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void Limpiar(bool cancel)
        {
            if (cerrarForm) return;

            cmbFormaPago.SelectedIndex = -1;
            txtTarjeta.Text = string.Empty;

            lblInfoTarjeta.Visible = false;
            txtTarjeta.Visible = false;

            txtAcum.Text = "$ 0,00";
            txtCantItems.Text = "0";
            txtSaldo.Text = "$ 0,00";
            txtTotal.Text = "$ 0,00";

            oDtFactEcab.Rows.Clear();
            oDtFactDet.Rows.Clear();
            if(oDtCobrar != null) oDtCobrar.Rows.Clear();

            if (cancel)
            {
                txtUsuName.Text = string.Empty;
                dgvPubli.DataSource = null;
            }
            else
            {
                //DestildarGrilla
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
        }

        private void CargarCombos()
        {
            if (cerrarForm) return;

            try
            {
                cmbFormaPago.ValueMember = "fdp_Id";
                cmbFormaPago.DisplayMember = "fdp_Descripcion";
                cmbFormaPago.DataSource = InterfazBD.getFormasDePago();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarCombos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private bool ValidaAceptar()
        {
            if (txtUsuName.Text == "")
            {
                MessageBox.Show("Debe indicar un Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DataTable oDt = InterfazBD.getUsuario(txtUsuName.Text);

                if (oDt != null)
                {
                    if (oDt.Rows.Count <= 0)
                    {
                        MessageBox.Show("Usuario Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                usu_Id = Convert.ToInt32(oDt.Rows[0]["usu_Id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Aplicar()
        {
            HabilitarMod(true);
            CargarGrillaPendientes();
            dgvPubli.Focus();
        }

        private void CargarGrillaPendientes()
        {
            try
            {
                dgvPubli.DataSource = null;
                oDtCobrar = InterfazBD.BuscarPendientesFact(usu_Id);
                dgvPubli.DataSource = oDtCobrar;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Obtener Datos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (decTotal <= 0)
            {
                mensaje = mensaje + "Debe Seleccionar al menos 1 item para Facturar." + System.Environment.NewLine;
                datosOk = false;
            }

            if (!datosOk)
                MessageBox.Show(mensaje, "Validaciones - Generar Factura", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return datosOk;
        }

        private bool Generar()
        {
            String[] result;

            try
            {
                CargarDTFactEncab();
                CargarDTFactDet();

                result = "true|@nroFact".Split('|');
                result = InterfazBD.GenerarFactura(oDtFactEcab, oDtFactDet).Split('|');

                MessageBox.Show("La Factura fue generada con exito." + System.Environment.NewLine + "Numero de Factura: " + result[1].ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return Convert.ToBoolean(result[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDTFactDet()
        {
            DataTable gDt = (DataTable)dgvPubli.DataSource;
            DataRow oDr;

            foreach (DataRow gDr in gDt.Rows)
            {
                oDr = oDtFactDet.NewRow();

                oDr["facdet_fac_Numero"] = 0;
                oDr["facdet_pub_Codigo"] = gDr["pub_Codigo"];
                oDr["facdet_comp_Id"] = gDr["comp_Id"];
                oDr["facdet_CompId"] = gDr["Concepto"];
                oDr["facdet_Cantidad"] = gDr["Cantidad"];
                oDr["facdet_Importe"] = gDr["Importe"];

                oDtFactDet.Rows.Add(oDr);
            }
        }

        private void CargarDTFactEncab()
        {
            oDtFactEcab.Rows.Clear();

            DataRow oDr = oDtFactEcab.NewRow();

            oDr["fac_Numero"] = 0;
            oDr["fac_usu_Id"] = Singleton.usuario["usu_id"];
            oDr["fac_Fecha"] = Singleton.FechaDelSistema;
            oDr["fac_Total"] = decTotal;

            if(txtTarjeta.Text != "")
                oDr["fac_Forma_Pago_Desc"] = cmbFormaPago.Text + " - " + txtTarjeta.Text;
            else
                oDr["fac_Forma_Pago_Desc"] = cmbFormaPago.Text;

            oDtFactEcab.Rows.Add(oDr);
        }

        private void FacturarPublicaciones_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
        }
    }
}
