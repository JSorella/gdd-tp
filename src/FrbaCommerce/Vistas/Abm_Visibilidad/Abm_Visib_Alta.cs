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
    public partial class Abm_Visib_Alta : Form
    {
        DataTable oDtVisib;
        bool cerrarForm = false;

        public Abm_Visib_Alta()
        {
            InitializeComponent();
        }

        private void Abm_Visib_Alta_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea generar la Visibilidad?", "Nueva Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidaGenerar())
                {
                    if (Generar())
                    {
                        Limpiar();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", "Nueva Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Salir?", "Nueva Visibilidad", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                this.Close();
        }

        private void txtCodigo_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
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

        private void Limpiar()
        {
            txtCodigo.Text = string.Empty;
            txtDesc.Text = string.Empty;
            nudDiasVto.Value = 0;
            nudPorcentaje.Value = 0;
            nudPrecio.Value = 0;

            oDtVisib.Rows.Clear();
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
            {
                MessageBox.Show(mensaje, "Validaciones - Nueva Visbilidad", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDtVisib = InterfazBD.getVisibilidad(Convert.ToInt32(txtCodigo.Text));

                if (oDtVisib != null)
                {
                    if (oDtVisib.Rows.Count > 0)
                    {
                        MessageBox.Show("Ya existe una Visibilidad con este Codigo.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return datosOk;
        }

        private bool Generar()
        {
            bool result;

            try
            {
                CargarDTVisib();

                result = InterfazBD.NuevaVisibilidad(oDtVisib);

                MessageBox.Show("Su Visibilidad fue grabada con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDTVisib()
        {
            oDtVisib.Rows.Clear();

            DataRow oDr = oDtVisib.NewRow();

            oDr["pubvis_id"] = 0;
            oDr["pubvis_Codigo"] = txtCodigo.Text;
            oDr["pubvis_Descripcion"] = txtDesc.Text;
            oDr["pubvis_Precio"] = nudPrecio.Value;
            oDr["pubvis_Porcentaje"] = nudPorcentaje.Value;
            oDr["pubvis_Dias_Vto"] = nudDiasVto.Value;
            oDr["pubvis_Eliminado"] = false;

            oDtVisib.Rows.Add(oDr);
        }

        private void Abm_Visib_Alta_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
        }
    }
}
