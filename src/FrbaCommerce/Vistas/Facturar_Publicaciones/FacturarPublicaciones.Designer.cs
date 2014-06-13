namespace FrbaCommerce
{
    partial class FacturarPublicaciones
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
            this.components = new System.ComponentModel.Container();
            this.pnlParam = new System.Windows.Forms.Panel();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.txtUsuName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSeleccionar = new System.Windows.Forms.Button();
            this.pnlDatos = new System.Windows.Forms.Panel();
            this.txtSaldo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.lblInfoTarjeta = new System.Windows.Forms.Label();
            this.txtAcum = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtCantItems = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbFormaPago = new System.Windows.Forms.ComboBox();
            this.txtTarjeta = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgvPubli = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.pnlParam.SuspendLayout();
            this.pnlDatos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPubli)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlParam
            // 
            this.pnlParam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlParam.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlParam.Controls.Add(this.btnAceptar);
            this.pnlParam.Controls.Add(this.txtUsuName);
            this.pnlParam.Controls.Add(this.label1);
            this.pnlParam.Controls.Add(this.btnSeleccionar);
            this.pnlParam.Location = new System.Drawing.Point(12, 12);
            this.pnlParam.Name = "pnlParam";
            this.pnlParam.Size = new System.Drawing.Size(707, 48);
            this.pnlParam.TabIndex = 19;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAceptar.Location = new System.Drawing.Point(627, 11);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 3;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // txtUsuName
            // 
            this.txtUsuName.Location = new System.Drawing.Point(118, 13);
            this.txtUsuName.Name = "txtUsuName";
            this.txtUsuName.Size = new System.Drawing.Size(169, 20);
            this.txtUsuName.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Indique un Usuario :";
            // 
            // btnSeleccionar
            // 
            this.btnSeleccionar.Location = new System.Drawing.Point(293, 11);
            this.btnSeleccionar.Name = "btnSeleccionar";
            this.btnSeleccionar.Size = new System.Drawing.Size(75, 23);
            this.btnSeleccionar.TabIndex = 2;
            this.btnSeleccionar.Text = "Seleccionar";
            this.btnSeleccionar.UseVisualStyleBackColor = true;
            this.btnSeleccionar.Click += new System.EventHandler(this.btnSeleccionar_Click);
            // 
            // pnlDatos
            // 
            this.pnlDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlDatos.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlDatos.Controls.Add(this.txtSaldo);
            this.pnlDatos.Controls.Add(this.label8);
            this.pnlDatos.Controls.Add(this.lblInfoTarjeta);
            this.pnlDatos.Controls.Add(this.txtAcum);
            this.pnlDatos.Controls.Add(this.label6);
            this.pnlDatos.Controls.Add(this.txtTotal);
            this.pnlDatos.Controls.Add(this.label5);
            this.pnlDatos.Controls.Add(this.txtCantItems);
            this.pnlDatos.Controls.Add(this.label4);
            this.pnlDatos.Controls.Add(this.cmbFormaPago);
            this.pnlDatos.Controls.Add(this.txtTarjeta);
            this.pnlDatos.Controls.Add(this.label3);
            this.pnlDatos.Controls.Add(this.dgvPubli);
            this.pnlDatos.Controls.Add(this.label2);
            this.pnlDatos.Location = new System.Drawing.Point(12, 66);
            this.pnlDatos.Name = "pnlDatos";
            this.pnlDatos.Size = new System.Drawing.Size(707, 486);
            this.pnlDatos.TabIndex = 20;
            // 
            // txtSaldo
            // 
            this.txtSaldo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtSaldo.BackColor = System.Drawing.Color.LightBlue;
            this.txtSaldo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSaldo.Location = new System.Drawing.Point(365, 399);
            this.txtSaldo.Name = "txtSaldo";
            this.txtSaldo.ReadOnly = true;
            this.txtSaldo.Size = new System.Drawing.Size(115, 20);
            this.txtSaldo.TabIndex = 6;
            this.txtSaldo.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(270, 402);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(91, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Saldo Pendiente :";
            // 
            // lblInfoTarjeta
            // 
            this.lblInfoTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblInfoTarjeta.AutoSize = true;
            this.lblInfoTarjeta.Location = new System.Drawing.Point(16, 455);
            this.lblInfoTarjeta.Name = "lblInfoTarjeta";
            this.lblInfoTarjeta.Size = new System.Drawing.Size(103, 13);
            this.lblInfoTarjeta.TabIndex = 18;
            this.lblInfoTarjeta.Text = "Datos de la Tarjeta :";
            // 
            // txtAcum
            // 
            this.txtAcum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAcum.BackColor = System.Drawing.Color.LightBlue;
            this.txtAcum.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAcum.Location = new System.Drawing.Point(125, 399);
            this.txtAcum.Name = "txtAcum";
            this.txtAcum.ReadOnly = true;
            this.txtAcum.Size = new System.Drawing.Size(115, 20);
            this.txtAcum.TabIndex = 5;
            this.txtAcum.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 402);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 13);
            this.label6.TabIndex = 16;
            this.label6.Text = "Total Adeudado :";
            // 
            // txtTotal
            // 
            this.txtTotal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTotal.BackColor = System.Drawing.Color.LightBlue;
            this.txtTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTotal.Location = new System.Drawing.Point(604, 425);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(98, 20);
            this.txtTotal.TabIndex = 8;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 428);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 13);
            this.label5.TabIndex = 14;
            this.label5.Text = "Total a Facturar :";
            // 
            // txtCantItems
            // 
            this.txtCantItems.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCantItems.BackColor = System.Drawing.Color.LightBlue;
            this.txtCantItems.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtCantItems.Location = new System.Drawing.Point(604, 399);
            this.txtCantItems.Name = "txtCantItems";
            this.txtCantItems.ReadOnly = true;
            this.txtCantItems.Size = new System.Drawing.Size(98, 20);
            this.txtCantItems.TabIndex = 7;
            this.txtCantItems.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(500, 402);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Cantidad de Items :";
            // 
            // cmbFormaPago
            // 
            this.cmbFormaPago.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFormaPago.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFormaPago.FormattingEnabled = true;
            this.cmbFormaPago.Location = new System.Drawing.Point(125, 424);
            this.cmbFormaPago.Name = "cmbFormaPago";
            this.cmbFormaPago.Size = new System.Drawing.Size(115, 21);
            this.cmbFormaPago.TabIndex = 9;
            this.cmbFormaPago.SelectedIndexChanged += new System.EventHandler(this.cmbFormaPago_SelectedIndexChanged);
            // 
            // txtTarjeta
            // 
            this.txtTarjeta.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTarjeta.Location = new System.Drawing.Point(125, 452);
            this.txtTarjeta.Name = "txtTarjeta";
            this.txtTarjeta.Size = new System.Drawing.Size(577, 20);
            this.txtTarjeta.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 427);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(85, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Forma de Pago :";
            // 
            // dgvPubli
            // 
            this.dgvPubli.AllowUserToAddRows = false;
            this.dgvPubli.AllowUserToDeleteRows = false;
            this.dgvPubli.AllowUserToOrderColumns = true;
            this.dgvPubli.AllowUserToResizeRows = false;
            this.dgvPubli.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPubli.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPubli.Location = new System.Drawing.Point(13, 30);
            this.dgvPubli.MultiSelect = false;
            this.dgvPubli.Name = "dgvPubli";
            this.dgvPubli.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPubli.Size = new System.Drawing.Size(689, 363);
            this.dgvPubli.TabIndex = 4;
            this.dgvPubli.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPubli_CellDoubleClick);
            this.dgvPubli.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPubli_CellContentClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(140, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Pendientes de Facturación :";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancelar.Location = new System.Drawing.Point(644, 558);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 13;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.Location = new System.Drawing.Point(563, 558);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(75, 23);
            this.btnLimpiar.TabIndex = 12;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGenerar.Location = new System.Drawing.Point(482, 558);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 11;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // FacturarPublicaciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 593);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnGenerar);
            this.Controls.Add(this.pnlDatos);
            this.Controls.Add(this.pnlParam);
            this.Name = "FacturarPublicaciones";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Facturar Publicaciones";
            this.Load += new System.EventHandler(this.FacturarPublicaciones_Load);
            this.VisibleChanged += new System.EventHandler(this.FacturarPublicaciones_VisibleChanged);
            this.pnlParam.ResumeLayout(false);
            this.pnlParam.PerformLayout();
            this.pnlDatos.ResumeLayout(false);
            this.pnlDatos.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPubli)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlParam;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.TextBox txtUsuName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSeleccionar;
        private System.Windows.Forms.Panel pnlDatos;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTarjeta;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvPubli;
        private System.Windows.Forms.ComboBox cmbFormaPago;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCantItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblInfoTarjeta;
        private System.Windows.Forms.TextBox txtAcum;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSaldo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}