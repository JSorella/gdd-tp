namespace FrbaCommerce
{
    partial class Respuesta
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
            this.txtRespuesta = new System.Windows.Forms.TextBox();
            this.btnResponder = new System.Windows.Forms.Button();
            this.lblLenght = new System.Windows.Forms.Label();
            this.txtPregunta = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRespuesta.Location = new System.Drawing.Point(12, 114);
            this.txtRespuesta.MaxLength = 255;
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(418, 100);
            this.txtRespuesta.TabIndex = 0;
            this.txtRespuesta.TextChanged += new System.EventHandler(this.txtRespuesta_TextChanged);
            // 
            // btnResponder
            // 
            this.btnResponder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResponder.Location = new System.Drawing.Point(327, 220);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(103, 28);
            this.btnResponder.TabIndex = 1;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // lblLenght
            // 
            this.lblLenght.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblLenght.AutoSize = true;
            this.lblLenght.Location = new System.Drawing.Point(12, 228);
            this.lblLenght.Name = "lblLenght";
            this.lblLenght.Size = new System.Drawing.Size(107, 13);
            this.lblLenght.TabIndex = 3;
            this.lblLenght.Text = "Caracteres restantes:";
            // 
            // txtPregunta
            // 
            this.txtPregunta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPregunta.Location = new System.Drawing.Point(12, 25);
            this.txtPregunta.MaxLength = 255;
            this.txtPregunta.Multiline = true;
            this.txtPregunta.Name = "txtPregunta";
            this.txtPregunta.ReadOnly = true;
            this.txtPregunta.Size = new System.Drawing.Size(418, 59);
            this.txtPregunta.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Pregunta:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(113, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ingrese su Respuesta:";
            // 
            // Respuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(445, 253);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtPregunta);
            this.Controls.Add(this.lblLenght);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.txtRespuesta);
            this.Name = "Respuesta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Responder Pregunta";
            this.Load += new System.EventHandler(this.Respuesta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Button btnResponder;
        private System.Windows.Forms.Label lblLenght;
        private System.Windows.Forms.TextBox txtPregunta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}