﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Abm_Empresa_Alta : Form
    {
        private string usuario;
        private string pass;
        DateTime dteFecCreac;
        private bool usu_Primer_Ingreso;  

        public Abm_Empresa_Alta()        //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            this.usu_Primer_Ingreso = true;
            InitializeComponent();
        }

        public Abm_Empresa_Alta(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            this.usu_Primer_Ingreso = false; //si soy el usuario, no necesito cambiar contraseña, ya la elegi yo!
            InitializeComponent();
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y, false);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecCreac = oFrm.FechaSeleccionada;
                tboxFechaCreacion.Text = oFrm.FechaSeleccionada.ToShortDateString();
        }

        private void altaAdminDatosUsuario()
        {
            if (Singleton.sessionRol_Id == 1) //Soy el Admin
            {
                usuario = txtCuit.Text.Replace("-", "");
                pass = "p455w0rd";
            }
        }

        private Boolean ValidarCampos()
        {
            try
            {
                if (this.tboxRazonSocial.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Razon Social", this.Text); return false;
                }
                if (this.txtCuit.Text.Replace(" ", "").Length != 14)
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
                    Funciones.mostrarAlert("Ingrese Codigo Postal", this.Text); return false;
                }
                if (this.tboxCiudad.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Ciudad", this.Text); return false;
                }

                //Validamos que el CUIT no esté repetido
                InterfazBD.existeCUIT(txtCuit.Text);

                //Validamos que la Razon Social no esté repetida
                InterfazBD.existeRazonSocial(tboxRazonSocial.Text);

                return true;
            }
            catch (Exception ex)
            {
                Funciones.mostrarAlert(ex.Message, this.Text);
                return false;
            }
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                altaAdminDatosUsuario();


                DataTable oDtEmpresaUsuario = new DataTable();
                oDtEmpresaUsuario = InterfazBD.getDTEmpresaUsuario();

                oDtEmpresaUsuario.Rows.Clear();

                DataRow oDrEmpresaUsuario = oDtEmpresaUsuario.NewRow();
                //Empresa
                oDrEmpresaUsuario["emp_Razon_Social"] = tboxRazonSocial.Text;
                oDrEmpresaUsuario["emp_Cuit"] = txtCuit.Text;
                oDrEmpresaUsuario["emp_Mail"] = tboxMail.Text;
                oDrEmpresaUsuario["emp_Tel"] = tboxTelefono.Text;
                oDrEmpresaUsuario["emp_Contacto"] = tboxNombreContacto.Text;
                oDrEmpresaUsuario["emp_Fecha_Creacion"] = dteFecCreac;
                oDrEmpresaUsuario["emp_Dom_Calle"] = tboxCalle.Text;
                oDrEmpresaUsuario["emp_Nro_Calle"] = Convert.ToInt32(tboxAltura.Text);

                if(tboxPiso.Text == "")
                    oDrEmpresaUsuario["emp_Piso"] = Convert.ToInt32(0);
                else
                    oDrEmpresaUsuario["emp_Piso"] = Convert.ToInt32(tboxPiso.Text);

                oDrEmpresaUsuario["emp_Dpto"] = tboxDpto.Text;
                oDrEmpresaUsuario["emp_Localidad"] = tboxLocalidad.Text;
                oDrEmpresaUsuario["emp_CP"] = tboxCodPostal.Text;
                oDrEmpresaUsuario["emp_Ciudad"] = tboxCiudad.Text;
                oDrEmpresaUsuario["emp_usu_Id"] = 0;
                //Usuario
                oDrEmpresaUsuario["usu_Id"] = 0;
                oDrEmpresaUsuario["usu_UserName"] = this.usuario;
                oDrEmpresaUsuario["usu_Pass"] = Funciones.get_hash(this.pass);  //Encripto el Password;
                oDrEmpresaUsuario["usu_Cant_Intentos"] = 0;
                oDrEmpresaUsuario["usu_Inhabilitado"] = 0;
                oDrEmpresaUsuario["usu_Motivo"] = "";
                oDrEmpresaUsuario["usu_Eliminado"] = 0;
                oDrEmpresaUsuario["usu_Primer_Ingreso"] = this.usu_Primer_Ingreso;
                oDrEmpresaUsuario["usu_Inhabilitado_Comprar"] = 0;

                oDtEmpresaUsuario.Rows.Add(oDrEmpresaUsuario);

                InterfazBD.CargarEmpresa(oDtEmpresaUsuario);
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
                return;
            }

            if (Singleton.sessionRol_Id == 1)
                Funciones.mostrarInformacion("La Empresa ha sido dado de alta con exito.\n Usuario: " + usuario + "\n Password: " + pass, this.Text);
            else
                Funciones.mostrarInformacion("La Empresa ha sido dado de alta con exito.", this.Text);

            this.Close();
        }

        private void tboxAltura_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void tboxPiso_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void tboxTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
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
