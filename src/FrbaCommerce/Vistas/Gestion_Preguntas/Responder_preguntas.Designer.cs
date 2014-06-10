namespace FrbaCommerce
{
    partial class Responder_preguntas
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
            this.gridPreguntas = new System.Windows.Forms.DataGridView();
            this.btnResponder = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gridPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridPreguntas
            // 
            this.gridPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridPreguntas.Location = new System.Drawing.Point(13, 13);
            this.gridPreguntas.Name = "gridPreguntas";
            this.gridPreguntas.Size = new System.Drawing.Size(577, 234);
            this.gridPreguntas.TabIndex = 0;
            // 
            // btnResponder
            // 
            this.btnResponder.Location = new System.Drawing.Point(13, 253);
            this.btnResponder.Name = "btnResponder";
            this.btnResponder.Size = new System.Drawing.Size(110, 40);
            this.btnResponder.TabIndex = 1;
            this.btnResponder.Text = "Responder";
            this.btnResponder.UseVisualStyleBackColor = true;
            this.btnResponder.Click += new System.EventHandler(this.btnResponder_Click);
            // 
            // Responder_preguntas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 300);
            this.Controls.Add(this.btnResponder);
            this.Controls.Add(this.gridPreguntas);
            this.Name = "Responder_preguntas";
            this.Text = "Responder preguntas";
            ((System.ComponentModel.ISupportInitialize)(this.gridPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridPreguntas;
        private System.Windows.Forms.Button btnResponder;
    }
}