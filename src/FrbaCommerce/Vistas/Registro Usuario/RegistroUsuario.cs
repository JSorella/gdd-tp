using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

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
        }

        private void passw_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Console.WriteLine(comboRol.Text);

            if (comboRol.Text == "Cliente")
            { 

            }

            if (comboRol.Text == "Empresa")
            { 
            }
            if (comboRol.Text == "")
            {
            }
        }
    }
}
