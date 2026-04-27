namespace UTN.WinForms.ApCars.Layers.UI.Procesos
{
    partial class frmFacturacion
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
            this.tspBarraSuperior = new System.Windows.Forms.ToolStrip();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLblDolar = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pnlFirma = new System.Windows.Forms.Panel();
            this.grbFacturacion = new System.Windows.Forms.GroupBox();
            this.tlpProducto = new System.Windows.Forms.TableLayoutPanel();
            this.txtVIN = new System.Windows.Forms.TextBox();
            this.txtMarca = new System.Windows.Forms.TextBox();
            this.lblMarca = new System.Windows.Forms.Label();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.lblVIN = new System.Windows.Forms.Label();
            this.txtDescripcionVehiculo = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.txtPrecio = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tlpAgrupamiento = new System.Windows.Forms.TableLayoutPanel();
            this.lblCliente = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNumeroTarjeta = new System.Windows.Forms.TextBox();
            this.txtClienteId = new System.Windows.Forms.TextBox();
            this.rdbTransferencia = new System.Windows.Forms.RadioButton();
            this.cmbTarjeta = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtNumeroFactura = new System.Windows.Forms.TextBox();
            this.txtNombreCliente = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.rdbCredito = new System.Windows.Forms.RadioButton();
            this.grbDetalle = new System.Windows.Forms.GroupBox();
            this.tlbPanelTotalPagar = new System.Windows.Forms.TableLayoutPanel();
            this.txtDolares = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSubtotal = new System.Windows.Forms.TextBox();
            this.txtImpuesto = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.dgvDetalleFactura = new System.Windows.Forms.DataGridView();
            this.No = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.VIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Marca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripciónVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Impuesto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.erpError = new System.Windows.Forms.ErrorProvider(this.components);
            this.btnLimpiarFirma = new System.Windows.Forms.Button();
            this.picFirma = new System.Windows.Forms.PictureBox();
            this.btnBuscarVehiculo = new System.Windows.Forms.Button();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.btnBuscarCliente = new System.Windows.Forms.Button();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnFacturar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.tspBarraSuperior.SuspendLayout();
            this.sttBarraInferior.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.pnlFirma.SuspendLayout();
            this.grbFacturacion.SuspendLayout();
            this.tlpProducto.SuspendLayout();
            this.tlpAgrupamiento.SuspendLayout();
            this.grbDetalle.SuspendLayout();
            this.tlbPanelTotalPagar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirma)).BeginInit();
            this.SuspendLayout();
            // 
            // tspBarraSuperior
            // 
            this.tspBarraSuperior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspBarraSuperior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnFacturar,
            this.toolStripBtnSalir});
            this.tspBarraSuperior.Location = new System.Drawing.Point(0, 0);
            this.tspBarraSuperior.Name = "tspBarraSuperior";
            this.tspBarraSuperior.Size = new System.Drawing.Size(1400, 71);
            this.tspBarraSuperior.TabIndex = 2;
            this.tspBarraSuperior.Text = "toolStrip1";
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLblDolar});
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 757);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(1400, 34);
            this.sttBarraInferior.TabIndex = 3;
            this.sttBarraInferior.Text = "statusStrip1";
            // 
            // toolStripStatusLblDolar
            // 
            this.toolStripStatusLblDolar.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripStatusLblDolar.Name = "toolStripStatusLblDolar";
            this.toolStripStatusLblDolar.Size = new System.Drawing.Size(20, 28);
            this.toolStripStatusLblDolar.Text = "-";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 71);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pnlFirma);
            this.splitContainer1.Panel1.Controls.Add(this.grbFacturacion);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.grbDetalle);
            this.splitContainer1.Size = new System.Drawing.Size(1400, 686);
            this.splitContainer1.SplitterDistance = 676;
            this.splitContainer1.TabIndex = 4;
            // 
            // pnlFirma
            // 
            this.pnlFirma.Controls.Add(this.btnLimpiarFirma);
            this.pnlFirma.Controls.Add(this.picFirma);
            this.pnlFirma.Location = new System.Drawing.Point(13, 561);
            this.pnlFirma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pnlFirma.Name = "pnlFirma";
            this.pnlFirma.Size = new System.Drawing.Size(644, 117);
            this.pnlFirma.TabIndex = 8;
            // 
            // grbFacturacion
            // 
            this.grbFacturacion.Controls.Add(this.tlpProducto);
            this.grbFacturacion.Controls.Add(this.tlpAgrupamiento);
            this.grbFacturacion.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grbFacturacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbFacturacion.Location = new System.Drawing.Point(4, 25);
            this.grbFacturacion.Margin = new System.Windows.Forms.Padding(4);
            this.grbFacturacion.Name = "grbFacturacion";
            this.grbFacturacion.Padding = new System.Windows.Forms.Padding(4);
            this.grbFacturacion.Size = new System.Drawing.Size(653, 530);
            this.grbFacturacion.TabIndex = 7;
            this.grbFacturacion.TabStop = false;
            this.grbFacturacion.Text = "Facturación";
            // 
            // tlpProducto
            // 
            this.tlpProducto.ColumnCount = 3;
            this.tlpProducto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpProducto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpProducto.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 181F));
            this.tlpProducto.Controls.Add(this.txtVIN, 1, 0);
            this.tlpProducto.Controls.Add(this.txtMarca, 1, 1);
            this.tlpProducto.Controls.Add(this.lblMarca, 0, 1);
            this.tlpProducto.Controls.Add(this.btnBuscarVehiculo, 2, 0);
            this.tlpProducto.Controls.Add(this.lblDescripcion, 0, 2);
            this.tlpProducto.Controls.Add(this.lblVIN, 0, 0);
            this.tlpProducto.Controls.Add(this.txtDescripcionVehiculo, 1, 2);
            this.tlpProducto.Controls.Add(this.label13, 0, 3);
            this.tlpProducto.Controls.Add(this.txtEstado, 1, 3);
            this.tlpProducto.Controls.Add(this.txtPrecio, 1, 4);
            this.tlpProducto.Controls.Add(this.label7, 0, 4);
            this.tlpProducto.Controls.Add(this.btnAgregar, 2, 4);
            this.tlpProducto.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlpProducto.Location = new System.Drawing.Point(9, 298);
            this.tlpProducto.Margin = new System.Windows.Forms.Padding(4);
            this.tlpProducto.Name = "tlpProducto";
            this.tlpProducto.RowCount = 5;
            this.tlpProducto.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProducto.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProducto.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProducto.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProducto.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpProducto.Size = new System.Drawing.Size(644, 195);
            this.tlpProducto.TabIndex = 7;
            // 
            // txtVIN
            // 
            this.txtVIN.Location = new System.Drawing.Point(96, 4);
            this.txtVIN.Margin = new System.Windows.Forms.Padding(4);
            this.txtVIN.Name = "txtVIN";
            this.txtVIN.ReadOnly = true;
            this.txtVIN.Size = new System.Drawing.Size(241, 22);
            this.txtVIN.TabIndex = 15;
            this.txtVIN.TabStop = false;
            // 
            // txtMarca
            // 
            this.txtMarca.Location = new System.Drawing.Point(96, 34);
            this.txtMarca.Margin = new System.Windows.Forms.Padding(4);
            this.txtMarca.Name = "txtMarca";
            this.txtMarca.ReadOnly = true;
            this.txtMarca.Size = new System.Drawing.Size(241, 22);
            this.txtMarca.TabIndex = 14;
            this.txtMarca.TabStop = false;
            // 
            // lblMarca
            // 
            this.lblMarca.AutoSize = true;
            this.lblMarca.Location = new System.Drawing.Point(4, 30);
            this.lblMarca.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMarca.Name = "lblMarca";
            this.lblMarca.Size = new System.Drawing.Size(45, 16);
            this.lblMarca.TabIndex = 13;
            this.lblMarca.Text = "Marca";
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Location = new System.Drawing.Point(4, 60);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(79, 16);
            this.lblDescripcion.TabIndex = 8;
            this.lblDescripcion.Text = "Descripción";
            // 
            // lblVIN
            // 
            this.lblVIN.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblVIN.AutoSize = true;
            this.lblVIN.Location = new System.Drawing.Point(4, 7);
            this.lblVIN.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblVIN.Name = "lblVIN";
            this.lblVIN.Size = new System.Drawing.Size(84, 16);
            this.lblVIN.TabIndex = 0;
            this.lblVIN.Text = "VIN Vehiculo";
            // 
            // txtDescripcionVehiculo
            // 
            this.txtDescripcionVehiculo.Location = new System.Drawing.Point(96, 64);
            this.txtDescripcionVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcionVehiculo.Name = "txtDescripcionVehiculo";
            this.txtDescripcionVehiculo.ReadOnly = true;
            this.txtDescripcionVehiculo.Size = new System.Drawing.Size(241, 22);
            this.txtDescripcionVehiculo.TabIndex = 0;
            this.txtDescripcionVehiculo.TabStop = false;
            // 
            // label13
            // 
            this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(4, 97);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(84, 16);
            this.label13.TabIndex = 12;
            this.label13.Text = "Estado";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(96, 94);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.ReadOnly = true;
            this.txtEstado.Size = new System.Drawing.Size(241, 22);
            this.txtEstado.TabIndex = 0;
            this.txtEstado.TabStop = false;
            // 
            // txtPrecio
            // 
            this.txtPrecio.Location = new System.Drawing.Point(96, 124);
            this.txtPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.txtPrecio.Name = "txtPrecio";
            this.txtPrecio.ReadOnly = true;
            this.txtPrecio.Size = new System.Drawing.Size(241, 22);
            this.txtPrecio.TabIndex = 0;
            this.txtPrecio.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(4, 120);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(46, 16);
            this.label7.TabIndex = 9;
            this.label7.Text = "Precio";
            // 
            // tlpAgrupamiento
            // 
            this.tlpAgrupamiento.BackColor = System.Drawing.SystemColors.Control;
            this.tlpAgrupamiento.ColumnCount = 3;
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 172F));
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 277F));
            this.tlpAgrupamiento.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 408F));
            this.tlpAgrupamiento.Controls.Add(this.lblCliente, 0, 4);
            this.tlpAgrupamiento.Controls.Add(this.label2, 0, 3);
            this.tlpAgrupamiento.Controls.Add(this.label4, 0, 2);
            this.tlpAgrupamiento.Controls.Add(this.txtNumeroTarjeta, 1, 3);
            this.tlpAgrupamiento.Controls.Add(this.txtClienteId, 1, 4);
            this.tlpAgrupamiento.Controls.Add(this.rdbTransferencia, 1, 1);
            this.tlpAgrupamiento.Controls.Add(this.cmbTarjeta, 1, 2);
            this.tlpAgrupamiento.Controls.Add(this.btnBuscarCliente, 2, 3);
            this.tlpAgrupamiento.Controls.Add(this.label1, 0, 1);
            this.tlpAgrupamiento.Controls.Add(this.label11, 0, 0);
            this.tlpAgrupamiento.Controls.Add(this.txtNumeroFactura, 1, 0);
            this.tlpAgrupamiento.Controls.Add(this.txtNombreCliente, 1, 5);
            this.tlpAgrupamiento.Controls.Add(this.label12, 0, 5);
            this.tlpAgrupamiento.Controls.Add(this.rdbCredito, 2, 1);
            this.tlpAgrupamiento.Location = new System.Drawing.Point(21, 30);
            this.tlpAgrupamiento.Margin = new System.Windows.Forms.Padding(4);
            this.tlpAgrupamiento.Name = "tlpAgrupamiento";
            this.tlpAgrupamiento.RowCount = 6;
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpAgrupamiento.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpAgrupamiento.Size = new System.Drawing.Size(612, 215);
            this.tlpAgrupamiento.TabIndex = 2;
            // 
            // lblCliente
            // 
            this.lblCliente.AutoSize = true;
            this.lblCliente.Location = new System.Drawing.Point(4, 120);
            this.lblCliente.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCliente.Name = "lblCliente";
            this.lblCliente.Size = new System.Drawing.Size(48, 16);
            this.lblCliente.TabIndex = 2;
            this.lblCliente.Text = "Cliente";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 90);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "No Tarjeta";
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 66);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(164, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Tarjeta";
            // 
            // txtNumeroTarjeta
            // 
            this.txtNumeroTarjeta.Location = new System.Drawing.Point(176, 94);
            this.txtNumeroTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroTarjeta.Name = "txtNumeroTarjeta";
            this.txtNumeroTarjeta.Size = new System.Drawing.Size(239, 22);
            this.txtNumeroTarjeta.TabIndex = 2;
            // 
            // txtClienteId
            // 
            this.txtClienteId.Location = new System.Drawing.Point(176, 124);
            this.txtClienteId.Margin = new System.Windows.Forms.Padding(4);
            this.txtClienteId.Name = "txtClienteId";
            this.txtClienteId.Size = new System.Drawing.Size(239, 22);
            this.txtClienteId.TabIndex = 3;
            // 
            // rdbTransferencia
            // 
            this.rdbTransferencia.AutoSize = true;
            this.rdbTransferencia.Location = new System.Drawing.Point(176, 34);
            this.rdbTransferencia.Margin = new System.Windows.Forms.Padding(4);
            this.rdbTransferencia.Name = "rdbTransferencia";
            this.rdbTransferencia.Size = new System.Drawing.Size(111, 20);
            this.rdbTransferencia.TabIndex = 0;
            this.rdbTransferencia.Text = "Transferencia";
            this.rdbTransferencia.UseVisualStyleBackColor = true;
            // 
            // cmbTarjeta
            // 
            this.cmbTarjeta.FormattingEnabled = true;
            this.cmbTarjeta.Location = new System.Drawing.Point(176, 62);
            this.cmbTarjeta.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTarjeta.Name = "cmbTarjeta";
            this.cmbTarjeta.Size = new System.Drawing.Size(239, 24);
            this.cmbTarjeta.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 36);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(164, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tipo Pago";
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 7);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(164, 16);
            this.label11.TabIndex = 11;
            this.label11.Text = "No. Factura";
            // 
            // txtNumeroFactura
            // 
            this.txtNumeroFactura.Location = new System.Drawing.Point(176, 4);
            this.txtNumeroFactura.Margin = new System.Windows.Forms.Padding(4);
            this.txtNumeroFactura.Name = "txtNumeroFactura";
            this.txtNumeroFactura.ReadOnly = true;
            this.txtNumeroFactura.Size = new System.Drawing.Size(265, 22);
            this.txtNumeroFactura.TabIndex = 0;
            this.txtNumeroFactura.TabStop = false;
            // 
            // txtNombreCliente
            // 
            this.tlpAgrupamiento.SetColumnSpan(this.txtNombreCliente, 2);
            this.txtNombreCliente.Location = new System.Drawing.Point(176, 166);
            this.txtNombreCliente.Margin = new System.Windows.Forms.Padding(4);
            this.txtNombreCliente.Name = "txtNombreCliente";
            this.txtNombreCliente.ReadOnly = true;
            this.txtNombreCliente.Size = new System.Drawing.Size(424, 22);
            this.txtNombreCliente.TabIndex = 0;
            this.txtNombreCliente.TabStop = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 162);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(100, 16);
            this.label12.TabIndex = 14;
            this.label12.Text = "Nombre Cliente";
            // 
            // rdbCredito
            // 
            this.rdbCredito.AutoSize = true;
            this.rdbCredito.Checked = true;
            this.rdbCredito.Location = new System.Drawing.Point(453, 34);
            this.rdbCredito.Margin = new System.Windows.Forms.Padding(4);
            this.rdbCredito.Name = "rdbCredito";
            this.tlpAgrupamiento.SetRowSpan(this.rdbCredito, 2);
            this.rdbCredito.Size = new System.Drawing.Size(71, 20);
            this.rdbCredito.TabIndex = 0;
            this.rdbCredito.TabStop = true;
            this.rdbCredito.Text = "Crédito";
            this.rdbCredito.UseVisualStyleBackColor = true;
            this.rdbCredito.Click += new System.EventHandler(this.rdbCredito_Click);
            // 
            // grbDetalle
            // 
            this.grbDetalle.Controls.Add(this.tlbPanelTotalPagar);
            this.grbDetalle.Controls.Add(this.dgvDetalleFactura);
            this.grbDetalle.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbDetalle.Location = new System.Drawing.Point(19, 25);
            this.grbDetalle.Margin = new System.Windows.Forms.Padding(4);
            this.grbDetalle.Name = "grbDetalle";
            this.grbDetalle.Padding = new System.Windows.Forms.Padding(4);
            this.grbDetalle.Size = new System.Drawing.Size(676, 570);
            this.grbDetalle.TabIndex = 9;
            this.grbDetalle.TabStop = false;
            this.grbDetalle.Text = "Detalle";
            // 
            // tlbPanelTotalPagar
            // 
            this.tlbPanelTotalPagar.ColumnCount = 2;
            this.tlbPanelTotalPagar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 34.68208F));
            this.tlbPanelTotalPagar.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 65.31792F));
            this.tlbPanelTotalPagar.Controls.Add(this.txtDolares, 1, 3);
            this.tlbPanelTotalPagar.Controls.Add(this.label8, 0, 0);
            this.tlbPanelTotalPagar.Controls.Add(this.label9, 0, 1);
            this.tlbPanelTotalPagar.Controls.Add(this.label10, 0, 2);
            this.tlbPanelTotalPagar.Controls.Add(this.txtSubtotal, 1, 0);
            this.tlbPanelTotalPagar.Controls.Add(this.txtImpuesto, 1, 1);
            this.tlbPanelTotalPagar.Controls.Add(this.txtTotal, 1, 2);
            this.tlbPanelTotalPagar.Controls.Add(this.label14, 0, 3);
            this.tlbPanelTotalPagar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlbPanelTotalPagar.Location = new System.Drawing.Point(389, 390);
            this.tlbPanelTotalPagar.Margin = new System.Windows.Forms.Padding(4);
            this.tlbPanelTotalPagar.Name = "tlbPanelTotalPagar";
            this.tlbPanelTotalPagar.RowCount = 4;
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlbPanelTotalPagar.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlbPanelTotalPagar.Size = new System.Drawing.Size(273, 151);
            this.tlbPanelTotalPagar.TabIndex = 5;
            // 
            // txtDolares
            // 
            this.txtDolares.Location = new System.Drawing.Point(98, 118);
            this.txtDolares.Margin = new System.Windows.Forms.Padding(4);
            this.txtDolares.Name = "txtDolares";
            this.txtDolares.ReadOnly = true;
            this.txtDolares.Size = new System.Drawing.Size(165, 30);
            this.txtDolares.TabIndex = 4;
            this.txtDolares.TabStop = false;
            this.txtDolares.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(4, 10);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 17);
            this.label8.TabIndex = 0;
            this.label8.Text = "Subtotal";
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(4, 48);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "Impuesto";
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 86);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Total";
            // 
            // txtSubtotal
            // 
            this.txtSubtotal.Location = new System.Drawing.Point(98, 4);
            this.txtSubtotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtSubtotal.Name = "txtSubtotal";
            this.txtSubtotal.ReadOnly = true;
            this.txtSubtotal.Size = new System.Drawing.Size(169, 30);
            this.txtSubtotal.TabIndex = 0;
            this.txtSubtotal.TabStop = false;
            this.txtSubtotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtImpuesto
            // 
            this.txtImpuesto.Location = new System.Drawing.Point(98, 42);
            this.txtImpuesto.Margin = new System.Windows.Forms.Padding(4);
            this.txtImpuesto.Name = "txtImpuesto";
            this.txtImpuesto.ReadOnly = true;
            this.txtImpuesto.Size = new System.Drawing.Size(165, 30);
            this.txtImpuesto.TabIndex = 0;
            this.txtImpuesto.TabStop = false;
            this.txtImpuesto.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(98, 80);
            this.txtTotal.Margin = new System.Windows.Forms.Padding(4);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(165, 30);
            this.txtTotal.TabIndex = 0;
            this.txtTotal.TabStop = false;
            this.txtTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(3, 124);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(88, 16);
            this.label14.TabIndex = 3;
            this.label14.Text = "Dólares";
            // 
            // dgvDetalleFactura
            // 
            this.dgvDetalleFactura.AllowUserToAddRows = false;
            this.dgvDetalleFactura.AllowUserToDeleteRows = false;
            this.dgvDetalleFactura.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalleFactura.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.No,
            this.VIN,
            this.Marca,
            this.DescripciónVehiculo,
            this.Impuesto,
            this.Precio});
            this.dgvDetalleFactura.Location = new System.Drawing.Point(16, 25);
            this.dgvDetalleFactura.Margin = new System.Windows.Forms.Padding(4);
            this.dgvDetalleFactura.Name = "dgvDetalleFactura";
            this.dgvDetalleFactura.ReadOnly = true;
            this.dgvDetalleFactura.RowHeadersWidth = 51;
            this.dgvDetalleFactura.Size = new System.Drawing.Size(660, 341);
            this.dgvDetalleFactura.TabIndex = 0;
            this.dgvDetalleFactura.TabStop = false;
            // 
            // No
            // 
            this.No.HeaderText = "No";
            this.No.MinimumWidth = 6;
            this.No.Name = "No";
            this.No.ReadOnly = true;
            this.No.Width = 125;
            // 
            // VIN
            // 
            this.VIN.HeaderText = "VIN";
            this.VIN.MinimumWidth = 6;
            this.VIN.Name = "VIN";
            this.VIN.ReadOnly = true;
            this.VIN.Width = 125;
            // 
            // Marca
            // 
            this.Marca.HeaderText = "Marca";
            this.Marca.MinimumWidth = 6;
            this.Marca.Name = "Marca";
            this.Marca.ReadOnly = true;
            this.Marca.Width = 125;
            // 
            // DescripciónVehiculo
            // 
            this.DescripciónVehiculo.HeaderText = "Descripción Vehiculo";
            this.DescripciónVehiculo.MinimumWidth = 6;
            this.DescripciónVehiculo.Name = "DescripciónVehiculo";
            this.DescripciónVehiculo.ReadOnly = true;
            this.DescripciónVehiculo.Width = 125;
            // 
            // Impuesto
            // 
            this.Impuesto.HeaderText = "Impuesto";
            this.Impuesto.MinimumWidth = 6;
            this.Impuesto.Name = "Impuesto";
            this.Impuesto.ReadOnly = true;
            this.Impuesto.Width = 125;
            // 
            // Precio
            // 
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 125;
            // 
            // erpError
            // 
            this.erpError.ContainerControl = this;
            // 
            // btnLimpiarFirma
            // 
            this.btnLimpiarFirma.Image = global::UTN.WinForms.ApCars.Properties.Resources.Limpiar;
            this.btnLimpiarFirma.Location = new System.Drawing.Point(52, 31);
            this.btnLimpiarFirma.Margin = new System.Windows.Forms.Padding(4);
            this.btnLimpiarFirma.Name = "btnLimpiarFirma";
            this.btnLimpiarFirma.Size = new System.Drawing.Size(128, 58);
            this.btnLimpiarFirma.TabIndex = 66;
            this.btnLimpiarFirma.Text = "Limpiar Firma";
            this.btnLimpiarFirma.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnLimpiarFirma.UseVisualStyleBackColor = true;
            this.btnLimpiarFirma.Click += new System.EventHandler(this.btnLimpiarFirma_Click);
            // 
            // picFirma
            // 
            this.picFirma.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.picFirma.Location = new System.Drawing.Point(251, 15);
            this.picFirma.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.picFirma.Name = "picFirma";
            this.picFirma.Size = new System.Drawing.Size(351, 90);
            this.picFirma.TabIndex = 67;
            this.picFirma.TabStop = false;
            this.picFirma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseDown);
            this.picFirma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseMove);
            this.picFirma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picFirma_MouseUp);
            // 
            // btnBuscarVehiculo
            // 
            this.btnBuscarVehiculo.Image = global::UTN.WinForms.ApCars.Properties.Resources.buscar1;
            this.btnBuscarVehiculo.Location = new System.Drawing.Point(467, 4);
            this.btnBuscarVehiculo.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarVehiculo.Name = "btnBuscarVehiculo";
            this.tlpProducto.SetRowSpan(this.btnBuscarVehiculo, 3);
            this.btnBuscarVehiculo.Size = new System.Drawing.Size(145, 64);
            this.btnBuscarVehiculo.TabIndex = 6;
            this.btnBuscarVehiculo.Text = "Buscar Vehiculo";
            this.btnBuscarVehiculo.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarVehiculo.UseVisualStyleBackColor = true;
            this.btnBuscarVehiculo.Click += new System.EventHandler(this.btnBuscarVehiculo_Click);
            // 
            // btnAgregar
            // 
            this.btnAgregar.Image = global::UTN.WinForms.ApCars.Properties.Resources.ADD;
            this.btnAgregar.Location = new System.Drawing.Point(467, 124);
            this.btnAgregar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(159, 70);
            this.btnAgregar.TabIndex = 8;
            this.btnAgregar.Text = "Agregar";
            this.btnAgregar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // btnBuscarCliente
            // 
            this.btnBuscarCliente.Image = global::UTN.WinForms.ApCars.Properties.Resources.buscar1;
            this.btnBuscarCliente.Location = new System.Drawing.Point(453, 94);
            this.btnBuscarCliente.Margin = new System.Windows.Forms.Padding(4);
            this.btnBuscarCliente.Name = "btnBuscarCliente";
            this.tlpAgrupamiento.SetRowSpan(this.btnBuscarCliente, 2);
            this.btnBuscarCliente.Size = new System.Drawing.Size(147, 64);
            this.btnBuscarCliente.TabIndex = 4;
            this.btnBuscarCliente.Text = "Buscar Cliente";
            this.btnBuscarCliente.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnBuscarCliente.UseVisualStyleBackColor = true;
            this.btnBuscarCliente.Click += new System.EventHandler(this.btnBuscarCliente_Click);
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.Image = global::UTN.WinForms.ApCars.Properties.Resources.nuevo;
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(120, 68);
            this.toolStripBtnNuevo.Text = "Nuevo";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // toolStripBtnFacturar
            // 
            this.toolStripBtnFacturar.Image = global::UTN.WinForms.ApCars.Properties.Resources.Fact;
            this.toolStripBtnFacturar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnFacturar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnFacturar.Name = "toolStripBtnFacturar";
            this.toolStripBtnFacturar.Size = new System.Drawing.Size(129, 68);
            this.toolStripBtnFacturar.Text = "Facturar";
            this.toolStripBtnFacturar.Click += new System.EventHandler(this.toolStripBtnFacturar_Click);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.WinForms.ApCars.Properties.Resources.Salir2;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(106, 68);
            this.toolStripBtnSalir.Text = "Salir";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // frmFacturacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1400, 791);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sttBarraInferior);
            this.Controls.Add(this.tspBarraSuperior);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "frmFacturacion";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Facturacion";
            this.Load += new System.EventHandler(this.frmFacturacion_Load);
            this.tspBarraSuperior.ResumeLayout(false);
            this.tspBarraSuperior.PerformLayout();
            this.sttBarraInferior.ResumeLayout(false);
            this.sttBarraInferior.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.pnlFirma.ResumeLayout(false);
            this.grbFacturacion.ResumeLayout(false);
            this.tlpProducto.ResumeLayout(false);
            this.tlpProducto.PerformLayout();
            this.tlpAgrupamiento.ResumeLayout(false);
            this.tlpAgrupamiento.PerformLayout();
            this.grbDetalle.ResumeLayout(false);
            this.tlbPanelTotalPagar.ResumeLayout(false);
            this.tlbPanelTotalPagar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalleFactura)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.erpError)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFirma)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspBarraSuperior;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnFacturar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLblDolar;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox grbFacturacion;
        private System.Windows.Forms.TableLayoutPanel tlpProducto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtPrecio;
        private System.Windows.Forms.Button btnBuscarVehiculo;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.Label lblVIN;
        private System.Windows.Forms.TextBox txtDescripcionVehiculo;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.TableLayoutPanel tlpAgrupamiento;
        private System.Windows.Forms.Label lblCliente;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNumeroTarjeta;
        private System.Windows.Forms.TextBox txtClienteId;
        private System.Windows.Forms.RadioButton rdbTransferencia;
        private System.Windows.Forms.ComboBox cmbTarjeta;
        private System.Windows.Forms.Button btnBuscarCliente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtNumeroFactura;
        private System.Windows.Forms.TextBox txtNombreCliente;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RadioButton rdbCredito;
        private System.Windows.Forms.GroupBox grbDetalle;
        private System.Windows.Forms.TableLayoutPanel tlbPanelTotalPagar;
        private System.Windows.Forms.TextBox txtDolares;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSubtotal;
        private System.Windows.Forms.TextBox txtImpuesto;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DataGridView dgvDetalleFactura;
        private System.Windows.Forms.Label lblMarca;
        private System.Windows.Forms.TextBox txtMarca;
        private System.Windows.Forms.Panel pnlFirma;
        private System.Windows.Forms.Button btnLimpiarFirma;
        private System.Windows.Forms.PictureBox picFirma;
        private System.Windows.Forms.ErrorProvider erpError;
        private System.Windows.Forms.TextBox txtVIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn No;
        private System.Windows.Forms.DataGridViewTextBoxColumn VIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Marca;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripciónVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Impuesto;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
    }
}