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
    public partial class Abm_Rol_Baja : Form
    {
        int rol_id = 0;

        public Abm_Rol_Baja()
        {
            InitializeComponent();
        }

        private void Abm_Rol_Baja_Load(object sender, EventArgs e)
        {
            rol_id = 0;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Rol_Busqueda oFrm = new Abm_Rol_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                rol_id = Convert.ToInt32(oFrm.Resultado["Id"]);
                txtRol.Text = oFrm.Resultado["Nombre"].ToString();
            }
        }

        private void btnBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea dar de Baja este Rol?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidarBaja())
                {
                    if (RealizarBaja())
                    {
                        rol_id = 0;
                        txtRol.Text = "";
                    }
                }
            }
        }

        private bool ValidarBaja()
        {
            if (txtRol.Text == "")
            {
                MessageBox.Show("Debe indicar el Nombre del Rol.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DataTable oDtRol = InterfazBD.getRol(txtRol.Text);

                if (oDtRol != null)
                {
                    if (oDtRol.Rows.Count <= 0)
                    {
                        MessageBox.Show("Rol Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Rol Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                rol_id = Convert.ToInt32(oDtRol.Rows[0]["rol_id"]);

                if (rol_id < 4)
                {
                    MessageBox.Show("No tiene Permisos para dar de Baja este Rol, ya que es un Rol propio del Sistema. Gracias", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private bool RealizarBaja()
        {
            bool result;

            try
            {
                result = InterfazBD.RealizarBajaRol(rol_id);

                MessageBox.Show("Su Rol fue dado de Baja con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
