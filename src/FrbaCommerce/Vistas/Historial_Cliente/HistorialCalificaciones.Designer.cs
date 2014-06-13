namespace FrbaCommerce
{
    partial class HistorialCalificaciones
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
            this.dgvHistorialCal = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialCal
            // 
            this.dgvHistorialCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialCal.Location = new System.Drawing.Point(13, 13);
            this.dgvHistorialCal.Name = "dgvHistorialCal";
            this.dgvHistorialCal.Size = new System.Drawing.Size(696, 356);
            this.dgvHistorialCal.TabIndex = 0;
            // 
            // HistorialCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 381);
            this.Controls.Add(this.dgvHistorialCal);
            this.Name = "HistorialCalificaciones";
            this.Text = "Historial Cliente - Calificaciones";
            this.Load += new System.EventHandler(this.HistorialCalificaciones_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialCal;
    }
}