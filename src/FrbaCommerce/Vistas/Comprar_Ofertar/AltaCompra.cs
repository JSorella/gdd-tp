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
    public partial class AltaCompra : Form
    {
        private int codigoPublicacion;
        DataTable oDTPubli = new DataTable();
        private int nudMaximum;
        

        public AltaCompra(int _codigoPublicacion)
        {
            this.codigoPublicacion = _codigoPublicacion;
            InitializeComponent();
        }

        public void AltaCompra_Load(object sender, EventArgs e)
        {
            try
            {

                this.oDTPubli = InterfazBD.getPublicacion(Convert.ToInt32(this.codigoPublicacion));
                this.CargarDatosPubli();
                this.nudMaximum = Convert.ToInt32(oDTPubli.Rows[0]["pub_Stock"]);

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta Compra: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }

        private void CargarDatosPubli()
        {
            DataRow oDr = oDTPubli.Rows[0];
            txtDesc.Text = oDr["pub_Descripcion"].ToString();
            txtPrecio.Text = oDr["pub_Precio"].ToString();
        }

        private void btnComprar_Click(object sender, EventArgs e)
        {
            if (!validarCampos())
                return;

            try
            {
                DataTable DTcompra = new DataTable();
                DTcompra = InterfazBD.getDTCompra();

                DTcompra.Rows.Clear();

                DataRow compra = DTcompra.NewRow();

                compra["comp_Id"] = 0;
                compra["comp_pub_Codigo"] = this.codigoPublicacion;
                compra["comp_usu_Id"] = Singleton.usuario["usu_Id"];
                compra["comp_Fecha"] = Singleton.FechaDelSistema;
                compra["comp_Cantidad"] = nudCantidad.Value;
                DataRow oDr = oDTPubli.Rows[0];
                compra["comp_Comision"] = decimal.Multiply(decimal.Multiply(Convert.ToDecimal(oDr["pub_vis_Porcentaje"]), Convert.ToDecimal(oDr["pub_Precio"])) , nudCantidad.Value);
                compra["comp_cal_Codigo"] = 0;
                compra["comp_Facturada"] = 0;

                DTcompra.Rows.Add(compra);

                InterfazBD.setCompra(DTcompra);
                Funciones.mostrarInformacion("Su Compra se ha efectuado Satisfactoriamente!", "Compra Efectuada");

                DatosVendedor oFrm = new DatosVendedor(Convert.ToInt32(oDTPubli.Rows[0]["pub_usu_Id"]));
                oFrm.ShowDialog();
                this.Close();
                

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta Pregunta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            if (this.nudCantidad.Value > this.nudMaximum)
            {
                Funciones.mostrarAlert("Cantidad supera el Stock disponible!", this.Text); 
                nudCantidad.Value = this.nudMaximum;
                return false;
            }


            return true;
        }
    }
}
