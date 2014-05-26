using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Abm_Cliente
{
    public partial class AltaCliente : Form
    {

        private string usuario;
        private string pass;


        public AltaCliente()    //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            InitializeComponent();
        }

        public AltaCliente(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            InitializeComponent();
        }

        private void AltaCliente_Load(object sender, EventArgs e)
        {
            this.comboDoc.DropDownStyle = ComboBoxStyle.DropDownList; //cambio style en combo
            this.comboDoc.DataSource = StoredProcedures.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void nombre_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.validarCampos();

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

                StoredProcedures.setNuevoCliente(cliente);
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message);
                return;
            }
        }

        private void validarCampos()
        {
            if (this.nombre_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Nombre"); return;
            }
            if (this.apellido_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Apellido"); return;
            }
            if (this.dni_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese DNI"); return;
            }
            if (this.comboDoc.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Tipo Documento"); return;
            }
            if (this.cuil_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Cuil"); return;
            }

            if (this.mail_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Email"); return;
            }
            if (this.apellido_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Apellido"); return;
            }
            if (this.telefono_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Teléfono"); return;
            }
            if (this.calle_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Calle"); return;
            }
            if (this.altura_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Altura Calle"); return;
            }
            if (this.piso_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Piso"); return;
            }
            if (this.depto_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Departamento"); return;
            }
            if (this.localidad_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Localidad"); return;
            }
            if (this.cp_textbox.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Código Postal"); return;
            }
            if (this.fechaNacimiento.Text == "")
            {
                Funciones.mostrarAlert("Ingrese Fecha Nacimiento"); return;
            }
        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void altura_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerFechaAlta_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cuil_textbox_TextChanged(object sender, EventArgs e)
        {

        }

    }
}
