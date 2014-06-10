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
        DataTable DTrespuesta;
        DataRow oDrPregunta;

        public Respuesta()
        {
            InitializeComponent();
        }

        public DataRow PreguntaDr
        {
            set { oDrPregunta = value; }
        }

        private void Respuesta_Load(object sender, EventArgs e)
        {
            lblLenght.Text = "Caracteres restantes: " + txtRespuesta.MaxLength.ToString();
            txtPregunta.Text = oDrPregunta["Pregunta"].ToString();
        }

        private void txtRespuesta_TextChanged(object sender, EventArgs e)
        {
            lblLenght.Text = "Caracteres restantes: " + (txtRespuesta.MaxLength - txtRespuesta.TextLength).ToString();
        }

        private void btnResponder_Click(object sender, EventArgs e)
        {
            try
            {
                DTrespuesta = InterfazBD.getDTPregunta();

                DTrespuesta.Rows.Clear();

                DataRow respuesta = DTrespuesta.NewRow();

                respuesta["preg_Id"] = oDrPregunta["preg_Id"];
                respuesta["preg_pub_codigo"] = oDrPregunta["preg_pub_Codigo"];
                respuesta["preg_tipo"] = "R";
                respuesta["preg_Comentario"] = txtRespuesta.Text;
                respuesta["preg_Fecha"] = Singleton.FechaDelSistema; //Nuevo campo que no tuvimos en cuenta.
                respuesta["preg_usu_Id"] = Singleton.usuario["usu_Id"];

                DTrespuesta.Rows.Add(respuesta);

                InterfazBD.setPregunta(DTrespuesta);

                Funciones.mostrarInformacion("Su Respuesta ha sido publicada!", "Preguntas");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en Respuesta: " + System.Environment.NewLine + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Close();
            }
        }
    }
}
