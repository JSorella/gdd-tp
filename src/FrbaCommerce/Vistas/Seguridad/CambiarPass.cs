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
    public partial class CambiarPass : Form
    {
        int usu_Id;
        bool admin = true;

        public CambiarPass()
        {
            InitializeComponent();
        }

        private void CambiarPass_Load(object sender, EventArgs e)
        {
            Limpiar(true);
            HabilitarMod(false);

            //Si no es admin solo puede modificar su propia pass.-
            if (Singleton.sessionRol_Id != 1)
            {
                admin = false;
                txtUsuName.Text = Singleton.usuario["usu_UserName"].ToString();
                usu_Id = Convert.ToInt32(Singleton.usuario["usu_id"]);
                Aplicar();
            }
        }

        private void Limpiar(bool cancel)
        {
            if (cancel) txtUsuName.Text = string.Empty;
            
            txtconfirm.Text = string.Empty;
            txtnewpass.Text = string.Empty;
        }

        private void HabilitarMod(bool habilitado)
        {
            pnlParam.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGenerar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            BuscarUsuario oFrm = new BuscarUsuario();
            oFrm.ShowDialog();
            
            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                usu_Id = Convert.ToInt32(oFrm.Resultado["usu_Id"]);
                txtUsuName.Text = oFrm.Resultado["Usuario"].ToString();

                Aplicar();
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                Aplicar();
            }
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Guardar los cambios en el Rol?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidaGenerar())
                {
                    if (Generar())
                    {
                        Limpiar(true);
                        HabilitarMod(false);
                        if (!admin) this.Close();
                    }
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(true);
                HabilitarMod(false);
                if (!admin) this.Close();
            }
        }

        private bool ValidaAceptar()
        {
            if (txtUsuName.Text == "")
            {
                MessageBox.Show("Debe indicar un Usuario.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                DataTable oDt = InterfazBD.getUsuario(txtUsuName.Text);

                if (oDt != null)
                {
                    if (oDt.Rows.Count <= 0)
                    {
                        MessageBox.Show("Usuario Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Usuario Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                usu_Id = Convert.ToInt32(oDt.Rows[0]["usu_Id"]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void Aplicar()
        {
            HabilitarMod(true);
            txtnewpass.Focus();
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (txtnewpass.Text == "")
            {
                mensaje = mensaje + "Debe indicar la nueva contraseña." + System.Environment.NewLine;
                txtnewpass.Text = "";
                datosOk = false;
            }

            if (txtnewpass.Text != "" && txtconfirm.Text == "")
            {
                mensaje = mensaje + "Debe confirmar la contraseña ingresada." + System.Environment.NewLine;
                txtconfirm.Text = "";
                datosOk = false;
            }

            if (!datosOk)
            {
                MessageBox.Show(mensaje, "Validaciones - Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return datosOk;
            }

            if (txtnewpass.Text != txtconfirm.Text)
            {
                MessageBox.Show("Las contraseñas deben ser Iguales.", "Validaciones - Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtconfirm.Text = "";
                datosOk = false;
            }

            return datosOk;
        }

        private bool Generar()
        {
            bool result;

            try
            {
                result = InterfazBD.CambiarPassUsuario(usu_Id, Funciones.get_hash(txtnewpass.Text));

                MessageBox.Show("Su contraseña fue modificada con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }
    }
}
