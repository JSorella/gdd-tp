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

        public Abm_Cliente_Alta()    //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            InitializeComponent();
        }

        public Abm_Cliente_Alta(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
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
                Cliente cliente = new Cliente(
                                    this.usuario, 
                                    this.pass, 
                                    this.nombre_textbox.Text, 
                                    this.apellido_textbox.Text, 
                                    Convert.ToInt64(this.dni_textbox.Text), 
                                    Convert.ToInt32(((DataRowView)this.comboDoc.SelectedItem).Row["tipodoc_Id"]), 
                                    this.mail_textbox.Text, 
                                    Convert.ToInt64(this.telefono_textbox.Text), 
                                    this.calle_textbox.Text, 
                                    Convert.ToInt32(this.altura_textbox.Text), 
                                    Convert.ToInt32(this.piso_textbox.Text), 
                                    this.depto_textbox.Text, 
                                    this.localidad_textbox.Text, 
                                    this.cp_textbox.Text, 
                                    (DateTime)this.fechaNacimiento.Value,
                                    Convert.ToInt64(this.cuil_textbox.Text) 
                                    );

                InterfazBD.setNuevoCliente(cliente);
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

            return true;
        }
    }
}
