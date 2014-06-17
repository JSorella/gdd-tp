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
        DataTable oDtClienteUsuario;
        DateTime dteFecNac;

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
            HabilitarMod(false);

            this.comboDocEleccion.DataSource = InterfazBD.getTiposDoc();
            this.comboDocEleccion.DisplayMember = "tipodoc_Descripcion";
            this.comboDocEleccion.ValueMember = "tipodoc_Id";
            this.comboDocEleccion.SelectedIndex = -1;

            this.comboDoc.DataSource = InterfazBD.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
            this.comboDoc.SelectedIndex = -1;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Clientes_Busqueda oFrm = new Abm_Clientes_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtCliente = InterfazBD.getClienteUsuario(Convert.ToInt32(oFrm.Resultado["cli_Tipodoc_Id"]), Convert.ToInt32(oFrm.Resultado["cli_Nro_Doc"]));
                this.cli_Tipodoc_Id = Convert.ToInt32(oDtCliente.Rows[0]["cli_Tipodoc_Id"]);
                this.cli_Nro_Doc = Convert.ToInt32(oDtCliente.Rows[0]["cli_Nro_Doc"]);

                this.comboDocEleccion.SelectedValue = this.cli_Tipodoc_Id;
                this.txtNroDoc.Text = this.cli_Nro_Doc.ToString();
            }
        }

        private void CargarDatosCliente()
        {
            DataRow clienteUsuario = oDtClienteUsuario.Rows[0];

            this.nombre_textbox.Text = clienteUsuario["cli_Nombre"].ToString();
            this.apellido_textbox.Text = clienteUsuario["cli_Apellido"].ToString();
            this.comboDoc.SelectedValue = Convert.ToInt32(clienteUsuario["cli_Tipodoc_Id"]);
            this.dni_textbox.Text = clienteUsuario["cli_Nro_Doc"].ToString();
            this.mail_textbox.Text = clienteUsuario["cli_Mail"].ToString();
            this.telefono_textbox.Text = clienteUsuario["cli_Tel"].ToString();
            this.calle_textbox.Text = clienteUsuario["cli_Dom_Calle"].ToString();
            this.altura_textbox.Text = clienteUsuario["cli_Nro_Calle"].ToString();
            this.piso_textbox.Text = clienteUsuario["cli_Piso"].ToString();
            this.depto_textbox.Text = clienteUsuario["cli_Dpto"].ToString();
            this.localidad_textbox.Text = clienteUsuario["cli_Localidad"].ToString();
            this.cp_textbox.Text = clienteUsuario["cli_CP"].ToString();
            this.txtCuil.Text = clienteUsuario["cli_Cuil"].ToString();
            dteFecNac = Convert.ToDateTime(clienteUsuario["cli_Fecha_Nac"]);
            this.fechaNacimiento.Text = dteFecNac.ToShortDateString();

            chkboxHabilitada.Checked = Convert.ToBoolean(clienteUsuario["usu_Inhabilitado"]);
        }

        private void HabilitarMod(bool habilitado)
        {
            if (cerrarForm) return;

            pnlDatos.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGuardar.Enabled = habilitado;
        }

        private void Aplicar()
        {
            CargarDatosCliente();
            HabilitarMod(true);
        }

        private bool ValidaAceptar()
        {
            if (this.txtNroDoc.Text == "")
            {
                MessageBox.Show("Debe indicar el Nro de Documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.comboDocEleccion.Text == "")
            {
                MessageBox.Show("Debe indicar el Tipo de Documento.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDtClienteUsuario = InterfazBD.getClienteUsuario(Convert.ToInt32(comboDocEleccion.SelectedValue), Convert.ToInt32(this.txtNroDoc.Text));

                if (oDtClienteUsuario != null)
                {
                    if (oDtClienteUsuario.Rows.Count <= 0)
                    {
                        MessageBox.Show("Cliente Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Cliente Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            try
            {
                if (!ValidarCampos())
                    return;

                DataRow oDr = oDtClienteUsuario.Rows[0];

                oDtCliente = InterfazBD.getClienteUsuario(Convert.ToInt32(oDr["cli_Tipodoc_Id"]), Convert.ToInt32(oDr["cli_Nro_Doc"]));

                DataRow clienteUsuario = oDtCliente.Rows[0];

                clienteUsuario.BeginEdit();

                //Cliente
                clienteUsuario["cli_Nombre"] = this.nombre_textbox.Text;
                clienteUsuario["cli_Apellido"] = this.apellido_textbox.Text;
                clienteUsuario["cli_Tipodoc_Id"] = Convert.ToInt32(this.comboDoc.SelectedValue);
                clienteUsuario["cli_Nro_Doc"] = Convert.ToInt32(this.dni_textbox.Text);
                clienteUsuario["cli_Mail"] = this.mail_textbox.Text;
                clienteUsuario["cli_Tel"] = this.telefono_textbox.Text;
                clienteUsuario["cli_Dom_Calle"] = this.calle_textbox.Text;
                clienteUsuario["cli_Nro_Calle"] = Convert.ToInt32(this.altura_textbox.Text);
                clienteUsuario["cli_Piso"] = Convert.ToInt32(this.piso_textbox.Text);
                clienteUsuario["cli_Dpto"] = this.depto_textbox.Text;
                clienteUsuario["cli_Localidad"] = this.localidad_textbox.Text;
                clienteUsuario["cli_CP"] = this.cp_textbox.Text;
                clienteUsuario["cli_Fecha_Nac"] = dteFecNac;
                clienteUsuario["cli_Cuil"] = txtCuil.Text;

                //Usuario
                clienteUsuario["usu_Inhabilitado"] = chkboxHabilitada.Checked ? 1 : 0;

                clienteUsuario.EndEdit();

                InterfazBD.actualizarCliente(oDtCliente);
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
                if (this.nombre_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Nombre", this.Text); return false;
                }
                if (this.apellido_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Apellido", this.Text); return false;
                }
                if (this.dni_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese DNI", this.Text); return false;
                }
                if (this.comboDocEleccion.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Tipo Documento", this.Text); return false;
                }
                if (this.txtCuil.Text.Replace(" ", "").Length != 13)
                {
                    Funciones.mostrarAlert("Ingrese Cuil", this.Text); return false;
                }
                if (this.mail_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Email", this.Text); return false;
                }
                if (this.apellido_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Apellido", this.Text); return false;
                }
                if (this.telefono_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Teléfono", this.Text); return false;
                }
                if (this.calle_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Calle", this.Text); return false;
                }
                if (this.altura_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Altura Calle", this.Text); return false;
                }
                if (this.localidad_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Localidad", this.Text); return false;
                }
                if (this.cp_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Código Postal", this.Text); return false;
                }
                if (this.fechaNacimiento.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Fecha Nacimiento", this.Text); return false;
                }

                DataRow oDr = oDtClienteUsuario.Rows[0];

                //Validamos que el teléfono no lo tenga otro usuario
                InterfazBD.existeOtroTelefono(this.telefono_textbox.Text, Convert.ToInt32(oDr["cli_usu_Id"]));

                //Validamos que el Cuil no esté repetido
                InterfazBD.existeCuil(this.txtCuil.Text, Convert.ToInt32(oDr["cli_usu_Id"]));

                //Validamos que el DNI no lo tenga otro usuario
                InterfazBD.existeOtroDni(
                    Convert.ToInt32(this.comboDoc.SelectedValue)
                    , Convert.ToInt32(this.dni_textbox.Text)
                    , Convert.ToInt32(oDr["cli_usu_Id"]));

                return true;
            }
            catch (Exception ex)
            {
                Funciones.mostrarAlert(ex.Message, this.Text);
                return false;
            }
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Solo numeros por tecla presionada
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            //Solo numero por Copiar/Pegar
            TextBox oTxt = (TextBox)sender;
            oTxt.Text = Funciones.ValidaTextoSoloNumerosConFiltro(oTxt.Text, "");
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            ControlFecha oFrm = new ControlFecha(ppos.X, ppos.Y, false);
            oFrm.FechaSeleccionada = dteFecNac;
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecNac = oFrm.FechaSeleccionada;

            fechaNacimiento.Text = dteFecNac.ToShortDateString();
        }

    }
}
