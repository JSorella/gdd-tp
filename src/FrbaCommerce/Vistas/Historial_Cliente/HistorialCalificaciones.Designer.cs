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
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCal)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvHistorialCal
            // 
            this.dgvHistorialCal.AllowUserToAddRows = false;
            this.dgvHistorialCal.AllowUserToDeleteRows = false;
            this.dgvHistorialCal.AllowUserToOrderColumns = true;
            this.dgvHistorialCal.AllowUserToResizeRows = false;
            this.dgvHistorialCal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvHistorialCal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHistorialCal.Location = new System.Drawing.Point(12, 12);
            this.dgvHistorialCal.MultiSelect = false;
            this.dgvHistorialCal.Name = "dgvHistorialCal";
            this.dgvHistorialCal.ReadOnly = true;
            this.dgvHistorialCal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvHistorialCal.Size = new System.Drawing.Size(697, 328);
            this.dgvHistorialCal.TabIndex = 1;
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(634, 346);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 2;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // HistorialCalificaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 381);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.dgvHistorialCal);
            this.Name = "HistorialCalificaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Historial de Calificaciones";
            this.Load += new System.EventHandler(this.HistorialCalificaciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvHistorialCal)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvHistorialCal;
        private System.Windows.Forms.Button btnSalir;

    }
}