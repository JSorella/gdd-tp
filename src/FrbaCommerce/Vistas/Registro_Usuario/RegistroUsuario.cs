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
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            this.InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (!validarCampos())
                    return;

                // Cuando le doy click a "Siguiente >>" abro un Alta de Usuario o de Empresa, y a este form le mando el nombre y pass.
                if (this.cmbRoles.Text == "Cliente")
                {
                    Abm_Cliente_Alta newWindow = new Abm_Cliente_Alta(this.txtUserName.Text, this.txtPass.Text);
                    newWindow.Icon = this.Icon;
                    newWindow.ShowDialog();
                }

                if (this.cmbRoles.Text == "Empresa")
                {
                    Abm_Empresa_Alta newWindow = new Abm_Empresa_Alta(this.txtUserName.Text, this.txtPass.Text);
                    newWindow.Icon = this.Icon;
                    newWindow.ShowDialog();
                }
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
            }

            this.Close();
        }

        private bool validarCampos()
        {
            try
            {            
                // Validación Textboxes
                if (this.txtUserName.Text == "")
                {
                    Funciones.mostrarAlert("Debe Ingresar nombre de usuario", this.Text);
                    return false;
                }

                if (this.txtPass.Text == "")
                {
                    Funciones.mostrarAlert("Debe Ingresar password", this.Text);
                    return false;
                }

                if (this.cmbRoles.Text == "")
                {
                    Funciones.mostrarAlert("Debe Ingresar un Rol", this.Text);
                    return false;
                }

                //Validamos que el nombre de usuario no existe actualmente...
                InterfazBD.existeUsuario(this.txtUserName.Text);

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
