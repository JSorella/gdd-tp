using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace FrbaCommerce
{
    public partial class ControlFecha : Form
    {
        Boolean isLoad = false;
        Boolean booCancelado = false;
        DateTime dteFecha;
        private bool fechaMin;

        public DateTime FechaSeleccionada
        {
            get { return dteFecha; }
            set { dteFecha = value; }
        }

        public Boolean Cancelado
        {
            get { return booCancelado; }
        }

        public ControlFecha(int eX, int eY) //con fecha min Actual
        {
            InitializeComponent();
            //Posicionamiento del Form
            this.Location = new System.Drawing.Point(eX, eY);
            this.fechaMin = true; // por defecto
        }

        public ControlFecha(int eX, int eY, bool _fechaMin) //Puedo elegir restricción fecha mínima
        {
            InitializeComponent();
            //Posicionamiento del Form
            this.Location = new System.Drawing.Point(eX, eY);
            this.fechaMin = _fechaMin;
        }

        private void ControlFecha_Load(object sender, EventArgs e)
        {
            isLoad = true;

            // Asignamos la menor fecha posible
            if (this.fechaMin)
            {
                this.mcSelFecha.MinDate = Singleton.FechaDelSistema;
            }

            // Seleccionamos una fecha.
            if (dteFecha < Singleton.FechaDelSistema)
                this.mcSelFecha.SelectionStart = Singleton.FechaDelSistema;
            else
                this.mcSelFecha.SelectionStart = dteFecha;

            isLoad = false;
        }

        private void ControlFecha_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                booCancelado = true;
                this.Close();
            }

            if (e.KeyCode == Keys.Enter)
            {
                dteFecha = mcSelFecha.SelectionRange.Start;
                this.Close();
            }
        }

        private void mcSelFecha_DateSelected(object sender, DateRangeEventArgs e)
        {
            if (!isLoad)
            {
                dteFecha = mcSelFecha.SelectionRange.Start;
                this.Close();
            }
        }
    }
}
