using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce;

namespace FrbaCommerce.Vistas.Listado_Estadistico
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
            cargarComboBoxAños();
            cargarComboBoxTrimestres();
            cargarComboBoxListados();
            cargarComboBoxVisibilidades();
        }


        public void cargarComboBoxAños()
        {
            List<KeyValuePair<string, int>> anio = new List<KeyValuePair<string, int>>();
            //esto se podria flexibilizar trayendo los anios de las fechas de la base de datos, pero como la bdd no crece y estamos en el 2014.
            anio.Add(generarKeyValueInt("2013", 2013));
            anio.Add(generarKeyValueInt("2014", 2014));
            cboxAnio.DisplayMember = "Key";
            cboxAnio.ValueMember = "Value";
            cboxAnio.DataSource = anio;
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
            listado.Add(generarKeyValueInt("getTop5VendedoresConMayorCantDeProdNoVendidos", 1));
            listado.Add(generarKeyValueInt("getTop5VendedoresConMayorFacturacion", 2));
            listado.Add(generarKeyValueInt("getTop5VendedoresConMayoresCalificaciones", 3));
            listado.Add(generarKeyValueInt("getTop5ClientesConMayorCantDePublicacionesSinCalificar", 4));
            cboxListado.DisplayMember = "Key";
            cboxListado.ValueMember = "Value";
            cboxListado.DataSource = listado;
        }

        public void cargarComboBoxVisibilidades()
        {
            string query = "select * from J2LA.Publicaciones_Visibilidades";
            Connection connect = new Connection();
            DataTable tablaVisibilidades = connect.execute_query(query);
            cboxVisibilidad.DataSource = tablaVisibilidades;
            cboxVisibilidad.DisplayMember = "pubvis_Descripcion";
            cboxVisibilidad.ValueMember = "pubvis_Codigo";
        }

        public void cargarComboBoxMeses()
        {
            List<KeyValuePair<string, int>> mes = new List<KeyValuePair<string, int>>();
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
            return ((KeyValuePair<string, int>)cboxAnio.SelectedItem).Value;
        }

        private int getTrimestre()
        {
            return ((KeyValuePair<string, int>)cboxTrimestre.SelectedItem).Value;
        }

        private int getVisibilidad()
        {
            return ((KeyValuePair<string, int>)cboxVisibilidad.SelectedItem).Value;
        }

        private int getMes()
        {
            return ((KeyValuePair<string, int>)cboxMes.SelectedItem).Value;
        }

        public DataTable getTop5VendedoresConMayorCantDeProdNoVendidos(int anio, int trimestre)
        {
            string query = "exec J2LA.getTop5VendedoresConMayorCantDeProdNoVendidos "+anio+", "+trimestre;
            Connection connect = new Connection();
            DataTable tablaListado = connect.execute_query(query);
            return tablaListado;
        }

        public DataTable getTop5VendedoresConMayorFacturacion(int anio, int trimestre)
        {
            string query = "exec J2LA.getTop5VendedoresConMayorFacturacion " + anio + ", " + trimestre;
            Connection connect = new Connection();
            DataTable tablaListado = connect.execute_query(query);
            return tablaListado;
        }

        public DataTable getTop5VendedoresConMayoresCalificaciones(int anio, int trimestre)
        {
            string query = "exec J2LA.getTop5VendedoresConMayoresCalificaciones " + anio + ", " + trimestre;
            Connection connect = new Connection();
            DataTable tablaListado = connect.execute_query(query);
            return tablaListado;
        }

        public DataTable getTop5ClientesConMayorCantDePublicacionesSinCalificar(int anio, int trimestre)
        {
            string query = "exec J2LA.getTop5ClientesConMayorCantDePublicacionesSinCalificar " + anio + ", " + trimestre;
            Connection connect = new Connection();
            DataTable tablaListado = connect.execute_query(query);
            return tablaListado;
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
                    this.cargarGrid(getTop5VendedoresConMayorCantDeProdNoVendidos(anio, trimestre));
                    break;
                case 1:
                    this.cargarGrid(getTop5VendedoresConMayorFacturacion(anio, trimestre));
                    break;
                case 2:
                    this.cargarGrid(getTop5VendedoresConMayoresCalificaciones(anio, trimestre));
                    break;
                case 3:
                    this.cargarGrid(getTop5ClientesConMayorCantDePublicacionesSinCalificar(anio, trimestre));
                    break;
                default:
                    break;
            }
        }

        private void cBoxVisibilidad_SelectedIndexChanged(object sender, EventArgs e)
        {

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

    }
}
