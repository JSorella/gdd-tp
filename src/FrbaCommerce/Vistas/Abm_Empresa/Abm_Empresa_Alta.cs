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
    public partial class Abm_Empresa_Alta : Form
    {
        private string usuario;
        private string pass;
        DateTime dteFecCreac;
        private bool usu_Primer_Ingreso;  

        public Abm_Empresa_Alta()        //Alta desde Admin
        {
            this.usuario = "";
            this.pass = "";
            this.usu_Primer_Ingreso = true;
            InitializeComponent();
        }

        public Abm_Empresa_Alta(string _usuario, string _pass)    //Alta desde ResgistroUsuario
        {
            this.usuario = _usuario;
            this.pass = _pass;
            this.usu_Primer_Ingreso = false; //si soy el usuario, no necesito cambiar contraseña, ya la elegi yo!
            InitializeComponent();
        }

        private void Abm_Empresa_Alta_Load(object sender, EventArgs e)
        {

        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            Point ppos = this.btnSelFec.PointToScreen(new Point());
            ppos.X = ppos.X + this.btnSelFec.Width;

            FrbaCommerce.ControlFecha oFrm = new FrbaCommerce.ControlFecha(ppos.X, ppos.Y, false);
            oFrm.ShowDialog();

            if (!oFrm.Cancelado)
                dteFecCreac = oFrm.FechaSeleccionada;
                tboxFechaCreacion.Text = oFrm.FechaSeleccionada.ToShortDateString();
        }

        private void altaAdminDatosUsuario()
        {
            if (Singleton.sessionRol_Id == 1) //Soy el Admin
            {
                usuario = tboxCUIT.Text;
                pass = "p455w0rd";
            }
        }

        private Boolean ValidarCampos()
        {
            try
            {
                if (this.tboxRazonSocial.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Razon Social", this.Text); return false;
                }
                if (this.tboxCUIT.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese CUIT", this.Text); return false;
                }
                if (this.tboxMail.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Mail", this.Text); return false;
                }
                if (this.tboxTelefono.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Telefono", this.Text); return false;
                }
                if (this.tboxNombreContacto.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Nombre de Contacto", this.Text); return false;
                }
                if (this.tboxFechaCreacion.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Fecha de Creacion", this.Text); return false;
                }
                if (this.tboxCalle.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Calle", this.Text); return false;
                }
                if (this.tboxAltura.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Altura", this.Text); return false;
                }
                if (this.tboxLocalidad.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Localidad", this.Text); return false;
                }
                if (this.tboxCodPostal.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Codigo POstal", this.Text); return false;
                }
                if (this.tboxCiudad.Text == "")
                {
                    Funciones.mostrarAlert("Ingrese Ciudad", this.Text); return false;
                }

                //Validamos que el CUIT no esté repetido
                InterfazBD.existeCUIT(tboxCUIT.Text);

                //Validamos que la Razon Social no esté repetida
                InterfazBD.existeRazonSocial(tboxRazonSocial.Text);

                //Validamos que el teléfono no esté repetido
                InterfazBD.existeTelefono(Convert.ToInt64(this.tboxTelefono.Text));

                return true;
            }
            catch (Exception ex)
            {
                Funciones.mostrarAlert(ex.Message, this.Text);
                return false;
            }
        }

        private void btnDarDeAlta_Click(object sender, EventArgs e)
        {
            if (!ValidarCampos())
                return;

            try
            {
                altaAdminDatosUsuario();


                DataTable oDtEmpresaUsuario = new DataTable();
                oDtEmpresaUsuario = InterfazBD.getDTEmpresaUsuario();

                oDtEmpresaUsuario.Rows.Clear();

                DataRow oDrEmpresaUsuario = oDtEmpresaUsuario.NewRow();
                //Cliente
                oDrEmpresaUsuario["emp_Razon_Social"] = tboxRazonSocial.Text;
                oDrEmpresaUsuario["emp_Cuit"] = tboxCUIT.Text;
                oDrEmpresaUsuario["emp_Mail"] = tboxMail.Text;
                oDrEmpresaUsuario["emp_Tel"] = tboxTelefono.Text;
                oDrEmpresaUsuario["emp_Contacto"] = tboxNombreContacto.Text;
                oDrEmpresaUsuario["emp_Fecha_Creacion"] = tboxFechaCreacion.Text;
                oDrEmpresaUsuario["emp_Dom_Calle"] = tboxCalle.Text;
                oDrEmpresaUsuario["emp_Nro_Calle"] = tboxAltura.Text;
                oDrEmpresaUsuario["emp_Piso"] = tboxPiso.Text;
                oDrEmpresaUsuario["emp_Dpto"] = tboxDpto.Text;
                oDrEmpresaUsuario["emp_Localidad"] = tboxLocalidad.Text;
                oDrEmpresaUsuario["emp_CP"] = tboxCodPostal.Text;
                oDrEmpresaUsuario["emp_Ciudad"] = tboxCiudad.Text;
                oDrEmpresaUsuario["emp_usu_Id"] = 0;
                //Usuario
                oDrEmpresaUsuario["usu_Id"] = 0;
                oDrEmpresaUsuario["usu_UserName"] = this.usuario;
                oDrEmpresaUsuario["usu_Pass"] = Funciones.get_hash(this.pass);  //Encripto el Password;
                oDrEmpresaUsuario["usu_Cant_Intentos"] = 0;
                oDrEmpresaUsuario["usu_Inhabilitado"] = 0;
                oDrEmpresaUsuario["usu_Motivo"] = "";
                oDrEmpresaUsuario["usu_Eliminado"] = 0;
                oDrEmpresaUsuario["usu_Primer_Ingreso"] = this.usu_Primer_Ingreso ? 1 : 0;
                oDrEmpresaUsuario["usu_Inhabilitado_Comprar"] = 0;

                oDtEmpresaUsuario.Rows.Add(oDrEmpresaUsuario);

                InterfazBD.CargarEmpresa(oDtEmpresaUsuario);
            }
            catch (Exception error)
            {
                Funciones.mostrarAlert(error.Message, this.Text);
                return;
            }

            if (Singleton.sessionRol_Id == 1)
                Funciones.mostrarInformacion("La Empresa ha sido dado de alta con exito.\nUsuario: "+usuario+"\nPassword: "+pass, this.Text);
            else
                Funciones.mostrarInformacion("La Empresa ha sido dado de alta con exito.", this.Text);

            this.Close();
        }

    }
}
