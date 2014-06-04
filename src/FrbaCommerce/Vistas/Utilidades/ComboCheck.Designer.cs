namespace FrbaCommerce
{
    partial class ComboCheck
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ComboCheck));
            this.ImageList1 = new System.Windows.Forms.ImageList(this.components);
            this.Panel = new System.Windows.Forms.Panel();
            this.btnTodos = new System.Windows.Forms.Button();
            this.btnInvertir = new System.Windows.Forms.Button();
            this.btnOcultarPanel = new System.Windows.Forms.Button();
            this.clbLista = new System.Windows.Forms.CheckedListBox();
            this.cmbCombo = new System.Windows.Forms.ComboBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.Panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ImageList1
            // 
            this.ImageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList1.ImageStream")));
            this.ImageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList1.Images.SetKeyName(0, "cross.png");
            this.ImageList1.Images.SetKeyName(1, "1289503863_list-edit.ico");
            this.ImageList1.Images.SetKeyName(2, "1289503925_list.png");
            this.ImageList1.Images.SetKeyName(3, "tick.png");
            // 
            // Panel
            // 
            this.Panel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Panel.BackColor = System.Drawing.Color.Gainsboro;
            this.Panel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Panel.Controls.Add(this.btnTodos);
            this.Panel.Controls.Add(this.btnInvertir);
            this.Panel.Controls.Add(this.btnOcultarPanel);
            this.Panel.Controls.Add(this.clbLista);
            this.Panel.Location = new System.Drawing.Point(0, 21);
            this.Panel.Name = "Panel";
            this.Panel.Size = new System.Drawing.Size(192, 185);
            this.Panel.TabIndex = 0;
            // 
            // btnTodos
            // 
            this.btnTodos.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTodos.ImageIndex = 2;
            this.btnTodos.ImageList = this.ImageList1;
            this.btnTodos.Location = new System.Drawing.Point(131, 156);
            this.btnTodos.Name = "btnTodos";
            this.btnTodos.Size = new System.Drawing.Size(25, 25);
            this.btnTodos.TabIndex = 3;
            this.toolTip1.SetToolTip(this.btnTodos, "Marcar Todos");
            this.btnTodos.UseVisualStyleBackColor = true;
            this.btnTodos.Click += new System.EventHandler(this.btnTodos_Click);
            // 
            // btnInvertir
            // 
            this.btnInvertir.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnInvertir.ImageIndex = 1;
            this.btnInvertir.ImageList = this.ImageList1;
            this.btnInvertir.Location = new System.Drawing.Point(162, 156);
            this.btnInvertir.Name = "btnInvertir";
            this.btnInvertir.Size = new System.Drawing.Size(25, 25);
            this.btnInvertir.TabIndex = 2;
            this.toolTip1.SetToolTip(this.btnInvertir, "Invertir Selección");
            this.btnInvertir.UseVisualStyleBackColor = true;
            this.btnInvertir.Click += new System.EventHandler(this.btnInvertir_Click);
            // 
            // btnOcultarPanel
            // 
            this.btnOcultarPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOcultarPanel.ImageIndex = 3;
            this.btnOcultarPanel.ImageList = this.ImageList1;
            this.btnOcultarPanel.Location = new System.Drawing.Point(2, 156);
            this.btnOcultarPanel.Name = "btnOcultarPanel";
            this.btnOcultarPanel.Size = new System.Drawing.Size(25, 25);
            this.btnOcultarPanel.TabIndex = 1;
            this.toolTip1.SetToolTip(this.btnOcultarPanel, "Confirmar");
            this.btnOcultarPanel.UseVisualStyleBackColor = true;
            this.btnOcultarPanel.Click += new System.EventHandler(this.btnOcultarPanel_Click);
            // 
            // clbLista
            // 
            this.clbLista.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.clbLista.BackColor = System.Drawing.Color.White;
            this.clbLista.CheckOnClick = true;
            this.clbLista.FormattingEnabled = true;
            this.clbLista.Location = new System.Drawing.Point(0, 0);
            this.clbLista.Name = "clbLista";
            this.clbLista.Size = new System.Drawing.Size(190, 154);
            this.clbLista.TabIndex = 0;
            this.clbLista.MouseClick += new System.Windows.Forms.MouseEventHandler(this.clbLista_MouseClick);
            this.clbLista.SelectedIndexChanged += new System.EventHandler(this.clbLista_SelectedIndexChanged);
            this.clbLista.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.clbLista_ItemCheck);
            // 
            // cmbCombo
            // 
            this.cmbCombo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCombo.DropDownHeight = 1;
            this.cmbCombo.FormattingEnabled = true;
            this.cmbCombo.IntegralHeight = false;
            this.cmbCombo.Location = new System.Drawing.Point(0, 0);
            this.cmbCombo.Name = "cmbCombo";
            this.cmbCombo.Size = new System.Drawing.Size(192, 21);
            this.cmbCombo.TabIndex = 1;
            this.cmbCombo.MouseClick += new System.Windows.Forms.MouseEventHandler(this.cmbCombo_MouseClick);
            // 
            // ComboCheck
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.cmbCombo);
            this.Controls.Add(this.Panel);
            this.Name = "ComboCheck";
            this.Size = new System.Drawing.Size(192, 206);
            this.Panel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.ImageList ImageList1;
        private System.Windows.Forms.Panel Panel;
        private System.Windows.Forms.ComboBox cmbCombo;
        private System.Windows.Forms.CheckedListBox clbLista;
        private System.Windows.Forms.Button btnTodos;
        private System.Windows.Forms.Button btnInvertir;
        private System.Windows.Forms.Button btnOcultarPanel;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}
