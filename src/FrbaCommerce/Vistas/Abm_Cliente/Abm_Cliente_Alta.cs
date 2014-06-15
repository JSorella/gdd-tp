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
        DateTime dteFecCreac;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            try
            {
                altaAdminDatosUsuario();


                DataTable DTCliente = new DataTable();
                DTCliente = InterfazBD.getDTCliente();

                DTCliente.Rows.Clear();

                DataRow clienteUsuario = DTCliente.NewRow();
                //Cliente
                clienteUsuario["cli_Nombre"] = this.nombre_textbox.Text;
                clienteUsuario["cli_Apellido"] = this.apellido_textbox.Text;
                clienteUsuario["cli_Tipodoc_Id"] = Convert.ToInt32(((DataRowView)this.comboDoc.SelectedItem).Row["tipodoc_Id"]);
                clienteUsuario["cli_Nro_Doc"] = Convert.ToInt64(this.dni_textbox.Text);
                clienteUsuario["cli_Mail"] = this.mail_textbox.Text;
                clienteUsuario["cli_Tel"] = Convert.ToInt64(this.telefono_textbox.Text);
                clienteUsuario["cli_Dom_Calle"] = this.calle_textbox.Text;
                clienteUsuario["cli_Nro_Calle"] = Convert.ToInt32(this.altura_textbox.Text);
                clienteUsuario["cli_Piso"] = Convert.ToInt32(this.piso_textbox.Text);
                clienteUsuario["cli_Dpto"] = this.depto_textbox.Text;
                clienteUsuario["cli_Localidad"] = this.localidad_textbox.Text; 
                clienteUsuario["cli_CP"] = this.cp_textbox.Text;
                clienteUsuario["cli_Fecha_Nac"] = (DateTime)this.dteFecCreac;
                clienteUsuario["cli_Cuil"] = Convert.ToInt64(this.cuil_textbox.Text);
                clienteUsuario["cli_usu_Id"] = 0;
                //Usuario
                clienteUsuario["usu_Id"] = 0;
                clienteUsuario["usu_UserName"] = this.usuario;
                clienteUsuario["usu_Pass"] = Funciones.get_hash(this.pass);  //Encripto el Password;
                clienteUsuario["usu_Cant_Intentos"] = 0;
                clienteUsuario["usu_Inhabilitado"] = 0;
                clienteUsuario["usu_Motivo"] = "";
                clienteUsuario["usu_Eliminado"] = 0;
                clienteUsuario["usu_Primer_Ingreso"] = this.usu_Primer_Ingreso ? 1 : 0;
                clienteUsuario["usu_Inhabilitado_Comprar"] = 0;

                DTCliente.Rows.Add(clienteUsuario);

                InterfazBD.setNuevoCliente(DTCliente);
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
                return;
            }

            Funciones.mostrarInformacion("El Cliente ha sido dado de alta exitosamente!!", this.Text);
            this.Close();
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
                    Funciones.mostrarAlert("Ingrese DNI", this.Text); return false;
                }
                if (this.comboDoc.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Tipo Documento", this.Text); return false;
                }
                if (this.cuil_textbox.Text == "")
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
                if (this.piso_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Piso", this.Text); return false;
                }
                if (this.depto_textbox.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Departamento", this.Text); return false;
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
                InterfazBD.existeTelefono(Convert.ToInt64(this.telefono_textbox.Text));

                //Validamos que el DNI no esté repetido
                InterfazBD.existeDni(
                    Convert.ToInt32(((DataRowView)this.comboDoc.SelectedItem).Row["tipodoc_Id"]),
                    Convert.ToInt64(this.dni_textbox.Text));

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
            if (Singleton.sessionRol_Id == 1) //Soy el Admin
            {
                this.usuario = this.dni_textbox.Text + ((DataRowView)this.comboDoc.SelectedItem).Row["tipodoc_Id"];
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
                dteFecCreac = oFrm.FechaSeleccionada;
                fechaNacimiento.Text = oFrm.FechaSeleccionada.ToShortDateString();
        }

        private void textbox_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }
    }
}
