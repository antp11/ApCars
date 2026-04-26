using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities.DTO;

namespace UTN.WinForms.ApCars.Layers.UI.Reportes
{
    public partial class frmGraficoVentas : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");

        public frmGraficoVentas()
        {
            InitializeComponent();
        }
        private void FormatearEtiquetas(Chart chart)
        {
            var cultureCR = new System.Globalization.CultureInfo("es-CR");
            var cultureUS = new System.Globalization.CultureInfo("en-US");

            if (chart.Series.IndexOf("Colones") >= 0)
            {
                foreach (var pt in chart.Series["Colones"].Points)
                {
                    pt.Label = pt.YValues[0].ToString("C2", cultureCR);
                }
            }

            if (chart.Series.IndexOf("Dolares") >= 0)
            {
                foreach (var pt in chart.Series["Dolares"].Points)
                {
                    pt.Label = pt.YValues[0].ToString("C2", cultureUS);
                }
            }
        }


        private async void btnGrafico_Click(object sender, EventArgs e)
        {
            IBLLFactura bllFactura = new BLLFactura();


            try
            {


                IEnumerable<VentasDTO> lista = await bllFactura.GetTotalVentasXFecha(dtpFechaInicial.Value, dtpFechaFinal.Value);


                // Se asigna la lista al DataSource del Chart
                chartVentas.DataSource = lista;
                //Limpia el Grafico para que cuando se elija otro tipo de moneda no se duplique 
                chartVentas.Series.Clear();
                chartVentas.ChartAreas[0].AxisY.LabelStyle.Format = "N0";

             
                    if (rdbColones.Checked)
                {

                    chartVentas.Series.Add("Colones");
                    chartVentas.Series["Colones"].XValueMember = "Dia";
                    chartVentas.Series["Colones"].YValueMembers = "TotalVentaColones";
      


                    //Mostrar Labels
                    chartVentas.Series["Colones"].IsValueShownAsLabel = true;
                    //color de barra, lineas etc
                    chartVentas.Series["Colones"].Color = Color.FromArgb(230, 35, 70, 94);
                    chartVentas.Series["Colones"]["PointWidth"] = "0.6"; // ancho de la barra
                    chartVentas.Series["Colones"]["DrawingStyle"] = "Cylinder"; // efecto cilíndrico


                    // Se escoge el tipo de Gráfico 
                    if (cmbTipoGrafico.SelectedIndex == 0)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Column;

                    if (cmbTipoGrafico.SelectedIndex == 1)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Line;
                    if (cmbTipoGrafico.SelectedIndex == 2)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Bar;
                    if (cmbTipoGrafico.SelectedIndex == 3)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Pie;
                    if (cmbTipoGrafico.SelectedIndex == 4)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Doughnut;
                    if (cmbTipoGrafico.SelectedIndex == 5)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Area;
                    if (cmbTipoGrafico.SelectedIndex == 6)
                        chartVentas.Series["Colones"].ChartType = SeriesChartType.Spline;
                }


                if (rdbDolaraes.Checked)
                {

                    chartVentas.Series.Add("Dolares");
                    chartVentas.Series["Dolares"].XValueMember = "Dia";
                    chartVentas.Series["Dolares"].YValueMembers = "TotalVentaDolares";
           


                    //Mostrar Labels
                    chartVentas.Series["Dolares"].IsValueShownAsLabel = true;
                    //color de barra, lineas etc
                    chartVentas.Series["Dolares"].Color = Color.FromArgb(230, 35, 70, 94);
                    chartVentas.Series["Dolares"]["PointWidth"] = "0.6"; // ancho de la barra
                    chartVentas.Series["Dolares"]["DrawingStyle"] = "Cylinder"; // efecto cilíndrico

                    // Se escoge el tipo de Gráfico
                    if (cmbTipoGrafico.SelectedIndex == 0)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Column;

                    if (cmbTipoGrafico.SelectedIndex == 1)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Line;
                    if (cmbTipoGrafico.SelectedIndex == 2)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Bar;
                    if (cmbTipoGrafico.SelectedIndex == 3)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Pie;
                    if (cmbTipoGrafico.SelectedIndex == 4)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Doughnut;
                    if (cmbTipoGrafico.SelectedIndex == 5)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Area;
                    if (cmbTipoGrafico.SelectedIndex == 6)
                        chartVentas.Series["Dolares"].ChartType = SeriesChartType.Spline;

                }
                // Colocar el Titulo
                chartVentas.Titles.Clear();
                chartVentas.Titles.Add("Total Ventas");
                chartVentas.Titles[0].Font = new Font("Segoe UI", 15F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));



                //Formatea las etiquetas para el tipo de moneda
                this.FormatearEtiquetas(chartVentas);
            }

            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click_1(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();

            dialog.Title = "Seleccione el Directorio";
            dialog.FileName = "GraficoVentas.png";
            DialogResult result = dialog.ShowDialog();

            if (result == DialogResult.OK)
            {
                chartVentas.SaveImage(dialog.FileName, ChartImageFormat.Png);
            }
        }

        private void btnSalir_Click_1(object sender, EventArgs e)
        {
            Close();
        }

        private void frmGraficoVentas_Load(object sender, EventArgs e)
        {
            this.cmbTipoGrafico.Items.Add("Column");
            this.cmbTipoGrafico.Items.Add("Line");
            this.cmbTipoGrafico.Items.Add("Bar");
            this.cmbTipoGrafico.Items.Add("Pie");
            this.cmbTipoGrafico.Items.Add("Doughnut");
            this.cmbTipoGrafico.Items.Add("Area");
            this.cmbTipoGrafico.Items.Add("Spline");
            this.cmbTipoGrafico.SelectedIndex = 0;
        }

        private void chartVentas_PostPaint(object sender, ChartPaintEventArgs e)
        {
            var chart = sender as Chart;
            var cultureCR = new System.Globalization.CultureInfo("es-CR");
            var cultureUS = new System.Globalization.CultureInfo("en-US");

            if (chart.Series.IndexOf("Colones") >= 0)
            {
                foreach (var pt in chart.Series["Colones"].Points)
                {
                    pt.Label = pt.YValues[0].ToString("C2", cultureCR);
                }
            }

            if (chart.Series.IndexOf("Dolares") >= 0)
            {
                foreach (var pt in chart.Series["Dolares"].Points)
                {
                    pt.Label = pt.YValues[0].ToString("C2", cultureUS);
                }
            }
        }
    }
}

