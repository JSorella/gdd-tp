using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using FrbaCommerce.Vistas.Abm_Rol;
using FrbaCommerce.Vistas.Registro_Usuario;
using FrbaCommerce.Vistas.Abm_Cliente;
using FrbaCommerce.Vistas.Listado_Estadistico;
using FrbaCommerce.Vistas.Editar_Publicacion;
using FrbaCommerce.Vistas.Comprar_Ofertar;
using FrbaCommerce.Vistas.Historial_Cliente;
using FrbaCommerce.Vistas.Facturar_Publicaciones;
using FrbaCommerce.Vistas.Gestion_de_Preguntas;
using FrbaCommerce.Vistas.Abm_Visibilidad;
using FrbaCommerce.Vistas.Abm_Empresa;



namespace FrbaCommerce.Vistas.Login
{
    public partial class MenuFunciones : Form
    {
        public MenuFunciones()
        {
            this.InitializeComponent();
            this.comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void MenuFunciones_Load(object sender, EventArgs e)
        {
            this.comboBox1.DataSource = StoredProcedures.getFuncionalidadesPorRol(Singleton.sessionRol);
            this.comboBox1.DisplayMember = "fun_Nombre";
            this.comboBox1.ValueMember = "fun_Id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //switch (Convert.ToString(((DataRowView)comboBox1.SelectedItem).Row["fun_Nombre"]))
            switch (comboBox1.Text)
            {
                case "ABM de Rol":
                    Abm_Rol_Busqueda abmRolWindow = new Abm_Rol_Busqueda();
                    abmRolWindow.ShowDialog();
                    break;

                //case "Registro de Usuario":
                //    RegistroUsuario registroUsuarioWindow = new RegistroUsuario();
                //    registroUsuarioWindow.ShowDialog();
                //    break;

                case "ABM de Cliente":
                    AbmCliente abmClienteWindow = new AbmCliente();
                    abmClienteWindow.ShowDialog();
                    break;

                case "ABM de Empresa":
                    AbmEmpresa abmEmpresaWindow = new AbmEmpresa();
                    abmEmpresaWindow.ShowDialog();
                    break;

                case "ABM de visibilidad de publicacion":
                    AbmVisibilidad abmVisibilidadWindow = new AbmVisibilidad();
                    abmVisibilidadWindow.ShowDialog();
                    break;

                case "Generar Publicacion":
                    GenerarPublicacion generarPublicacionWindow = new GenerarPublicacion();
                    generarPublicacionWindow.ShowDialog();
                    break;

                case "Editar Publicacion":
                    EditarPublicacion editarPublicacionWindow = new EditarPublicacion();
                    editarPublicacionWindow.ShowDialog();
                    break;

                case "Comprar/Ofertar":
                    ComprarOfertar comprarOfertarEstadisticoWindow = new ComprarOfertar();
                    comprarOfertarEstadisticoWindow.ShowDialog();
                    break;

                case "Gestión de Preguntas":
                    GestionPreguntas gestionPreguntasWindow = new GestionPreguntas();
                    gestionPreguntasWindow.ShowDialog();
                    break;

                case "Historial de Cliente":
                    HistorialCliente historialClienteWindow = new HistorialCliente();
                    historialClienteWindow.ShowDialog();
                    break;

                case "Facturar Publicaciones":
                    FacturarPublicaciones facturarPublicacionesWindow = new FacturarPublicaciones();
                    facturarPublicacionesWindow.ShowDialog();
                    break;
                    
                case "Listado Estadístico":
                    ListadoEstadistico listadoEstadisticoWindow = new ListadoEstadistico();
                    listadoEstadisticoWindow.ShowDialog();
                    break;
              
            }
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
