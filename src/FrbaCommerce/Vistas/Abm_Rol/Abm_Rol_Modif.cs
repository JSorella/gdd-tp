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
    public partial class Abm_Rol_Modif : Form
    {
        DataTable oDtRol; //Datos del Rol
        DataTable oDtRolFun;//Relacion - Roles_Funcionalidades

        bool cerrarForm = false;

        public Abm_Rol_Modif()
        {
            InitializeComponent();
        }

        private void Abm_Rol_Modif_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            CargarFuncionalidades();
            Limpiar(true);
            HabilitarMod(false);
        }

        private void ArmarDataTables()
        {
            if (cerrarForm) return;

            try
            {
                oDtRol = InterfazBD.getDTRol();
                oDtRolFun = InterfazBD.getDTRol_Fun();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en ArmarDataTables: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void CargarFuncionalidades()
        {
            try
            {
                //DataSource es el origen de los datos en nuestro caso la tabla que alberga las funcionalidades
                listfunc.DataSource = InterfazBD.getFuncionalidades();

                //Displaymember es la columna de la tabla que se va a mostrar en nuestro caso hay una sola
                listfunc.DisplayMember = "fun_nombre";

                //ValueMembermember es el valor que tiene el campo seleccionado en nuestro caso ponemos la PK
                listfunc.ValueMember = "fun_id";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en CargarFuncionalidades: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                cerrarForm = true;
            }
        }

        private void Limpiar(bool cancel)
        {
            if (cerrarForm) return;

            if (cancel) txtRolName.Text = string.Empty;
            txtNombre.Text = string.Empty;

            //destildamos todas las opciones
            for (int i = 0; i < (listfunc.Items.Count); i++)
                listfunc.SetItemChecked(i, false);

            oDtRol.Rows.Clear();
            oDtRolFun.Rows.Clear();
        }

        private void HabilitarMod(bool habilitado)
        {
            if (cerrarForm) return;

            pnlParam.Enabled = !habilitado;
            pnlDatos.Enabled = habilitado;
            btnGenerar.Enabled = habilitado;
            btnLimpiar.Enabled = habilitado;
            btnCancelar.Enabled = habilitado;
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Abm_Rol_Busqueda oFrm = new Abm_Rol_Busqueda();
            oFrm.ShowDialog();

            if ((oFrm.Resultado != null)) //Resultado es el DataRow.-
            {
                oDtRol = InterfazBD.getRol(oFrm.Resultado["Nombre"].ToString());

                txtRolName.Text = oFrm.Resultado["Nombre"].ToString();

                Aplicar();
            }
        }

        private void Aplicar()
        {
            CargarDatosRol();
            HabilitarMod(true);
            chkInhabilitado.Focus();
        }

        private void CargarDatosRol()
        {
            DataRow oDr = oDtRol.Rows[0];

            txtNombre.Text = oDr["rol_Nombre"].ToString();
            chkInhabilitado.Checked = Convert.ToBoolean(oDr["rol_Inhabilitado"]);

            MarcarFuncionalidades();
        }

        private void MarcarFuncionalidades()
        {
            oDtRolFun = InterfazBD.getRoles_Funcionalidades(Convert.ToInt32(oDtRol.Rows[0]["rol_Id"]));

            int index = 0;

            foreach (DataRow oDr in oDtRolFun.Rows)
            {
                index = listfunc.FindStringExact(oDr["fun_Nombre"].ToString());
                listfunc.SetItemChecked(index, true);
            }
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (ValidaAceptar())
            {
                Aplicar();
            }
        }

        private bool ValidaAceptar()
        {
            if (txtRolName.Text == "")
            {
                MessageBox.Show("Debe indicar el Nombre del Rol.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            try
            {
                oDtRol = InterfazBD.getRol(txtRolName.Text);

                if (oDtRol != null)
                {
                    if (oDtRol.Rows.Count <= 0)
                    {
                        MessageBox.Show("Rol Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("Rol Inexistente.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
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
                    }
                }
            }
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (txtNombre.Text == "")
            {
                mensaje = mensaje + "Debe indicar un Nombre." + System.Environment.NewLine;
                datosOk = false;
            }

            if (listfunc.CheckedIndices.Count <= 0)
            {
                mensaje = mensaje + "Debe seleccionar al menos una Funcionalidad." + System.Environment.NewLine;
                datosOk = false;
            }

            if (!datosOk)
                MessageBox.Show(mensaje, "Validaciones - Modificar Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return datosOk;
        }

        private bool Generar()
        {
            bool result;

            try
            {
                CargarDTRol();
                CargarDtFuncs();

                result = InterfazBD.ModificarRol(oDtRol, oDtRolFun);

                MessageBox.Show("Su Rol fue grabado con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDtFuncs()
        {
            DataRow oDr;

            try
            {
                oDtRolFun = InterfazBD.getDTRol_Fun();

                foreach (int x in listfunc.CheckedIndices)
                {
                    oDr = oDtRolFun.NewRow();

                    listfunc.SelectedIndex = x;

                    oDr["rolfun_rol_Id"] = oDtRol.Rows[0]["rol_Id"];
                    oDr["rolfun_fun_Id"] = listfunc.SelectedValue;

                    oDtRolFun.Rows.Add(oDr);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private void CargarDTRol()
        {
            DataRow oDr = oDtRol.Rows[0];

            oDr.BeginEdit();

            oDr["rol_Nombre"] = txtNombre.Text;
            oDr["rol_Inhabilitado"] = chkInhabilitado.Checked;

            oDr.EndEdit();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Limpiar los datos ingresados?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                Limpiar(false);
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea Cancelar los datos ingresados?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Limpiar(true);
                HabilitarMod(false);
            }
        }

        private void Abm_Rol_Modif_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm) this.Close();
        }
    }
}
