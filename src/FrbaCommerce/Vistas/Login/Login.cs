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
        private Usuario usuario = new Usuario();
        DataTable oDTRolesxUsuario;

        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            ConfirmarLogIn();
        }

        private void registrar_usuario_button_Click(object sender, EventArgs e)
        {
            RegistroUsuario registroUsuarioWindow = new RegistroUsuario();
            registroUsuarioWindow.ShowDialog();

            if (Singleton.sessionRol_Id != 0)
                this.Close();
        }

        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConfirmarLogIn();
            }

            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void ConfirmarLogIn()
        {
            if (!Validar())
                return;

            try
            {
                usuario = InterfazBD.getUsuarioSinRoles(this.txtUserName.Text);
                //NOTA: es importante que sea sin roles ya que, de no tenerlos, el user debería poder loguearse igual y ser informado de esto

                //evaluamos si esta bien la contraseña
                if (Funciones.get_hash(txtPass.Text) == usuario.pass) //Login Successful!!
                {
                    
                    limpiarCantidadIntentos();
                    oDTRolesxUsuario = InterfazBD.getUsuarioConRoles(usuario.nombre);
                    cargarUsuarioEnSingleton();
                    validarPrimerIngreso();

                    //Abro forms de acuerdo a la cantidad de Roles asignados
                    if (Singleton.debeCambiarPass)
                    {
                        Funciones.mostrarAlert("Debe cambiar password para proseguir", "Acceso al Sistema");
                        return;
                    }

                    if (oDTRolesxUsuario.Rows.Count == 1)
                    {
                        Singleton.sessionRol_Id = Convert.ToInt32(oDTRolesxUsuario.Rows[0]["rol_Id"]);

                        this.Close(); //Volvemos al Main!
                        return;
                    }
                    else
                    {
                        EleccionRol rolWindow = new EleccionRol();
                        rolWindow.RolesTable = oDTRolesxUsuario;
                        rolWindow.ShowDialog();

                        if (Singleton.sessionRol_Id != 0)
                            this.Close();

                        return;
                    }
                }
                else  //Wrong Password...
                {
                    //Se debe actualizar el campo usu_cant_intentos de la base de datos
                    usuario.cantidadIntentos++;
                    InterfazBD.setCantidadIntentos(usuario);
                    string strCantIntentos = (3 - usuario.cantidadIntentos).ToString();
                    string mensaje = "Password Incorrecto." + System.Environment.NewLine;

                    if ((3 - usuario.cantidadIntentos) == 0)
                        mensaje = mensaje + "Su usuario ha sido Inhabilitado. Contacte al Administrador del Sistema.";
                    else
                        mensaje = mensaje + "Le quedan " + strCantIntentos + " intentos.";

                    Funciones.mostrarAlert(mensaje, "Acceso al Sistema");
                }
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, "Acceso al Sistema");
            }

            return;
        }

        private bool Validar()
        {
            // Validación Textboxes
            if (this.txtUserName.Text == "")
            {
                MessageBox.Show("Debe Ingresar nombre de usuario", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (this.txtPass.Text == "")
            {
                MessageBox.Show("Debe Ingresar password", "Acceso al Sistema", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        private void limpiarCantidadIntentos()
        {
            this.usuario.cantidadIntentos = 0;
            InterfazBD.setCantidadIntentos(this.usuario);
        }

        private void cargarUsuarioEnSingleton()
        {
            Singleton.usuario = oDTRolesxUsuario.NewRow();
            Singleton.usuario.ItemArray = oDTRolesxUsuario.Rows[0].ItemArray;
        }

        private void validarPrimerIngreso()
        {
            if (InterfazBD.validarPrimerIngreso(Convert.ToInt32(Singleton.usuario["usu_Id"])))
            {
                Singleton.debeCambiarPass = true;
                CambiarPass oForm = new CambiarPass();
                oForm.ShowDialog();
            }
        }
    }
}
