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
    public partial class Abm_Rol_Alta : Form
    {
        DataTable oDtFunRol;//Relacion - Roles_Funcionalidades

        bool cerrarForm = false;

        public Abm_Rol_Alta()
        {
            this.InitializeComponent();
        }

        private void Abm_Rol_Alta_Load(object sender, EventArgs e)
        {
            ArmarDataTables();
            CargarFuncionalidades();
            Limpiar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Confirma que desea grabar los Datos?", "Nuevo Rol", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (ValidaGenerar())
                {
                    if (Generar())
                    {
                        Limpiar();
                    }
                }
            }
        }

        private void ArmarDataTables()
        {
            try
            {
                oDtFunRol = InterfazBD.getDTRol_Fun();
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

        private void Limpiar()
        {
            if (cerrarForm) return;

            txtRolName.Text = string.Empty;

            //destildamos todas las opciones
            for (int i = 0; i < (listfunc.Items.Count); i++)
                listfunc.SetItemChecked(i, false);
        }

        private bool ValidaGenerar()
        {
            bool datosOk = true;
            string mensaje = "";

            if (txtRolName.Text == "")
            {
                mensaje = mensaje + "Debe ingresar un nombre de Rol.";
                datosOk = false;
            }

            if (listfunc.CheckedIndices.Count == 0)
            {
                mensaje = mensaje + "Debe seleccionar al menos una funcionalidad";
                datosOk = false;
            }

            //controlamos que el nombre de rol ingresado NO este en la base de datos
            if (InterfazBD.ExisteNombreRol(txtRolName.Text))
            {
                mensaje = mensaje + "El Nombre que indicó para el Nuevo Rol ya existe en el Sistema.";
                txtRolName.Text = string.Empty;
                datosOk = false;
            }

            if (!datosOk)
                MessageBox.Show(mensaje, "Validaciones - Nuevo Rol", MessageBoxButtons.OK, MessageBoxIcon.Error);

            return datosOk;
        }

        private bool Generar()
        {
            bool result;

            try
            {
                CargarDtFuncs(0);

                result = InterfazBD.NuevoRol(txtRolName.Text, oDtFunRol);

                MessageBox.Show("El Rol fue generado con exito.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

                return result;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void CargarDtFuncs(int rol_id)
        {
            oDtFunRol.Rows.Clear();
            DataRow oDr;

            foreach (int x in listfunc.CheckedIndices)
            {
                oDr = oDtFunRol.NewRow();

                listfunc.SelectedIndex = x;

                oDr["rolfun_rol_Id"] = rol_id;
                oDr["rolfun_fun_Id"] = listfunc.SelectedValue;

                oDtFunRol.Rows.Add(oDr);
            }
        }

        private void Abm_Rol_Alta_VisibleChanged(object sender, EventArgs e)
        {
            if (cerrarForm)
                this.Close();
        }
    }
}
