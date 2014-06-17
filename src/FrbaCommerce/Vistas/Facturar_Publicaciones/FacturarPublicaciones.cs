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
        int cantBonif = 0;
        decimal decBonif = 0;

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

        private void btnHistBonif_Click(object sender, EventArgs e)
        {
            HistorialBinificacion oFrm = new HistorialBinificacion();
            oFrm.Icon = this.Icon;
            oFrm._Datos = oDtBonif;
            oFrm.ShowDialog();
        }

        private void dgvPubli_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            string RowsNumber = (e.RowIndex + 1).ToString();

            SizeF size = e.Graphics.MeasureString(RowsNumber, this.Font);

            if (dgvPubli.RowHeadersWidth < Convert.ToInt32(size.Width + 20))
            {
                dgvPubli.RowHeadersWidth = Convert.ToInt32(size.Width + 20);
            }

            Brush ob = SystemBrushes.ControlText;
            e.Graphics.DrawString(RowsNumber, this.Font, ob, e.RowBounds.Location.X + 15, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dgvPubli_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPubli.Columns["Facturar"].Index)
            {
                //Invertimos el valor del Check.
                dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dgvPubli.EndEdit();  //Cancelo la Edicion para Confirmar el cambio.-

                //Validar Compras - Debe Cancelar en orden de Fecha Desc.
                if (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "C")
                {
                    if (!ValidarComprasAnteriores(e.ColumnIndex, e.RowIndex))
                    {
                        //Si no es Valido lo Destildo.-
                        dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }

                //Validar Bonificacion - Cada 10 Costos de Pub de un mismo Tipo 1 Bonif.-
                if (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "P")
                {
                    CalcularBonificacion(e.ColumnIndex, e.RowIndex);
                }

                //Actualizamos los Totales
                CalcularValores();
            }
        }

        private void dgvPubli_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPubli.Columns["Facturar"].Index)
            {
                //Invertimos el valor del Check.
                dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = !(bool)dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                dgvPubli.EndEdit();  //Cancelo la Edicion para Confirmar el cambio.-

                //Validar Compras - Debe Cancelar en orden de Fecha Desc.
                if ((Convert.ToBoolean(dgvPubli.Rows[e.RowIndex].Cells["Facturar"].Value))
                    && (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "C"))
                {
                    if (!ValidarComprasAnteriores(e.ColumnIndex, e.RowIndex))
                    {
                        //Si no es Valido lo Destildo.-
                        dgvPubli.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = false;
                    }
                }

                //Validar Bonificacion - Cada 10 Costos de Pub de un mismo Tipo 1 Bonif.-
                if (dgvPubli.Rows[e.RowIndex].Cells["Tipo"].Value.ToString() == "P")
                {
                    CalcularBonificacion(e.ColumnIndex, e.RowIndex);
                }

                //Actualizamos los Totales
                CalcularValores();
            }
        }

        private void CalcularBonificacion(int colIndex, int rowIndex)
        {
            DataTable oDtBonifAux = oDtBonif.Copy();
            DataTable oDtCobAux = oDtCobrar.Clone();
            DataRow[] aDrs;
            DataRow oDr;

            int contador = 0;

            EliminarBonificaciones(); //Elimino todas para Recalcular.-

            foreach (DataGridViewRow row in dgvPubli.Rows)
            {
                if ((Convert.ToBoolean(row.Cells["Facturar"].Value)) //Si esta Marcada
                    && ((row.Cells["Tipo"].Value.ToString() == "P"))) //Si es Costo x Publicar
                {
                    //Obtengo el contador por Visibilidad
                    aDrs = oDtBonifAux.Select("ucftv_vis_Id = " + row.Cells["pub_visibilidad_Id"].Value);

                    if (aDrs.Length > 0)
                    {
                        contador = Convert.ToInt32(aDrs[0]["ucftv_Cantidad"]) + 1;
                        aDrs[0]["ucftv_Cantidad"] = contador;

                        if ((contador % 10) == 0) //Si es multiplo de 10 => Se bonifica.-
                        {
                            oDr = oDtCobAux.NewRow();

                            oDr["pub_Codigo"] = row.Cells["pub_Codigo"].Value;
                            oDr["comp_Id"] = 0;
                            oDr["Facturar"] = true;
                            oDr["Codigo Publi"] = row.Cells["pub_Codigo"].Value;
                            oDr["Tipo"] = "B";
                            oDr["Fecha"] = Singleton.FechaDelSistema.ToShortDateString();
                            oDr["Concepto"] = "Bonificacion 10 Publicaciones (Nro.Pub: " + row.Cells["pub_Codigo"].Value.ToString() + ")";
                            oDr["Cantidad"] = 1;
                            oDr["Importe"] = (Convert.ToDecimal(row.Cells["Importe"].Value) * -1);
                            oDr["pub_visibilidad_Id"] = row.Cells["pub_visibilidad_Id"].Value;
                            oDr["FechaDte"] = Singleton.FechaDelSistema;

                            oDtCobAux.Rows.Add(oDr);
                        }
                    }
                }
            }

            //Inserto las bonificaciones calculadas.
            if (oDtCobAux.Rows.Count > 0)
            {
                DataRow newRow;

                foreach (DataRow row in oDtCobAux.Rows)
                {
                    newRow = oDtCobrar.NewRow();
                    newRow.ItemArray = row.ItemArray;
                    oDtCobrar.Rows.InsertAt(newRow, 0);
                }
            }

            //inicializo contadores
            cantBonif = 0;
            decBonif = 0;

            //Cambio el color de las Filas de las Bonificaciones
            foreach (DataGridViewRow row in dgvPubli.Rows)
            {
                if(row.Cells["Tipo"].Value.ToString() == "B")
                {
                    row.DefaultCellStyle.BackColor = Color.LightBlue;
                    cantBonif++;
                    decBonif = decBonif + Convert.ToDecimal(row.Cells["Importe"].Value);
                }
            }

            txtCantBonif.Text = cantBonif.ToString();
            txtBonif.Text = "$ " + decBonif.ToString();
        }

        private void EliminarBonificaciones()
        {
            List<int> listIndex = new List<int>();

            //Obtengo la Lista con los Index de las Bonificaciones.-
            foreach(DataGridViewRow row in dgvPubli.Rows)
            {
                if (row.Cells["Tipo"].Value.ToString() == "B")
                {
                    listIndex.Add(row.Index);
                }
            }

            //Ordeno la Lista de Mayor a Menor
            listIndex.Reverse();

            //Elimino las Filas de Bonificaciones.-
            foreach (int iindex in listIndex)
            {
                dgvPubli.Rows.RemoveAt(iindex);
            }
        }

        private bool ValidarComprasAnteriores(int colIndex, int rowIndex)
        {
            bool valida = true;
            DateTime fechaComp = Convert.ToDateTime(dgvPubli.Rows[rowIndex].Cells["Fecha"].Value);

            if (Convert.ToBoolean(dgvPubli.Rows[rowIndex].Cells["Facturar"].Value))
            {
                foreach (DataGridViewRow row in dgvPubli.Rows)
                {
                    //Obtener la fecha y buscar las anteriores Todo DataSet
                    if ((!Convert.ToBoolean(row.Cells["Facturar"].Value)) //Si no esta marcada
                        && ((row.Cells["Tipo"].Value.ToString() == "C"))) //Y es compra.-
                    {
                        //Si tiene menor fecha informo.
                        if (Convert.ToDateTime(row.Cells["Fecha"].Value) < fechaComp)
                        {
                            MessageBox.Show("No puede pagar la Compra de la Fila " + (rowIndex + 1).ToString() +
                                " sin antes haber pagado las compras de Fechas anteriores.",
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                            valida = false;

                            break;
                        }
                    }
                }
            }
            else
            {
                foreach (DataGridViewRow row in dgvPubli.Rows)
                {
                    if ((Convert.ToBoolean(row.Cells["Facturar"].Value)) //Si esta marcada
                        && ((row.Cells["Tipo"].Value.ToString() == "C"))) //Y es compra.-
                    {
                        //Si tiene fecha mayor, la destildo.
                        if (Convert.ToDateTime(row.Cells["Fecha"].Value) > fechaComp)
                        {
                            row.Cells["Facturar"].Value = false;
                            valida = false;
                        }
                    }
                }

                MessageBox.Show("No puede pagar las Compra con una Fecha mayor a la de la Fila " + (rowIndex + 1).ToString(),
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            txtCantBonif.Text = "0";
            txtSaldo.Text = "$ 0,00";
            txtTotal.Text = "$ 0,00";
            txtBonif.Text = "$ 0,00";

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
            dgvPubli.EndEdit(); //Cancelo edicion antes de calcular los valores.
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

                if (oDtBonif.Rows.Count == 0)
                    btnHistBonif.Visible = false;
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
            dgvPubli.Columns["pub_visibilidad_id"].Visible = false;
            dgvPubli.Columns["FechaDte"].Visible = false;

            dgvPubli.Columns["Codigo Publi"].ReadOnly = true;
            dgvPubli.Columns["Tipo"].ReadOnly = true;
            dgvPubli.Columns["Fecha"].ReadOnly = true;
            dgvPubli.Columns["Concepto"].ReadOnly = true;
            dgvPubli.Columns["Cantidad"].ReadOnly = true;
            dgvPubli.Columns["Importe"].ReadOnly = true;

            dgvPubli.Columns[0].Width = 100;
            dgvPubli.Columns[1].Width = 100;
            dgvPubli.Columns[2].Width = 54;
            dgvPubli.Columns[3].Width = 89;
            dgvPubli.Columns[4].Width = 43;
            dgvPubli.Columns[5].Width = 73;
            dgvPubli.Columns[6].Width = 274;
            dgvPubli.Columns[7].Width = 60;
            dgvPubli.Columns[8].Width = 53;
            dgvPubli.Columns[9].Width = 100;
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
            oDr["fac_usu_Id"] = usu_Id;
            oDr["fac_Fecha"] = Singleton.FechaDelSistema;
            oDr["fac_usu_id_gen"] = Singleton.usuario["usu_Id"];
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

            txtSaldo.Text = "$ " + (decAcum - decTotal + decBonif).ToString();
            txtCantItems.Text = count.ToString();
            txtTotal.Text = "$ " + decTotal.ToString();
        }
    }
}
