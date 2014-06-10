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
            this.dgvPreguntas = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPreguntas
            // 
            this.dgvPreguntas.AllowUserToAddRows = false;
            this.dgvPreguntas.AllowUserToDeleteRows = false;
            this.dgvPreguntas.AllowUserToOrderColumns = true;
            this.dgvPreguntas.AllowUserToResizeRows = false;
            this.dgvPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPreguntas.Location = new System.Drawing.Point(12, 12);
            this.dgvPreguntas.MultiSelect = false;
            this.dgvPreguntas.Name = "dgvPreguntas";
            this.dgvPreguntas.ReadOnly = true;
            this.dgvPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPreguntas.Size = new System.Drawing.Size(646, 346);
            this.dgvPreguntas.TabIndex = 5;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.Location = new System.Drawing.Point(502, 366);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(583, 366);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // Ver_Respuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(670, 401);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRefrescar);
            this.Controls.Add(this.dgvPreguntas);
            this.Name = "Ver_Respuestas";
            this.Text = "Ver Respuestas";
            this.Load += new System.EventHandler(this.Ver_Respuestas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPreguntas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnSalir;


    }
}