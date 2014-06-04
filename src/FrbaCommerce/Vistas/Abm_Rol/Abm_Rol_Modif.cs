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

                txtRolName.Text = rol_nomb_mod;
                chkInhabilitado.Checked = Convert.ToBoolean(buscar_rol.Resultado["rol_inhabilitado"]);

                CargarFuncionalidadesxRol(Convert.ToInt32(buscar_rol.Resultado["rol_id"]));
            }
        }

        private void CargarFuncionalidadesxRol(int rol_id)
        {
            // Deberia estar filtrando por el rol_id.
            DataTable oDt = InterfazBD.getFuncionalidadesPorRol(rol_nomb_mod);
            int index = 0;

            foreach (DataRow oDr in oDt.Rows)
            {
                index = list_funcionalidades.FindStringExact(oDr["fun_nombre"].ToString());
                list_funcionalidades.SetItemChecked(index, true);
            }
        }

        private void list_funcionalidades_Load(object sender, EventArgs e)
        {
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!

            if (this.rol_nomb_mod != null) //evaluamos si esta seteada la var rol_nombre
            {                               //esta seteada si ya se selecciono un rol a modificar
                this.txtRolName.Text = this.rol_nomb_mod;
                //this.rol_select_tbox.ReadOnly = true;
                this.select_boton.Enabled = false;

                //cargamos lista segun corresponde                
                list_funcionalidades.DataSource = InterfazBD.getFuncionalidades();
                list_funcionalidades.DisplayMember = "fun_nombre";
                list_funcionalidades.ValueMember = "fun_id";                
            }
            else
            {
                this.txtRolName.Enabled = false;

                //cargamos lista segun corresponde                
                list_funcionalidades.DataSource = InterfazBD.getFuncionalidades();
                list_funcionalidades.DisplayMember = "fun_nombre";
                list_funcionalidades.ValueMember = "fun_id";                
            }

            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
        }

        private void aplicar_boton_Click(object sender, EventArgs e)
        {

            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!
            // Esto quedo asi del TP anterior, adaptar!!

            // Aca directamente haces, update de rol, delete de rol_fun y despues insert.-
            // Usa la clase de interfaz con la BD, fijate como hace con los rubros en Generacion de Publicaciones.

            int i;
            Funciones func = new Funciones();

            //this.Visible = true;
            //devuelve true si se realizaron cambios en el nombre o estado 
            //if (func.check_cambio_nomb_est_rol(id_rol_a_mod, this.estado_actual_rol, this.rol_select_tbox.Text, this.rol_nomb_mod))
            InterfazBD.update_rol(this.id_rol_a_mod, this.txtRolName.Text, chkInhabilitado.Checked);

            for (i = 0; i < (this.list_funcionalidades.Items.Count); i++)
            {

                this.list_funcionalidades.SelectedIndex = i;
                if (this.list_funcionalidades.GetItemChecked(i))
                {
                    //consulto si la func la tnia ya el Rol
                    //si la tnia la dejo sino la agrego
                    if (!func.check_func_activa(this.id_rol_a_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString())))
                    {
                        InterfazBD.insert_funcxrol(this.rol_nomb_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString()));
                    }
                }
                else
                {
                    //consulto si la func la tnia ya el usuario
                    //si la tnia la elimino
                    if (func.check_func_activa(this.id_rol_a_mod, Convert.ToInt16(this.list_funcionalidades.SelectedValue.ToString())))
                    {
                        InterfazBD.delete_funcxrol(this.id_rol_a_mod, this.list_funcionalidades.SelectedValue.ToString());
                    }
                }


            }

            MessageBox.Show("Actualización Exitosa", "Modificación  Rol", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();

        }
    }
}
