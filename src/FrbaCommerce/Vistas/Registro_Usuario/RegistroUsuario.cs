using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Vistas.Abm_Cliente;
using FrbaCommerce.Vistas.Abm_Empresa;

namespace FrbaCommerce.Vistas.Registro_Usuario
{
    public partial class RegistroUsuario : Form
    {
        public RegistroUsuario()
        {
            this.InitializeComponent();
            this.comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void RegistroUsuario_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Validación Textboxes
            if (this.username_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar nombre de usuario", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.passw_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar password", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.comboRol.Text == "")
            {
                MessageBox.Show("Debe Ingresar un Rol", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Cuando le doy click a "Siguiente >>" abro un Alta de Usuario o de Empresa, y a este form le mando el nombre y pass.

            if (this.comboRol.Text == "Cliente")
            {
                AltaCliente newWindow = new AltaCliente(this.username_textbox.Text, this.passw_textbox.Text);
                newWindow.ShowDialog();
            }

            if (this.comboRol.Text == "Empresa")
            {
                AltaEmpresa newWindow = new AltaEmpresa(this.username_textbox.Text, this.passw_textbox.Text);
                newWindow.ShowDialog();
            }


        }

        private void passw_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(comboRol.Text);

            
        }
    }
}
