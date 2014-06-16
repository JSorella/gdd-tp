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
    public partial class Usuarios_Baja : Form
    {
        private int usu_Id;
        
        DataTable oDtCliente;

        public Usuarios_Baja()
        {
            InitializeComponent();
        }


        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea dar de Baja este cliente?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                try
                {
                    if (ValidarBaja())
                    {
                        if (RealizarBaja())
                        {
                            this.txtUserName.Text = "";
                            this.usu_Id = 0;
                        }
                    }
                }
                catch (Exception error)
                {
                    Funciones.mostrarAlert("Error en Baja Usuarios: " + error.Message, this.Text);
                }
            }
        }

        

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BuscarUsuario oFrm = new BuscarUsuario();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtCliente = InterfazBD.getUsuarioConRoles(oFrm.Resultado["Usuario"].ToString());
                this.usu_Id = Convert.ToInt32(oDtCliente.Rows[0]["usu_Id"]);
                this.txtUserName.Text = oFrm.Resultado["Usuario"].ToString();
            }
        }

        private bool ValidarBaja()
        {
            if (txtUserName.Text == "")
            {
                Funciones.mostrarAlert("Debe indicar el nombre de Usuario.", "Atención");
                return false;
            }


            DataTable oDtUsuario = InterfazBD.getUsuarioConRoles(txtUserName.Text);

            if (oDtUsuario != null)
            {
                if (oDtUsuario.Rows.Count <= 0)
                {
                    Funciones.mostrarAlert("Usuario Inexistente", "Aviso");
                    return false;
                }
            }
            else
            {
                Funciones.mostrarAlert("Usuario Inexistente", "Aviso");
                return false;
            }      

            return true;
        }

        private bool RealizarBaja()
        {
            bool result;


            result = InterfazBD.setBajaUsuario(this.usu_Id);

            Funciones.mostrarInformacion("El usuario fue dado de baja con exito","Operacion Exitosa");
            return result;   
        }

    }
}
