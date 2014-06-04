namespace FrbaCommerce
{
    partial class Abm_Rol_Baja
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
            this.txtRol = new System.Windows.Forms.TextBox();
            this.select_boton = new System.Windows.Forms.Button();
            this.baja_boton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Nombre del Rol: ";
            // 
            // txtRol
            // 
            this.txtRol.Location = new System.Drawing.Point(104, 12);
            this.txtRol.Name = "txtRol";
            this.txtRol.Size = new System.Drawing.Size(133, 20);
            this.txtRol.TabIndex = 1;
            // 
            // select_boton
            // 
            this.select_boton.Location = new System.Drawing.Point(243, 8);
            this.select_boton.Name = "select_boton";
            this.select_boton.Size = new System.Drawing.Size(101, 27);
            this.select_boton.TabIndex = 2;
            this.select_boton.Text = "Seleccionar";
            this.select_boton.UseVisualStyleBackColor = true;
            this.select_boton.Click += new System.EventHandler(this.select_boton_Click);
            // 
            // baja_boton
            // 
            this.baja_boton.Location = new System.Drawing.Point(243, 56);
            this.baja_boton.Name = "baja_boton";
            this.baja_boton.Size = new System.Drawing.Size(101, 27);
            this.baja_boton.TabIndex = 3;
            this.baja_boton.Text = "Dar de Baja";
            this.baja_boton.UseVisualStyleBackColor = true;
            this.baja_boton.Click += new System.EventHandler(this.baja_boton_Click);
            // 
            // Abm_Rol_Baja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 99);
            this.Controls.Add(this.baja_boton);
            this.Controls.Add(this.select_boton);
            this.Controls.Add(this.txtRol);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "Abm_Rol_Baja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Abm_Rol_Baja";
            this.Load += new System.EventHandler(this.Abm_Rol_Baja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtRol;
        private System.Windows.Forms.Button select_boton;
        private System.Windows.Forms.Button baja_boton;
    }
}