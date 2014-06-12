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
    public partial class AltaOferta : Form
    {
        private int codigoPublicacion;
        DataTable oDTPubli = new DataTable();

        public AltaOferta(int _codigoPublicacion)
        {
            this.codigoPublicacion = _codigoPublicacion;
            InitializeComponent();
        }


        private void AltaOferta_Load(object sender, EventArgs e)
        {
            try
            {

                //oDTPubli = InterfazBD.getPublicacion(Convert.ToInt32(this.codigoPublicacion));
                //this.CargarDatosPubli();
                nudCantidad.Value = InterfazBD.getPrecioMax(codigoPublicacion) + 1;
                nudCantidad.Minimum = nudCantidad.Value;

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta Oferta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

        }

        private void btnOfertar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            try
            {
                DataTable DToferta = new DataTable();
                DToferta = InterfazBD.getDTOferta();

                DToferta.Rows.Clear();

                DataRow oferta = DToferta.NewRow();

                oferta["ofer_Id"] = 0;
                oferta["ofer_pub_Codigo"] = this.codigoPublicacion;
                oferta["ofer_usu_Id"] = Singleton.usuario["usu_Id"];
                oferta["ofer_Fecha"] = Singleton.FechaDelSistema;
                oferta["ofer_Monto"] = nudCantidad.Value;

                DToferta.Rows.Add(oferta);

                InterfazBD.setOferta(DToferta);
                Funciones.mostrarInformacion("Su Oferta se ha efectuado satisfactoriamente!", "Oferta Efectuada");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta Oferta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }

            this.Close();
        }

        private Boolean validarCampos()
        {
            if (this.nudCantidad.Value == 0)
            {
                Funciones.mostrarAlert("Falta ingresar Cantidad a comprar", this.Text); return false;
            }

            return true;
        }
    }
}
