﻿namespace FrbaCommerce
{
    partial class CalificarBusqueda
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.gridCalificacionesPendientes = new System.Windows.Forms.DataGridView();
            this.SeleccionarCompra = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridCalificacionesPendientes)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una compra para calificar a su vendedor:";
            // 
            // gridCalificacionesPendientes
            // 
            this.gridCalificacionesPendientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridCalificacionesPendientes.Location = new System.Drawing.Point(18, 59);
            this.gridCalificacionesPendientes.Name = "gridCalificacionesPendientes";
            this.gridCalificacionesPendientes.Size = new System.Drawing.Size(469, 145);
            this.gridCalificacionesPendientes.TabIndex = 1;
            // 
            // SeleccionarCompra
            // 
            this.SeleccionarCompra.Location = new System.Drawing.Point(215, 223);
            this.SeleccionarCompra.Name = "SeleccionarCompra";
            this.SeleccionarCompra.Size = new System.Drawing.Size(69, 33);
            this.SeleccionarCompra.TabIndex = 2;
            this.SeleccionarCompra.Text = "Calificar";
            this.SeleccionarCompra.UseVisualStyleBackColor = true;
            this.SeleccionarCompra.Click += new System.EventHandler(this.SeleccionarCompra_Click);
            // 
            // CalificarBusqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 271);
            this.Controls.Add(this.SeleccionarCompra);
            this.Controls.Add(this.gridCalificacionesPendientes);
            this.Controls.Add(this.label1);
            this.Name = "CalificarBusqueda";
            this.Text = "Calificar Vendedor";
            this.Load += new System.EventHandler(this.CalificarVendedor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridCalificacionesPendientes)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView gridCalificacionesPendientes;
        private System.Windows.Forms.Button SeleccionarCompra;
    }
}