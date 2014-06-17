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
    public partial class Abm_Cliente_Alta : Form
    {
        private string usuario;
        private string pass;
        DateTime dteFecNac;
        private bool usu_Primer_Ingreso;  

        public Abm_Cliente_Alta()    //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            this.usu_Primer_Ingreso = true;
            InitializeComponent();
        }

        public Abm_Cliente_Alta(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            this.usu_Primer_Ingreso = false; //si soy el usuario, no necesito cambiar contraseña, ya la elegi yo!
            InitializeComponent();
        }

        private void Abm_Cliente_Alta_Load(object sender, EventArgs e)
        {
            this.comboDoc.DataSource = InterfazBD.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
        }

        private void darDeAlta_Click(object sender, EventArgs e)
        {
            altaAdminDatosUsuario();

            if (!validarCampos())
                return;

            try
            {   
                DataTable DTCliente = new DataTable();
                DTCliente = InterfazBD.getDTClienteUsuario();

                DTCliente.Rows.Clear();

                DataRow clienteUsuario = DTCliente.NewRow();
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
                clienteUsuario["cli_Fecha_Nac"] = this.dteFecNac;
                clienteUsuario["cli_Cuil"] = this.txtCuil.Text;
                clienteUsuario["cli_usu_Id"] = 0;
                //Usuario
                clienteUsuario["usu_Id"] = 0;
                clienteUsuario["usu_UserName"] = this.usuario;
                clienteUsuario["usu_Pass"] = Funciones.get_hash(this.pass);  //Encripto el Password;
                clienteUsuario["usu_Cant_Intentos"] = 0;
                clienteUsuario["usu_Inhabilitado"] = 0;
                clienteUsuario["usu_Motivo"] = "";
                clienteUsuario["usu_Eliminado"] = 0;
                clienteUsuario["usu_Primer_Ingreso"] = this.usu_Primer_Ingreso;
                clienteUsuario["usu_Inhabilitado_Comprar"] = 0;

                DTCliente.Rows.Add(clienteUsuario);

                InterfazBD.setNuevoCliente(DTCliente);

                if (Singleton.sessionRol_Id == 1)
                    Funciones.mostrarInformacion("El Cliente ha sido dado de alta con exito.\n Usuario: " + usuario + "\n Password: " + pass, this.Text);
                else
                    Funciones.mostrarInformacion("El Cliente ha sido dado de alta con exito.", this.Text);

                this.Close();
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
                return;
            }
        }

        private Boolean validarCampos()
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
                    Funciones.mostrarAlert("Ingrese Nro. Doc", this.Text); return false;
                }
                if (this.comboDoc.Text == "")
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

                //Validamos que el nombre de usuario no existe actualmente... (otra vez, por si acaso)
                InterfazBD.existeUsuario(this.usuario);

                //Validamos que el teléfono no esté repetido
                InterfazBD.existeTelefono(this.telefono_textbox.Text);

                //Validamos que el Cuil no esté repetido
                InterfazBD.existeCuil(this.txtCuil.Text, 0);

                //Validamos que el DNI no esté repetido
                InterfazBD.existeDni(
                    Convert.ToInt32(comboDoc.SelectedValue),
                    Convert.ToInt32(this.dni_textbox.Text));

                return true;
            }
            catch (Exception ex)
            {
                Funciones.mostrarAlert(ex.Message, this.Text);
                return false;
            }
        }

        private void altaAdminDatosUsuario()
        {
            if (Singleton.sessionRol_Id == 1) //Rol Admin
            {
                this.usuario = this.dni_textbox.Text + (comboDoc.SelectedValue).ToString();
                // Estaría bueno que el password sea el Teléfono, pero dificulta el testing
                //this.pass = this.telefono_textbox.Text;
                this.pass = "p455w0rd";
            } 
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y, false);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecNac = oFrm.FechaSeleccionada;

            fechaNacimiento.Text = dteFecNac.ToShortDateString();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            //Solo numero por ingreso de teclas
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void textbox_TextChanged(object sender, EventArgs e)
        {
            //Solo numero por Copiar/Pegar
            TextBox oTxt = (TextBox)sender;

            oTxt.Text = Funciones.ValidaTextoSoloNumerosConFiltro(oTxt.Text, "");
        }
    }
}
