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
    public partial class Abm_Empresa_Modif : Form
    {
        DataTable oDtEmpresa;
        DateTime dteFecCreac;

        bool cerrarForm = false;

        public Abm_Empresa_Modif()
        {
            InitializeComponent();
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecCreac = oFrm.FechaSeleccionada;
            tboxFechaCreacion.Text = oFrm.FechaSeleccionada.ToShortDateString();
        }

        private void Abm_Empresa_Modif_Load(object sender, EventArgs e)
        {
            //Limpiar(true);
            HabilitarMod(false);
            tboxEmpresaSeleccionada.Focus();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Empresas_Busqueda oFrm = new Abm_Empresas_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtEmpresa = InterfazBD.getEmpresa(oFrm.Resultado["emp_CUIT"].ToString());

                tboxEmpresaSeleccionada.Text = oFrm.Resultado["emp_CUIT"].ToString();
            }
        }

        private void CargarDatosEmpresa()
        {
            DataRow oDr = oDtEmpresa.Rows[0];

            tboxRazonSocial.Text = oDr["emp_Razon_Social"].ToString();
            tboxMail.Text = oDr["emp_Mail"].ToString();
            tboxTelefono.Text = oDr["emp_Tel"].ToString();
            tboxCUIT.Text = oDr["emp_CUIT"].ToString();
            tboxNombreContacto.Text = oDr["emp_Contacto"].ToString();
            dteFecCreac = Convert.ToDateTime(oDr["emp_Fecha_Creacion"]);
            tboxCalle.Text = oDr["emp_Dom_Calle"].ToString();
            tboxAltura.Text = oDr["emp_Nro_Calle"].ToString();
            tboxPiso.Text = oDr["emp_Piso"].ToString();
            tboxDpto.Text = oDr["emp_Dpto"].ToString();
            tboxLocalidad.Text = oDr["emp_Localidad"].ToString();
            tboxCiudad.Text = oDr["emp_Ciudad"].ToString();
            tboxCodPostal.Text = oDr["emp_CP"].ToString();

            tboxFechaCreacion.Text = dteFecCreac.ToShortDateString();

            if (Convert.ToInt32(oDr["usu_Inhabilitado"]) == 1)
            {
                chkboxInhabilitada.Checked = true;
            }
        }

        private void HabilitarMod(bool habilitado)
        {
            if (cerrarForm) return;

            pnlDatos.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGuardar.Enabled = habilitado;
            //btnLimpiar.Enabled = habilitado;
            //btnCancelar.Enabled = habilitado;
        }

        private void Aplicar()
        {
            CargarDatosEmpresa();
            HabilitarMod(true);
            tboxEmpresaSeleccionada.Focus();
        }

        private bool ValidaAceptar()
        {
            if (tboxEmpresaSeleccionada.Text == "")
            {
                MessageBox.Show("Debe indicar el CUIT de una empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDtEmpresa = InterfazBD.getEmpresa(tboxEmpresaSeleccionada.Text);

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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                Aplicar();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

        }

    }
}
