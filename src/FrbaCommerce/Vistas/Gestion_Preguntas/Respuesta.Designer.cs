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
            this.btnrespond = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtRespuesta
            // 
            this.txtRespuesta.Location = new System.Drawing.Point(13, 13);
            this.txtRespuesta.Multiline = true;
            this.txtRespuesta.Name = "txtRespuesta";
            this.txtRespuesta.Size = new System.Drawing.Size(416, 79);
            this.txtRespuesta.TabIndex = 0;
            // 
            // btnrespond
            // 
            this.btnrespond.Location = new System.Drawing.Point(313, 116);
            this.btnrespond.Name = "btnrespond";
            this.btnrespond.Size = new System.Drawing.Size(103, 28);
            this.btnrespond.TabIndex = 1;
            this.btnrespond.Text = "Responder";
            this.btnrespond.UseVisualStyleBackColor = true;
            this.btnrespond.Click += new System.EventHandler(this.btnrespond_Click);
            // 
            // Respuesta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 156);
            this.Controls.Add(this.btnrespond);
            this.Controls.Add(this.txtRespuesta);
            this.Name = "Respuesta";
            this.Text = "Respuesta";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtRespuesta;
        private System.Windows.Forms.Button btnrespond;
    }
}