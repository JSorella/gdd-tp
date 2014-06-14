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
    public partial class EleccionRol : Form
    {
        DataTable oDTRoles;

        public DataTable RolesTable
        {
            get { return oDTRoles; }
            set { oDTRoles = value; }
        }

        public EleccionRol()
        {
            this.InitializeComponent();
        }

        private void EleccionRol_Load(object sender, EventArgs e)
        {
            this.cmbRoles.DataSource = oDTRoles;
            this.cmbRoles.ValueMember = "rol_Id";
            this.cmbRoles.DisplayMember = "rol_Nombre";
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            Singleton.sessionRol_Id = Convert.ToInt32(cmbRoles.SelectedValue);
            this.Close();
        }
    }
}
