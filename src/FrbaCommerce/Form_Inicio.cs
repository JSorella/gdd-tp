using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;


namespace FrbaCommerce
{
    public partial class Form_Inicio : Form
    {
        connection connect = new connection();
        string query;
        private DataGridView dataGridView1;
        DataTable tablaTop10 = new DataTable();
        BindingSource SBind = new BindingSource();

        //fecha del sistema
        DateTime fechaDelSistema = Convert.ToDateTime((System.Configuration.ConfigurationSettings.AppSettings["FechaDelSistema"]).ToString());

        //CONSTRUCTOR
        public Form_Inicio()
        {
            //InitializeComponent();
            /*-------------------------ACTUALIZACION DE FECHA DE ALTA DE MICRO--------------*/
            //stored_procedures stored = new stored_procedures();
            //stored.update_fecha_alta_micro(fechadelsistema.tostring("yyyy-mm-dd hh:mm"));
            Console.WriteLine("Debug 1");

            //hallamos Id_Rol
            query = "SELECT TOP 10 Publicacion_Cod, Publ_Empresa_Dom_Calle FROM gd_esquema.Maestra";
            
            tablaTop10 = connect.execute_query(query);
            Console.WriteLine("hay "+ tablaTop10.Rows.Count + " filas");
            SBind.DataSource = tablaTop10;

            this.InitializeComponent();

            Console.WriteLine(this.dataGridView1.GridColor.ToString());
            this.dataGridView1.DataSource = SBind;
            this.dataGridView1.Refresh(); 
             
        }



        private void comboBoxPerfil_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (this.comboBoxPerfil.SelectedIndex == 1)
            {
                //es un cliente


                //funciones func = new funciones();

                //chequeo si esta habilitado
                if (!func.check_estado_rol("2", 'H'))
                {
                    MessageBox.Show("Rol cliente Inhabilitado");
                    return;
                }

                //chequeo si compra esta habilitado
                if (func.check_func_activa("2", "4"))
                {
                    FormCompra compra = new FormCompra();
                    //chequeo que este habilitado consultar puntos
                    if (!func.check_func_activa("2", "10"))
                    {
                        compra.buttonConsultaPuntos.Visible = false;
                    }
                    compra.ShowDialog();
                }
                else
                {
                    if (func.check_func_activa("2", "10"))
                    {
                        Abm_Consulta_Puntos consultar_puntos = new Abm_Consulta_Puntos();
                        consultar_puntos.ShowDialog();
                    }
                }

            }
            else
            {
                login login = new login();
                login.ShowDialog();
            } 
            */
        }

        private void InitializeComponent()
        {
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(2, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(775, 242);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Form_Inicio
            // 
            this.ClientSize = new System.Drawing.Size(778, 285);
            this.Controls.Add(this.dataGridView1);
            this.Name = "Form_Inicio";
            this.Load += new System.EventHandler(this.Form_Inicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
        }

        private void Form_Inicio_Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }
            

    }
}
