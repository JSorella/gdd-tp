namespace FrbaCommerce
{
    partial class Abm_Cliente_Alta
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
            this.button1 = new System.Windows.Forms.Button();
            this.apellido_textbox = new System.Windows.Forms.TextBox();
            this.nombre_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dni_textbox = new System.Windows.Forms.TextBox();
            this.mail_textbox = new System.Windows.Forms.TextBox();
            this.telefono_textbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.calle_textbox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.piso_textbox = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.depto_textbox = new System.Windows.Forms.TextBox();
            this.localidad_textbox = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cp_textbox = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.comboDoc = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.altura_textbox = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.btnSelFec = new System.Windows.Forms.Button();
            this.fechaNacimiento = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCuil = new System.Windows.Forms.MaskedTextBox();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 254);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(141, 30);
            this.button1.TabIndex = 16;
            this.button1.Text = "Dar de Alta";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.darDeAlta_Click);
            // 
            // apellido_textbox
            // 
            this.apellido_textbox.Location = new System.Drawing.Point(98, 36);
            this.apellido_textbox.MaxLength = 255;
            this.apellido_textbox.Name = "apellido_textbox";
            this.apellido_textbox.Size = new System.Drawing.Size(191, 20);
            this.apellido_textbox.TabIndex = 2;
            // 
            // nombre_textbox
            // 
            this.nombre_textbox.Location = new System.Drawing.Point(98, 10);
            this.nombre_textbox.MaxLength = 255;
            this.nombre_textbox.Name = "nombre_textbox";
            this.nombre_textbox.Size = new System.Drawing.Size(191, 20);
            this.nombre_textbox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 17;
            this.label2.Text = "Apellido";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Nombre";
            // 
            // dni_textbox
            // 
            this.dni_textbox.Location = new System.Drawing.Point(97, 88);
            this.dni_textbox.MaxLength = 18;
            this.dni_textbox.Name = "dni_textbox";
            this.dni_textbox.Size = new System.Drawing.Size(191, 20);
            this.dni_textbox.TabIndex = 4;
            this.dni_textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.dni_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // mail_textbox
            // 
            this.mail_textbox.Location = new System.Drawing.Point(97, 140);
            this.mail_textbox.MaxLength = 255;
            this.mail_textbox.Name = "mail_textbox";
            this.mail_textbox.Size = new System.Drawing.Size(191, 20);
            this.mail_textbox.TabIndex = 6;
            // 
            // telefono_textbox
            // 
            this.telefono_textbox.Location = new System.Drawing.Point(97, 166);
            this.telefono_textbox.MaxLength = 50;
            this.telefono_textbox.Name = "telefono_textbox";
            this.telefono_textbox.Size = new System.Drawing.Size(191, 20);
            this.telefono_textbox.TabIndex = 7;
            this.telefono_textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.telefono_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(50, 13);
            this.label4.TabIndex = 27;
            this.label4.Text = "Nro. Doc";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 65);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(51, 13);
            this.label5.TabIndex = 28;
            this.label5.Text = "Tipo Doc";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 143);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 13);
            this.label6.TabIndex = 29;
            this.label6.Text = "Mail";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(15, 169);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(49, 13);
            this.label7.TabIndex = 30;
            this.label7.Text = "Teléfono";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 32;
            this.label1.Text = "Calle";
            // 
            // calle_textbox
            // 
            this.calle_textbox.Location = new System.Drawing.Point(72, 15);
            this.calle_textbox.MaxLength = 255;
            this.calle_textbox.Name = "calle_textbox";
            this.calle_textbox.Size = new System.Drawing.Size(169, 20);
            this.calle_textbox.TabIndex = 10;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(8, 70);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(27, 13);
            this.label9.TabIndex = 35;
            this.label9.Text = "Piso";
            // 
            // piso_textbox
            // 
            this.piso_textbox.Location = new System.Drawing.Point(72, 67);
            this.piso_textbox.MaxLength = 18;
            this.piso_textbox.Name = "piso_textbox";
            this.piso_textbox.Size = new System.Drawing.Size(36, 20);
            this.piso_textbox.TabIndex = 12;
            this.piso_textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.piso_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(163, 70);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(36, 13);
            this.label10.TabIndex = 37;
            this.label10.Text = "Depto";
            // 
            // depto_textbox
            // 
            this.depto_textbox.Location = new System.Drawing.Point(205, 67);
            this.depto_textbox.MaxLength = 50;
            this.depto_textbox.Name = "depto_textbox";
            this.depto_textbox.Size = new System.Drawing.Size(36, 20);
            this.depto_textbox.TabIndex = 13;
            // 
            // localidad_textbox
            // 
            this.localidad_textbox.Location = new System.Drawing.Point(72, 93);
            this.localidad_textbox.MaxLength = 255;
            this.localidad_textbox.Name = "localidad_textbox";
            this.localidad_textbox.Size = new System.Drawing.Size(169, 20);
            this.localidad_textbox.TabIndex = 14;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 96);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 39;
            this.label11.Text = "Localidad";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 122);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(58, 13);
            this.label12.TabIndex = 40;
            this.label12.Text = "Cod Postal";
            // 
            // cp_textbox
            // 
            this.cp_textbox.Location = new System.Drawing.Point(72, 119);
            this.cp_textbox.MaxLength = 50;
            this.cp_textbox.Name = "cp_textbox";
            this.cp_textbox.Size = new System.Drawing.Size(100, 20);
            this.cp_textbox.TabIndex = 15;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(15, 200);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 13);
            this.label13.TabIndex = 43;
            this.label13.Text = "Fecha de Nacimiento";
            // 
            // comboDoc
            // 
            this.comboDoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboDoc.FormattingEnabled = true;
            this.comboDoc.Location = new System.Drawing.Point(97, 62);
            this.comboDoc.Name = "comboDoc";
            this.comboDoc.Size = new System.Drawing.Size(192, 21);
            this.comboDoc.Sorted = true;
            this.comboDoc.TabIndex = 3;
            this.comboDoc.TabStop = false;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(8, 44);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 13);
            this.label14.TabIndex = 47;
            this.label14.Text = "Altura";
            // 
            // altura_textbox
            // 
            this.altura_textbox.Location = new System.Drawing.Point(72, 41);
            this.altura_textbox.MaxLength = 18;
            this.altura_textbox.Name = "altura_textbox";
            this.altura_textbox.Size = new System.Drawing.Size(100, 20);
            this.altura_textbox.TabIndex = 11;
            this.altura_textbox.TextChanged += new System.EventHandler(this.textbox_TextChanged);
            this.altura_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textbox_KeyPress);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(16, 117);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(24, 13);
            this.label15.TabIndex = 49;
            this.label15.Text = "Cuil";
            // 
            // btnSelFec
            // 
            this.btnSelFec.Location = new System.Drawing.Point(213, 195);
            this.btnSelFec.Name = "btnSelFec";
            this.btnSelFec.Size = new System.Drawing.Size(75, 23);
            this.btnSelFec.TabIndex = 9;
            this.btnSelFec.Text = "Seleccionar";
            this.btnSelFec.UseVisualStyleBackColor = true;
            this.btnSelFec.Click += new System.EventHandler(this.btnSelFec_Click);
            // 
            // fechaNacimiento
            // 
            this.fechaNacimiento.Location = new System.Drawing.Point(129, 197);
            this.fechaNacimiento.Name = "fechaNacimiento";
            this.fechaNacimiento.ReadOnly = true;
            this.fechaNacimiento.Size = new System.Drawing.Size(78, 20);
            this.fechaNacimiento.TabIndex = 8;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.txtCuil);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.btnSelFec);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.fechaNacimiento);
            this.panel1.Controls.Add(this.nombre_textbox);
            this.panel1.Controls.Add(this.label15);
            this.panel1.Controls.Add(this.apellido_textbox);
            this.panel1.Controls.Add(this.dni_textbox);
            this.panel1.Controls.Add(this.mail_textbox);
            this.panel1.Controls.Add(this.comboDoc);
            this.panel1.Controls.Add(this.telefono_textbox);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(12, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(620, 229);
            this.panel1.TabIndex = 51;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.calle_textbox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.altura_textbox);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.piso_textbox);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.depto_textbox);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.localidad_textbox);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.Controls.Add(this.cp_textbox);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Location = new System.Drawing.Point(350, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(247, 150);
            this.groupBox1.TabIndex = 51;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dirección";
            // 
            // txtCuil
            // 
            this.txtCuil.Location = new System.Drawing.Point(98, 114);
            this.txtCuil.Mask = "##-########-#";
            this.txtCuil.Name = "txtCuil";
            this.txtCuil.Size = new System.Drawing.Size(100, 20);
            this.txtCuil.TabIndex = 5;
            // 
            // Abm_Cliente_Alta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(644, 296);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Abm_Cliente_Alta";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alta de Clientes";
            this.Load += new System.EventHandler(this.Abm_Cliente_Alta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox apellido_textbox;
        private System.Windows.Forms.TextBox nombre_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox dni_textbox;
        private System.Windows.Forms.TextBox mail_textbox;
        private System.Windows.Forms.TextBox telefono_textbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox calle_textbox;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox piso_textbox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox depto_textbox;
        private System.Windows.Forms.TextBox localidad_textbox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox cp_textbox;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox comboDoc;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox altura_textbox;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button btnSelFec;
        private System.Windows.Forms.TextBox fechaNacimiento;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MaskedTextBox txtCuil;
    }
}