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
            this.cmbTipoPubli = new System.Windows.Forms.ComboBox();
            this.nudStock = new System.Windows.Forms.NumericUpDown();
            this.nudPrecio = new System.Windows.Forms.NumericUpDown();
            this.chkPreguntas = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoVis = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtFechaVto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelFec = new System.Windows.Forms.Button();
            this.txtFechaIni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listRubros = new System.Windows.Forms.CheckedListBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.cmbTipoPubli);
            this.pnlDatos.Controls.Add(this.nudStock);
            this.pnlDatos.Controls.Add(this.nudPrecio);
            this.pnlDatos.Controls.Add(this.chkPreguntas);
            this.pnlDatos.Controls.Add(this.cmbEstado);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.cmbTipoVis);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtFechaVto);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.btnSelFec);
            this.pnlDatos.Controls.Add(this.txtFechaIni);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.label10);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.listRubros);
            this.pnlDatos.Controls.Add(this.txtDesc);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Location = new System.Drawing.Point(12, 12);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(596, 375);
            this.pnlDatos.TabIndex = 7;
            // 
            // cmbTipoPubli
            // 
            this.cmbTipoPubli.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoPubli.Enabled = false;
            this.cmbTipoPubli.FormattingEnabled = true;
            this.cmbTipoPubli.Location = new System.Drawing.Point(90, 141);
            this.cmbTipoPubli.Name = "cmbTipoPubli";
            this.cmbTipoPubli.Size = new System.Drawing.Size(181, 21);
            this.cmbTipoPubli.TabIndex = 5;
            // 
            // nudStock
            // 
            this.nudStock.Location = new System.Drawing.Point(90, 222);
            this.nudStock.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudStock.Name = "nudStock";
            this.nudStock.Size = new System.Drawing.Size(148, 20);
            this.nudStock.TabIndex = 8;
            this.nudStock.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // nudPrecio
            // 
            this.nudPrecio.DecimalPlaces = 2;
            this.nudPrecio.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.nudPrecio.Location = new System.Drawing.Point(90, 248);
            this.nudPrecio.Maximum = new decimal(new int[] {
            1874919423,
            2328306,
            0,
            0});
            this.nudPrecio.Name = "nudPrecio";
            this.nudPrecio.Size = new System.Drawing.Size(148, 20);
            this.nudPrecio.TabIndex = 9;
            this.nudPrecio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.nudPrecio.ThousandsSeparator = true;
            // 
            // chkPreguntas
            // 
            this.chkPreguntas.AutoSize = true;
            this.chkPreguntas.Location = new System.Drawing.Point(16, 334);
            this.chkPreguntas.Name = "chkPreguntas";
            this.chkPreguntas.Size = new System.Drawing.Size(112, 17);
            this.chkPreguntas.TabIndex = 13;
            this.chkPreguntas.Text = "Permite Preguntas";
            this.chkPreguntas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPreguntas.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(90, 194);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(181, 21);
            this.cmbEstado.TabIndex = 7;
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
            // cmbTipoVis
            // 
            this.cmbTipoVis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVis.FormattingEnabled = true;
            this.cmbTipoVis.Location = new System.Drawing.Point(90, 167);
            this.cmbTipoVis.Name = "cmbTipoVis";
            this.cmbTipoVis.Size = new System.Drawing.Size(181, 21);
            this.cmbTipoVis.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Visibilidad :";
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
            this.txtFechaVto.Location = new System.Drawing.Point(90, 299);
            this.txtFechaVto.Name = "txtFechaVto";
            this.txtFechaVto.ReadOnly = true;
            this.txtFechaVto.Size = new System.Drawing.Size(67, 20);
            this.txtFechaVto.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 302);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 34;
            this.label5.Text = "Fecha Vto. :";
            // 
            // btnSelFec
            // 
            this.btnSelFec.Location = new System.Drawing.Point(163, 271);
            this.btnSelFec.Name = "btnSelFec";
            this.btnSelFec.Size = new System.Drawing.Size(75, 23);
            this.btnSelFec.TabIndex = 11;
            this.btnSelFec.Text = "Seleccionar";
            this.btnSelFec.UseVisualStyleBackColor = true;
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.Location = new System.Drawing.Point(90, 273);
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.ReadOnly = true;
            this.txtFechaIni.Size = new System.Drawing.Size(67, 20);
            this.txtFechaIni.TabIndex = 10;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 276);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Fecha Inicio :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 26;
            this.label3.Text = "Stock :";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(13, 144);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(34, 13);
            this.label10.TabIndex = 22;
            this.label10.Text = "Tipo :";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(292, 144);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(112, 13);
            this.label7.TabIndex = 16;
            this.label7.Text = "Selección de Rubros :";
            // 
            // listRubros
            // 
            this.listRubros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.listRubros.FormattingEnabled = true;
            this.listRubros.Location = new System.Drawing.Point(295, 160);
            this.listRubros.Name = "listRubros";
            this.listRubros.Size = new System.Drawing.Size(286, 184);
            this.listRubros.TabIndex = 14;
            // 
            // txtDesc
            // 
            this.txtDesc.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDesc.Location = new System.Drawing.Point(16, 28);
            this.txtDesc.MaxLength = 255;
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
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
            // DetallesPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(726, 522);
            this.Controls.Add(this.pnlDatos);
            this.Name = "DetallesPublicacion";
            this.Text = "Detalles Publicacion";
            this.Load += new System.EventHandler(this.DetallesPublicacion_Load);
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nudStock)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudPrecio)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.ComboBox cmbTipoPubli;
        private System.Windows.Forms.NumericUpDown nudStock;
        private System.Windows.Forms.NumericUpDown nudPrecio;
        private System.Windows.Forms.CheckBox chkPreguntas;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTipoVis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtFechaVto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelFec;
        private System.Windows.Forms.TextBox txtFechaIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox listRubros;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
    }
}