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
    public partial class GestionPreguntas : Form
    {
        public GestionPreguntas()
        {
            InitializeComponent();
        }

        private void GestionPreguntas_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Responder_preguntas oFrm = new Responder_preguntas();
            oFrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Respuesta oFrm = new Respuesta();
            oFrm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Ver_Respuestas oFrm = new Ver_Respuestas();
            oFrm.Show();
        }
    }
}
