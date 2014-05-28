using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Abm_Rol
{
    public partial class Abm_Rol_Modif : Form
    {
        /*-----------ATRIBUTOS--------------------*/
        public string rol_nomb_mod;
        public int id_rol_a_mod;

        /*----------------------------------------*/        
        public Abm_Rol_Modif()
        {
            InitializeComponent();
        }

        private void select_boton_Click(object sender, EventArgs e)
        {

            Abm_Rol_Busqueda buscar_rol = new Abm_Rol_Busqueda();
            buscar_rol.ShowDialog();
            if ((buscar_rol.Resultado != null)) //Resultado es el DataRow.-
            {
                id_rol_a_mod = Convert.ToInt32(buscar_rol.Resultado["rol_id"]);
                rol_nomb_mod = buscar_rol.Resultado["rol_nombre"].ToString();
                chkInhabilitado.Checked = Convert.ToBoolean(buscar_rol.Resultado["rol_inhabilitado"]);

                CargarFuncionalidadesxRol(Convert.ToInt32(buscar_rol.Resultado["rol_id"]));
            }
        }

        private void CargarFuncionalidadesxRol(int rol_id)
        {
            //Ir a la BD y traer los id de funcionalidades que ya tiene el ROL - J2LA.Roles_Funcionalidades -
            // filtrando por el rol_id.
            // esto se graba en un DataTable
            // Hasta aca hacer!!
            // tenes que recorrer el DataTable y por cada fun_id busacarlo en el List y tildarlo.-
            // Bancame al de Rubros.-
        }

        private void list_funcionalidades_Load(object sender, EventArgs e)
        {
            if (this.rol_nomb_mod != null) //evaluamos si esta seteada la var rol_nombre
            {                               //esta seteada si ya se selecciono un rol a modificar
                this.rol_select_tbox.Text = this.rol_nomb_mod;
                //this.rol_select_tbox.ReadOnly = true;
                this.select_boton.Enabled = false;

                //cargamos lista segun corresponde
                
                string query = "SELECT fun_id, fun_nombre FROM J2LA.Funcionalidades";
                Connection connect = new Connection();
                DataTable tabla_todas_func = connect.execute_query(query);
                list_funcionalidades.DataSource = tabla_todas_func;
                list_funcionalidades.DisplayMember = "fun_nombre";
                list_funcionalidades.ValueMember = "fun_id";

                //tildamos las funciones que ya tiene el rol

                //int i;
                //Funciones func = new Funciones();
                //for (i = 0; i < (this.list_funcionalidades.Items.Count); i++)
                //{
                //    this.list_funcionalidades.SelectedIndex = i;
                //    if (func.check_func_activa(this.id_rol_a_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString())))
                //        this.list_funcionalidades.SetItemChecked(i, true);
                //}
                
            }
            else
            {
                this.rol_select_tbox.Enabled = false;
            }
        }

        private void aplicar_boton_Click(object sender, EventArgs e)
        {
            int i;
            Funciones func = new Funciones();

            //this.Visible = true;
            //devuelve true si se realizaron cambios en el nombre o estado 
            //if (func.check_cambio_nomb_est_rol(id_rol_a_mod, this.estado_actual_rol, this.rol_select_tbox.Text, this.rol_nomb_mod))
            StoredProcedures.update_rol(this.id_rol_a_mod, this.rol_select_tbox.Text, chkInhabilitado.Checked);

            for (i = 0; i < (this.list_funcionalidades.Items.Count); i++)
            {

                this.list_funcionalidades.SelectedIndex = i;
                if (this.list_funcionalidades.GetItemChecked(i))
                {
                    //consulto si la func la tnia ya el Rol
                    //si la tnia la dejo sino la agrego
                    if (!func.check_func_activa(this.id_rol_a_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString())))
                    {
                        StoredProcedures.insert_funcxrol(this.rol_nomb_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString()));
                    }
                }
                else
                {
                    //consulto si la func la tnia ya el usuario
                    //si la tnia la elimino
                    if (func.check_func_activa(this.id_rol_a_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString())))
                    {
                        StoredProcedures.delete_funcxrol(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString());
                    }
                }


            }

            MessageBox.Show("Actualización Exitosa", "Modificación  Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
