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
            cargarPreguntasRespuestas();
        }

        private void cargarPreguntasRespuestas()
        {
            this.cargarGrid(InterfazBD.respuestas());
        }

        private void cargarGrid(DataTable dataTable)
        {
            gridRespuestas.Visible = true;
            gridRespuestas.DataSource = dataTable;
        }
    }
}
