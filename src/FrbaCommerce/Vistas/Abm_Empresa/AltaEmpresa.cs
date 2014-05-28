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
    public partial class AltaEmpresa : Form
    {
        private string usuario;
        private string pass;

        public AltaEmpresa()        //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            InitializeComponent();
        }

        public AltaEmpresa(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            InitializeComponent();
        }

        private void AltaEmpresa_Load(object sender, EventArgs e)
        {

        }
    }
}
