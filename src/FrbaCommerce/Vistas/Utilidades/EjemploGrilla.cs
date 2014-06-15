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
    public partial class EjemploGrilla : Form
    {
        private PaginarGrilla oPag;

        public EjemploGrilla()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            oPag = InterfazBD.BuscarPublicacionesOrdenadas("");
            dvgPublis.DataSource = oPag.cargar();
            dvgPublis.DataMember = "Publicaciones";

            Actualizar();

            dvgPublis.Columns["Publicación Precio"].Visible = false;

            this.WindowState = FormWindowState.Maximized;
        }

        private void Actualizar()
        {
            lblInfo.Text = "Página " + oPag.numPag().ToString() + 
                            " de " + oPag.countPag().ToString() +
                            " ( " + oPag.countRow().ToString() + 
                            " Publicaciones ) - " +
                            oPag.limitRow().ToString() + " por Página";
        }

        private void btnPrimera_Click(object sender, EventArgs e)
        {
            oPag.primeraPagina();
            Actualizar();
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            oPag.atras();
            Actualizar();
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            oPag.adelante();
            Actualizar();
        }

        private void btnUltima_Click(object sender, EventArgs e)
        {
            oPag.ultimaPagina();
            Actualizar();
        }

        private void EjemploGrilla_Load(object sender, EventArgs e)
        {

        }


    }
}
