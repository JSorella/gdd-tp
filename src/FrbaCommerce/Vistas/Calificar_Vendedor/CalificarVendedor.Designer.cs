namespace FrbaCommerce
{
    partial class CalificarVendedor
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
            this.cboxCalificaciones = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tboxComentario = new System.Windows.Forms.TextBox();
            this.Guardar = new System.Windows.Forms.Button();
            this.lblLenght = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cboxCalificaciones
            // 
            this.cboxCalificaciones.FormattingEnabled = true;
            this.cboxCalificaciones.Location = new System.Drawing.Point(168, 12);
            this.cboxCalificaciones.Name = "cboxCalificaciones";
            this.cboxCalificaciones.Size = new System.Drawing.Size(100, 21);
            this.cboxCalificaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione una calificación :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese un comentario";
            // 
            // tboxComentario
            // 
            this.tboxComentario.Location = new System.Drawing.Point(12, 65);
            this.tboxComentario.MaxLength = 255;
            this.tboxComentario.Multiline = true;
            this.tboxComentario.Name = "tboxComentario";
            this.tboxComentario.Size = new System.Drawing.Size(382, 70);
            this.tboxComentario.TabIndex = 3;
            this.tboxComentario.TextChanged += new System.EventHandler(this.tboxComentario_TextChanged);
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(285, 141);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(109, 35);
            this.Guardar.TabIndex = 4;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // lblLenght
            // 
            this.lblLenght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLenght.AutoSize = true;
            this.lblLenght.Location = new System.Drawing.Point(12, 152);
            this.lblLenght.Name = "lblLenght";
            this.lblLenght.Size = new System.Drawing.Size(107, 13);
            this.lblLenght.TabIndex = 5;
            this.lblLenght.Text = "Caracteres restantes:";
            // 
            // CalificarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 185);
            this.Controls.Add(this.lblLenght);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.tboxComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxCalificaciones);
            this.Name = "CalificarVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Calificar";
            this.Load += new System.EventHandler(this.CalificarVendedor_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cboxCalificaciones;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tboxComentario;
        private System.Windows.Forms.Button Guardar;
        private System.Windows.Forms.Label lblLenght;
    }
}