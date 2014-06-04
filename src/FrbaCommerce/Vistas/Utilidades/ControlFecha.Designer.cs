namespace FrbaCommerce
{
    partial class ControlFecha
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
            this.mcSelFecha = new System.Windows.Forms.MonthCalendar();
            this.SuspendLayout();
            // 
            // mcSelFecha
            // 
            this.mcSelFecha.Location = new System.Drawing.Point(0, 0);
            this.mcSelFecha.MaxSelectionCount = 1;
            this.mcSelFecha.Name = "mcSelFecha";
            this.mcSelFecha.TabIndex = 0;
            this.mcSelFecha.DateSelected += new System.Windows.Forms.DateRangeEventHandler(this.mcSelFecha_DateSelected);
            // 
            // ControlFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(227, 162);
            this.ControlBox = false;
            this.Controls.Add(this.mcSelFecha);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ControlFecha";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Load += new System.EventHandler(this.ControlFecha_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ControlFecha_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MonthCalendar mcSelFecha;
    }
}