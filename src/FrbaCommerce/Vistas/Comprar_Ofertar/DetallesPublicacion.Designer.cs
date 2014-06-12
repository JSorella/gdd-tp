namespace FrbaCommerce
{
    partial class DetallesPublicacion
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
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.btnOfertar = new System.Windows.Forms.Button();
            this.btnComprar = new System.Windows.Forms.Button();
            this.btnPregunta = new System.Windows.Forms.Button();
            this.txtVendedor = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtTipoPubli = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaVto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lblStock = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupPreguntas = new System.Windows.Forms.GroupBox();
            this.dgPreguntas = new System.Windows.Forms.DataGridView();
            this.pnlDatos.SuspendLayout();
            this.groupPreguntas.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgPreguntas)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.btnOfertar);
            this.pnlDatos.Controls.Add(this.btnComprar);
            this.pnlDatos.Controls.Add(this.btnPregunta);
            this.pnlDatos.Controls.Add(this.txtVendedor);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.txtPrecio);
            this.pnlDatos.Controls.Add(this.txtStock);
            this.pnlDatos.Controls.Add(this.txtEstado);
            this.pnlDatos.Controls.Add(this.txtTipoPubli);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtFechaVto);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.lblStock);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.txtDesc);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Location = new System.Drawing.Point(12, 12);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(603, 304);
            this.pnlDatos.TabIndex = 7;
            // 
            // btnOfertar
            // 
            this.btnOfertar.Location = new System.Drawing.Point(452, 267);
            this.btnOfertar.Name = "btnOfertar";
            this.btnOfertar.Size = new System.Drawing.Size(75, 23);
            this.btnOfertar.TabIndex = 48;
            this.btnOfertar.Text = "Ofertar!";
            this.btnOfertar.UseVisualStyleBackColor = true;
            this.btnOfertar.Click += new System.EventHandler(this.btnOfertar_Click);
            // 
            // btnComprar
            // 
            this.btnComprar.Location = new System.Drawing.Point(452, 245);
            this.btnComprar.Name = "btnComprar";
            this.btnComprar.Size = new System.Drawing.Size(75, 23);
            this.btnComprar.TabIndex = 47;
            this.btnComprar.Text = "Comprar!";
            this.btnComprar.UseVisualStyleBackColor = true;
            this.btnComprar.Click += new System.EventHandler(this.btnComprar_Click);
            // 
            // btnPregunta
            // 
            this.btnPregunta.Location = new System.Drawing.Point(390, 197);
            this.btnPregunta.Name = "btnPregunta";
            this.btnPregunta.Size = new System.Drawing.Size(137, 23);
            this.btnPregunta.TabIndex = 46;
            this.btnPregunta.Text = "Hacer una Pregunta";
            this.btnPregunta.UseVisualStyleBackColor = true;
            this.btnPregunta.Click += new System.EventHandler(this.btnPregunta_Click);
            // 
            // txtVendedor
            // 
            this.txtVendedor.Location = new System.Drawing.Point(371, 160);
            this.txtVendedor.Name = "txtVendedor";
            this.txtVendedor.ReadOnly = true;
            this.txtVendedor.Size = new System.Drawing.Size(156, 20);
            this.txtVendedor.TabIndex = 45;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(294, 163);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(59, 13);
            this.label7.TabIndex = 43;
            this.label7.Text = "Vendedor :";
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(90, 247);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(67, 20);
            this.txtPrecio.TabIndex = 42;
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(90, 221);
            this.txtStock.Name = "txtStock";
            this.txtStock.ReadOnly = true;
            this.txtStock.Size = new System.Drawing.Size(67, 20);
            this.txtStock.TabIndex = 41;
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(90, 190);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(114, 20);
            this.txtEstado.TabIndex = 40;
            // 
            // txtTipoPubli
            // 
            this.txtTipoPubli.Location = new System.Drawing.Point(90, 164);
            this.txtTipoPubli.Name = "txtTipoPubli";
            this.txtTipoPubli.ReadOnly = true;
            this.txtTipoPubli.Size = new System.Drawing.Size(114, 20);
            this.txtTipoPubli.TabIndex = 38;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 197);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 37;
            this.label9.Text = "Estado :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 250);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 35;
            this.label6.Text = "Precio :";
            // 
            // txtFechaVto
            // 
            this.txtFechaVto.Location = new System.Drawing.Point(90, 274);
            this.txtFechaVto.Name = "txtFechaVto";
            this.txtFechaVto.ReadOnly = true;
            this.txtFechaVto.Size = new System.Drawing.Size(67, 20);
            this.txtFechaVto.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Fecha Vto. :";
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(13, 224);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(41, 13);
            this.lblStock.TabIndex = 26;
            this.lblStock.Text = "Stock :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 167);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tipo :";
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(16, 28);
            this.txtDesc.MaxLength = 255;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ReadOnly = true;
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(565, 107);
            this.txtDesc.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Descripción :";
            // 
            // groupPreguntas
            // 
            this.groupPreguntas.Controls.Add(this.dgPreguntas);
            this.groupPreguntas.Location = new System.Drawing.Point(12, 322);
            this.groupPreguntas.Name = "groupPreguntas";
            this.groupPreguntas.Size = new System.Drawing.Size(603, 174);
            this.groupPreguntas.TabIndex = 8;
            this.groupPreguntas.TabStop = false;
            this.groupPreguntas.Text = "Preguntas";
            // 
            // dgPreguntas
            // 
            this.dgPreguntas.AllowDrop = true;
            this.dgPreguntas.AllowUserToAddRows = false;
            this.dgPreguntas.AllowUserToDeleteRows = false;
            this.dgPreguntas.AllowUserToOrderColumns = true;
            this.dgPreguntas.AllowUserToResizeRows = false;
            this.dgPreguntas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgPreguntas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgPreguntas.Location = new System.Drawing.Point(6, 19);
            this.dgPreguntas.MultiSelect = false;
            this.dgPreguntas.Name = "dgPreguntas";
            this.dgPreguntas.ReadOnly = true;
            this.dgPreguntas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgPreguntas.Size = new System.Drawing.Size(591, 145);
            this.dgPreguntas.TabIndex = 18;
            // 
            // DetallesPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 508);
            this.Controls.Add(this.groupPreguntas);
            this.Controls.Add(this.pnlDatos);
            this.Name = "DetallesPublicacion";
            this.Text = "Detalles Publicacion";
            this.Load += new System.EventHandler(this.DetallesPublicacion_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.groupPreguntas.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgPreguntas)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaVto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TextBox txtTipoPubli;
        private System.Windows.Forms.TextBox txtVendedor;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnOfertar;
        private System.Windows.Forms.Button btnComprar;
        private System.Windows.Forms.Button btnPregunta;
        private System.Windows.Forms.GroupBox groupPreguntas;
        private System.Windows.Forms.DataGridView dgPreguntas;
    }
}