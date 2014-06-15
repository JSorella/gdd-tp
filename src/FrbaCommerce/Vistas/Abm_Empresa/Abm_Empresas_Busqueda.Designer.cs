namespace FrbaCommerce
{
    partial class Abm_Empresas_Busqueda
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tboxRazonSocial = new System.Windows.Forms.TextBox();
            this.tboxMail = new System.Windows.Forms.TextBox();
            this.tboxCUIT = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.gridEmpresas = new System.Windows.Forms.DataGridView();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpresas)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Razón Social";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "CUIT";
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mail";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // tboxRazonSocial
            // 
            this.tboxRazonSocial.Location = new System.Drawing.Point(91, 28);
            this.tboxRazonSocial.Name = "tboxRazonSocial";
            this.tboxRazonSocial.Size = new System.Drawing.Size(283, 20);
            this.tboxRazonSocial.TabIndex = 3;
            this.tboxRazonSocial.TextChanged += new System.EventHandler(this.tboxRazonSocial_TextChanged);
            // 
            // tboxMail
            // 
            this.tboxMail.Location = new System.Drawing.Point(91, 91);
            this.tboxMail.Name = "tboxMail";
            this.tboxMail.Size = new System.Drawing.Size(283, 20);
            this.tboxMail.TabIndex = 4;
            this.tboxMail.TextChanged += new System.EventHandler(this.tboxMail_TextChanged);
            // 
            // tboxCUIT
            // 
            this.tboxCUIT.Location = new System.Drawing.Point(91, 60);
            this.tboxCUIT.Name = "tboxCUIT";
            this.tboxCUIT.Size = new System.Drawing.Size(283, 20);
            this.tboxCUIT.TabIndex = 5;
            this.tboxCUIT.TextChanged += new System.EventHandler(this.tboxCUIT_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnLimpiar);
            this.groupBox1.Controls.Add(this.btnBuscar);
            this.groupBox1.Controls.Add(this.tboxCUIT);
            this.groupBox1.Controls.Add(this.tboxMail);
            this.groupBox1.Controls.Add(this.tboxRazonSocial);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(388, 164);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtros de búsqueda";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 125);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(70, 30);
            this.btnLimpiar.TabIndex = 7;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnBuscar
            // 
            this.btnBuscar.Location = new System.Drawing.Point(302, 125);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(72, 30);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            this.btnBuscar.Click += new System.EventHandler(this.btnBuscar_Click);
            // 
            // gridEmpresas
            // 
            this.gridEmpresas.AllowUserToAddRows = false;
            this.gridEmpresas.AllowUserToDeleteRows = false;
            this.gridEmpresas.AllowUserToOrderColumns = true;
            this.gridEmpresas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridEmpresas.Location = new System.Drawing.Point(12, 194);
            this.gridEmpresas.Name = "gridEmpresas";
            this.gridEmpresas.ReadOnly = true;
            this.gridEmpresas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.gridEmpresas.Size = new System.Drawing.Size(387, 215);
            this.gridEmpresas.TabIndex = 7;
            this.gridEmpresas.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmpresas_CellDoubleClick);
            this.gridEmpresas.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gridEmpresas_CellContentClick);
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(314, 427);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(84, 28);
            this.btnSeleccionar.TabIndex = 8;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // Abm_Empresas_Busqueda
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(412, 462);
            this.Controls.Add(this.btnSeleccionar);
            this.Controls.Add(this.gridEmpresas);
            this.Controls.Add(this.groupBox1);
            this.Name = "Abm_Empresas_Busqueda";
            this.Text = "Abm_Empresas_Busqueda";
            this.Load += new System.EventHandler(this.Abm_Empresas_Busqueda_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridEmpresas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tboxRazonSocial;
        private System.Windows.Forms.TextBox tboxMail;
        private System.Windows.Forms.TextBox tboxCUIT;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.DataGridView gridEmpresas;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}