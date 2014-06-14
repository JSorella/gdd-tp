namespace FrbaCommerce
{
    partial class Abm_Empresa_Baja
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.tboxEmpresaSeleccionada = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnSeleccionar);
            this.panel1.Controls.Add(this.tboxEmpresaSeleccionada);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(499, 46);
            this.panel1.TabIndex = 60;
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(415, 6);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(73, 30);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            // 
            // tboxEmpresaSeleccionada
            // 
            this.tboxEmpresaSeleccionada.Location = new System.Drawing.Point(190, 12);
            this.tboxEmpresaSeleccionada.Name = "tboxEmpresaSeleccionada";
            this.tboxEmpresaSeleccionada.Size = new System.Drawing.Size(219, 20);
            this.tboxEmpresaSeleccionada.TabIndex = 1;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(4, 15);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(184, 13);
            this.label15.TabIndex = 0;
            this.label15.Text = "Indique la razón social de la empresa:";
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.Location = new System.Drawing.Point(206, 70);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(108, 30);
            this.btnDarDeBaja.TabIndex = 3;
            this.btnDarDeBaja.Text = "Dar de Baja";
            this.btnDarDeBaja.UseVisualStyleBackColor = true;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // 
            // Abm_Empresa_Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 109);
            this.Controls.Add(this.btnDarDeBaja);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "Abm_Empresa_Baja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abm_Empresa_Baja";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.TextBox tboxEmpresaSeleccionada;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnDarDeBaja;

    }
}