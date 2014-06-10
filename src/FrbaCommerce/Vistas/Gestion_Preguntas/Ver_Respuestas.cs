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
    public partial class Ver_Respuestas : Form
    {
        public Ver_Respuestas()
        {
            InitializeComponent();
        }

        private void cargarPreguntasRespuestas()
        {
            try
            {
                gridRespuestas.Visible = true;
                gridRespuestas.DataSource = InterfazBD.getRespuestas();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ver_Respuestas_Load(object sender, EventArgs e)
        {
            cargarPreguntasRespuestas();
        }


    }
}
