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
    public partial class AltaPregunta : Form
    {
        private Int32 codigoPublicacion;
        private DataTable DTpregunta;

        public AltaPregunta(Int32 _codigoPublicacion)
        {
            InitializeComponent();
            this.codigoPublicacion = _codigoPublicacion;
        }

        private void AltaPregunta_Load(object sender, EventArgs e)
        {
            lblLenght.Text = txtDesc.MaxLength.ToString();
        }

        private void txtDesc_TextChanged(object sender, EventArgs e)
        {
            lblLenght.Text = (txtDesc.MaxLength - txtDesc.TextLength).ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                this.DTpregunta = InterfazBD.getDTPregunta();
                //DataRow pregunta = DTPregunta.Rows[0];
                DTpregunta.Rows.Clear();

                DataRow pregunta = DTpregunta.NewRow();

                pregunta["preg_Id"] = 100;
                pregunta["preg_pub_codigo"] = this.codigoPublicacion;
                pregunta["preg_tipo"] = "P";
                pregunta["preg_Comentario"] = txtDesc.Text;
                pregunta["preg_usu_Id"] = Singleton.usuario["usu_Id"];

                DTpregunta.Rows.Add(pregunta);

                InterfazBD.setPregunta(DTpregunta);
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
