namespace FrbaCommerce
{
    partial class DatosVendedor
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
            this.dgVendedor = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgVendedor)).BeginInit();
            this.SuspendLayout();
            // 
            // dgVendedor
            // 
            this.dgVendedor.AllowDrop = true;
            this.dgVendedor.AllowUserToAddRows = false;
            this.dgVendedor.AllowUserToDeleteRows = false;
            this.dgVendedor.AllowUserToOrderColumns = true;
            this.dgVendedor.AllowUserToResizeRows = false;
            this.dgVendedor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgVendedor.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgVendedor.Location = new System.Drawing.Point(12, 48);
            this.dgVendedor.MultiSelect = false;
            this.dgVendedor.Name = "dgVendedor";
            this.dgVendedor.ReadOnly = true;
            this.dgVendedor.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgVendedor.Size = new System.Drawing.Size(727, 108);
            this.dgVendedor.TabIndex = 19;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 23);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(159, 13);
            this.label7.TabIndex = 44;
            this.label7.Text = "Datos disponibles del Vendedor:";
            // 
            // DatosVendedor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 168);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dgVendedor);
            this.Name = "DatosVendedor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Datos del Vendedor";
            this.Load += new System.EventHandler(this.DatosVendedor_Load);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DatosVendedor_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.dgVendedor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgVendedor;
        private System.Windows.Forms.Label label7;

    }
}