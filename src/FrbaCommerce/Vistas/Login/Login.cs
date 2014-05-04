using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using FrbaCommerce.Homes;
using FrbaCommerce.Dominio;


namespace FrbaCommerce.Vistas.Login
{
    public partial class Login : Form
    {
        Connection connect = new Connection();
        string query;
        private DataGridView dataGridView1;
        DataTable tablaTop10 = new DataTable();
        BindingSource SBind = new BindingSource();
        private FontDialog fontDialog1;
        private Label label1;
        private Button login_button;
        private TextBox passw_textbox;
        private TextBox username_textbox;
        private Label label2;
        private Label label3;
        private Label label4;
        private HomeUsuarios homeUsuarios = new HomeUsuarios();


        //fecha del sistema
        DateTime fechaDelSistema = Convert.ToDateTime((System.Configuration.ConfigurationSettings.AppSettings["FechaDelSistema"]).ToString());

        //CONSTRUCTOR
        public Login()
        {
            this.InitializeComponent();

            /*-------------------------ACTUALIZACION DE FECHA DE ALTA DE MICRO--------------*/
            //stored_procedures stored = new stored_procedures();
            //stored.update_fecha_alta_micro(fechadelsistema.tostring("yyyy-mm-dd hh:mm"));

            //hallamos Id_Rol
            //query = "SELECT TOP 10 Publicacion_Cod, Publ_Empresa_Dom_Calle FROM gd_esquema.Maestra";
            
            //tablaTop10 = connect.execute_query(query);
            //Console.WriteLine("hay "+ tablaTop10.Rows.Count + " filas");
            //SBind.DataSource = tablaTop10;

            //this.dataGridView1.DataSource = SBind;
            //this.dataGridView1.Refresh(); 
             
        }

        private void InitializeComponent()
        {
            this.fontDialog1 = new System.Windows.Forms.FontDialog();
            this.label1 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.passw_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, -2);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 37);
            this.label1.TabIndex = 1;
            this.label1.Text = "FrbaCommerce 2014";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(406, 202);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(119, 25);
            this.login_button.TabIndex = 9;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // passw_textbox
            // 
            this.passw_textbox.Location = new System.Drawing.Point(406, 149);
            this.passw_textbox.Name = "passw_textbox";
            this.passw_textbox.Size = new System.Drawing.Size(191, 20);
            this.passw_textbox.TabIndex = 8;
            this.passw_textbox.UseSystemPasswordChar = true;
            this.passw_textbox.TextChanged += new System.EventHandler(this.passw_textbox_TextChanged);
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(406, 101);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(191, 20);
            this.username_textbox.TabIndex = 7;
            this.username_textbox.TextChanged += new System.EventHandler(this.username_textbox_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(269, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Password:";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(269, 108);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Username:";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(723, 239);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Powered by J2LA ©";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // Login
            // 
            this.ClientSize = new System.Drawing.Size(855, 262);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.passw_textbox);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Form_Login";
            this.Load += new System.EventHandler(this.Login_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void Login_Load(object sender, EventArgs e)
        {
           

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
          
        }

        private void Login_Load_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void error()
        {
            //this.username_textbox.Text = "";
            //this.passw_textbox.Text = "";
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            // Validación Textboxes
            if (this.username_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar nombre de usuario", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.error();
                return;
            }

            if (this.passw_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar password", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.error();
                return;
            }
            /*------------------------------------------------*/
            //Ahora si... ingreso usuario y contraseña 

            Usuario usuario = new Usuario();

            try
            {
                usuario = this.homeUsuarios.getUsuarioSinRoles(this.username_textbox.Text);
            }
            catch (Exception error)
            {
                MessageBox.Show(error.Message, "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            if (usuario != null)
            {
                //verificamos que el usuario NO este inhabilitado
                if (usuario.inhabilitado)
                {
                    MessageBox.Show(
                        @"Usuario Inhabilitado
                        \n Motivo: " + usuario.motivo
                        , "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // evaluamos la cant_intentos              
                if (usuario.cantidadIntentos >= 3)
                {
                    MessageBox.Show("Se logueó mal 3 veces, está inhabilitado para logearse", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.error();
                    return;
                }

                //evaluamos si esta bien la contraseña
                
                if (Funciones.get_hash(passw_textbox.Text) == usuario.pass)
                {
                    //Login Successful!! ... abrimos el formulario de Funcionalides

                    //limpiamos cant_intentos
                    usuario.cantidadIntentos = 0;

                    EleccionRol rolWindow = new EleccionRol();
                    
                    rolWindow.ShowDialog();
                }
                else  //Wrong Password...
                {
                    //Se debe actualizar el campo usu_cant_intentos de la base de datos
                    usuario.cantidadIntentos +=1;
                    
                    MessageBox.Show(@"
                        Password Incorrecto
                        Le quedan " + (int)(3 - usuario.cantidadIntentos) + " intentos" 
                        , "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            return;
        }

        private void passw_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void username_textbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
            

    }
}
