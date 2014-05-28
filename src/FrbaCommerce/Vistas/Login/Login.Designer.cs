namespace FrbaCommerce
{
    partial class Login
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
            this.registrar_usuario_button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.login_button = new System.Windows.Forms.Button();
            this.passw_textbox = new System.Windows.Forms.TextBox();
            this.username_textbox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // registrar_usuario_button
            // 
            this.registrar_usuario_button.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.registrar_usuario_button.Location = new System.Drawing.Point(102, 227);
            this.registrar_usuario_button.Name = "registrar_usuario_button";
            this.registrar_usuario_button.Size = new System.Drawing.Size(191, 23);
            this.registrar_usuario_button.TabIndex = 19;
            this.registrar_usuario_button.Text = "Registrar Nuevo Usuario";
            this.registrar_usuario_button.UseVisualStyleBackColor = true;
            this.registrar_usuario_button.Click += new System.EventHandler(this.registrar_usuario_button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Cambria", 11.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(223, 285);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(129, 17);
            this.label4.TabIndex = 18;
            this.label4.Text = "Powered by J2LA ©";
            // 
            // login_button
            // 
            this.login_button.Location = new System.Drawing.Point(102, 152);
            this.login_button.Name = "login_button";
            this.login_button.Size = new System.Drawing.Size(191, 25);
            this.login_button.TabIndex = 17;
            this.login_button.Text = "Login";
            this.login_button.UseVisualStyleBackColor = true;
            this.login_button.Click += new System.EventHandler(this.login_button_Click);
            // 
            // passw_textbox
            // 
            this.passw_textbox.Location = new System.Drawing.Point(102, 115);
            this.passw_textbox.Name = "passw_textbox";
            this.passw_textbox.Size = new System.Drawing.Size(191, 20);
            this.passw_textbox.TabIndex = 16;
            this.passw_textbox.UseSystemPasswordChar = true;
            // 
            // username_textbox
            // 
            this.username_textbox.Location = new System.Drawing.Point(102, 77);
            this.username_textbox.Name = "username_textbox";
            this.username_textbox.Size = new System.Drawing.Size(191, 20);
            this.username_textbox.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Username:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(324, 37);
            this.label1.TabIndex = 12;
            this.label1.Text = "FrbaCommerce 2014";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(368, 307);
            this.Controls.Add(this.registrar_usuario_button);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.login_button);
            this.Controls.Add(this.passw_textbox);
            this.Controls.Add(this.username_textbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Inicio de Sesión";
            this.Load += new System.EventHandler(this.Login_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button registrar_usuario_button;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button login_button;
        private System.Windows.Forms.TextBox passw_textbox;
        private System.Windows.Forms.TextBox username_textbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
    }
}