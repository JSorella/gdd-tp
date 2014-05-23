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
        int estado_actual_rol;

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

            }
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

                int i;
                Funciones func = new Funciones();
                for (i = 0; i < (this.list_funcionalidades.Items.Count); i++)
                {
                    this.list_funcionalidades.SelectedIndex = i;
                    if (func.check_func_activa(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString()))
                        this.list_funcionalidades.SetItemChecked(i, true);
                }
                
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
            Stored_procedures stored_proc = new Stored_procedures();
            //this.Visible = false;
            for (i = 0; i < (this.list_funcionalidades.Items.Count); i++)
            {

                this.list_funcionalidades.SelectedIndex = i;
                if (this.list_funcionalidades.GetItemChecked(i))
                {
                    //consulto si la func la tnia ya el Rol
                    //si la tnia la dejo sino la agrego
                    if (!func.check_func_activa(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString()))
                    {
                        stored_proc.insert_funcxrol(this.rol_nomb_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString()));
                    }
                }
                else
                {
                    //consulto si la func la tnia ya el usuario
                    //si la tnia la elimino
                    if (func.check_func_activa(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString()))
                    {
                        stored_proc.delete_funcxrol(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString());
                    }
                }


            }

            if (this.estado_comboBox.SelectedIndex == -1) //Devuelve -1 si no se ha seleccionado ninguna opcion del combo
            {
                estado_actual_rol = func.get_estado_BD(id_rol_a_mod);
            }

            //this.Visible = true;
            //devuelve true si se realizaron cambios en el nombre o estado 
            if (func.check_cambio_nomb_est_rol(id_rol_a_mod, this.estado_actual_rol, this.rol_select_tbox.Text, this.rol_nomb_mod))
                stored_proc.update_rol(this.id_rol_a_mod, this.rol_select_tbox.Text, estado_actual_rol);

            MessageBox.Show("Actualización Exitosa", "Modificación  Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }

        private void rol_select_tbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void estado_comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (estado_comboBox.Text == "Habilitado")
            {
                this.estado_actual_rol = 'H';
            }
            else
            {
                this.estado_actual_rol = 'D';
            }
        }

        private void inhabilitado_checkBox_CheckedChanged(object sender, EventArgs e)
        {
            if (inhabilitado_checkBox.Checked)
            {
                this.estado_actual_rol = 1;
            }
            else
            {
                this.estado_actual_rol = 0;
            }
        }
    }
}
