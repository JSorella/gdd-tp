﻿namespace FrbaCommerce
{
    partial class Abm_Visib_Baja
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
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.txtCodVisib = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBaja
            // 
            this.btnBaja.Location = new System.Drawing.Point(242, 60);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(101, 27);
            this.btnBaja.TabIndex = 3;
            this.btnBaja.Text = "Dar de Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            this.btnBaja.Click += new System.EventHandler(this.btnBaja_Click);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(242, 8);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(101, 27);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // txtCodVisib
            // 
            this.txtCodVisib.Location = new System.Drawing.Point(127, 12);
            this.txtCodVisib.Name = "txtCodVisib";
            this.txtCodVisib.Size = new System.Drawing.Size(109, 20);
            this.txtCodVisib.TabIndex = 1;
            this.txtCodVisib.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.txtCodVisib.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodVisib_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Codigo de Visibilidad :";
            // 
            // Abm_Visib_Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 99);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.txtCodVisib);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Abm_Visib_Baja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Baja de Visibilidades";
            this.Load += new System.EventHandler(this.Abm_Visib_Baja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox txtCodVisib;
        private System.Windows.Forms.Label label1;
    }
}