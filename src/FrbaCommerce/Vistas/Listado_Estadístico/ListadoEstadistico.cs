using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce;

namespace FrbaCommerce
{
    public partial class ListadoEstadistico : Form
    {
        public ListadoEstadistico()
        {
            InitializeComponent();
        }

        private void ListadoEstadistico_Load(object sender, EventArgs e)
        {
            gridListado.Visible = false;
            cargarComboBoxAnios();
            cargarComboBoxTrimestres();
            cargarComboBoxListados();
            cargarComboBoxVisibilidades();
        }


        public void cargarComboBoxAnios()
        {
            cboxAnio.DataSource = InterfazBD.getAnios();
            cboxAnio.DisplayMember = "Anio";
            cboxAnio.ValueMember = "Anio";
        }

        public void cargarComboBoxTrimestres()
        {
            List<KeyValuePair<string, int>> trimestre = new List<KeyValuePair<string, int>>();
            trimestre.Add(generarKeyValueInt("Primero", 1));
            trimestre.Add(generarKeyValueInt("Segundo", 2));
            trimestre.Add(generarKeyValueInt("Tercero", 3));
            trimestre.Add(generarKeyValueInt("Cuarto", 4));
            cboxTrimestre.DisplayMember = "Key";
            cboxTrimestre.ValueMember = "Value";
            cboxTrimestre.DataSource = trimestre;
        }

        public void cargarComboBoxListados()
        {
            List<KeyValuePair<string, int>> listado = new List<KeyValuePair<string, int>>();
            listado.Add(generarKeyValueInt("Vendedores con mayor cantidad de productos no vendidos", 1));
            listado.Add(generarKeyValueInt("Vendedores con mayor facturacion", 2));
            listado.Add(generarKeyValueInt("Vendedores con mayores calificaciones", 3));
            listado.Add(generarKeyValueInt("Clientes con mayor cantidad de publicaciones sin calificar", 4));
            cboxListado.DisplayMember = "Key";
            cboxListado.ValueMember = "Value";
            cboxListado.DataSource = listado;
        }

        public void cargarComboBoxVisibilidades()
        {
            String query = "Select pubvis_id,pubvis_Descripcion From J2LA.Publicaciones_Visibilidades " +
                "Where pubvis_Eliminado = 0 " +
                "Order By pubvis_Descripcion";

            DataTable dt = Singleton.conexion.executeQueryTable(query, null, null);
            DataRow dr = dt.NewRow();
            dr["pubvis_id"] = 0;
            dr["pubvis_Descripcion"] = "Sin Filtro";
            dt.Rows.InsertAt(dr, 0);
            cboxVisibilidad.DataSource = dt;
            cboxVisibilidad.DisplayMember = "pubvis_Descripcion";
            cboxVisibilidad.ValueMember = "pubvis_id";
        }


        public void cargarComboBoxMeses()
        {
            List<KeyValuePair<string, int>> mes = new List<KeyValuePair<string, int>>();
            mes.Add(generarKeyValueInt("Sin Filtro", 0));
            if (cboxTrimestre.SelectedIndex == 0)
            {
                mes.Add(generarKeyValueInt("Enero", 1));
                mes.Add(generarKeyValueInt("Febrero", 2));
                mes.Add(generarKeyValueInt("Marzo", 3));
            }
            else
            {
                if (cboxTrimestre.SelectedIndex == 1)
                {
                    mes.Add(generarKeyValueInt("Abril", 4));
                    mes.Add(generarKeyValueInt("Mayo", 5));
                    mes.Add(generarKeyValueInt("Junio", 6));
                }
                else
                {
                    if (cboxTrimestre.SelectedIndex == 2)
                    {
                        mes.Add(generarKeyValueInt("Julio", 7));
                        mes.Add(generarKeyValueInt("Agosto", 8));
                        mes.Add(generarKeyValueInt("Septiembre", 9));
                    }
                    else
                    {
                        mes.Add(generarKeyValueInt("Octubre", 10));
                        mes.Add(generarKeyValueInt("Noviembre", 11));
                        mes.Add(generarKeyValueInt("Diciembre", 12));
                    }
                }
            }
            cboxMes.DisplayMember = "Key";
            cboxMes.ValueMember = "Value";
            cboxMes.DataSource = mes;
        }

        private KeyValuePair<string, int> generarKeyValueInt(string descripcion, int numero)
        {
            return new KeyValuePair<string, int>(descripcion, numero);
        }

        private int getAnio()
        {
            return Convert.ToInt32(cboxAnio.SelectedValue);
        }

        private int getTrimestre()
        {
            return ((KeyValuePair<string, int>)cboxTrimestre.SelectedItem).Value;
        }

        private int getVisibilidad()
        {
            return Convert.ToInt32(((DataRowView)cboxVisibilidad.SelectedItem).Row["pubvis_id"]);
        }

        private int getMes()
        {
            return ((KeyValuePair<string, int>)cboxMes.SelectedItem).Value;
        }

        private void cargarGrid(DataTable dt)
        {
            gridListado.Visible = true;
            gridListado.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int anio = this.getAnio();
            int trimestre = this.getTrimestre();
            switch (cboxListado.SelectedIndex)
            {
                case 0:
                    int visibilidad = getVisibilidad();
                    int mes = getMes();
                    this.cargarGrid(InterfazBD.getTop5VendedoresConMayorCantDeProdNoVendidos(anio, trimestre, visibilidad, mes));
                    break;
                case 1:
                    this.cargarGrid(InterfazBD.getTop5VendedoresConMayorFacturacion(anio, trimestre));
                    break;
                case 2:
                    this.cargarGrid(InterfazBD.getTop5VendedoresConMayoresCalificaciones(anio, trimestre));
                    break;
                case 3:
                    this.cargarGrid(InterfazBD.getTop5ClientesConMayorCantDePublicacionesSinCalificar(anio, trimestre));
                    break;
                default:
                    break;
            }
        }

        private void cboxListado_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboxListado.SelectedIndex == 0)
            {
                cboxVisibilidad.Visible = true;
                cboxMes.Visible = true;
                labelVisibilidad.Visible = true;
                labelMes.Visible = true;
            }
            else
            {
                cboxVisibilidad.Visible = false;
                cboxMes.Visible = false;
                labelVisibilidad.Visible = false;
                labelMes.Visible = false;
            }
        }

        private void cboxTrimestre_SelectedIndexChanged(object sender, EventArgs e)
        {
            cargarComboBoxMeses();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

    }
}
