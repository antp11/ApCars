namespace UTN.WinForms.ApCars.Layers.UI.Reportes
{
    partial class frmReporteVehiculo
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
            this.txtFiltro = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnReporte = new System.Windows.Forms.Button();
            this.sttBarraInferior = new System.Windows.Forms.StatusStrip();
            this.rdbDescripcion = new System.Windows.Forms.RadioButton();
            this.rdbMarca = new System.Windows.Forms.RadioButton();
            this.rdbEstilo = new System.Windows.Forms.RadioButton();
            this.gpbTipoBusqueda = new System.Windows.Forms.GroupBox();
            this.gpbTipoBusqueda.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFiltro
            // 
            this.txtFiltro.Location = new System.Drawing.Point(179, 43);
            this.txtFiltro.Margin = new System.Windows.Forms.Padding(4);
            this.txtFiltro.Name = "txtFiltro";
            this.txtFiltro.Size = new System.Drawing.Size(339, 22);
            this.txtFiltro.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 47);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(107, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "Buscar Vehiculo ";
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(388, 94);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(132, 95);
            this.btnSalir.TabIndex = 7;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click);
            // 
            // btnReporte
            // 
            this.btnReporte.Location = new System.Drawing.Point(248, 94);
            this.btnReporte.Margin = new System.Windows.Forms.Padding(4);
            this.btnReporte.Name = "btnReporte";
            this.btnReporte.Size = new System.Drawing.Size(132, 95);
            this.btnReporte.TabIndex = 6;
            this.btnReporte.Text = "Reporte";
            this.btnReporte.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnReporte.UseVisualStyleBackColor = true;
            this.btnReporte.Click += new System.EventHandler(this.btnReporte_Click);
            // 
            // sttBarraInferior
            // 
            this.sttBarraInferior.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.sttBarraInferior.Location = new System.Drawing.Point(0, 340);
            this.sttBarraInferior.Name = "sttBarraInferior";
            this.sttBarraInferior.Padding = new System.Windows.Forms.Padding(1, 0, 19, 0);
            this.sttBarraInferior.Size = new System.Drawing.Size(786, 22);
            this.sttBarraInferior.TabIndex = 5;
            // 
            // rdbDescripcion
            // 
            this.rdbDescripcion.AutoSize = true;
            this.rdbDescripcion.Checked = true;
            this.rdbDescripcion.Location = new System.Drawing.Point(6, 23);
            this.rdbDescripcion.Name = "rdbDescripcion";
            this.rdbDescripcion.Size = new System.Drawing.Size(100, 20);
            this.rdbDescripcion.TabIndex = 9;
            this.rdbDescripcion.TabStop = true;
            this.rdbDescripcion.Text = "Descripción";
            this.rdbDescripcion.UseVisualStyleBackColor = true;
            // 
            // rdbMarca
            // 
            this.rdbMarca.AutoSize = true;
            this.rdbMarca.Location = new System.Drawing.Point(6, 49);
            this.rdbMarca.Name = "rdbMarca";
            this.rdbMarca.Size = new System.Drawing.Size(66, 20);
            this.rdbMarca.TabIndex = 10;
            this.rdbMarca.Text = "Marca";
            this.rdbMarca.UseVisualStyleBackColor = true;
            // 
            // rdbEstilo
            // 
            this.rdbEstilo.AutoSize = true;
            this.rdbEstilo.Location = new System.Drawing.Point(6, 75);
            this.rdbEstilo.Name = "rdbEstilo";
            this.rdbEstilo.Size = new System.Drawing.Size(61, 20);
            this.rdbEstilo.TabIndex = 11;
            this.rdbEstilo.Text = "Estilo";
            this.rdbEstilo.UseVisualStyleBackColor = true;
            // 
            // gpbTipoBusqueda
            // 
            this.gpbTipoBusqueda.Controls.Add(this.rdbMarca);
            this.gpbTipoBusqueda.Controls.Add(this.rdbDescripcion);
            this.gpbTipoBusqueda.Controls.Add(this.rdbEstilo);
            this.gpbTipoBusqueda.Location = new System.Drawing.Point(15, 94);
            this.gpbTipoBusqueda.Name = "gpbTipoBusqueda";
            this.gpbTipoBusqueda.Size = new System.Drawing.Size(202, 101);
            this.gpbTipoBusqueda.TabIndex = 12;
            this.gpbTipoBusqueda.TabStop = false;
            this.gpbTipoBusqueda.Text = "Tipo Busqueda";
            // 
            // frmReporteVehiculo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(786, 362);
            this.Controls.Add(this.gpbTipoBusqueda);
            this.Controls.Add(this.txtFiltro);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnReporte);
            this.Controls.Add(this.sttBarraInferior);
            this.Name = "frmReporteVehiculo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Vehiculo";
            this.gpbTipoBusqueda.ResumeLayout(false);
            this.gpbTipoBusqueda.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtFiltro;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnReporte;
        private System.Windows.Forms.StatusStrip sttBarraInferior;
        private System.Windows.Forms.RadioButton rdbDescripcion;
        private System.Windows.Forms.RadioButton rdbMarca;
        private System.Windows.Forms.RadioButton rdbEstilo;
        private System.Windows.Forms.GroupBox gpbTipoBusqueda;
    }
}