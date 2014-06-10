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
    public partial class Respuesta : Form
    {
        private DataTable DTrespuesta;
        public Respuesta()
        {
            InitializeComponent();
        }

        private void btnrespond_Click(object sender, EventArgs e)
        {
            try
            {
                this.DTrespuesta = InterfazBD.getDTPregunta();
                //DataRow pregunta = DTrespuesta.Rows[0];
                DTrespuesta.Rows.Clear();

                DataRow pregunta = DTrespuesta.NewRow();

                pregunta["preg_Id"] = 100 //codigo de la pregunta;
                pregunta["preg_pub_codigo"] = this.codigoPublicacion;
                pregunta["preg_tipo"] = "R";
                pregunta["preg_Comentario"] = txtRespuesta.Text;
                pregunta["preg_usu_Id"] = Singleton.usuario["usu_Id"];

                DTrespuesta.Rows.Add(pregunta);

                InterfazBD.setPregunta(DTrespuesta);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta Pregunta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
            Funciones.mostrarInformacion("Su Pregunta ha sido publicada!", "Preguntas");
            this.Close();
        }
    }
}
