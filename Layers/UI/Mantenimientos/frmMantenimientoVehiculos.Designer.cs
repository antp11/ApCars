namespace UTN.WinForms.ApCars.Layers.UI
{
    partial class frmMantenimientoVehiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMantenimientoVehiculos));
            this.tspPrincipal = new System.Windows.Forms.ToolStrip();
            this.toolStripBtnNuevo = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnEditar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnBorrar = new System.Windows.Forms.ToolStripButton();
            this.toolStripBtnSalir = new System.Windows.Forms.ToolStripButton();
            this.sttInferior = new System.Windows.Forms.StatusStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mskAnno = new System.Windows.Forms.MaskedTextBox();
            this.txtExtras = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbTransmision = new System.Windows.Forms.ComboBox();
            this.lblTransmision = new System.Windows.Forms.Label();
            this.txtColor = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cmbCombustible = new System.Windows.Forms.ComboBox();
            this.lblTipoCombustible = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbEstilo = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.mskVIN = new System.Windows.Forms.MaskedTextBox();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.pbDocumentacion = new System.Windows.Forms.PictureBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.nudCantidadPasajeros = new System.Windows.Forms.NumericUpDown();
            this.mskPrecio = new System.Windows.Forms.MaskedTextBox();
            this.pbImagen = new System.Windows.Forms.PictureBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.epError = new System.Windows.Forms.ErrorProvider(this.components);
            this.IdVIN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdMarca = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IdEstilo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DescripcionVehiculo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Anno = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CantidadPaasajero = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoCombustible = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TipoTransmision = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Precio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Foto = new System.Windows.Forms.DataGridViewImageColumn();
            this.tspPrincipal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocumentacion)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadPasajeros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).BeginInit();
            this.SuspendLayout();
            // 
            // tspPrincipal
            // 
            this.tspPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.tspPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripBtnNuevo,
            this.toolStripBtnEditar,
            this.toolStripBtnBorrar,
            this.toolStripBtnSalir});
            this.tspPrincipal.Location = new System.Drawing.Point(0, 0);
            this.tspPrincipal.Name = "tspPrincipal";
            this.tspPrincipal.Size = new System.Drawing.Size(1626, 55);
            this.tspPrincipal.TabIndex = 3;
            // 
            // toolStripBtnNuevo
            // 
            this.toolStripBtnNuevo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.toolStripBtnNuevo.Image = global::UTN.WinForms.ApCars.Properties.Resources.nuevo;
            this.toolStripBtnNuevo.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnNuevo.Name = "toolStripBtnNuevo";
            this.toolStripBtnNuevo.Size = new System.Drawing.Size(96, 52);
            this.toolStripBtnNuevo.Text = "&Nuevo";
            this.toolStripBtnNuevo.Click += new System.EventHandler(this.toolStripBtnNuevo_Click);
            // 
            // toolStripBtnEditar
            // 
            this.toolStripBtnEditar.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_editar_48;
            this.toolStripBtnEditar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnEditar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnEditar.Name = "toolStripBtnEditar";
            this.toolStripBtnEditar.Size = new System.Drawing.Size(100, 52);
            this.toolStripBtnEditar.Text = "&Editar";
            this.toolStripBtnEditar.Click += new System.EventHandler(this.toolStripBtnEditar_Click);
            // 
            // toolStripBtnBorrar
            // 
            this.toolStripBtnBorrar.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_eliminar_48;
            this.toolStripBtnBorrar.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnBorrar.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnBorrar.Name = "toolStripBtnBorrar";
            this.toolStripBtnBorrar.Size = new System.Drawing.Size(102, 52);
            this.toolStripBtnBorrar.Text = "&Borrar";
            this.toolStripBtnBorrar.Click += new System.EventHandler(this.toolStripBtnBorrar_Click);
            // 
            // toolStripBtnSalir
            // 
            this.toolStripBtnSalir.Image = global::UTN.WinForms.ApCars.Properties.Resources.icons8_cerrar_ventana_48;
            this.toolStripBtnSalir.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.toolStripBtnSalir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripBtnSalir.Name = "toolStripBtnSalir";
            this.toolStripBtnSalir.Size = new System.Drawing.Size(90, 52);
            this.toolStripBtnSalir.Text = "&Salir";
            this.toolStripBtnSalir.Click += new System.EventHandler(this.toolStripBtnSalir_Click);
            // 
            // sttInferior
            // 
            this.sttInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttInferior.Location = new System.Drawing.Point(0, 818);
            this.sttInferior.Name = "sttInferior";
            this.sttInferior.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sttInferior.Size = new System.Drawing.Size(1626, 22);
            this.sttInferior.TabIndex = 4;
            this.sttInferior.Text = "statusStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 55);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvDatos);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer1.Size = new System.Drawing.Size(1626, 763);
            this.splitContainer1.SplitterDistance = 979;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 5;
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.IdVIN,
            this.IdMarca,
            this.IdEstilo,
            this.DescripcionVehiculo,
            this.Anno,
            this.CantidadPaasajero,
            this.TipoCombustible,
            this.TipoTransmision,
            this.Precio,
            this.Foto});
            this.dgvDatos.Location = new System.Drawing.Point(0, 3);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 51;
            this.dgvDatos.RowTemplate.Height = 24;
            this.dgvDatos.Size = new System.Drawing.Size(965, 763);
            this.dgvDatos.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.15678F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40.84322F));
            this.tableLayoutPanel1.Controls.Add(this.mskAnno, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtExtras, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.cmbTransmision, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.lblTransmision, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtColor, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.cmbCombustible, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.lblTipoCombustible, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.cmbEstilo, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.cmbMarca, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.mskVIN, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtDescripcion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 12);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnCancelar, 1, 14);
            this.tableLayoutPanel1.Controls.Add(this.pbDocumentacion, 1, 13);
            this.tableLayoutPanel1.Controls.Add(this.btnAceptar, 0, 14);
            this.tableLayoutPanel1.Controls.Add(this.nudCantidadPasajeros, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.mskPrecio, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.pbImagen, 1, 12);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 15);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 15;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(621, 691);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // mskAnno
            // 
            this.mskAnno.Location = new System.Drawing.Point(371, 128);
            this.mskAnno.Margin = new System.Windows.Forms.Padding(4);
            this.mskAnno.Name = "mskAnno";
            this.mskAnno.Size = new System.Drawing.Size(207, 22);
            this.mskAnno.TabIndex = 34;
            // 
            // txtExtras
            // 
            this.txtExtras.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.txtExtras.Location = new System.Drawing.Point(371, 310);
            this.txtExtras.Margin = new System.Windows.Forms.Padding(4);
            this.txtExtras.Name = "txtExtras";
            this.txtExtras.Size = new System.Drawing.Size(207, 22);
            this.txtExtras.TabIndex = 33;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 283);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(359, 16);
            this.label4.TabIndex = 32;
            this.label4.Text = "Precio";
            // 
            // cmbTransmision
            // 
            this.cmbTransmision.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTransmision.FormattingEnabled = true;
            this.cmbTransmision.Location = new System.Drawing.Point(371, 248);
            this.cmbTransmision.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTransmision.Name = "cmbTransmision";
            this.cmbTransmision.Size = new System.Drawing.Size(207, 24);
            this.cmbTransmision.TabIndex = 31;
            // 
            // lblTransmision
            // 
            this.lblTransmision.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTransmision.AutoSize = true;
            this.lblTransmision.Location = new System.Drawing.Point(4, 252);
            this.lblTransmision.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTransmision.Name = "lblTransmision";
            this.lblTransmision.Size = new System.Drawing.Size(359, 16);
            this.lblTransmision.TabIndex = 30;
            this.lblTransmision.Text = "Transmision";
            // 
            // txtColor
            // 
            this.txtColor.Location = new System.Drawing.Point(371, 218);
            this.txtColor.Margin = new System.Windows.Forms.Padding(4);
            this.txtColor.Name = "txtColor";
            this.txtColor.Size = new System.Drawing.Size(207, 22);
            this.txtColor.TabIndex = 29;
            // 
            // label11
            // 
            this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(4, 221);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(359, 16);
            this.label11.TabIndex = 28;
            this.label11.Text = "Color";
            // 
            // cmbCombustible
            // 
            this.cmbCombustible.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCombustible.FormattingEnabled = true;
            this.cmbCombustible.Location = new System.Drawing.Point(371, 186);
            this.cmbCombustible.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCombustible.Name = "cmbCombustible";
            this.cmbCombustible.Size = new System.Drawing.Size(207, 24);
            this.cmbCombustible.TabIndex = 27;
            // 
            // lblTipoCombustible
            // 
            this.lblTipoCombustible.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTipoCombustible.AutoSize = true;
            this.lblTipoCombustible.Location = new System.Drawing.Point(4, 190);
            this.lblTipoCombustible.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoCombustible.Name = "lblTipoCombustible";
            this.lblTipoCombustible.Size = new System.Drawing.Size(359, 16);
            this.lblTipoCombustible.TabIndex = 26;
            this.lblTipoCombustible.Text = "Tipo Combustible";
            // 
            // label12
            // 
            this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(4, 160);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(359, 16);
            this.label12.TabIndex = 23;
            this.label12.Text = "Cantidad Pasajeros";
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 131);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(359, 16);
            this.label8.TabIndex = 21;
            this.label8.Text = "Año";
            // 
            // cmbEstilo
            // 
            this.cmbEstilo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEstilo.FormattingEnabled = true;
            this.cmbEstilo.Location = new System.Drawing.Point(371, 66);
            this.cmbEstilo.Margin = new System.Windows.Forms.Padding(4);
            this.cmbEstilo.Name = "cmbEstilo";
            this.cmbEstilo.Size = new System.Drawing.Size(207, 24);
            this.cmbEstilo.TabIndex = 20;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(4, 70);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(359, 16);
            this.label10.TabIndex = 19;
            this.label10.Text = "Estilo";
            // 
            // cmbMarca
            // 
            this.cmbMarca.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(371, 34);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(4);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(207, 24);
            this.cmbMarca.TabIndex = 18;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(4, 38);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(359, 16);
            this.label9.TabIndex = 17;
            this.label9.Text = "Marca";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(359, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "VIN";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(359, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Descripción";
            // 
            // label3
            // 
            this.label3.AccessibleName = "Ext";
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 313);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(359, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Extras";
            // 
            // mskVIN
            // 
            this.mskVIN.Location = new System.Drawing.Point(371, 4);
            this.mskVIN.Margin = new System.Windows.Forms.Padding(4);
            this.mskVIN.Name = "mskVIN";
            this.mskVIN.Size = new System.Drawing.Size(207, 22);
            this.mskVIN.TabIndex = 1;
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Location = new System.Drawing.Point(371, 98);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(207, 22);
            this.txtDescripcion.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 385);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(359, 16);
            this.label5.TabIndex = 8;
            this.label5.Text = "Imagen";
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 494);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(359, 16);
            this.label6.TabIndex = 9;
            this.label6.Text = "Documentación";
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(371, 558);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(4);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(221, 105);
            this.btnCancelar.TabIndex = 6;
            this.btnCancelar.Text = "&Cancelar";
            this.btnCancelar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // pbDocumentacion
            // 
            this.pbDocumentacion.Image = ((System.Drawing.Image)(resources.GetObject("pbDocumentacion.Image")));
            this.pbDocumentacion.Location = new System.Drawing.Point(371, 454);
            this.pbDocumentacion.Margin = new System.Windows.Forms.Padding(4);
            this.pbDocumentacion.Name = "pbDocumentacion";
            this.pbDocumentacion.Size = new System.Drawing.Size(208, 96);
            this.pbDocumentacion.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbDocumentacion.TabIndex = 11;
            this.pbDocumentacion.TabStop = false;
            this.pbDocumentacion.Click += new System.EventHandler(this.pbDocumentacion_Click);
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(4, 558);
            this.btnAceptar.Margin = new System.Windows.Forms.Padding(4);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(246, 105);
            this.btnAceptar.TabIndex = 5;
            this.btnAceptar.Text = "&Aceptar";
            this.btnAceptar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // nudCantidadPasajeros
            // 
            this.nudCantidadPasajeros.Location = new System.Drawing.Point(370, 157);
            this.nudCantidadPasajeros.Name = "nudCantidadPasajeros";
            this.nudCantidadPasajeros.Size = new System.Drawing.Size(209, 22);
            this.nudCantidadPasajeros.TabIndex = 25;
            // 
            // mskPrecio
            // 
            this.mskPrecio.Location = new System.Drawing.Point(371, 280);
            this.mskPrecio.Margin = new System.Windows.Forms.Padding(4);
            this.mskPrecio.Name = "mskPrecio";
            this.mskPrecio.Size = new System.Drawing.Size(207, 22);
            this.mskPrecio.TabIndex = 3;
            // 
            // pbImagen
            // 
            this.pbImagen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pbImagen.Image = global::UTN.WinForms.ApCars.Properties.Resources.insert_image;
            this.pbImagen.InitialImage = null;
            this.pbImagen.Location = new System.Drawing.Point(371, 340);
            this.pbImagen.Margin = new System.Windows.Forms.Padding(4);
            this.pbImagen.Name = "pbImagen";
            this.pbImagen.Size = new System.Drawing.Size(208, 106);
            this.pbImagen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pbImagen.TabIndex = 10;
            this.pbImagen.TabStop = false;
            this.pbImagen.Click += new System.EventHandler(this.pbImagen_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "buscar vehiculo.png");
            // 
            // epError
            // 
            this.epError.ContainerControl = this;
            // 
            // IdVIN
            // 
            this.IdVIN.DataPropertyName = "IdVIN";
            this.IdVIN.HeaderText = "VIN";
            this.IdVIN.MinimumWidth = 6;
            this.IdVIN.Name = "IdVIN";
            this.IdVIN.ReadOnly = true;
            this.IdVIN.Width = 125;
            // 
            // IdMarca
            // 
            this.IdMarca.DataPropertyName = "IdMarca";
            this.IdMarca.HeaderText = "Marca";
            this.IdMarca.MinimumWidth = 6;
            this.IdMarca.Name = "IdMarca";
            this.IdMarca.ReadOnly = true;
            this.IdMarca.Width = 125;
            // 
            // IdEstilo
            // 
            this.IdEstilo.DataPropertyName = "IdEstilo";
            this.IdEstilo.HeaderText = "Estilo";
            this.IdEstilo.MinimumWidth = 6;
            this.IdEstilo.Name = "IdEstilo";
            this.IdEstilo.ReadOnly = true;
            this.IdEstilo.Width = 125;
            // 
            // DescripcionVehiculo
            // 
            this.DescripcionVehiculo.DataPropertyName = "DescripcionVehiculo";
            this.DescripcionVehiculo.HeaderText = "Modelo";
            this.DescripcionVehiculo.MinimumWidth = 6;
            this.DescripcionVehiculo.Name = "DescripcionVehiculo";
            this.DescripcionVehiculo.ReadOnly = true;
            this.DescripcionVehiculo.Width = 125;
            // 
            // Anno
            // 
            this.Anno.DataPropertyName = "Anno";
            this.Anno.HeaderText = "Año";
            this.Anno.MinimumWidth = 6;
            this.Anno.Name = "Anno";
            this.Anno.ReadOnly = true;
            this.Anno.Width = 125;
            // 
            // CantidadPaasajero
            // 
            this.CantidadPaasajero.DataPropertyName = "CantidadPaasajero";
            this.CantidadPaasajero.HeaderText = "Cantidad Pasajero ";
            this.CantidadPaasajero.MinimumWidth = 6;
            this.CantidadPaasajero.Name = "CantidadPaasajero";
            this.CantidadPaasajero.ReadOnly = true;
            this.CantidadPaasajero.Width = 125;
            // 
            // TipoCombustible
            // 
            this.TipoCombustible.DataPropertyName = "TipoCombustible";
            this.TipoCombustible.HeaderText = "Combustible ";
            this.TipoCombustible.MinimumWidth = 6;
            this.TipoCombustible.Name = "TipoCombustible";
            this.TipoCombustible.ReadOnly = true;
            this.TipoCombustible.Width = 125;
            // 
            // TipoTransmision
            // 
            this.TipoTransmision.DataPropertyName = "TipoTransmision";
            this.TipoTransmision.HeaderText = "Transmision ";
            this.TipoTransmision.MinimumWidth = 6;
            this.TipoTransmision.Name = "TipoTransmision";
            this.TipoTransmision.ReadOnly = true;
            this.TipoTransmision.Width = 125;
            // 
            // Precio
            // 
            this.Precio.DataPropertyName = "Precio";
            this.Precio.HeaderText = "Precio";
            this.Precio.MinimumWidth = 6;
            this.Precio.Name = "Precio";
            this.Precio.ReadOnly = true;
            this.Precio.Width = 125;
            // 
            // Foto
            // 
            this.Foto.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Foto.DataPropertyName = "Foto";
            this.Foto.HeaderText = "Foto";
            this.Foto.MinimumWidth = 6;
            this.Foto.Name = "Foto";
            this.Foto.ReadOnly = true;
            // 
            // frmMantenimientoVehiculos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1626, 840);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.sttInferior);
            this.Controls.Add(this.tspPrincipal);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmMantenimientoVehiculos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vehiculos";
            this.Load += new System.EventHandler(this.frmMantenimientoVehiculos_Load);
            this.tspPrincipal.ResumeLayout(false);
            this.tspPrincipal.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbDocumentacion)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nudCantidadPasajeros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbImagen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.epError)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspPrincipal;
        private System.Windows.Forms.ToolStripButton toolStripBtnNuevo;
        private System.Windows.Forms.ToolStripButton toolStripBtnEditar;
        private System.Windows.Forms.ToolStripButton toolStripBtnBorrar;
        private System.Windows.Forms.ToolStripButton toolStripBtnSalir;
        private System.Windows.Forms.StatusStrip sttInferior;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox mskVIN;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.ComboBox cmbEstilo;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown nudCantidadPasajeros;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.ComboBox cmbCombustible;
        private System.Windows.Forms.Label lblTipoCombustible;
        private System.Windows.Forms.ComboBox cmbTransmision;
        private System.Windows.Forms.Label lblTransmision;
        private System.Windows.Forms.TextBox txtColor;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pbImagen;
        private System.Windows.Forms.TextBox txtExtras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.PictureBox pbDocumentacion;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.MaskedTextBox mskPrecio;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ErrorProvider epError;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.MaskedTextBox mskAnno;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdVIN;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdMarca;
        private System.Windows.Forms.DataGridViewTextBoxColumn IdEstilo;
        private System.Windows.Forms.DataGridViewTextBoxColumn DescripcionVehiculo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Anno;
        private System.Windows.Forms.DataGridViewTextBoxColumn CantidadPaasajero;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoCombustible;
        private System.Windows.Forms.DataGridViewTextBoxColumn TipoTransmision;
        private System.Windows.Forms.DataGridViewTextBoxColumn Precio;
        private System.Windows.Forms.DataGridViewImageColumn Foto;
    }
}