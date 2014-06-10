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
        DataTable oDtRespuesta;
        DataRow oDrPregunta;

        public Respuesta()
        {
            InitializeComponent();
        }

        public DataRow Pregunta
        {
            get { return oDrPregunta; }
        }

        private void btnrespond_Click(object sender, EventArgs e)
        {
            try
            {
                oDtRespuesta = InterfazBD.getDTPregunta();
                
                oDtRespuesta.Rows.Clear();

                DataRow pregunta = oDtRespuesta.NewRow();

                pregunta["preg_Id"] = oDrPregunta["preg_Id"]; //codigo de la pregunta;
                pregunta["preg_pub_codigo"] = oDrPregunta["preg_pub_codigo"]; //this.codigoPublicacion;
                pregunta["preg_tipo"] = "R";
                pregunta["preg_Comentario"] = txtRespuesta.Text;
                pregunta["preg_usu_Id"] = Singleton.usuario["usu_Id"];

                oDtRespuesta.Rows.Add(pregunta);

                InterfazBD.setPregunta(oDtRespuesta);

                Funciones.mostrarInformacion("Su Respuesta ha sido publicada!", "Responder Preguntas");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Alta de Respuesta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
