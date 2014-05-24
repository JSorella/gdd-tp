using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce.Vistas.Generar_Publicacion
{
    public partial class GenerarPublicacion : Form
    {
        public GenerarPublicacion()
        {
            InitializeComponent();
        }

        private bool SoloNumeros(Char chrKey)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsNumber(chrKey)) //e.KeyChar
            {
                return false; // e.Handled = false;
            }
            else
                if (Char.IsControl(chrKey)) //permitir teclas de control como retroceso
                {
                    return false; // e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    return true; // e.Handled = true;
                }
        }

        private bool SoloNumerosDecimales(Char chrKey)
        {
            //Para obligar a que sólo se introduzcan números
            if (Char.IsDigit(chrKey)) //e.KeyChar
            {
                return false; // e.Handled = false;
            }
            else
                if (Char.IsControl(chrKey)) //permitir teclas de control como retroceso
                {
                    return false; // e.Handled = false;
                }
                else
                {
                    //el resto de teclas pulsadas se desactivan
                    return true; // e.Handled = true;
                }
        }

        private void GenerarPublicacion_Load(object sender, EventArgs e)
        {

        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {

        }

        private void txtStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = SoloNumeros(e.KeyChar);
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = SoloNumerosDecimales(e.KeyChar);
        }

        private void btnSelFec_Click(object sender, EventArgs e)
        {
            this.Enabled = false;

            FrbaCommerce.Vistas.Generar_Publicacion.ControlFecha oFrm;
            oFrm = new FrbaCommerce.Vistas.Generar_Publicacion.ControlFecha(
                this.Location.X + pnlDatos.Location.X + this.btnSelFec.Location.X + this.btnSelFec.Size.Width + 10,
                this.Location.Y + pnlDatos.Location.Y + this.btnSelFec.Location.Y - 50);
            oFrm.ShowDialog();

            txtFechaIni.Text = oFrm.FechaSeleccionada.ToString();

            this.Enabled = true;
        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {

        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {

        }
    }
}
