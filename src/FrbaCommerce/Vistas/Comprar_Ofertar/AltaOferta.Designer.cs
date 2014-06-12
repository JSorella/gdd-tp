namespace FrbaCommerce
{
    partial class AltaOferta
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
            this.btnOfertar = new System.Windows.Forms.Button();
            this.nudCantidad = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).BeginInit();
            this.SuspendLayout();
            // 
            // btnOfertar
            // 
            this.btnOfertar.Location = new System.Drawing.Point(258, 21);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(113, 23);
            this.btnOfertar.TabIndex = 49;
            this.btnOfertar.Text = "Ofertar";
            this.btnOfertar.UseVisualStyleBackColor = true;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // nudCantidad
            // 
            this.nudCantidad.Location = new System.Drawing.Point(103, 21);
            this.nudCantidad.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudCantidad.Name = "nudCantidad";
            this.nudCantidad.Size = new System.Drawing.Size(106, 20);
            this.nudCantidad.TabIndex = 51;
            this.nudCantidad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 50;
            this.label1.Text = "Monto a ofertar:";
            // 
            // AltaOferta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 64);
            this.Controls.Add(this.nudCantidad);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnOfertar);
            this.Name = "AltaOferta";
            this.Text = "Ofertar";
            this.Load += new System.EventHandler(this.AltaOferta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidad)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnOfertar;
        private System.Windows.Forms.NumericUpDown nudCantidad;
        private System.Windows.Forms.Label label1;
    }
}