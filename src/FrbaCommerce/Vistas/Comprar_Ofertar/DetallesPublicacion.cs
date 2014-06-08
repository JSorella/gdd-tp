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
    public partial class DetallesPublicacion : Form
    {
        DataTable oDTPubli = new DataTable();
        private Int32 codigoPublicacion;

        DateTime dteFecIni;
        DateTime dteFecVto;

        public DetallesPublicacion(Int32 _codigoPublicacion)
        { 
            InitializeComponent();
            this.codigoPublicacion = _codigoPublicacion;
        }

        private void DetallesPublicacion_Load(object sender, EventArgs e)
        {
            oDTPubli = InterfazBD.getPublicacion(Convert.ToInt32( this.codigoPublicacion));
            this.CargarDatosPubli();
        }

        private void CargarDatosPubli()
        {
            DataRow oDr = oDTPubli.Rows[0];

            cmbTipoPubli.SelectedValue = oDr["pub_tipo_Id"];
            txtDesc.Text = oDr["pub_Descripcion"].ToString();
            nudStock.Value = Convert.ToDecimal(oDr["pub_Stock"]);
            dteFecIni = Convert.ToDateTime(oDr["pub_Fecha_Ini"]);
            dteFecVto = Convert.ToDateTime(oDr["pub_Fecha_Vto"]);
            nudPrecio.Value = Convert.ToDecimal(oDr["pub_Precio"]);
            cmbTipoVis.SelectedValue = oDr["pub_visibilidad_Id"];
            cmbEstado.SelectedValue = oDr["pub_estado_Id"];
            chkPreguntas.Checked = Convert.ToBoolean(oDr["pub_Permite_Preg"]);

            txtFechaIni.Text = dteFecIni.ToShortDateString();
            txtFechaVto.Text = dteFecVto.ToShortDateString();

        }
    }
}
