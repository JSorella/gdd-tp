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
    public partial class Abm_Cliente_Modif : Form
    {
        DataTable oDtEmpresaUsuario;
        DateTime dteFecCreac;

        bool cerrarForm = false;

        private int cli_Tipodoc_Id;
        private int cli_Nro_Doc;

        DataTable oDtCliente;

        public Abm_Cliente_Modif()
        {
            InitializeComponent();
        }
        private void Abm_Cliente_Modif_Load(object sender, EventArgs e)
        {
            //Limpiar(true);
            HabilitarMod(false);
            this.comboDoc.DataSource = InterfazBD.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
            this.comboDoc.SelectedIndex = -1;
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

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Empresas_Busqueda oFrm = new Abm_Empresas_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtCliente = InterfazBD.getClienteUsuario(Convert.ToInt32(oFrm.Resultado["cli_Tipodoc_Id"]), Convert.ToInt32(oFrm.Resultado["cli_Nro_Doc"]));
                this.cli_Tipodoc_Id = Convert.ToInt32(oDtCliente.Rows[0]["cli_Tipodoc_Id"]);
                this.cli_Nro_Doc = Convert.ToInt32(oDtCliente.Rows[0]["cli_Nro_Doc"]);

                this.comboDoc.SelectedIndex = this.cli_Tipodoc_Id;
                this.txtNroDoc.Text = this.cli_Nro_Doc.ToString();
            }
        }

        private void CargarDatosEmpresa()
        {
            DataRow oDr = oDtEmpresaUsuario.Rows[0];

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

            if (Convert.ToInt32(oDr["usu_Eliminado"]) == 1)
                chkboxEliminada.Checked = true;

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
            //tboxEmpresaSeleccionada.Focus();
        }

        private bool ValidaAceptar()
        {
            //if (tboxEmpresaSeleccionada.Text == "")
            //{
            //    MessageBox.Show("Debe indicar el CUIT de una empresa.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    return false;
            //}

            try
            {
                //oDtEmpresaUsuario = InterfazBD.getEmpresaUsuario(tboxEmpresaSeleccionada.Text);

                if (oDtEmpresaUsuario != null)
                {
                    if (oDtEmpresaUsuario.Rows.Count <= 0)
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
            if (!ValidarCampos())
                return;

            try
            {
                DataTable oDtEmpresaUsuario = new DataTable();
                //oDtEmpresaUsuario = InterfazBD.getEmpresaUsuario(tboxEmpresaSeleccionada.Text);

                DataRow oDr = oDtEmpresaUsuario.Rows[0];

                oDr.BeginEdit();

                //Cliente
                oDr["emp_Razon_Social"] = tboxRazonSocial.Text;
                oDr["emp_Cuit"] = tboxCUIT.Text;
                oDr["emp_Mail"] = tboxMail.Text;
                oDr["emp_Tel"] = tboxTelefono.Text;
                oDr["emp_Contacto"] = tboxNombreContacto.Text;
                oDr["emp_Fecha_Creacion"] = tboxFechaCreacion.Text;
                oDr["emp_Dom_Calle"] = tboxCalle.Text;
                oDr["emp_Nro_Calle"] = tboxAltura.Text;
                oDr["emp_Piso"] = tboxPiso.Text;
                oDr["emp_Dpto"] = tboxDpto.Text;
                oDr["emp_Localidad"] = tboxLocalidad.Text;
                oDr["emp_CP"] = tboxCodPostal.Text;
                oDr["emp_Ciudad"] = tboxCiudad.Text;

                //Usuario
                oDr["usu_Eliminado"] = chkboxEliminada.Checked ? 1 : 0;

                oDr.EndEdit();

                InterfazBD.ActualizarEmpresa(oDtEmpresaUsuario);
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
                return;
            }

            Funciones.mostrarInformacion("El Cliente ha sido modificado con exito.", this.Text);
            this.Close();
        }

        private Boolean ValidarCampos()
        {
            try
            {
                if (this.tboxRazonSocial.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Razon Social", this.Text); return false;
                }
                if (this.tboxCUIT.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese CUIT", this.Text); return false;
                }
                if (this.tboxMail.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Mail", this.Text); return false;
                }
                if (this.tboxTelefono.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Telefono", this.Text); return false;
                }
                if (this.tboxNombreContacto.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Nombre de Contacto", this.Text); return false;
                }
                if (this.tboxFechaCreacion.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Fecha de Creacion", this.Text); return false;
                }
                if (this.tboxCalle.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Calle", this.Text); return false;
                }
                if (this.tboxAltura.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Altura", this.Text); return false;
                }
                if (this.tboxLocalidad.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Localidad", this.Text); return false;
                }
                if (this.tboxCodPostal.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Codigo POstal", this.Text); return false;
                }
                if (this.tboxCiudad.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Ciudad", this.Text); return false;
                }

                return true;
            }
            catch (Exception ex)
            {
                Funciones.mostrarAlert(ex.Message, this.Text);
                return false;
            }
        }
    }
}
