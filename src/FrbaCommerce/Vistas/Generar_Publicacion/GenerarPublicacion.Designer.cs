namespace FrbaCommerce
{
    partial class GenerarPublicacion
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
            this.pnlParam = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbTipoPubli = new System.Windows.Forms.ComboBox();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.chkPreguntas = new System.Windows.Forms.CheckBox();
            this.cmbEstado = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cmbTipoVis = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.listRubros = new System.Windows.Forms.CheckedListBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtVto = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSelFec = new System.Windows.Forms.Button();
            this.txtFechaIni = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnSalir = new System.Windows.Forms.Button();
            this.pnlParam.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlParam
            // 
            this.pnlParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam.Controls.Add(this.btnAceptar);
            this.pnlParam.Controls.Add(this.label1);
            this.pnlParam.Controls.Add(this.cmbTipoPubli);
            this.pnlParam.Location = new System.Drawing.Point(12, 12);
            this.pnlParam.Name = "pnlParam";
            this.pnlParam.Size = new System.Drawing.Size(596, 48);
            this.pnlParam.TabIndex = 0;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(490, 10);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(91, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Seleccione el Tipo de Publicación: ";
            // 
            // cmbTipoPubli
            // 
            this.cmbTipoPubli.FormattingEnabled = true;
            this.cmbTipoPubli.Location = new System.Drawing.Point(193, 12);
            this.cmbTipoPubli.Name = "cmbTipoPubli";
            this.cmbTipoPubli.Size = new System.Drawing.Size(228, 21);
            this.cmbTipoPubli.TabIndex = 0;
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.chkPreguntas);
            this.pnlDatos.Controls.Add(this.cmbEstado);
            this.pnlDatos.Controls.Add(this.label9);
            this.pnlDatos.Controls.Add(this.cmbTipoVis);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.label7);
            this.pnlDatos.Controls.Add(this.listRubros);
            this.pnlDatos.Controls.Add(this.txtPrecio);
            this.pnlDatos.Controls.Add(this.txtStock);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtVto);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.btnSelFec);
            this.pnlDatos.Controls.Add(this.txtFechaIni);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.txtDesc);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Location = new System.Drawing.Point(12, 66);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(596, 375);
            this.pnlDatos.TabIndex = 1;
            // 
            // chkPreguntas
            // 
            this.chkPreguntas.AutoSize = true;
            this.chkPreguntas.Location = new System.Drawing.Point(16, 308);
            this.chkPreguntas.Name = "chkPreguntas";
            this.chkPreguntas.Size = new System.Drawing.Size(112, 17);
            this.chkPreguntas.TabIndex = 21;
            this.chkPreguntas.Text = "Permite Preguntas";
            this.chkPreguntas.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkPreguntas.UseVisualStyleBackColor = true;
            // 
            // cmbEstado
            // 
            this.cmbEstado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstado.FormattingEnabled = true;
            this.cmbEstado.Location = new System.Drawing.Point(90, 168);
            this.cmbEstado.Name = "cmbEstado";
            this.cmbEstado.Size = new System.Drawing.Size(181, 21);
            this.cmbEstado.TabIndex = 20;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(13, 171);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 19;
            this.label9.Text = "Estado :";
            // 
            // cmbTipoVis
            // 
            this.cmbTipoVis.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoVis.FormattingEnabled = true;
            this.cmbTipoVis.Location = new System.Drawing.Point(90, 141);
            this.cmbTipoVis.Name = "cmbTipoVis";
            this.cmbTipoVis.Size = new System.Drawing.Size(181, 21);
            this.cmbTipoVis.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(13, 144);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(59, 13);
            this.label8.TabIndex = 17;
            this.label8.Text = "Visibilidad :";
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
            this.listRubros.Size = new System.Drawing.Size(286, 169);
            this.listRubros.TabIndex = 15;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(90, 221);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.Size = new System.Drawing.Size(148, 20);
            this.txtPrecio.TabIndex = 14;
            this.txtPrecio.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPrecio_KeyPress);
            // 
            // txtStock
            // 
            this.txtStock.Location = new System.Drawing.Point(90, 195);
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(148, 20);
            this.txtStock.TabIndex = 13;
            this.txtStock.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtStock_KeyPress);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(13, 224);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Precio :";
            // 
            // txtVto
            // 
            this.txtVto.Location = new System.Drawing.Point(90, 273);
            this.txtVto.Name = "txtVto";
            this.txtVto.ReadOnly = true;
            this.txtVto.Size = new System.Drawing.Size(67, 20);
            this.txtVto.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 276);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Fecha Vto. :";
            // 
            // btnSelFec
            // 
            this.btnSelFec.Location = new System.Drawing.Point(163, 245);
            this.btnSelFec.Name = "btnSelFec";
            this.btnSelFec.Size = new System.Drawing.Size(75, 23);
            this.btnSelFec.TabIndex = 8;
            this.btnSelFec.Text = "Seleccionar";
            this.btnSelFec.UseVisualStyleBackColor = true;
            this.btnSelFec.Click += new System.EventHandler(this.btnSelFec_Click);
            // 
            // txtFechaIni
            // 
            this.txtFechaIni.Location = new System.Drawing.Point(90, 247);
            this.txtFechaIni.Name = "txtFechaIni";
            this.txtFechaIni.ReadOnly = true;
            this.txtFechaIni.Size = new System.Drawing.Size(67, 20);
            this.txtFechaIni.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 250);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Fecha Inicio :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 198);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Stock :";
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
            this.txtDesc.TabIndex = 3;
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
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.Location = new System.Drawing.Point(371, 447);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 2;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(452, 447);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 3;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnSalir
            // 
            this.btnSalir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSalir.Location = new System.Drawing.Point(533, 447);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(75, 23);
            this.btnSalir.TabIndex = 4;
            this.btnSalir.Text = "Salir";
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // GenerarPublicacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(620, 482);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlParam);
            this.Name = "GenerarPublicacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generar Publicaciones";
            this.Load += new System.EventHandler(this.GenerarPublicacion_Load);
            this.pnlParam.ResumeLayout(false);
            this.pnlParam.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParam;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbTipoPubli;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtVto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSelFec;
        private System.Windows.Forms.TextBox txtFechaIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkPreguntas;
        private System.Windows.Forms.ComboBox cmbEstado;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbTipoVis;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckedListBox listRubros;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.TextBox txtStock;
    }
}