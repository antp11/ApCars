namespace apCars
{
    partial class frmPrincipal
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
            this.mspMenuPrincipal = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemMantenimientos = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItemCliente = new System.Windows.Forms.ToolStripMenuItem();
            this.vehiculosToolStripMenuItemProductos = new System.Windows.Forms.ToolStripMenuItem();
            this.tarjetasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.impuestoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.marcaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.provinciaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemProcesos = new System.Windows.Forms.ToolStripMenuItem();
            this.facturarToolStripMenuItemFacturar = new System.Windows.Forms.ToolStripMenuItem();
            this.anularFacturaToolStripMenuItemAnularFactura = new System.Windows.Forms.ToolStripMenuItem();
            this.cierreToolStripMenuItemCierre = new System.Windows.Forms.ToolStripMenuItem();
            this.reportesToolStripMenuItemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.VehiculoToolStripMenuItemElectronico = new System.Windows.Forms.ToolStripMenuItem();
            this.clientesToolStripMenuItemClientes = new System.Windows.Forms.ToolStripMenuItem();
            this.facturaciónToolStripMenuItemfacturacion = new System.Windows.Forms.ToolStripMenuItem();
            this.gráficoToolStripMenuItemGraficos = new System.Windows.Forms.ToolStripMenuItem();
            this.ventaElectronicoToolStripMenuItemVentaElectronico = new System.Windows.Forms.ToolStripMenuItem();
            this.productosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.administracionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItemUsuarios = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAcercaDe = new System.Windows.Forms.ToolStripMenuItem();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblMensaje = new System.Windows.Forms.ToolStripStatusLabel();
            this.mspMenuPrincipal.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            this.SuspendLayout();
            // 
            // mspMenuPrincipal
            // 
            this.mspMenuPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mspMenuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemMantenimientos,
            this.toolStripMenuItemProcesos,
            this.reportesToolStripMenuItemReportes,
            this.administracionToolStripMenuItem,
            this.toolStripMenuItemAcercaDe});
            this.mspMenuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.mspMenuPrincipal.Name = "mspMenuPrincipal";
            this.mspMenuPrincipal.Size = new System.Drawing.Size(1184, 56);
            this.mspMenuPrincipal.TabIndex = 2;
            this.mspMenuPrincipal.Text = "menuStrip1";
            // 
            // toolStripMenuItemMantenimientos
            // 
            this.toolStripMenuItemMantenimientos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientesToolStripMenuItemCliente,
            this.vehiculosToolStripMenuItemProductos,
            this.tarjetasToolStripMenuItem,
            this.impuestoToolStripMenuItem,
            this.marcaToolStripMenuItem,
            this.provinciaToolStripMenuItem});
            this.toolStripMenuItemMantenimientos.Image = global::UTN.WinForms.ApCars.Properties.Resources.setting;
            this.toolStripMenuItemMantenimientos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemMantenimientos.Name = "toolStripMenuItemMantenimientos";
            this.toolStripMenuItemMantenimientos.Size = new System.Drawing.Size(178, 52);
            this.toolStripMenuItemMantenimientos.Text = "Mantenimientos";
            // 
            // clientesToolStripMenuItemCliente
            // 
            this.clientesToolStripMenuItemCliente.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientesToolStripMenuItemCliente.Name = "clientesToolStripMenuItemCliente";
            this.clientesToolStripMenuItemCliente.Size = new System.Drawing.Size(154, 26);
            this.clientesToolStripMenuItemCliente.Text = "Clientes";
            this.clientesToolStripMenuItemCliente.Click += new System.EventHandler(this.clientesToolStripMenuItemCliente_Click);
            // 
            // vehiculosToolStripMenuItemProductos
            // 
            this.vehiculosToolStripMenuItemProductos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.vehiculosToolStripMenuItemProductos.Name = "vehiculosToolStripMenuItemProductos";
            this.vehiculosToolStripMenuItemProductos.Size = new System.Drawing.Size(154, 26);
            this.vehiculosToolStripMenuItemProductos.Text = "Vehiculos";
            this.vehiculosToolStripMenuItemProductos.Click += new System.EventHandler(this.vehiculosToolStripMenuItemProductos_Click);
            // 
            // tarjetasToolStripMenuItem
            // 
            this.tarjetasToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tarjetasToolStripMenuItem.Name = "tarjetasToolStripMenuItem";
            this.tarjetasToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.tarjetasToolStripMenuItem.Text = "Tarjetas";
            // 
            // impuestoToolStripMenuItem
            // 
            this.impuestoToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.impuestoToolStripMenuItem.Name = "impuestoToolStripMenuItem";
            this.impuestoToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.impuestoToolStripMenuItem.Text = "Impuesto";
            this.impuestoToolStripMenuItem.Click += new System.EventHandler(this.impuestoToolStripMenuItem_Click);
            // 
            // marcaToolStripMenuItem
            // 
            this.marcaToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.marcaToolStripMenuItem.Name = "marcaToolStripMenuItem";
            this.marcaToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.marcaToolStripMenuItem.Text = "Marca";
            this.marcaToolStripMenuItem.Click += new System.EventHandler(this.marcaToolStripMenuItem_Click);
            // 
            // provinciaToolStripMenuItem
            // 
            this.provinciaToolStripMenuItem.Name = "provinciaToolStripMenuItem";
            this.provinciaToolStripMenuItem.Size = new System.Drawing.Size(154, 26);
            this.provinciaToolStripMenuItem.Text = "Provincia";
            this.provinciaToolStripMenuItem.Click += new System.EventHandler(this.provinciaToolStripMenuItem_Click);
            // 
            // toolStripMenuItemProcesos
            // 
            this.toolStripMenuItemProcesos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.facturarToolStripMenuItemFacturar,
            this.anularFacturaToolStripMenuItemAnularFactura,
            this.cierreToolStripMenuItemCierre});
            this.toolStripMenuItemProcesos.Image = global::UTN.WinForms.ApCars.Properties.Resources.run_build_2;
            this.toolStripMenuItemProcesos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemProcesos.Name = "toolStripMenuItemProcesos";
            this.toolStripMenuItemProcesos.Size = new System.Drawing.Size(129, 52);
            this.toolStripMenuItemProcesos.Text = "Procesos";
            // 
            // facturarToolStripMenuItemFacturar
            // 
            this.facturarToolStripMenuItemFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturarToolStripMenuItemFacturar.Name = "facturarToolStripMenuItemFacturar";
            this.facturarToolStripMenuItemFacturar.Size = new System.Drawing.Size(186, 26);
            this.facturarToolStripMenuItemFacturar.Text = "Facturar";
            this.facturarToolStripMenuItemFacturar.Click += new System.EventHandler(this.facturarToolStripMenuItemFacturar_Click);
            // 
            // anularFacturaToolStripMenuItemAnularFactura
            // 
            this.anularFacturaToolStripMenuItemAnularFactura.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.anularFacturaToolStripMenuItemAnularFactura.Name = "anularFacturaToolStripMenuItemAnularFactura";
            this.anularFacturaToolStripMenuItemAnularFactura.Size = new System.Drawing.Size(186, 26);
            this.anularFacturaToolStripMenuItemAnularFactura.Text = "Anular Factura";
            // 
            // cierreToolStripMenuItemCierre
            // 
            this.cierreToolStripMenuItemCierre.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.cierreToolStripMenuItemCierre.Name = "cierreToolStripMenuItemCierre";
            this.cierreToolStripMenuItemCierre.Size = new System.Drawing.Size(186, 26);
            this.cierreToolStripMenuItemCierre.Text = "Cierre";
            // 
            // reportesToolStripMenuItemReportes
            // 
            this.reportesToolStripMenuItemReportes.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.VehiculoToolStripMenuItemElectronico,
            this.clientesToolStripMenuItemClientes,
            this.facturaciónToolStripMenuItemfacturacion,
            this.gráficoToolStripMenuItemGraficos});
            this.reportesToolStripMenuItemReportes.Image = global::UTN.WinForms.ApCars.Properties.Resources.document_print_2;
            this.reportesToolStripMenuItemReportes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.reportesToolStripMenuItemReportes.Name = "reportesToolStripMenuItemReportes";
            this.reportesToolStripMenuItemReportes.Size = new System.Drawing.Size(130, 52);
            this.reportesToolStripMenuItemReportes.Text = "Reportes";
            // 
            // VehiculoToolStripMenuItemElectronico
            // 
            this.VehiculoToolStripMenuItemElectronico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.VehiculoToolStripMenuItemElectronico.Name = "VehiculoToolStripMenuItemElectronico";
            this.VehiculoToolStripMenuItemElectronico.Size = new System.Drawing.Size(224, 26);
            this.VehiculoToolStripMenuItemElectronico.Text = "Vehiculo";
            this.VehiculoToolStripMenuItemElectronico.Click += new System.EventHandler(this.VehiculoToolStripMenuItemElectronico_Click);
            // 
            // clientesToolStripMenuItemClientes
            // 
            this.clientesToolStripMenuItemClientes.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.clientesToolStripMenuItemClientes.Name = "clientesToolStripMenuItemClientes";
            this.clientesToolStripMenuItemClientes.Size = new System.Drawing.Size(224, 26);
            this.clientesToolStripMenuItemClientes.Text = "Clientes";
            this.clientesToolStripMenuItemClientes.Click += new System.EventHandler(this.clientesToolStripMenuItemClientes_Click);
            // 
            // facturaciónToolStripMenuItemfacturacion
            // 
            this.facturaciónToolStripMenuItemfacturacion.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.facturaciónToolStripMenuItemfacturacion.Name = "facturaciónToolStripMenuItemfacturacion";
            this.facturaciónToolStripMenuItemfacturacion.Size = new System.Drawing.Size(224, 26);
            this.facturaciónToolStripMenuItemfacturacion.Text = "Facturación";
            // 
            // gráficoToolStripMenuItemGraficos
            // 
            this.gráficoToolStripMenuItemGraficos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ventaElectronicoToolStripMenuItemVentaElectronico,
            this.productosToolStripMenuItem});
            this.gráficoToolStripMenuItemGraficos.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.gráficoToolStripMenuItemGraficos.Name = "gráficoToolStripMenuItemGraficos";
            this.gráficoToolStripMenuItemGraficos.Size = new System.Drawing.Size(224, 26);
            this.gráficoToolStripMenuItemGraficos.Text = "Gráfico";
            // 
            // ventaElectronicoToolStripMenuItemVentaElectronico
            // 
            this.ventaElectronicoToolStripMenuItemVentaElectronico.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.ventaElectronicoToolStripMenuItemVentaElectronico.Name = "ventaElectronicoToolStripMenuItemVentaElectronico";
            this.ventaElectronicoToolStripMenuItemVentaElectronico.Size = new System.Drawing.Size(207, 26);
            this.ventaElectronicoToolStripMenuItemVentaElectronico.Text = "Venta Electronico";
            // 
            // productosToolStripMenuItem
            // 
            this.productosToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.productosToolStripMenuItem.Name = "productosToolStripMenuItem";
            this.productosToolStripMenuItem.Size = new System.Drawing.Size(207, 26);
            this.productosToolStripMenuItem.Text = "Productos";
            // 
            // administracionToolStripMenuItem
            // 
            this.administracionToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosToolStripMenuItemUsuarios});
            this.administracionToolStripMenuItem.Image = global::UTN.WinForms.ApCars.Properties.Resources.system_settings;
            this.administracionToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.administracionToolStripMenuItem.Name = "administracionToolStripMenuItem";
            this.administracionToolStripMenuItem.Size = new System.Drawing.Size(171, 52);
            this.administracionToolStripMenuItem.Text = "Administración";
            // 
            // usuariosToolStripMenuItemUsuarios
            // 
            this.usuariosToolStripMenuItemUsuarios.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.usuariosToolStripMenuItemUsuarios.Name = "usuariosToolStripMenuItemUsuarios";
            this.usuariosToolStripMenuItemUsuarios.Size = new System.Drawing.Size(148, 26);
            this.usuariosToolStripMenuItemUsuarios.Text = "Usuarios";
            this.usuariosToolStripMenuItemUsuarios.Click += new System.EventHandler(this.usuariosToolStripMenuItemUsuarios_Click);
            // 
            // toolStripMenuItemAcercaDe
            // 
            this.toolStripMenuItemAcercaDe.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripMenuItemAcercaDe.Name = "toolStripMenuItemAcercaDe";
            this.toolStripMenuItemAcercaDe.Size = new System.Drawing.Size(14, 52);
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblMensaje});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 881);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(1184, 26);
            this.sttBarraInferior.TabIndex = 4;
            // 
            // toolStripStatusLblMensaje
            // 
            this.toolStripStatusLblMensaje.Name = "toolStripStatusLblMensaje";
            this.toolStripStatusLblMensaje.Size = new System.Drawing.Size(15, 20);
            this.toolStripStatusLblMensaje.Text = "-";
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::UTN.WinForms.ApCars.Properties.Resources.logoActualizado_2;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1184, 907);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.mspMenuPrincipal);
            this.DoubleBuffered = true;
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Principal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            this.mspMenuPrincipal.ResumeLayout(false);
            this.mspMenuPrincipal.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mspMenuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemMantenimientos;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItemCliente;
        private System.Windows.Forms.ToolStripMenuItem vehiculosToolStripMenuItemProductos;
        private System.Windows.Forms.ToolStripMenuItem tarjetasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem impuestoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem marcaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemProcesos;
        private System.Windows.Forms.ToolStripMenuItem facturarToolStripMenuItemFacturar;
        private System.Windows.Forms.ToolStripMenuItem anularFacturaToolStripMenuItemAnularFactura;
        private System.Windows.Forms.ToolStripMenuItem cierreToolStripMenuItemCierre;
        private System.Windows.Forms.ToolStripMenuItem reportesToolStripMenuItemReportes;
        private System.Windows.Forms.ToolStripMenuItem VehiculoToolStripMenuItemElectronico;
        private System.Windows.Forms.ToolStripMenuItem clientesToolStripMenuItemClientes;
        private System.Windows.Forms.ToolStripMenuItem facturaciónToolStripMenuItemfacturacion;
        private System.Windows.Forms.ToolStripMenuItem gráficoToolStripMenuItemGraficos;
        private System.Windows.Forms.ToolStripMenuItem ventaElectronicoToolStripMenuItemVentaElectronico;
        private System.Windows.Forms.ToolStripMenuItem productosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem administracionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItemUsuarios;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAcercaDe;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblMensaje;
        private System.Windows.Forms.ToolStripMenuItem provinciaToolStripMenuItem;
    }
}

