namespace FrbaCommerce
{
    partial class HistorialOfertas
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
            this.dgvHistorialO = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialO)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialO
            // 
            this.dgvHistorialO.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialO.Location = new System.Drawing.Point(13, 13);
            this.dgvHistorialO.Name = "dgvHistorialO";
            this.dgvHistorialO.Size = new System.Drawing.Size(680, 331);
            this.dgvHistorialO.TabIndex = 0;
            // 
            // HistorialOfertas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(705, 356);
            this.Controls.Add(this.dgvHistorialO);
            this.Name = "HistorialOfertas";
            this.Text = "Historial Cliente - Ofertas";
            this.Load += new System.EventHandler(this.HistorialOfertas_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialO)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialO;
    }
}