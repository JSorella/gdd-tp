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
    public partial class Abm_Cliente_Baja : Form
    {
        private int cli_Tipodoc_Id;
        private string cli_Nro_Doc;
        
        DataTable oDtCliente;

        public Abm_Cliente_Baja()
        {
            InitializeComponent();
        }

        private void Abm_Empresa_Baja_Load(object sender, EventArgs e)
        {
            this.comboDoc.DataSource = InterfazBD.getTiposDoc();
            this.comboDoc.DisplayMember = "tipodoc_Descripcion";
            this.comboDoc.ValueMember = "tipodoc_Id";
            this.comboDoc.SelectedIndex = -1;
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
                            this.cli_Nro_Doc = "";
                            this.txtNroDoc.Text = "";
                            this.cli_Tipodoc_Id = 0;
                            this.comboDoc.SelectedIndex = -1;
                        }
                    }
                }
                catch (Exception error)
                {
                    Funciones.mostrarAlert("Error en Baja Clientes: " + error.Message, this.Text);
                }
            }
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Clientes_Busqueda oFrm = new Abm_Clientes_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtCliente = InterfazBD.getClienteUsuario(Convert.ToInt32(oFrm.Resultado["cli_Tipodoc_Id"]), 
                                                            oFrm.Resultado["cli_Nro_Doc"].ToString());

                this.cli_Tipodoc_Id = Convert.ToInt32(oDtCliente.Rows[0]["cli_Tipodoc_Id"]);
                this.cli_Nro_Doc = oDtCliente.Rows[0]["cli_Nro_Doc"].ToString();

                this.comboDoc.SelectedValue = this.cli_Tipodoc_Id;
                this.txtNroDoc.Text = this.cli_Nro_Doc.ToString();
            }
        }

        private bool ValidarBaja()
        {
            if (txtNroDoc.Text == "")
            {
                Funciones.mostrarAlert("Debe indicar el Número de Documento del Cliente.", "Atención");
                return false;
            }

            if (comboDoc.Text == "")
            {
                Funciones.mostrarAlert("Debe indicar el Tipo de Documento del Cliente.", "Atención");
                return false;
            }

            DataTable oDtCliente = InterfazBD.getClienteUsuario(Convert.ToInt32(comboDoc.SelectedValue), 
                                                                txtNroDoc.Text);

            if (oDtCliente != null)
            {
                if (oDtCliente.Rows.Count <= 0)
                {
                    Funciones.mostrarAlert("Cliente Inexistente", "Aviso");
                    return false;
                }
            }
            else
            {
                Funciones.mostrarAlert("Cliente Inexistente", "Aviso");
                return false;
            }

            cli_Tipodoc_Id = Convert.ToInt32(oDtCliente.Rows[0]["cli_Tipodoc_Id"]);
            cli_Nro_Doc = oDtCliente.Rows[0]["cli_Nro_Doc"].ToString();

            return true;
        }

        private bool RealizarBaja()
        {
            bool result;

            try
            {
                result = InterfazBD.setBajaCliente(this.cli_Tipodoc_Id, this.cli_Nro_Doc);

                Funciones.mostrarInformacion("El cliente fue dado de baja con exito", "Operacion Exitosa");
                return result; 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }  
        }

        private void txtNroDoc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Funciones.SoloNumeros(e.KeyChar);
        }

        private void txtNroDoc_TextChanged(object sender, EventArgs e)
        {
            txtNroDoc.Text = Funciones.ValidaTextoSoloNumerosConFiltro(txtNroDoc.Text, "");
        }

    }
}
