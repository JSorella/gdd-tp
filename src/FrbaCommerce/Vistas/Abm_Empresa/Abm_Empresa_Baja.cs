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
    public partial class Abm_Empresa_Baja : Form
    {
        DataTable oDtEmpresa;

        string emp_CUIT;

        public Abm_Empresa_Baja()
        {
            InitializeComponent();
        }

        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea dar de Baja esta Empresa?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidarBaja())
                {
                    if (RealizarBaja())
                    {
                        emp_CUIT = "";
                        tboxEmpresaSeleccionada.Text = "";
                    }
                }
            }
        }

        private void Abm_Empresa_Baja_Load(object sender, EventArgs e)
        {

        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Empresas_Busqueda oFrm = new Abm_Empresas_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtEmpresa = InterfazBD.getEmpresaUsuario(oFrm.Resultado["emp_CUIT"].ToString());

                tboxEmpresaSeleccionada.Text = oFrm.Resultado["emp_CUIT"].ToString();
            }
        }

        private bool ValidarBaja()
        {
            if (tboxEmpresaSeleccionada.Text == "")
            {
                MessageBox.Show("Debe indicar el CUIT de la empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DataTable oDtEmpresa = InterfazBD.getEmpresaUsuario(tboxEmpresaSeleccionada.Text);

                if (oDtEmpresa != null)
                {
                    if (oDtEmpresa.Rows.Count <= 0)
                    {
                        MessageBox.Show("Empresa Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Empresa Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                emp_CUIT = oDtEmpresa.Rows[0]["emp_CUIT"].ToString();
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
                result = InterfazBD.RealizarBajaEmpresa(emp_CUIT);

                MessageBox.Show("La empresa fue dada de baja con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

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
