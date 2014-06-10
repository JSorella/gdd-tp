namespace FrbaCommerce
{
    partial class Ver_Respuestas
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
            this.gridRespuestas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridRespuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // gridRespuestas
            // 
            this.gridRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridRespuestas.Location = new System.Drawing.Point(12, 12);
            this.gridRespuestas.Name = "gridRespuestas";
            this.gridRespuestas.Size = new System.Drawing.Size(646, 377);
            this.gridRespuestas.TabIndex = 9;
            // 
            // Ver_Respuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 401);
            this.Controls.Add(this.gridRespuestas);
            this.Name = "Ver_Respuestas";
            this.Text = "Ver Respuestas";
            ((System.ComponentModel.ISupportInitialize)(this.gridRespuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView gridRespuestas;

    }
}