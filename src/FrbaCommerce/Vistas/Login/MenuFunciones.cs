using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Login
{
    public partial class MenuFunciones : Form
    {
        private int idRol;

        public MenuFunciones(int _idRol)
        {
            this.idRol = _idRol;
            this.InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void MenuFunciones_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
