using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace FrbaCommerce
{
    public partial class ComboCheck : UserControl
    {
        private bool booPanelVisible;
        private string[] strChequeados;
        private string strDescrip;
        private string strID;

        public ComboCheck()
        {
            InitializeComponent();
            
            OcultarPanel();
        }

        private void btnOcultarPanel_Click(object sender, EventArgs e)
        {
            OcultarPanel();
        }

        private void clbLista_MouseClick(object sender, MouseEventArgs e)
        {
            SeleccionarItem();
        }

        private void clbLista_SelectedIndexChanged(object sender, EventArgs e)
        {
            SeleccionarItem();
        }

        private void clbLista_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SeleccionarItem();
        }

        private void btnTodos_Click(object sender, EventArgs e)
        {
            TildarTodos();
        }

        private void btnInvertir_Click(object sender, EventArgs e)
        {
            InvertirTildados();
        }

        private void MostrarPanel()
        {
            booPanelVisible = true;
            this.Height = 206;
            this.clbLista.Focus();
        }

        private void OcultarPanel()
        {
            booPanelVisible = false;
            this.Height = 21;
            SeleccionarItem();
            this.clbLista.Focus();
        }

        private void AgregarChequeado(int Index, string strValor)
        {
            Array.Resize(ref strChequeados, Index + 1);
            strChequeados[Index] = strValor;
        }

        private void TildarTodos()
        {

            for (int intIndex = 0; intIndex <= clbLista.Items.Count - 1; intIndex++)
            {
                clbLista.SetItemCheckState(intIndex, CheckState.Checked);
            }

            SeleccionarItem();
        }

        private void InvertirTildados()
        {
            for (int intIndex = 0; intIndex <= clbLista.Items.Count - 1; intIndex++)
            {
                if (clbLista.GetItemChecked(intIndex))
                    clbLista.SetItemCheckState(intIndex, CheckState.Unchecked);
                else
                    clbLista.SetItemCheckState(intIndex, CheckState.Checked);
            }

            SeleccionarItem();
        }

        private void SeleccionarItem()
        {
            string strDescripcion = "";

            foreach (DataRowView oDrv in clbLista.CheckedItems)
            {
                if (strDescripcion.Length == 0)
                {
                    strDescripcion = strDescripcion + Convert.ToString(oDrv.Row[strDescrip]);
                }
                else
                {
                    strDescripcion = strDescripcion + " - " + Convert.ToString(oDrv.Row[strDescrip]);
                }
            }

            if (strDescripcion.Length == 0)
                strDescripcion = "(Todos)";

            cmbCombo.Text = strDescripcion;
            toolTip1.SetToolTip(cmbCombo, strDescripcion);
        }

        public string Texto()
        {
            return cmbCombo.Text;
        }

        public void TildeEnTodos()
        {
            TildarTodos();
        }

        public void TildeEnNinguno()
        {
            TildarTodos();
            InvertirTildados();
        }

        public void OcultarElPanel()
        {
            booPanelVisible = false;
            this.Height = 21;
            SeleccionarItem();
            this.clbLista.Focus();
        }

        public void SetearDatosLista(DataTable oDt, string strCampoID, string strCampoDescripcion)
        {
            strDescrip = strCampoDescripcion;
            strID = strCampoID;

            clbLista.DataSource = oDt;
            clbLista.DisplayMember = strCampoDescripcion;
            clbLista.ValueMember = strCampoID;
        }

        public string ObtenerstrChequeados(string strCampo)
        {
            string functionReturnValue = null;

            functionReturnValue = "";

            foreach (DataRowView oDrv in clbLista.CheckedItems)
                functionReturnValue = functionReturnValue + ", " + Convert.ToString(oDrv.Row[strCampo]);

            if (!string.IsNullOrEmpty(functionReturnValue))
                functionReturnValue = functionReturnValue.Remove(0, 1);

            return functionReturnValue;
        }

        public bool EstaTildado(string strCampo, string strValor)
        {
            int intIndex = 0;

            foreach (DataRowView oDrv in clbLista.CheckedItems)
            {
                if (Convert.ToString(oDrv.Row[strCampo]) == strValor)
                    return true;

                intIndex = intIndex + 1;
            }

            return false;
        }

        private void cmbCombo_MouseClick(object sender, MouseEventArgs e)
        {
            if ((e.X < this.cmbCombo.Width) && (e.X > this.cmbCombo.Width - 17))
            {
                if (booPanelVisible)
                    OcultarPanel();
                else
                    MostrarPanel();
            }
        }
    }
}
