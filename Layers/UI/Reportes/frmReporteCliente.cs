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
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;

namespace UTN.WinForms.ApCars.Layers.UI.Reportes
{
    public partial class frmReporteCliente : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public frmReporteCliente()
        {
            InitializeComponent();
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            IBLLCliente bllCliente = new BLLCliente();
            IBLLProvincia bLLProvincia = new BLLProvincia();
            string filtro = "";

            try
            {
                filtro = "%" + this.txtFiltro.Text + "%";

                var lista = bllCliente.GetByFilter(filtro);

                // Retorno elementos?
                if (!lista.Any())
                {
                    MessageBox.Show("No existe cliente con esa información", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtFiltro.Focus();
                    return;
                }


                // Ordenado
                if (rdbOrdenadoCedula.Checked)
                {
                    lista = lista.OrderBy(x => x.IdCliente).ToList();
                }
                else
                {
                    lista = lista.OrderBy(x => x.Nombre).ToList();
                }


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
                                col.Item().AlignLeft().Text("ApCars").Bold().FontSize(50).Bold().FontColor("#34495e");
                                row.ConstantItem(100).AlignRight().Height(100).Image(logoBytes);
                                col.Item().AlignLeft().Text($"Fecha: {DateTime.Now} ").FontSize(9);
                                col.Item().LineHorizontal(1f);

                            });

                        });

                        // Página
                        page.Content().PaddingVertical(10).Column(col1 =>
                        {
                            // Titulo del reporte
                            col1.Item().AlignCenter().Text("Reporte de Clientes").FontSize(14).Bold();
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
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                    columns.RelativeColumn(2);
                                });

                                // Define encabezado
                                tabla.Header(header =>
                                {
                                    header.Cell().Background("#34495e")
                                    .Padding(2).AlignCenter().Text("Identificación").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                    .Padding(2).AlignCenter().Text("Imagen").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                   .Padding(2).AlignCenter().Text("Nombre").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                   .Padding(2).AlignCenter().Text("Provincia").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                   .Padding(2).AlignCenter().Text("Dirección").FontColor("#fff");

                                    header.Cell().Background("#34495e")
                                   .Padding(2).AlignCenter().Text("Teléfono ").FontColor("#fff");
                                });


                                // recorrer la lista
                                foreach (var item in lista)
                                {

                                    // Column 1 
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).Text(item.IdCliente.ToString()).FontSize(10);

                                    // Column 2
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignLeft().Image(item.Foto);

                                    // Column 3
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignLeft().Text(item.ToString());

                                    // Column 4
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(bLLProvincia.GetById(item.IdProvincia).Descripcion).FontSize(10);

                                    // Column 5
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(item.Direccion.ToString());

                                    // Column 6
                                    tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                    .Padding(2).AlignCenter().Text(item.Telefono.ToString());

                                }
                            });


                            col1.Item().AlignLeft().Text("Cantidad de Clientes " + lista.Count().ToString()).FontSize(12).Bold();
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
                string file = @"c:\temp\rptCliente.pdf";
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

        private void lblFiltro_Click(object sender, EventArgs e)
        {

        }

        private void rdbOrdenadoCedula_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void rdbOrdenadoNombre_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void grbOrdenamiento_Enter(object sender, EventArgs e)
        {

        }

        private void sttBarraInferior_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void txtFiltro_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
