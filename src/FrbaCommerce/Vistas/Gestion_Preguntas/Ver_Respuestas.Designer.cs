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
            this.dgvMisPreguntas = new System.Windows.Forms.DataGridView();
            this.btnRefrescar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.tabPreguntas = new System.Windows.Forms.TabControl();
            this.tpMisPreguntas = new System.Windows.Forms.TabPage();
            this.tpMisRespuestas = new System.Windows.Forms.TabPage();
            this.dgvMisRespuestas = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisPreguntas)).BeginInit();
            this.tabPreguntas.SuspendLayout();
            this.tpMisPreguntas.SuspendLayout();
            this.tpMisRespuestas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisRespuestas)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMisPreguntas
            // 
            this.dgvMisPreguntas.AllowUserToAddRows = false;
            this.dgvMisPreguntas.AllowUserToDeleteRows = false;
            this.dgvMisPreguntas.AllowUserToOrderColumns = true;
            this.dgvMisPreguntas.AllowUserToResizeRows = false;
            this.dgvMisPreguntas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMisPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisPreguntas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMisPreguntas.Location = new System.Drawing.Point(3, 3);
            this.dgvMisPreguntas.MultiSelect = false;
            this.dgvMisPreguntas.Name = "dgvMisPreguntas";
            this.dgvMisPreguntas.ReadOnly = true;
            this.dgvMisPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisPreguntas.Size = new System.Drawing.Size(805, 322);
            this.dgvMisPreguntas.TabIndex = 5;
            // 
            // btnRefrescar
            // 
            this.btnRefrescar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefrescar.Location = new System.Drawing.Point(675, 372);
            this.btnRefrescar.Name = "btnRefrescar";
            this.btnRefrescar.Size = new System.Drawing.Size(75, 23);
            this.btnRefrescar.TabIndex = 6;
            this.btnRefrescar.Text = "Refrescar";
            this.btnRefrescar.UseVisualStyleBackColor = true;
            this.btnRefrescar.Click += new System.EventHandler(this.btnRefrescar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(756, 372);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // tabPreguntas
            // 
            this.tabPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabPreguntas.Controls.Add(this.tpMisPreguntas);
            this.tabPreguntas.Controls.Add(this.tpMisRespuestas);
            this.tabPreguntas.Location = new System.Drawing.Point(12, 12);
            this.tabPreguntas.Name = "tabPreguntas";
            this.tabPreguntas.SelectedIndex = 0;
            this.tabPreguntas.Size = new System.Drawing.Size(819, 354);
            this.tabPreguntas.TabIndex = 8;
            // 
            // tpMisPreguntas
            // 
            this.tpMisPreguntas.Controls.Add(this.dgvMisPreguntas);
            this.tpMisPreguntas.Location = new System.Drawing.Point(4, 22);
            this.tpMisPreguntas.Name = "tpMisPreguntas";
            this.tpMisPreguntas.Padding = new System.Windows.Forms.Padding(3);
            this.tpMisPreguntas.Size = new System.Drawing.Size(811, 328);
            this.tpMisPreguntas.TabIndex = 0;
            this.tpMisPreguntas.Text = "Mis Preguntas";
            this.tpMisPreguntas.UseVisualStyleBackColor = true;
            // 
            // tpMisRespuestas
            // 
            this.tpMisRespuestas.Controls.Add(this.dgvMisRespuestas);
            this.tpMisRespuestas.Location = new System.Drawing.Point(4, 22);
            this.tpMisRespuestas.Name = "tpMisRespuestas";
            this.tpMisRespuestas.Padding = new System.Windows.Forms.Padding(3);
            this.tpMisRespuestas.Size = new System.Drawing.Size(811, 328);
            this.tpMisRespuestas.TabIndex = 1;
            this.tpMisRespuestas.Text = "Mis Respuestas";
            this.tpMisRespuestas.UseVisualStyleBackColor = true;
            // 
            // dgvMisRespuestas
            // 
            this.dgvMisRespuestas.AllowUserToAddRows = false;
            this.dgvMisRespuestas.AllowUserToDeleteRows = false;
            this.dgvMisRespuestas.AllowUserToOrderColumns = true;
            this.dgvMisRespuestas.AllowUserToResizeRows = false;
            this.dgvMisRespuestas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvMisRespuestas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMisRespuestas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMisRespuestas.Location = new System.Drawing.Point(3, 3);
            this.dgvMisRespuestas.MultiSelect = false;
            this.dgvMisRespuestas.Name = "dgvMisRespuestas";
            this.dgvMisRespuestas.ReadOnly = true;
            this.dgvMisRespuestas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMisRespuestas.Size = new System.Drawing.Size(805, 322);
            this.dgvMisRespuestas.TabIndex = 6;
            // 
            // Ver_Respuestas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 407);
            this.Controls.Add(this.tabPreguntas);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnRefrescar);
            this.Name = "Ver_Respuestas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Ver Preguntas y Respuestas";
            this.Load += new System.EventHandler(this.Ver_Respuestas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisPreguntas)).EndInit();
            this.tabPreguntas.ResumeLayout(false);
            this.tpMisPreguntas.ResumeLayout(false);
            this.tpMisRespuestas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMisRespuestas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMisPreguntas;
        private System.Windows.Forms.Button btnRefrescar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.TabControl tabPreguntas;
        private System.Windows.Forms.TabPage tpMisPreguntas;
        private System.Windows.Forms.TabPage tpMisRespuestas;
        private System.Windows.Forms.DataGridView dgvMisRespuestas;


    }
}