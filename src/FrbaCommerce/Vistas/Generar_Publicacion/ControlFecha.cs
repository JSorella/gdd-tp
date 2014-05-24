﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;

namespace FrbaCommerce.Vistas.Generar_Publicacion
{
    public partial class ControlFecha : Form
    {
        Boolean isLoad = false;
        DateTime dteFecha;
        DateTime dteFechaSys = Convert.ToDateTime(ConfigurationSettings.AppSettings["FechaDelSistema"]);

        public DateTime FechaSeleccionada
        {
            get { return dteFecha; }
            set { dteFecha = value; }
        }

        public ControlFecha(int eX, int eY)
        {
            InitializeComponent();
            //Posicionamiento del Form
            this.Location = new System.Drawing.Point(eX, eY);
        }

        private void ControlFecha_Load(object sender, EventArgs e)
        {
            isLoad = true;

            // Asignamos la menor fecha posible
            if (dteFecha < dteFechaSys)
                this.mcSelFecha.MinDate = dteFecha;
            else
                this.mcSelFecha.MinDate = dteFechaSys;

            // Seleccionamos una fecha.
            this.mcSelFecha.SelectionStart = dteFecha;

            isLoad = false;
        }

        private void mcSelFecha_DateChanged(object sender, DateRangeEventArgs e)
        {
            if (!isLoad)
            {
                dteFecha = mcSelFecha.SelectionRange.Start;
                this.Close();
            }
        }
    }
}
