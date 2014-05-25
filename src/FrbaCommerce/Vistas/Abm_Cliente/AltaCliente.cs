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
    }
}
