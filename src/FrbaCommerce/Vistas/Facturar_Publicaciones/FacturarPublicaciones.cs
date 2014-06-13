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
        decimal decAcum = 0;

        DataTable oDtFactEcab;
        DataTable oDtFactDet;
        DataTable oDtCobrar;
        DataTable oDtBonif;

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

        private void FacturarPublicaciones_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
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

        private void dgvPubli_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPubli.Columns["Facturar"].Index)
            {
                dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                dgvPubli.EndEdit();  //Cancelo la Edicion para Confirmar el cambio.-

                //ValidarCompras
                if ((Convert.ToBoolean(dgvPubli.Rows[e.RowIndex].Cells["Facturar"].Value))
                    && (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].ToString() == "C"))
                {
                    if (!ValidarComprasAnteriores(e.ColumnIndex, e.RowIndex))
                    {
                        dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }

                //Validar Bonificacion
                if (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].ToString() == "P")
                {
                    CalcularBonificacion(e.ColumnIndex, e.RowIndex);
                }

                CalcularAcumulado();
                CalcularValores();
            }
        }

        private void dgvPubli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPubli.Columns["Facturar"].Index)
            {
                dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;

                dgvPubli.EndEdit(); //Cancelo la Edicion para Confirmar el cambio.-

                //ValidarCompras
                if ((Convert.ToBoolean(dgvPubli.Rows[e.RowIndex].Cells["Facturar"].Value))
                    && (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].ToString() == "C"))
                {
                    if (!ValidarComprasAnteriores(e.ColumnIndex, e.RowIndex))
                    {
                        dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }

                //Validar Bonificacion
                if (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].ToString() == "P")
                {
                    CalcularBonificacion(e.ColumnIndex, e.RowIndex);
                }

                CalcularAcumulado();
                CalcularValores();
            }
        }

        private void CalcularBonificacion(int colIndex, int rowIndex)
        {
            int cantbonif;
            DataRow[] aDrs;

            EliminarBonificaciones();

            foreach (DataGridViewRow row in dgvPubli.Rows)
            {
                if ((!Convert.ToBoolean(row.Cells["Facturar"].Value))
                    && ((row.Cells["Tipo"].ToString() == "P")))
                {
                    aDrs = oDtBonif.Select("ucftv_vis_Id = " + row.Cells["pub_visibilidad_Id"]);

                    if (aDrs.Length > 0)
                    {
                        cantbonif = Convert.ToInt32(aDrs[2]) + 1;

                        if ((cantbonif % 10) == 0) //Se bonifica.-
                        {
                            dgvPubli.Rows.Add(row.Cells["pub_Codigo"], //pub_Codigo
                                            0, //comp_Id
                                            true, //Facturar
                                            row.Cells["pub_Codigo"], //Codigo Publi
                                            "B", //Tipo
                                            Singleton.FechaDelSistema, //Fecha
                                            "Bonificacion 10 Publicaciones (Nro.Pub: " + row.Cells["pub_Codigo"].ToString() + ")", //Concepto
                                            1, //Cantidad
                                            (Convert.ToDecimal(row.Cells["Importe"]) * -1), //Importe
                                            row.Cells["pub_visibilidad_Id"]);
                        }
                    }
                }
            }
        }

        private void EliminarBonificaciones()
        {
            foreach (DataGridViewRow row in dgvPubli.Rows)
            {
                if (row.Cells["Tipo"].ToString() == "B")
                {
                    dgvPubli.Rows.Remove(row);
                }
            }
        }

        private bool ValidarComprasAnteriores(int colIndex, int rowIndex)
        {
            bool valida = true;

            for (int i = rowIndex - 1; i >= 0; i--)
            {
                if ((!Convert.ToBoolean(dgvPubli.Rows[i].Cells["Facturar"].Value))
                    &&((dgvPubli.Rows[i].Cells["Tipo"].ToString() == "C")))
                {
                    MessageBox.Show("No puede pagar la Compra de la Fila " + rowIndex.ToString() +
                        " sin antes haber pagado las compras de Fechas anteriores.");
                    valida = false;
                    break;
                }
            }

            return valida;
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

            if (cancel)
            {
                txtUsuName.Text = string.Empty;
                dgvPubli.DataSource = null;
                if (oDtCobrar != null) oDtCobrar.Rows.Clear();
                if (oDtBonif != null) oDtBonif.Rows.Clear();
            }
            else
            {
                oDtCobrar.AsEnumerable().All(c => { c["Facturar"] = false; return true; });
                dgvPubli.DataSource = oDtCobrar;
                ConfigurarGrilla();
                CalcularAcumulado();
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
            CargarGrillaPendientes();

            if (oDtCobrar.Rows.Count == 0)
            {
                MessageBox.Show("No hay Pendientes de Facturación.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
                Limpiar(true);
                HabilitarMod(false);
            }
            else
            {
                HabilitarMod(true);
                dgvPubli.Focus();
                CalcularAcumulado();
            }
        }

        private void CalcularAcumulado()
        {
            decAcum = oDtCobrar.AsEnumerable().Sum(x => x.Field<decimal>("Importe"));
            txtAcum.Text = "$ " + decAcum.ToString();
            CalcularValores();
        }

        private void CargarGrillaPendientes()
        {
            try
            {
                dgvPubli.DataSource = null;

                oDtCobrar = InterfazBD.BuscarPendientesFact(usu_Id);
                oDtBonif = InterfazBD.getCantFactxTipoVis(usu_Id);

                dgvPubli.DataSource = oDtCobrar;
                ConfigurarGrilla();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al Obtener Datos: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void ConfigurarGrilla()
        {
            dgvPubli.Columns["pub_Codigo"].Visible = false;
            dgvPubli.Columns["comp_Id"].Visible = false;

            dgvPubli.Columns["Codigo Publi"].ReadOnly = true;
            dgvPubli.Columns["Tipo"].ReadOnly = true;
            dgvPubli.Columns["Fecha"].ReadOnly = true;
            dgvPubli.Columns["Concepto"].ReadOnly = true;
            dgvPubli.Columns["Cantidad"].ReadOnly = true;
            dgvPubli.Columns["Importe"].ReadOnly = true;
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (((DataTable)dgvPubli.DataSource).Select("FACTURAR = true").Length <= 0)
            {
                mensaje = mensaje + "Debe Seleccionar al menos 1 item para Facturar." + System.Environment.NewLine;
                datosOk = false;
            }

            if (cmbFormaPago.SelectedIndex < 0)
            {
                mensaje = mensaje + "Debe Seleccionar la Forma de Pago de la Factura." + System.Environment.NewLine;
                datosOk = false;
            }

            if (txtTarjeta.Visible)
            {
                if (txtTarjeta.Text == "")
                {
                    mensaje = mensaje + "Debe Informar los datos de la Tarjeta." + System.Environment.NewLine;
                    datosOk = false;
                }
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

            foreach (DataGridViewRow gDr in dgvPubli.Rows)
            {
                if (Convert.ToBoolean(gDr.Cells["Facturar"].Value))
                {
                    oDr = oDtFactDet.NewRow();

                    oDr["facdet_fac_Numero"] = 0;
                    oDr["facdet_pub_Codigo"] = gDr.Cells["pub_Codigo"].Value;
                    oDr["facdet_comp_Id"] = gDr.Cells["comp_Id"].Value;
                    oDr["facdet_Concepto"] = gDr.Cells["Concepto"].Value;
                    oDr["facdet_Cantidad"] = gDr.Cells["Cantidad"].Value;
                    oDr["facdet_Importe"] = gDr.Cells["Importe"].Value;

                    oDtFactDet.Rows.Add(oDr);
                }
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

        private void CalcularValores()
        {
            decTotal = 0;
            int count = 0;

            foreach (DataGridViewRow row in dgvPubli.Rows)
            {
                if (Convert.ToBoolean(row.Cells["Facturar"].Value))
                {
                    decTotal = decTotal + Convert.ToDecimal(row.Cells["Importe"].Value);
                    count++;
                }
            }

            txtSaldo.Text = "$ " + (decAcum - decTotal).ToString();
            txtCantItems.Text = count.ToString();
            txtTotal.Text = "$ " + decTotal.ToString();
        }

    }
}
