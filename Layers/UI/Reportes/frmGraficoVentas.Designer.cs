namespace UTN.WinForms.ApCars.Layers.UI.Reportes
{
    partial class frmGraficoVentas
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend4 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpFechaFinal = new System.Windows.Forms.DateTimePicker();
            this.dtpFechaInicial = new System.Windows.Forms.DateTimePicker();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.lblTipoGrafico = new System.Windows.Forms.Label();
            this.cmbTipoGrafico = new System.Windows.Forms.ComboBox();
            this.btnSalir = new System.Windows.Forms.Button();
            this.btnGrafico = new System.Windows.Forms.Button();
            this.chartVentas = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 636);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "Fecha Final";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 599);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 16);
            this.label1.TabIndex = 19;
            this.label1.Text = "Fecha Inicial";
            // 
            // dtpFechaFinal
            // 
            this.dtpFechaFinal.Location = new System.Drawing.Point(116, 635);
            this.dtpFechaFinal.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaFinal.Name = "dtpFechaFinal";
            this.dtpFechaFinal.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaFinal.TabIndex = 18;
            this.dtpFechaFinal.Value = new System.DateTime(2035, 6, 23, 11, 31, 0, 0);
            // 
            // dtpFechaInicial
            // 
            this.dtpFechaInicial.Location = new System.Drawing.Point(116, 595);
            this.dtpFechaInicial.Margin = new System.Windows.Forms.Padding(4);
            this.dtpFechaInicial.Name = "dtpFechaInicial";
            this.dtpFechaInicial.Size = new System.Drawing.Size(265, 22);
            this.dtpFechaInicial.TabIndex = 17;
            this.dtpFechaInicial.Value = new System.DateTime(2000, 6, 23, 11, 31, 0, 0);
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(792, 572);
            this.btnSalvar.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(128, 85);
            this.btnSalvar.TabIndex = 16;
            this.btnSalvar.Text = "Exportar";
            this.btnSalvar.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click_1);
            // 
            // lblTipoGrafico
            // 
            this.lblTipoGrafico.AutoSize = true;
            this.lblTipoGrafico.Location = new System.Drawing.Point(-141, 204);
            this.lblTipoGrafico.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTipoGrafico.Name = "lblTipoGrafico";
            this.lblTipoGrafico.Size = new System.Drawing.Size(81, 16);
            this.lblTipoGrafico.TabIndex = 15;
            this.lblTipoGrafico.Text = "Tipo Grafico";
            // 
            // cmbTipoGrafico
            // 
            this.cmbTipoGrafico.FormattingEnabled = true;
            this.cmbTipoGrafico.Location = new System.Drawing.Point(133, 13);
            this.cmbTipoGrafico.Margin = new System.Windows.Forms.Padding(4);
            this.cmbTipoGrafico.Name = "cmbTipoGrafico";
            this.cmbTipoGrafico.Size = new System.Drawing.Size(188, 24);
            this.cmbTipoGrafico.TabIndex = 14;
            // 
            // btnSalir
            // 
            this.btnSalir.Location = new System.Drawing.Point(928, 572);
            this.btnSalir.Margin = new System.Windows.Forms.Padding(4);
            this.btnSalir.Name = "btnSalir";
            this.btnSalir.Size = new System.Drawing.Size(128, 85);
            this.btnSalir.TabIndex = 13;
            this.btnSalir.Text = "Salir";
            this.btnSalir.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnSalir.UseVisualStyleBackColor = true;
            this.btnSalir.Click += new System.EventHandler(this.btnSalir_Click_1);
            // 
            // btnGrafico
            // 
            this.btnGrafico.Location = new System.Drawing.Point(656, 572);
            this.btnGrafico.Margin = new System.Windows.Forms.Padding(4);
            this.btnGrafico.Name = "btnGrafico";
            this.btnGrafico.Size = new System.Drawing.Size(128, 85);
            this.btnGrafico.TabIndex = 12;
            this.btnGrafico.Text = "Grafico";
            this.btnGrafico.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btnGrafico.UseVisualStyleBackColor = true;
            this.btnGrafico.Click += new System.EventHandler(this.btnGrafico_Click);
            // 
            // chartVentas
            // 
            chartArea4.Name = "ChartArea1";
            this.chartVentas.ChartAreas.Add(chartArea4);
            legend4.Name = "Legend1";
            this.chartVentas.Legends.Add(legend4);
            this.chartVentas.Location = new System.Drawing.Point(27, 44);
            this.chartVentas.Name = "chartVentas";
            series4.ChartArea = "ChartArea1";
            series4.Legend = "Legend1";
            series4.Name = "Series1";
            this.chartVentas.Series.Add(series4);
            this.chartVentas.Size = new System.Drawing.Size(1061, 461);
            this.chartVentas.TabIndex = 21;
            this.chartVentas.Text = "chart1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(35, 16);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(81, 16);
            this.label3.TabIndex = 22;
            this.label3.Text = "Tipo Grafico";
            // 
            // frmGraficoVentas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1119, 704);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.chartVentas);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dtpFechaFinal);
            this.Controls.Add(this.dtpFechaInicial);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.lblTipoGrafico);
            this.Controls.Add(this.cmbTipoGrafico);
            this.Controls.Add(this.btnSalir);
            this.Controls.Add(this.btnGrafico);
            this.Name = "frmGraficoVentas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Grafico Ventas";
            this.Load += new System.EventHandler(this.frmGraficoVentas_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartVentas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpFechaFinal;
        private System.Windows.Forms.DateTimePicker dtpFechaInicial;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Label lblTipoGrafico;
        private System.Windows.Forms.ComboBox cmbTipoGrafico;
        private System.Windows.Forms.Button btnSalir;
        private System.Windows.Forms.Button btnGrafico;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartVentas;
        private System.Windows.Forms.Label label3;
    }
}