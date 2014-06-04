namespace FrbaCommerce
{
    partial class Abm_Rol_Modif
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
            this.txtRolName = new System.Windows.Forms.TextBox();
            this.select_boton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.list_funcionalidades = new System.Windows.Forms.CheckedListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.aplicar_boton = new System.Windows.Forms.Button();
            this.chkInhabilitado = new System.Windows.Forms.CheckBox();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Nombre del Rol: ";
            // 
            // txtRolName
            // 
            this.txtRolName.Location = new System.Drawing.Point(104, 12);
            this.txtRolName.Name = "txtRolName";
            this.txtRolName.Size = new System.Drawing.Size(133, 20);
            this.txtRolName.TabIndex = 8;
            // 
            // select_boton
            // 
            this.select_boton.Location = new System.Drawing.Point(243, 8);
            this.select_boton.Name = "select_boton";
            this.select_boton.Size = new System.Drawing.Size(101, 27);
            this.select_boton.TabIndex = 9;
            this.select_boton.Text = "Seleccionar";
            this.select_boton.UseVisualStyleBackColor = true;
            this.select_boton.Click += new System.EventHandler(this.select_boton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Funcionalidades: ";
            // 
            // list_funcionalidades
            // 
            this.list_funcionalidades.FormattingEnabled = true;
            this.list_funcionalidades.Location = new System.Drawing.Point(12, 95);
            this.list_funcionalidades.Name = "list_funcionalidades";
            this.list_funcionalidades.Size = new System.Drawing.Size(332, 169);
            this.list_funcionalidades.TabIndex = 11;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 12;
            this.label3.Text = "Estado:";
            // 
            // aplicar_boton
            // 
            this.aplicar_boton.Location = new System.Drawing.Point(232, 270);
            this.aplicar_boton.Name = "aplicar_boton";
            this.aplicar_boton.Size = new System.Drawing.Size(112, 26);
            this.aplicar_boton.TabIndex = 14;
            this.aplicar_boton.Text = "Aplicar";
            this.aplicar_boton.UseVisualStyleBackColor = true;
            this.aplicar_boton.Click += new System.EventHandler(this.aplicar_boton_Click);
            // 
            // chkInhabilitado
            // 
            this.chkInhabilitado.AutoSize = true;
            this.chkInhabilitado.Location = new System.Drawing.Point(104, 44);
            this.chkInhabilitado.Name = "chkInhabilitado";
            this.chkInhabilitado.Size = new System.Drawing.Size(80, 17);
            this.chkInhabilitado.TabIndex = 15;
            this.chkInhabilitado.Text = "Inhabilitado";
            this.chkInhabilitado.UseVisualStyleBackColor = true;
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(12, 270);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(112, 26);
            this.btnLimpiar.TabIndex = 16;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            // 
            // Abm_Rol_Modif
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(355, 308);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.chkInhabilitado);
            this.Controls.Add(this.aplicar_boton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.list_funcionalidades);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.select_boton);
            this.Controls.Add(this.txtRolName);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "Abm_Rol_Modif";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Modificación Rol";
            this.Load += new System.EventHandler(this.list_funcionalidades_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRolName;
        private System.Windows.Forms.Button select_boton;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckedListBox list_funcionalidades;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button aplicar_boton;
        private System.Windows.Forms.CheckBox chkInhabilitado;
        private System.Windows.Forms.Button btnLimpiar;
    }
}