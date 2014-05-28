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
    public partial class Login : Form
    {
        Connection connect = new Connection();

        //fecha del sistema
        DateTime fechaDelSistema = Convert.ToDateTime((System.Configuration.ConfigurationSettings.AppSettings["FechaDelSistema"]).ToString());

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            // Validación Textboxes
            if (this.username_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar nombre de usuario", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (this.passw_textbox.Text == "")
            {
                MessageBox.Show("Debe Ingresar password", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            /*------------------------------------------------*/
            //Ahora si... ingreso usuario y contraseña 
            Usuario usuario = new Usuario();

            try
            {
                usuario = StoredProcedures.getUsuarioSinRoles(this.username_textbox.Text);
                //NOTA: es importante que sea sin roles ya que, de no tenerlos, el user debería poder loguearse igual y ser informado de esto

                //evaluamos si esta bien la contraseña
                if (Funciones.get_hash(passw_textbox.Text) == usuario.pass)
                {
                    //Login Successful!! ... abrimos el formulario de Funcionalides
                    //limpiamos cant_intentos
                    usuario.cantidadIntentos = 0;
                    StoredProcedures.setCantidadIntentos(usuario);

                    DataTable usuarioConRoles;

                    usuarioConRoles = StoredProcedures.getUsuarioConRoles(usuario.nombre);

                    Singleton.usuario = usuarioConRoles;

                    if (usuarioConRoles.Rows.Count == 1)
                    {
                        Singleton.sessionRol = (string)Singleton.usuario.Rows[0]["rol_Nombre"];
                        MenuFunciones menuWindow = new MenuFunciones();
                        menuWindow.ShowDialog();
                    }
                    else
                    {
                        EleccionRol rolWindow = new EleccionRol();
                        rolWindow.ShowDialog();
                    }
                }
                else  //Wrong Password...
                {
                    //Se debe actualizar el campo usu_cant_intentos de la base de datos
                    usuario.cantidadIntentos++;
                    StoredProcedures.setCantidadIntentos(usuario);
                    Funciones.mostrarAlert(@"
                        Password Incorrecto
                        Le quedan " + (int)(3 - usuario.cantidadIntentos) + " intentos");
                }
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message);
            }
            return;
        }

        private void registrar_usuario_button_Click(object sender, EventArgs e)
        {
            RegistroUsuario registroUsuarioWindow = new RegistroUsuario();
            registroUsuarioWindow.ShowDialog();
        }
    }
}
