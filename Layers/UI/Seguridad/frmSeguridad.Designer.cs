namespace UTN.WinForms.ApCars.Layers.UI.Seguridad
{
    partial class frmSeguridad
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
            this.tspBarraPrincipal = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tplPanel = new System.Windows.Forms.TableLayoutPanel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.txtLogin = new System.Windows.Forms.TextBox();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.lblContrasena = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblRol = new System.Windows.Forms.Label();
            this.cmbRol = new System.Windows.Forms.ComboBox();
            this.trvUsuarios = new System.Windows.Forms.TreeView();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalvarUsuario = new System.Windows.Forms.ToolStripButton();
            this.tspBarraPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tplPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspBarraPrincipal
            // 
            this.tspBarraPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspBarraPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnSalvarUsuario,
            this.toolStripBtnSalir});
            this.tspBarraPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tspBarraPrincipal.Name = "tspBarraPrincipal";
            this.tspBarraPrincipal.Size = new System.Drawing.Size(800, 55);
            this.tspBarraPrincipal.TabIndex = 2;
            this.tspBarraPrincipal.Text = "toolStrip1";
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_cerrar_ventana_48;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(90, 52);
            this.toolStripBtnSalir.Text = "Sa&lir";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.trvUsuarios);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tplPanel);
            this.splitContainer1.Size = new System.Drawing.Size(800, 395);
            this.splitContainer1.SplitterDistance = 359;
            this.splitContainer1.TabIndex = 3;
            // 
            // tplPanel
            // 
            this.tplPanel.ColumnCount = 2;
            this.tplPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tplPanel.Controls.Add(this.lblLogin, 0, 0);
            this.tplPanel.Controls.Add(this.txtLogin, 1, 0);
            this.tplPanel.Controls.Add(this.txtNombre, 1, 1);
            this.tplPanel.Controls.Add(this.lblNombre, 0, 1);
            this.tplPanel.Controls.Add(this.lblContrasena, 0, 2);
            this.tplPanel.Controls.Add(this.txtPassword, 1, 2);
            this.tplPanel.Controls.Add(this.lblRol, 0, 3);
            this.tplPanel.Controls.Add(this.cmbRol, 1, 3);
            this.tplPanel.Location = new System.Drawing.Point(35, 45);
            this.tplPanel.Margin = new System.Windows.Forms.Padding(4);
            this.tplPanel.Name = "tplPanel";
            this.tplPanel.RowCount = 4;
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tplPanel.Size = new System.Drawing.Size(345, 158);
            this.tplPanel.TabIndex = 2;
            // 
            // lblLogin
            // 
            this.lblLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblLogin.AutoSize = true;
            this.lblLogin.Location = new System.Drawing.Point(4, 7);
            this.lblLogin.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(76, 16);
            this.lblLogin.TabIndex = 0;
            this.lblLogin.Text = "Login";
            // 
            // txtLogin
            // 
            this.txtLogin.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLogin.Location = new System.Drawing.Point(88, 4);
            this.txtLogin.Margin = new System.Windows.Forms.Padding(4);
            this.txtLogin.Name = "txtLogin";
            this.txtLogin.Size = new System.Drawing.Size(253, 22);
            this.txtLogin.TabIndex = 1;
            // 
            // txtNombre
            // 
            this.txtNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNombre.Location = new System.Drawing.Point(88, 34);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(253, 22);
            this.txtNombre.TabIndex = 2;
            // 
            // lblNombre
            // 
            this.lblNombre.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(4, 37);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(76, 16);
            this.lblNombre.TabIndex = 8;
            this.lblNombre.Text = "Nombre";
            // 
            // lblContrasena
            // 
            this.lblContrasena.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblContrasena.AutoSize = true;
            this.lblContrasena.Location = new System.Drawing.Point(4, 67);
            this.lblContrasena.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContrasena.Name = "lblContrasena";
            this.lblContrasena.Size = new System.Drawing.Size(76, 16);
            this.lblContrasena.TabIndex = 1;
            this.lblContrasena.Text = "Contrasena";
            // 
            // txtPassword
            // 
            this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPassword.Location = new System.Drawing.Point(88, 64);
            this.txtPassword.Margin = new System.Windows.Forms.Padding(4);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(253, 22);
            this.txtPassword.TabIndex = 3;
            // 
            // lblRol
            // 
            this.lblRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblRol.AutoSize = true;
            this.lblRol.Location = new System.Drawing.Point(4, 116);
            this.lblRol.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRol.Name = "lblRol";
            this.lblRol.Size = new System.Drawing.Size(76, 16);
            this.lblRol.TabIndex = 6;
            this.lblRol.Text = "Rol";
            // 
            // cmbRol
            // 
            this.cmbRol.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbRol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbRol.FormattingEnabled = true;
            this.cmbRol.Location = new System.Drawing.Point(88, 112);
            this.cmbRol.Margin = new System.Windows.Forms.Padding(4);
            this.cmbRol.Name = "cmbRol";
            this.cmbRol.Size = new System.Drawing.Size(253, 24);
            this.cmbRol.TabIndex = 4;
            // 
            // trvUsuarios
            // 
            this.trvUsuarios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.trvUsuarios.Location = new System.Drawing.Point(0, 0);
            this.trvUsuarios.Margin = new System.Windows.Forms.Padding(4);
            this.trvUsuarios.Name = "trvUsuarios";
            this.trvUsuarios.Size = new System.Drawing.Size(359, 395);
            this.trvUsuarios.TabIndex = 6;
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 428);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(800, 22);
            this.sttBarraInferior.TabIndex = 4;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_agregar_48;
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(104, 52);
            this.toolStripBtnNuevo.Text = "&Nuevo";
            // 
            // toolStripBtnSalvarUsuario
            // 
            this.toolStripBtnSalvarUsuario.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_guardar_40;
            this.toolStripBtnSalvarUsuario.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalvarUsuario.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalvarUsuario.Name = "toolStripBtnSalvarUsuario";
            this.toolStripBtnSalvarUsuario.Size = new System.Drawing.Size(93, 52);
            this.toolStripBtnSalvarUsuario.Text = "&Salvar";
            // 
            // frmSeguridad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.tspBarraPrincipal);
            this.Name = "frmSeguridad";
            this.Text = "Seguridad";
            this.tspBarraPrincipal.ResumeLayout(false);
            this.tspBarraPrincipal.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tplPanel.ResumeLayout(false);
            this.tplPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraPrincipal;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalvarUsuario;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView trvUsuarios;
        private System.Windows.Forms.TableLayoutPanel tplPanel;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.TextBox txtLogin;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.Label lblContrasena;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblRol;
        private System.Windows.Forms.ComboBox cmbRol;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
    }
}