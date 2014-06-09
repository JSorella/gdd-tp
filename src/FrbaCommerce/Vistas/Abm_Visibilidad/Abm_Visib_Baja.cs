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
    public partial class Abm_Visib_Baja : Form
    {
        int pubvis_Id = 0;

        public Abm_Visib_Baja()
        {
            InitializeComponent();
        }

        private void Abm_Visib_Baja_Load(object sender, EventArgs e)
        {
            pubvis_Id = 0;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Visibilidad_Buscar oFrm = new Abm_Visibilidad_Buscar();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                txtCodVisib.Text = oFrm.Resultado["Codigo"].ToString();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea dar de Baja esta Visibilidad?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidarBaja())
                {
                    if (RealizarBaja())
                    {
                        pubvis_Id = 0;
                        txtCodVisib.Text = "";
                    }
                }
            }
        }

        private void txtCodVisib_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private bool ValidarBaja()
        {
            if (txtCodVisib.Text == "")
            {
                MessageBox.Show("Debe indicar el Codigo de la Visibilidad.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DataTable oDtVisb = InterfazBD.getVisibilidad(Convert.ToInt32(txtCodVisib.Text));

                if (oDtVisb != null)
                {
                    if (oDtVisb.Rows.Count <= 0)
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

                pubvis_Id = Convert.ToInt32(oDtVisb.Rows[0]["pubvis_id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private bool RealizarBaja()
        {
            bool result;

            try
            {
                result = InterfazBD.RealizarBajaVisibilidad(pubvis_Id);

                MessageBox.Show("Su Visibilidad fue dada de Baja con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
