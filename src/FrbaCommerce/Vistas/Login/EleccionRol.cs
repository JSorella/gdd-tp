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
    public partial class EleccionRol : Form
    {
        public EleccionRol()
        {
            this.InitializeComponent();
            this.comboRol.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void EleccionRol_Load(object sender, EventArgs e)
        {
            this.comboRol.DataSource = Singleton.usuario;
            this.comboRol.DisplayMember = "rol_Nombre";
            this.comboRol.ValueMember = "rol_Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //guardo el ID de rol en el Singleton
            DataRow selectedDataRow = ((DataRowView)comboRol.SelectedItem).Row;
            Singleton.sessionRol = Convert.ToInt32(selectedDataRow["rol_Id"]);

            MenuFunciones menuWindow = new MenuFunciones((int)this.comboRol.SelectedValue);
            menuWindow.ShowDialog();
            this.Close();
        }

        private void comboRol_SelectedIndexChanged(object sender, EventArgs e)
        {

            
        }
    }
}
