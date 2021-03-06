﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class Abm_Empresas_Busqueda : Form
    {
        private DataRow mobjDrResultado;

        public System.Data.DataRow Resultado
        {
            get { return mobjDrResultado; }
        }

        public Abm_Empresas_Busqueda()
        {
            InitializeComponent();
        }

        private void Abm_Empresas_Busqueda_Load(object sender, EventArgs e)
        {
            mobjDrResultado = null;
        }

        private string ArmarFiltros()
        {
            String emp_Razon_Social = tboxRazonSocial.Text;
            String emp_CUIT = tboxCUIT.Text;
            String emp_Mail = tboxMail.Text;

            String filtros = " WHERE E.emp_usu_id = U.usu_Id AND U.usu_Eliminado = 0 ";

            if (emp_Razon_Social != "")
                filtros = filtros + " and E.emp_Razon_Social like '%" + emp_Razon_Social + "%' ";

            if (emp_CUIT != "")
                filtros = filtros + " and E.emp_CUIT like '%" + emp_CUIT + "%' ";

            if (emp_Mail != "")
                filtros = filtros + " and E.emp_Mail like '%" + emp_Mail + "%' ";

            return filtros;
        }

        private void Seleccionar()
        {
            DataGridViewSelectedRowCollection list = this.gridEmpresas.SelectedRows;

            if (list.Count > 0)
                mobjDrResultado = ((DataRowView)gridEmpresas.SelectedRows[0].DataBoundItem).Row;
            else
                MessageBox.Show("Seleccione una empresa.", "Alerta", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            this.Close();
        }

        private void Buscar()
        {
            try
            {
                gridEmpresas.DataSource = InterfazBD.BuscarEmpresas(ArmarFiltros());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            tboxRazonSocial.Text = string.Empty;
            tboxCUIT.Text = string.Empty;
            tboxMail.Text = string.Empty;
            gridEmpresas.DataSource = null;
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            Buscar();
        }

        private void btnSeleccionar_Click(object sender, EventArgs e)
        {
            Seleccionar();
        }

        private void gridEmpresas_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Seleccionar();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            Limpiar();
        }
    }
}
