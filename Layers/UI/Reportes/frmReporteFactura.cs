using log4net;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.Entities.DTO;

namespace UTN.WinForms.ApCars.Layers.UI.Filtros
{
    public partial class frmReporteFactura : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmReporteFactura()
        {
            InitializeComponent();
        }

        private async void btnReporte_Click(object sender, EventArgs e)
        {
            CultureInfo dolar = new CultureInfo("en-US");
            CultureInfo colon = new CultureInfo("es-CR");
            IBLLFactura bLLFactura = new BLLFactura();

            DateTime fechaInicial;
            DateTime fechaFinal;
            IEnumerable<VentasDTO> lista = new List<VentasDTO>();
            try
            {
                fechaInicial = dtpFechaInicial.Value;
                fechaFinal = dtpFechaFinal.Value;


                lista = await bLLFactura.GetTotalVentasXFecha(fechaInicial, fechaFinal);

                // Retorno elementos?
                if (!lista.Any())
                {
                    MessageBox.Show("No existe Facturas con esa información", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dtpFechaFinal.Focus();
                    return;
                }



                lista = lista.OrderBy(x => x.Dia).ToList();




                // Logo
                Bitmap logoBitmap = new Bitmap(Properties.Resources.smalllogo, 200, 200);
                byte[] logoBytes;
                MemoryStream memory = new MemoryStream();
                logoBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
                logoBytes = memory.ToArray();



                // Obligatorio la licencia Community
                QuestPDF.Settings.License = LicenseType.Community;

                var pdfFileBytes = Document.Create(document =>
                {
                    document.Page(page =>
                    {

                        page.Size(PageSizes.Letter);
                        page.Margin(2, QuestPDF.Infrastructure.Unit.Centimetre);
                        page.PageColor(Colors.White);
                        page.Margin(30);

                        // Encabezado de página
                        page.Header().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().AlignLeft().Text("Apcars").Bold().FontSize(50).Bold().FontColor("#34495e");
                                row.ConstantItem(100).AlignRight().Height(100).Image(logoBytes);
                                col.Item().AlignLeft().Text($"Fecha: {DateTime.Now} ").FontSize(9);
                                col.Item().LineHorizontal(1f);

                            });

                        });

                        // Página
                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            // Titulo del reporte
                            col1.Item().AlignCenter().Text("Reporte de Facturas").FontSize(14).Bold();
                            col1.Item().Text("");
                            col1.Item().LineHorizontal(0.5f);

                            col1.Item().Table(tabla =>
                            {
                                tabla.ColumnsDefinition(columns =>
                                {
                                    // Define cuantas columnas 
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);

                                });

                                // Define encabezado
                                tabla.Header(header =>
                                {
                                    header.Cell().Background("#34495e")
                                    .Padding(2).AlignCenter().Text("Día").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                    .Padding(2).AlignCenter().Text("Colones").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                   .Padding(2).AlignCenter().Text("Dolares").FontColor("#fff");


                                });


                                // recorrer la lista
                                foreach (var item in lista)
                                {

                                    // Column 1 
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(item.Dia.ToString()).FontSize(10);

                                    // Column 2
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(item.TotalVentaColones.ToString("C0",colon));

                                    // Column 3
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(item.TotalVentaDolares.ToString("C2", dolar));


                                }
                            });


                           
                        });

                        // Pie de página
                        page.Footer()
                        .AlignRight()
                        .Text(txt =>
                        {
                            txt.Span("Página ").FontSize(10);
                            txt.CurrentPageNumber().FontSize(10);
                            txt.Span(" de ").FontSize(10);
                            txt.TotalPages().FontSize(10);
                        });
                    });
                }).GeneratePdf();

                // Salvarlo en disco
                string file = @"c:\temp\rptFacturas.pdf";
                File.WriteAllBytes(file, pdfFileBytes);



                Process.Start(file);




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
    }
}
