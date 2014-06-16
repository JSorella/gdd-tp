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
            this.SuspendLayout();
            // 
            // cboxCalificaciones
            // 
            this.cboxCalificaciones.FormattingEnabled = true;
            this.cboxCalificaciones.Location = new System.Drawing.Point(141, 22);
            this.cboxCalificaciones.Name = "cboxCalificaciones";
            this.cboxCalificaciones.Size = new System.Drawing.Size(84, 21);
            this.cboxCalificaciones.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(19, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(116, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione calificacion";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Ingrese un comentario";
            // 
            // tboxComentario
            // 
            this.tboxComentario.Location = new System.Drawing.Point(22, 105);
            this.tboxComentario.Multiline = true;
            this.tboxComentario.Name = "tboxComentario";
            this.tboxComentario.Size = new System.Drawing.Size(354, 70);
            this.tboxComentario.TabIndex = 3;
            // 
            // Guardar
            // 
            this.Guardar.Location = new System.Drawing.Point(141, 190);
            this.Guardar.Name = "Guardar";
            this.Guardar.Size = new System.Drawing.Size(109, 35);
            this.Guardar.TabIndex = 4;
            this.Guardar.Text = "Guardar";
            this.Guardar.UseVisualStyleBackColor = true;
            this.Guardar.Click += new System.EventHandler(this.Guardar_Click);
            // 
            // CalificarVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 237);
            this.Controls.Add(this.Guardar);
            this.Controls.Add(this.tboxComentario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboxCalificaciones);
            this.Name = "CalificarVendedor";
            this.Text = "Calificar Vendedor";
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
    }
}