namespace FrbaCommerce
{
    partial class FrmMain
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.tsmiSeguridad = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiCambiarPass = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiBajaUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRoles = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRolAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRolBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRolMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClienteAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClienteBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiClienteMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpresas = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpresaAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpresaBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEmpresaMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRubros = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRubroAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRubroBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiRubroMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVisibilidades = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVisibilidadAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVisibilidadBaja = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiVisibilidadMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicaciones = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicacionAlta = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicacionMod = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicacionPreg = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicacionComp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiPublicacionCalif = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiHistorialCli = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiFacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiEstadisticas = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mosaicoVerticalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mosaicoHorizontalToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarTodoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ejemploToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslRol = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslUsuario = new System.Windows.Forms.ToolStripStatusLabel();
            this.tssiFecSystem = new System.Windows.Forms.ToolStripStatusLabel();
            this.responderPreguntasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verPreguntasYRespuestasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiSeguridad,
            this.tsmiRoles,
            this.tsmiClientes,
            this.tsmiEmpresas,
            this.tsmiRubros,
            this.tsmiVisibilidades,
            this.tsmiPublicaciones,
            this.tsmiHistorialCli,
            this.tsmiFacturacion,
            this.tsmiEstadisticas,
            this.ventanasToolStripMenuItem,
            this.ejemploToolStripMenuItem});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.MdiWindowListItem = this.ventanasToolStripMenuItem;
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(744, 42);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // tsmiSeguridad
            // 
            this.tsmiSeguridad.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCambiarPass,
            this.tsmiBajaUsuario});
            this.tsmiSeguridad.Name = "tsmiSeguridad";
            this.tsmiSeguridad.Size = new System.Drawing.Size(72, 19);
            this.tsmiSeguridad.Text = "Seguridad";
            // 
            // tsmiCambiarPass
            // 
            this.tsmiCambiarPass.Name = "tsmiCambiarPass";
            this.tsmiCambiarPass.Size = new System.Drawing.Size(195, 22);
            this.tsmiCambiarPass.Text = "Cambio de Contraseña";
            this.tsmiCambiarPass.Click += new System.EventHandler(this.tsmiCambiarPass_Click);
            // 
            // tsmiBajaUsuario
            // 
            this.tsmiBajaUsuario.Name = "tsmiBajaUsuario";
            this.tsmiBajaUsuario.Size = new System.Drawing.Size(195, 22);
            this.tsmiBajaUsuario.Text = "Baja de Usuarios";
            this.tsmiBajaUsuario.Click += new System.EventHandler(this.tsmiBajaUsuario_Click);
            // 
            // tsmiRoles
            // 
            this.tsmiRoles.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRolAlta,
            this.tsmiRolBaja,
            this.tsmiRolMod});
            this.tsmiRoles.Name = "tsmiRoles";
            this.tsmiRoles.Size = new System.Drawing.Size(47, 19);
            this.tsmiRoles.Text = "Roles";
            // 
            // tsmiRolAlta
            // 
            this.tsmiRolAlta.Name = "tsmiRolAlta";
            this.tsmiRolAlta.Size = new System.Drawing.Size(144, 22);
            this.tsmiRolAlta.Text = "Alta";
            this.tsmiRolAlta.Click += new System.EventHandler(this.tsmiRolAlta_Click);
            // 
            // tsmiRolBaja
            // 
            this.tsmiRolBaja.Name = "tsmiRolBaja";
            this.tsmiRolBaja.Size = new System.Drawing.Size(144, 22);
            this.tsmiRolBaja.Text = "Baja";
            this.tsmiRolBaja.Click += new System.EventHandler(this.tsmiRolBaja_Click);
            // 
            // tsmiRolMod
            // 
            this.tsmiRolMod.Name = "tsmiRolMod";
            this.tsmiRolMod.Size = new System.Drawing.Size(144, 22);
            this.tsmiRolMod.Text = "Modificación";
            this.tsmiRolMod.Click += new System.EventHandler(this.tsmiRolMod_Click);
            // 
            // tsmiClientes
            // 
            this.tsmiClientes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiClienteAlta,
            this.tsmiClienteBaja,
            this.tsmiClienteMod});
            this.tsmiClientes.Name = "tsmiClientes";
            this.tsmiClientes.Size = new System.Drawing.Size(61, 19);
            this.tsmiClientes.Text = "Clientes";
            // 
            // tsmiClienteAlta
            // 
            this.tsmiClienteAlta.Name = "tsmiClienteAlta";
            this.tsmiClienteAlta.Size = new System.Drawing.Size(144, 22);
            this.tsmiClienteAlta.Text = "Alta";
            this.tsmiClienteAlta.Click += new System.EventHandler(this.tsmiClienteAlta_Click);
            // 
            // tsmiClienteBaja
            // 
            this.tsmiClienteBaja.Name = "tsmiClienteBaja";
            this.tsmiClienteBaja.Size = new System.Drawing.Size(144, 22);
            this.tsmiClienteBaja.Text = "Baja";
            this.tsmiClienteBaja.Click += new System.EventHandler(this.tsmiClienteBaja_Click);
            // 
            // tsmiClienteMod
            // 
            this.tsmiClienteMod.Name = "tsmiClienteMod";
            this.tsmiClienteMod.Size = new System.Drawing.Size(144, 22);
            this.tsmiClienteMod.Text = "Modificación";
            this.tsmiClienteMod.Click += new System.EventHandler(this.tsmiClienteMod_Click);
            // 
            // tsmiEmpresas
            // 
            this.tsmiEmpresas.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiEmpresaAlta,
            this.tsmiEmpresaBaja,
            this.tsmiEmpresaMod});
            this.tsmiEmpresas.Name = "tsmiEmpresas";
            this.tsmiEmpresas.Size = new System.Drawing.Size(69, 19);
            this.tsmiEmpresas.Text = "Empresas";
            // 
            // tsmiEmpresaAlta
            // 
            this.tsmiEmpresaAlta.Name = "tsmiEmpresaAlta";
            this.tsmiEmpresaAlta.Size = new System.Drawing.Size(144, 22);
            this.tsmiEmpresaAlta.Text = "Alta";
            this.tsmiEmpresaAlta.Click += new System.EventHandler(this.tsmiEmpresaAlta_Click);
            // 
            // tsmiEmpresaBaja
            // 
            this.tsmiEmpresaBaja.Name = "tsmiEmpresaBaja";
            this.tsmiEmpresaBaja.Size = new System.Drawing.Size(144, 22);
            this.tsmiEmpresaBaja.Text = "Baja";
            this.tsmiEmpresaBaja.Click += new System.EventHandler(this.tsmiEmpresaBaja_Click);
            // 
            // tsmiEmpresaMod
            // 
            this.tsmiEmpresaMod.Name = "tsmiEmpresaMod";
            this.tsmiEmpresaMod.Size = new System.Drawing.Size(144, 22);
            this.tsmiEmpresaMod.Text = "Modificación";
            this.tsmiEmpresaMod.Click += new System.EventHandler(this.tsmiEmpresaMod_Click);
            // 
            // tsmiRubros
            // 
            this.tsmiRubros.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiRubroAlta,
            this.tsmiRubroBaja,
            this.tsmiRubroMod});
            this.tsmiRubros.Name = "tsmiRubros";
            this.tsmiRubros.Size = new System.Drawing.Size(56, 19);
            this.tsmiRubros.Text = "Rubros";
            // 
            // tsmiRubroAlta
            // 
            this.tsmiRubroAlta.Name = "tsmiRubroAlta";
            this.tsmiRubroAlta.Size = new System.Drawing.Size(144, 22);
            this.tsmiRubroAlta.Text = "Alta";
            this.tsmiRubroAlta.Click += new System.EventHandler(this.tsmiRubroAlta_Click);
            // 
            // tsmiRubroBaja
            // 
            this.tsmiRubroBaja.Name = "tsmiRubroBaja";
            this.tsmiRubroBaja.Size = new System.Drawing.Size(144, 22);
            this.tsmiRubroBaja.Text = "Baja";
            this.tsmiRubroBaja.Click += new System.EventHandler(this.tsmiRubroBaja_Click);
            // 
            // tsmiRubroMod
            // 
            this.tsmiRubroMod.Name = "tsmiRubroMod";
            this.tsmiRubroMod.Size = new System.Drawing.Size(144, 22);
            this.tsmiRubroMod.Text = "Modificación";
            this.tsmiRubroMod.Click += new System.EventHandler(this.tsmiRubroMod_Click);
            // 
            // tsmiVisibilidades
            // 
            this.tsmiVisibilidades.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiVisibilidadAlta,
            this.tsmiVisibilidadBaja,
            this.tsmiVisibilidadMod});
            this.tsmiVisibilidades.Name = "tsmiVisibilidades";
            this.tsmiVisibilidades.Size = new System.Drawing.Size(165, 19);
            this.tsmiVisibilidades.Text = "Visibilidad de Publicaciones";
            // 
            // tsmiVisibilidadAlta
            // 
            this.tsmiVisibilidadAlta.Name = "tsmiVisibilidadAlta";
            this.tsmiVisibilidadAlta.Size = new System.Drawing.Size(152, 22);
            this.tsmiVisibilidadAlta.Text = "Alta";
            this.tsmiVisibilidadAlta.Click += new System.EventHandler(this.tsmiVisibilidadAlta_Click);
            // 
            // tsmiVisibilidadBaja
            // 
            this.tsmiVisibilidadBaja.Name = "tsmiVisibilidadBaja";
            this.tsmiVisibilidadBaja.Size = new System.Drawing.Size(152, 22);
            this.tsmiVisibilidadBaja.Text = "Baja";
            this.tsmiVisibilidadBaja.Click += new System.EventHandler(this.tsmiVisibilidadBaja_Click);
            // 
            // tsmiVisibilidadMod
            // 
            this.tsmiVisibilidadMod.Name = "tsmiVisibilidadMod";
            this.tsmiVisibilidadMod.Size = new System.Drawing.Size(152, 22);
            this.tsmiVisibilidadMod.Text = "Modificación";
            this.tsmiVisibilidadMod.Click += new System.EventHandler(this.tsmiVisibilidadMod_Click);
            // 
            // tsmiPublicaciones
            // 
            this.tsmiPublicaciones.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiPublicacionAlta,
            this.tsmiPublicacionMod,
            this.tsmiPublicacionPreg,
            this.tsmiPublicacionComp,
            this.tsmiPublicacionCalif});
            this.tsmiPublicaciones.Name = "tsmiPublicaciones";
            this.tsmiPublicaciones.Size = new System.Drawing.Size(92, 19);
            this.tsmiPublicaciones.Text = "Publicaciones";
            // 
            // tsmiPublicacionAlta
            // 
            this.tsmiPublicacionAlta.Name = "tsmiPublicacionAlta";
            this.tsmiPublicacionAlta.Size = new System.Drawing.Size(197, 22);
            this.tsmiPublicacionAlta.Text = "Generar Publicación";
            this.tsmiPublicacionAlta.Click += new System.EventHandler(this.tsmiPublicacionAlta_Click);
            // 
            // tsmiPublicacionMod
            // 
            this.tsmiPublicacionMod.Name = "tsmiPublicacionMod";
            this.tsmiPublicacionMod.Size = new System.Drawing.Size(197, 22);
            this.tsmiPublicacionMod.Text = "Editar Publicación";
            this.tsmiPublicacionMod.Click += new System.EventHandler(this.tsmiPublicacionMod_Click);
            // 
            // tsmiPublicacionPreg
            // 
            this.tsmiPublicacionPreg.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.responderPreguntasToolStripMenuItem,
            this.verPreguntasYRespuestasToolStripMenuItem});
            this.tsmiPublicacionPreg.Name = "tsmiPublicacionPreg";
            this.tsmiPublicacionPreg.Size = new System.Drawing.Size(197, 22);
            this.tsmiPublicacionPreg.Text = "Gestión de Preguntas";
            this.tsmiPublicacionPreg.Click += new System.EventHandler(this.tsmiPublicacionPreg_Click);
            // 
            // tsmiPublicacionComp
            // 
            this.tsmiPublicacionComp.Name = "tsmiPublicacionComp";
            this.tsmiPublicacionComp.Size = new System.Drawing.Size(197, 22);
            this.tsmiPublicacionComp.Text = "Comprar/Ofertar";
            this.tsmiPublicacionComp.Click += new System.EventHandler(this.tsmiPublicacionComp_Click);
            // 
            // tsmiPublicacionCalif
            // 
            this.tsmiPublicacionCalif.Name = "tsmiPublicacionCalif";
            this.tsmiPublicacionCalif.Size = new System.Drawing.Size(197, 22);
            this.tsmiPublicacionCalif.Text = "Calificar a un Vendedor";
            this.tsmiPublicacionCalif.Click += new System.EventHandler(this.tsmiPublicacionCalif_Click);
            // 
            // tsmiHistorialCli
            // 
            this.tsmiHistorialCli.Name = "tsmiHistorialCli";
            this.tsmiHistorialCli.Size = new System.Drawing.Size(119, 19);
            this.tsmiHistorialCli.Text = "Historial de Cliente";
            this.tsmiHistorialCli.Click += new System.EventHandler(this.tsmiHistorialCli_Click);
            // 
            // tsmiFacturacion
            // 
            this.tsmiFacturacion.Name = "tsmiFacturacion";
            this.tsmiFacturacion.Size = new System.Drawing.Size(138, 19);
            this.tsmiFacturacion.Text = "Facturar Publicaciones";
            this.tsmiFacturacion.Click += new System.EventHandler(this.tsmiFacturacion_Click);
            // 
            // tsmiEstadisticas
            // 
            this.tsmiEstadisticas.Name = "tsmiEstadisticas";
            this.tsmiEstadisticas.Size = new System.Drawing.Size(79, 19);
            this.tsmiEstadisticas.Text = "Estadísticas";
            this.tsmiEstadisticas.Click += new System.EventHandler(this.tsmiEstadisticas_Click);
            // 
            // ventanasToolStripMenuItem
            // 
            this.ventanasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadaToolStripMenuItem,
            this.mosaicoVerticalToolStripMenuItem,
            this.mosaicoHorizontalToolStripMenuItem,
            this.cerrarTodoToolStripMenuItem,
            this.toolStripSeparator1});
            this.ventanasToolStripMenuItem.Name = "ventanasToolStripMenuItem";
            this.ventanasToolStripMenuItem.Size = new System.Drawing.Size(67, 19);
            this.ventanasToolStripMenuItem.Text = "Ventanas";
            // 
            // cascadaToolStripMenuItem
            // 
            this.cascadaToolStripMenuItem.Name = "cascadaToolStripMenuItem";
            this.cascadaToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cascadaToolStripMenuItem.Text = "Cascada";
            this.cascadaToolStripMenuItem.Click += new System.EventHandler(this.cascadaToolStripMenuItem_Click);
            // 
            // mosaicoVerticalToolStripMenuItem
            // 
            this.mosaicoVerticalToolStripMenuItem.Name = "mosaicoVerticalToolStripMenuItem";
            this.mosaicoVerticalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mosaicoVerticalToolStripMenuItem.Text = "Mosaico Vertical";
            this.mosaicoVerticalToolStripMenuItem.Click += new System.EventHandler(this.mosaicoVerticalToolStripMenuItem_Click);
            // 
            // mosaicoHorizontalToolStripMenuItem
            // 
            this.mosaicoHorizontalToolStripMenuItem.Name = "mosaicoHorizontalToolStripMenuItem";
            this.mosaicoHorizontalToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.mosaicoHorizontalToolStripMenuItem.Text = "Mosaico Horizontal";
            this.mosaicoHorizontalToolStripMenuItem.Click += new System.EventHandler(this.mosaicoHorizontalToolStripMenuItem_Click);
            // 
            // cerrarTodoToolStripMenuItem
            // 
            this.cerrarTodoToolStripMenuItem.Name = "cerrarTodoToolStripMenuItem";
            this.cerrarTodoToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.cerrarTodoToolStripMenuItem.Text = "Cerrar Todo";
            this.cerrarTodoToolStripMenuItem.Click += new System.EventHandler(this.cerrarTodoToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(174, 6);
            // 
            // ejemploToolStripMenuItem
            // 
            this.ejemploToolStripMenuItem.Name = "ejemploToolStripMenuItem";
            this.ejemploToolStripMenuItem.Size = new System.Drawing.Size(62, 19);
            this.ejemploToolStripMenuItem.Text = "Ejemplo";
            this.ejemploToolStripMenuItem.Click += new System.EventHandler(this.ejemploToolStripMenuItem_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.tsslRol,
            this.tsslUsuario,
            this.tssiFecSystem});
            this.statusStrip1.Location = new System.Drawing.Point(0, 321);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(744, 25);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabel1.Image = global::FrbaCommerce.Properties.Resources.Salir_16x16;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(49, 20);
            this.toolStripStatusLabel1.Text = "Salir";
            this.toolStripStatusLabel1.Click += new System.EventHandler(this.toolStripStatusLabel1_Click);
            // 
            // tsslRol
            // 
            this.tsslRol.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslRol.Image = global::FrbaCommerce.Properties.Resources.group;
            this.tsslRol.Name = "tsslRol";
            this.tsslRol.Size = new System.Drawing.Size(64, 20);
            this.tsslRol.Text = "Rol: XX";
            // 
            // tsslUsuario
            // 
            this.tsslUsuario.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.tsslUsuario.Image = global::FrbaCommerce.Properties.Resources.user;
            this.tsslUsuario.Name = "tsslUsuario";
            this.tsslUsuario.Size = new System.Drawing.Size(73, 20);
            this.tsslUsuario.Text = "Usuario :";
            // 
            // tssiFecSystem
            // 
            this.tssiFecSystem.Image = global::FrbaCommerce.Properties.Resources.FecSist;
            this.tssiFecSystem.Name = "tssiFecSystem";
            this.tssiFecSystem.Size = new System.Drawing.Size(134, 20);
            this.tssiFecSystem.Text = "toolStripStatusLabel1";
            // 
            // responderPreguntasToolStripMenuItem
            // 
            this.responderPreguntasToolStripMenuItem.Name = "responderPreguntasToolStripMenuItem";
            this.responderPreguntasToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.responderPreguntasToolStripMenuItem.Text = "Responder Preguntas";
            this.responderPreguntasToolStripMenuItem.Click += new System.EventHandler(this.responderPreguntasToolStripMenuItem_Click);
            // 
            // verPreguntasYRespuestasToolStripMenuItem
            // 
            this.verPreguntasYRespuestasToolStripMenuItem.Name = "verPreguntasYRespuestasToolStripMenuItem";
            this.verPreguntasYRespuestasToolStripMenuItem.Size = new System.Drawing.Size(217, 22);
            this.verPreguntasYRespuestasToolStripMenuItem.Text = "Ver Preguntas y Respuestas";
            this.verPreguntasYRespuestasToolStripMenuItem.Click += new System.EventHandler(this.verPreguntasYRespuestasToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(744, 346);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema FRBA-Commerce";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem tsmiSeguridad;
        private System.Windows.Forms.ToolStripMenuItem tsmiCambiarPass;
        private System.Windows.Forms.ToolStripMenuItem tsmiBajaUsuario;
        private System.Windows.Forms.ToolStripMenuItem tsmiRoles;
        private System.Windows.Forms.ToolStripMenuItem tsmiRolAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiRolBaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiRolMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiClientes;
        private System.Windows.Forms.ToolStripMenuItem tsmiClienteAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiClienteBaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiClienteMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpresas;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpresaAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpresaBaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiEmpresaMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiRubros;
        private System.Windows.Forms.ToolStripMenuItem tsmiRubroAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiRubroBaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiRubroMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiVisibilidades;
        private System.Windows.Forms.ToolStripMenuItem tsmiVisibilidadAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiVisibilidadBaja;
        private System.Windows.Forms.ToolStripMenuItem tsmiVisibilidadMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicaciones;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicacionAlta;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicacionMod;
        private System.Windows.Forms.ToolStripMenuItem tsmiFacturacion;
        private System.Windows.Forms.ToolStripMenuItem tsmiEstadisticas;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicacionPreg;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicacionComp;
        private System.Windows.Forms.ToolStripMenuItem tsmiPublicacionCalif;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tsslRol;
        private System.Windows.Forms.ToolStripStatusLabel tsslUsuario;
        private System.Windows.Forms.ToolStripStatusLabel tssiFecSystem;
        private System.Windows.Forms.ToolStripMenuItem tsmiHistorialCli;
        private System.Windows.Forms.ToolStripMenuItem ventanasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cascadaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaicoVerticalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mosaicoHorizontalToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cerrarTodoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem ejemploToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem responderPreguntasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verPreguntasYRespuestasToolStripMenuItem;
    }
}