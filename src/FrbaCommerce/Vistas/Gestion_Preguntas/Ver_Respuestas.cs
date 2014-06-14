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
                //Obtengo las Preguntas que hizo el usuario logueado
                //y que respuestas obtuvo.
                dgvMisPreguntas.Visible = true;
                dgvMisPreguntas.DataSource = InterfazBD.getPreguntasDelUsuario();

                //Obtengo las Respuestas que dio el usuario logueado
                //a las preguntas recibidas en sus Publicaciones
                dgvMisRespuestas.Visible = true;
                dgvMisRespuestas.DataSource = InterfazBD.getRespuestasDelUsuario();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Ver_Respuestas_Load(object sender, EventArgs e)
        {
            cargarPreguntasRespuestas();

            if (Singleton.sessionRol_Id == 3)
            {
                tabPreguntas.TabPages.Remove(tpMisPreguntas);
            }
        }

        private void btnRefrescar_Click(object sender, EventArgs e)
        {
            cargarPreguntasRespuestas();
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
