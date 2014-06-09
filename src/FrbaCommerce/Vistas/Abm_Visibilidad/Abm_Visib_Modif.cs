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
    public partial class Abm_Visib_Modif : Form
    {
        DataTable oDtVisib;
        bool cerrarForm = false;

        public Abm_Visib_Modif()
        {
            InitializeComponent();
        }

        private void Abm_Visib_Modif_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            Limpiar(true);
            HabilitarMod(false);
        }

        private void Abm_Visib_Modif_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
        }

        private void txtCodVisib_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void btnSelPubli_Click(object sender, EventArgs e)
        {
            Abm_Visibilidad_Buscar oFrm = new Abm_Visibilidad_Buscar();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtVisib = InterfazBD.getVisibilidad(Convert.ToInt32(oFrm.Resultado["Codigo"]));

                txtCodVisib.Text = oFrm.Resultado["Codigo"].ToString();

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

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea guardar los cambios en la Visibilidad?", "Modificar Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
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
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", "Modificar Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", "Modificar Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(true);
                HabilitarMod(false);
            }
        }

        private void ArmarDataTables()
        {
            try
            {
                oDtVisib = InterfazBD.getDTVisibilidades();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ArmarDataTables: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void Limpiar(bool cancel)
        {
            if (cancel) txtCodVisib.Text = string.Empty;

            txtCodigo.Text = string.Empty;
            txtDesc.Text = string.Empty;
            nudDiasVto.Value = 0;
            nudPorcentaje.Value = 0;
            nudPrecio.Value = 0;

            oDtVisib.Rows.Clear();
        }

        private bool ValidaAceptar()
        {
            if (txtCodVisib.Text == "")
            {
                MessageBox.Show("Debe indicar un Codigo de Visibilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDtVisib = InterfazBD.getVisibilidad(Convert.ToInt32(txtCodVisib.Text));

                if (oDtVisib != null)
                {
                    if (oDtVisib.Rows.Count <= 0)
                    {
                        MessageBox.Show("Visibilidad Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Visibilidad Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void Aplicar()
        {
            CargarDatosVisib();
            HabilitarMod(true);
            txtCodigo.Focus();
        }

        private void CargarDatosVisib()
        {
            DataRow oDr = oDtVisib.Rows[0];

            txtCodigo.Text = oDr["pubvis_Codigo"].ToString();
            txtDesc.Text = oDr["pubvis_Descripcion"].ToString();
            nudPrecio.Value = Convert.ToDecimal(oDr["pubvis_Precio"]);
            nudPorcentaje.Value = Convert.ToDecimal(oDr["pubvis_Porcentaje"]);
            nudDiasVto.Value = Convert.ToDecimal(oDr["pubvis_Dias_Vto"]);
        }

        private void CargarDTVisib()
        {
            DataRow oDr = oDtVisib.Rows[0];

            oDr.BeginEdit();

            oDr["pubvis_Codigo"] = txtCodigo.Text;
            oDr["pubvis_Descripcion"] = txtDesc.Text;
            oDr["pubvis_Precio"] = nudPrecio.Value;
            oDr["pubvis_Porcentaje"] = nudPorcentaje.Value;
            oDr["pubvis_Dias_Vto"] = nudDiasVto.Value;

            oDr.EndEdit();
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

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (txtCodigo.Text == "")
            {
                mensaje = mensaje + "Debe indicar un Codigo." + System.Environment.NewLine;
                datosOk = false;
            }

            if (txtDesc.Text == "")
            {
                mensaje = mensaje + "Debe indicar una Descripcion." + System.Environment.NewLine;
                datosOk = false;
            }

            if (nudDiasVto.Value < 1)
            {
                mensaje = mensaje + "Debe indicar los Dias para Vencimiento Mayor o Igual a 1." + System.Environment.NewLine;
                datosOk = false;
            }

            //if (nudPorcentaje.Value < 1)
            //{
            //    mensaje = mensaje + "Debe indicar un Porcentaje Mayor o Igual a 1." + System.Environment.NewLine;
            //    datosOk = false;
            //}

            //if (nudPrecio.Value < 1)
            //{
            //    mensaje = mensaje + "Debe indicar un Precio Mayor o Igual a $1,00." + System.Environment.NewLine;
            //    datosOk = false;
            //}

            if (!datosOk)
                MessageBox.Show(mensaje, "Validaciones - Nueva Publicación", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return datosOk;
        }

        private bool Generar()
        {
            bool result;

            try
            {
                CargarDTVisib();

                result = InterfazBD.ModificarVisibilidad(oDtVisib);

                MessageBox.Show("Su Visibilidad fue grabada con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
