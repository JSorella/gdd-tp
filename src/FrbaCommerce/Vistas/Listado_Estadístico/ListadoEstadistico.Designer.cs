﻿namespace FrbaCommerce
{
    partial class ListadoEstadistico
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.gridListado = new System.Windows.Forms.DataGridView();
            this.cboxListado = new System.Windows.Forms.ComboBox();
            this.cboxAnio = new System.Windows.Forms.ComboBox();
            this.cboxTrimestre = new System.Windows.Forms.ComboBox();
            this.btnConsultar = new System.Windows.Forms.Button();
            this.cboxVisibilidad = new System.Windows.Forms.ComboBox();
            this.cboxMes = new System.Windows.Forms.ComboBox();
            this.labelVisibilidad = new System.Windows.Forms.Label();
            this.labelMes = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(74, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Trimestre";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(31, 99);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(93, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Seleccione listado";
            // 
            // gridListado
            // 
            this.gridListado.AllowUserToAddRows = false;
            this.gridListado.AllowUserToDeleteRows = false;
            this.gridListado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gridListado.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.gridListado.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridListado.Location = new System.Drawing.Point(12, 219);
            this.gridListado.Name = "gridListado";
            this.gridListado.ReadOnly = true;
            this.gridListado.Size = new System.Drawing.Size(562, 214);
            this.gridListado.TabIndex = 6;
            // 
            // cboxListado
            // 
            this.cboxListado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxListado.FormattingEnabled = true;
            this.cboxListado.Location = new System.Drawing.Point(136, 96);
            this.cboxListado.Name = "cboxListado";
            this.cboxListado.Size = new System.Drawing.Size(355, 21);
            this.cboxListado.TabIndex = 7;
            this.cboxListado.SelectedIndexChanged += new System.EventHandler(this.cboxListado_SelectedIndexChanged);
            // 
            // cboxAnio
            // 
            this.cboxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxAnio.FormattingEnabled = true;
            this.cboxAnio.Location = new System.Drawing.Point(136, 17);
            this.cboxAnio.Name = "cboxAnio";
            this.cboxAnio.Size = new System.Drawing.Size(81, 21);
            this.cboxAnio.TabIndex = 9;
            // 
            // cboxTrimestre
            // 
            this.cboxTrimestre.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxTrimestre.FormattingEnabled = true;
            this.cboxTrimestre.Location = new System.Drawing.Point(136, 56);
            this.cboxTrimestre.Name = "cboxTrimestre";
            this.cboxTrimestre.Size = new System.Drawing.Size(81, 21);
            this.cboxTrimestre.TabIndex = 10;
            this.cboxTrimestre.SelectedIndexChanged += new System.EventHandler(this.cboxTrimestre_SelectedIndexChanged);
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(508, 92);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(64, 26);
            this.btnConsultar.TabIndex = 11;
            this.btnConsultar.Text = "Consultar!";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click);
            // 
            // cboxVisibilidad
            // 
            this.cboxVisibilidad.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxVisibilidad.FormattingEnabled = true;
            this.cboxVisibilidad.Location = new System.Drawing.Point(136, 137);
            this.cboxVisibilidad.Name = "cboxVisibilidad";
            this.cboxVisibilidad.Size = new System.Drawing.Size(81, 21);
            this.cboxVisibilidad.TabIndex = 12;
            // 
            // cboxMes
            // 
            this.cboxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboxMes.FormattingEnabled = true;
            this.cboxMes.Location = new System.Drawing.Point(136, 174);
            this.cboxMes.Name = "cboxMes";
            this.cboxMes.Size = new System.Drawing.Size(81, 21);
            this.cboxMes.TabIndex = 13;
            // 
            // labelVisibilidad
            // 
            this.labelVisibilidad.AutoSize = true;
            this.labelVisibilidad.Location = new System.Drawing.Point(71, 140);
            this.labelVisibilidad.Name = "labelVisibilidad";
            this.labelVisibilidad.Size = new System.Drawing.Size(53, 13);
            this.labelVisibilidad.TabIndex = 14;
            this.labelVisibilidad.Text = "Visibilidad";
            // 
            // labelMes
            // 
            this.labelMes.AutoSize = true;
            this.labelMes.Location = new System.Drawing.Point(97, 177);
            this.labelMes.Name = "labelMes";
            this.labelMes.Size = new System.Drawing.Size(27, 13);
            this.labelMes.TabIndex = 15;
            this.labelMes.Text = "Mes";
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 443);
            this.Controls.Add(this.labelMes);
            this.Controls.Add(this.labelVisibilidad);
            this.Controls.Add(this.cboxMes);
            this.Controls.Add(this.cboxVisibilidad);
            this.Controls.Add(this.btnConsultar);
            this.Controls.Add(this.cboxTrimestre);
            this.Controls.Add(this.cboxAnio);
            this.Controls.Add(this.cboxListado);
            this.Controls.Add(this.gridListado);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listados Estadisticos";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridListado)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView gridListado;
        private System.Windows.Forms.ComboBox cboxListado;
        private System.Windows.Forms.ComboBox cboxAnio;
        private System.Windows.Forms.ComboBox cboxTrimestre;
        private System.Windows.Forms.Button btnConsultar;
        private System.Windows.Forms.ComboBox cboxVisibilidad;
        private System.Windows.Forms.ComboBox cboxMes;
        private System.Windows.Forms.Label labelVisibilidad;
        private System.Windows.Forms.Label labelMes;
    }
}