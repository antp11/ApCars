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
using System.Net;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using UTN.WinForms.ApCars.Extensions;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.BLL;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;
using UTN.WinForms.ApCars.Layers.UI.Filtros;
using UTN.WinForms.ApCars.Properties;

namespace UTN.WinForms.ApCars.Layers.UI.Procesos
{
    public partial class frmFacturacion : Form
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        private Cliente _cliente = null;
        private Vehiculo _vehiculo = null;
        private FacturaEncabezado _facturaEncabezado = null;
        private double TipoCambio = 0;

        //variables para la fimrma.
        bool dibujando = false;
        Point puntoAnterior;
        Bitmap firmaBitmap;


        public frmFacturacion()
        {
            InitializeComponent();
        }

        private void btnBuscarCliente_Click(object sender, EventArgs e)
        {

            frmFiltroCliente ofrmFiltroCliente = new frmFiltroCliente();
            IBLLCliente bllCliente = new BLLCliente();
            try
            {
                erpError.Clear();

                this.txtNombreCliente.Text = "";

                if (!string.IsNullOrEmpty(this.txtClienteId.Text))
                {
                    _cliente = bllCliente.GetById(this.txtClienteId.Text);
                }
                else
                {
                    // Mostrar ventan de filtro
                    ofrmFiltroCliente.ShowDialog();
                    if (ofrmFiltroCliente.DialogResult == DialogResult.OK)
                    {
                        _cliente = ofrmFiltroCliente.Cliente;
                    }
                }

                if (_cliente == null)
                {
                    MessageBox.Show("No existe el Cliente", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                if (this.rdbCredito.Checked && string.IsNullOrEmpty(this.txtNumeroTarjeta.Text))
                {
                    txtNumeroTarjeta.Focus();
                    erpError.SetError(txtNumeroTarjeta, "El pago  por tarjeta debe indicar su número");
                    MessageBox.Show("El pago es por tarjeta debe indicar su número", "Atención", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }


                _facturaEncabezado = new FacturaEncabezado();

                _facturaEncabezado.IdTarjeta = (cmbTarjeta.SelectedItem as Tarjeta).IdTarjeta;
                _facturaEncabezado.IdFactura = Convert.ToInt32(this.txtNumeroFactura.Text);
                _facturaEncabezado.IdCliente = _cliente.IdCliente;
                _facturaEncabezado.IdUsuario = Settings.Default.Login;
                _facturaEncabezado.TipoPago = rdbCredito.Checked ? "Credito" : "Transferencia";
                _facturaEncabezado.NoReferencia = this.txtNumeroTarjeta.Text;
                _facturaEncabezado.Fecha = DateTime.Now;
                _facturaEncabezado.Estado = true;
                _facturaEncabezado.TipoCambio = TipoCambio;

                this.txtNombreCliente.Text = _cliente.ToString();
                this.txtClienteId.Text = _cliente.IdCliente;
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void frmFacturacion_Load(object sender, EventArgs e)
        {

            IBLLFactura bllFactura = new BLLFactura();
            IBLLDolar bllDolar = new BLLDolar();
            try
            {
                // Mostar Numero de factura
                this.txtNumeroFactura.Text = bllFactura.GetCurrentNumeroFactura().ToString();
                toolStripStatusLblDolar.Text = "Venta Dolar " + bllDolar.GetVentaDolar().ToString();
                TipoCambio = bllDolar.GetVentaDolar();

                // Cargar las Tarjetas
                LoadCreditCards();


                // Preparar la firma
                firmaBitmap = new Bitmap(picFirma.Width, picFirma.Height);
                picFirma.Image = firmaBitmap;

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void LoadCreditCards()
        {
            IBLLTarjeta bllTarjeta = new BLLTarjeta();
            foreach (var oTarjeta in bllTarjeta.GetAll())
            {
                this.cmbTarjeta.Items.Add(oTarjeta);
            }
            cmbTarjeta.SelectedIndex = 0;

        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            frmFiltroVehiculo oFrmFiltroVehiculo = new frmFiltroVehiculo();
            IBLLMarca bLLMarca = new BLLMarca();
            Marca oMarca = null;
            try
            {
                oFrmFiltroVehiculo.ShowDialog();

                if (oFrmFiltroVehiculo.DialogResult == DialogResult.OK)
                {
                    _vehiculo = oFrmFiltroVehiculo.Vehiculo;
                    txtDescripcionVehiculo.Text = _vehiculo.DescripcionVehiculo;
                    txtVIN.Text = _vehiculo.IdVIN;
                    oMarca = bLLMarca.GetById(_vehiculo.IdMarca);
                    txtMarca.Text = oMarca.ToString();
                    txtEstado.Text = _vehiculo.Estado;
                    txtPrecio.Text = _vehiculo.Precio.ToString();
                    ;

                }
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            IBLLImpuesto bllImpuesto = new BLLImpuesto();
            IBLLVehiculo bllVehiculo = new BLLVehiculo();
            FacturaDetalle oFacturaDetalle = new FacturaDetalle();
            IBLLFactura bllFactura = new BLLFactura();
            double dolares = 0d;
            try
            {
                erpError.Clear();

                if (_facturaEncabezado == null)
                {
                    MessageBox.Show("Debe agregar los datos del encabezado de la factura para continuar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Validar que el Producto ya no se haya agregado
                if (_facturaEncabezado._ListaFacturaDetalle.Count > 0)
                {
                    // Si ya se agrego no permitir agregarlo nuevamente
                    if (_facturaEncabezado._ListaFacturaDetalle.FindAll(p => p.IdVIN == (txtVIN.Text)).Count > 0)
                    {
                        MessageBox.Show("El producto ya fue agregado previamente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                // Valida que exista disponibilidad en el Inventario
                Vehiculo oVehiculo = bllVehiculo.AvabilityStock(this.txtVIN.Text);

                // Vuelve a mostrar Existencia.
                this.txtEstado.Text = oVehiculo.Estado;

                oFacturaDetalle.IdVIN = this.txtVIN.Text;
                oFacturaDetalle.DescripcionVehiculo = this.txtDescripcionVehiculo.Text;
                oFacturaDetalle.Marca = this.txtMarca.Text;

                // oFacturaDetalle.Cantidad = Convert.ToInt32(this.mskCantidad.Text);
                oFacturaDetalle.PrecioDolares = Convert.ToDouble(this.txtPrecio.Text);
                oFacturaDetalle.PrecioColones = Convert.ToDouble(this.txtPrecio.Text) * TipoCambio;


                oFacturaDetalle.IdFactura = _facturaEncabezado.IdFactura;
                // Calcular el Impuesto
                oFacturaDetalle.ImpuestoDolares = bllFactura.CalculateTax(oFacturaDetalle.PrecioDolares);
                oFacturaDetalle.ImpuestoColones = bllFactura.CalculateTax(oFacturaDetalle.PrecioDolares) * TipoCambio;


                // Enumerar la secuencia
                oFacturaDetalle.Consecutivo = (_facturaEncabezado._ListaFacturaDetalle.Count + 1).ToString();
                // Agregar
                _facturaEncabezado.AddDetalle(oFacturaDetalle);


                string[] lineaFactura = {oFacturaDetalle.Consecutivo.ToString(),
                                         this.txtVIN.Text,
                                         this.txtMarca.Text,
                                         this.txtDescripcionVehiculo.Text,
                                         oFacturaDetalle.ImpuestoColones.ToString("₡ ##,###.00"),
                                         oFacturaDetalle.PrecioColones.ToString("₡ ##,###.00"),
                                           };


                this.dgvDetalleFactura.Rows.Add(lineaFactura);

                this.txtSubtotal.Text = _facturaEncabezado.GetSubTotal().ToString("##,###.00");
                this.txtImpuesto.Text = _facturaEncabezado.GetImpuesto().ToString("##,###.00");
                this.txtTotal.Text = (_facturaEncabezado.GetSubTotal() + _facturaEncabezado.GetImpuesto()).ToString("##,###.00");
                dolares = Convert.ToDouble(this.txtTotal.Text) / TipoCambio;

                // Formato en dólares
                txtDolares.Text = dolares.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));


                this.txtDescripcionVehiculo.Text = "";
                this.txtEstado.Text = "";
                this.txtPrecio.Text = "";
                this.txtMarca.Text = "";
                this.txtVIN.Text = "";

                txtVIN.Focus();
            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void picFirma_MouseMove(object sender, MouseEventArgs e)
        {
            if (!dibujando) return;

            using (Graphics g = Graphics.FromImage(firmaBitmap))
            {
                g.DrawLine(Pens.Black, puntoAnterior, e.Location);
            }

            picFirma.Invalidate();
            puntoAnterior = e.Location;
        }

        private void picFirma_MouseDown(object sender, MouseEventArgs e)
        {
            dibujando = true;
            puntoAnterior = e.Location;
        }

        private void picFirma_MouseUp(object sender, MouseEventArgs e)
        {
            dibujando = false;
        }

        private void btnLimpiarFirma_Click(object sender, EventArgs e)
        {
            this.limpiarFirma();

        }

        private void limpiarFirma()
        {
            firmaBitmap = new Bitmap(picFirma.Width, picFirma.Height);
            picFirma.Image = firmaBitmap;
        }
        private byte[] ImagenToBytes(Bitmap bmp)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }
        }

        private void toolStripBtnFacturar_Click(object sender, EventArgs e)
        {
            IBLLFactura bllFactura = new BLLFactura();

            // Pasar la firma a byte[] (imagen del PictureBox)
            byte[] firmaBytes = ImagenToBytes(firmaBitmap);
            try
            {


                // Validar que exista firma
                if (picFirma.Image == null)
                {
                    MessageBox.Show("Debe firmar antes de facturar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (_cliente == null)
                {
                    MessageBox.Show("Debe Seleccionar un Cliente", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.txtClienteId.Focus();
                    return;
                }

                if (_facturaEncabezado == null)
                {
                    MessageBox.Show("No hay datos por facturar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                if (_facturaEncabezado._ListaFacturaDetalle.Count == 0)
                {
                    MessageBox.Show("No hay items en la factura ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Crear XML y guardar firma
                _facturaEncabezado.XML = bllFactura.GenerarXML(_facturaEncabezado, _facturaEncabezado._ListaFacturaDetalle);

                _facturaEncabezado.Firma = firmaBytes;
                toolStripBtnFacturar.Enabled = false;
                _facturaEncabezado = bllFactura.Save(_facturaEncabezado);


                // Crear Reporte en PDF
                CreateReportPDF(_facturaEncabezado);

                if (_facturaEncabezado == null)
                    MessageBox.Show("Error al crear factura!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                else
                    toolStripBtnNuevo_Click(null, null);



            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            finally
            {

                toolStripBtnFacturar.Enabled = true;
            }
        }

        private void toolStripBtnNuevo_Click(object sender, EventArgs e)
        {
            IBLLFactura bllFactura = new BLLFactura();

            try
            {

                _cliente = null;
                this.txtClienteId.Text = "";
                this.txtImpuesto.Text = "";
                this.txtNumeroTarjeta.Text = "";
                this.txtSubtotal.Text = "";
                this.txtTotal.Text = "";
                this.txtDolares.Text = "";
                this.txtPrecio.Text = "";
                txtMarca.Text = "";
                this.cmbTarjeta.SelectedIndex = 0;
                this.txtVIN.Text = "";
                this.txtNombreCliente.Text = "-";
                this.txtEstado.Text = "";
                this.txtDescripcionVehiculo.Text = "";
                this.rdbCredito_Click(null, null);
                this.txtNumeroTarjeta.Text = "";
                txtNumeroTarjeta.Focus();
                _facturaEncabezado = null;
                this.dgvDetalleFactura.Rows.Clear();

                this.limpiarFirma();

                // Mostar Numero de factura
                int numeroFactura = bllFactura.GetCurrentNumeroFactura();
                this.txtNumeroFactura.Text = numeroFactura.ToString();
            }
            catch (Exception er)
            {
                string msg = " ";


                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void rdbCredito_Click(object sender, EventArgs e)
        {
            this.txtNumeroTarjeta.Text = "";
            this.cmbTarjeta.Enabled = true;
            this.cmbTarjeta.SelectedItem = this.cmbTarjeta.Items[1];
            this.txtNumeroTarjeta.Enabled = true;
            this.txtNumeroTarjeta.Focus();
        }

        private void CreateReportPDF(FacturaEncabezado pFacturaEncabezado)
        {
            IBLLCliente bLLCliente = new BLLCliente();
            IBLLVehiculo bllVehiculo = new BLLVehiculo();


            double granTotal = 0d, subTotal = 0, impuestoTotal = 0d, total = 0d;

            // Crear imagen quickresponse
            System.Drawing.Image qrImage = QuickResponse.QuickResponseGenerador(pFacturaEncabezado.IdFactura.ToString(), 53);
            // Convert Image into bytes array 
            MemoryStream ms = new MemoryStream();
            qrImage.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
           

            // Logo
            Bitmap logoBitmap = new Bitmap(Properties.Resources.smalllogo, 200, 200);
            byte[] logoBytes;
            MemoryStream memory = new MemoryStream();
            logoBitmap.Save(memory, System.Drawing.Imaging.ImageFormat.Png);
            logoBytes = memory.ToArray();


            // Obligatorio la licencia Community
            QuestPDF.Settings.License = LicenseType.Community;

            var pdfBytesArray = Document.Create(document =>
            {
                document.Page(page =>
                {

                    page.Size(PageSizes.Letter);
                    page.Margin(2, Unit.Centimetre);
                    page.PageColor(Colors.White);
                    page.Margin(30);

                    // Encabezado de página
                    page.Header().Row(row =>
                    {
                        row.RelativeItem().Column(col =>
                        {

                            col.Item()
                               .AlignLeft()
                               .Text("ApCars")
                               .Bold()
                               .FontSize(50)
                               .FontColor("#34495e");

                            // Logo a la derecha
                            row.ConstantItem(100)
                               .AlignRight()
                               .Height(100)
                               .Image(logoBytes);


                            col.Item()
                               .AlignLeft()
                               .Text($"Fecha: {DateTime.Now:dd/MM/yyyy}")
                               .FontSize(9)
                               .FontColor("#6c757d");


                            col.Item()
                               .LineHorizontal(1f)
                               .LineColor("#dee2e6");



                        });
                    });
                    // Página
                    page.Content().PaddingVertical(10).Column(col1 =>
                    {
                        // Titulo del reporte
                        col1.Item().AlignLeft().Text($"Factura No {pFacturaEncabezado.IdFactura}").FontSize(14).Bold();
                        col1.Item().AlignLeft().Text($"Fecha: {pFacturaEncabezado.Fecha} ").FontSize(10);
                        col1.Item().AlignLeft().Text($"Cliente: {pFacturaEncabezado.IdCliente.Trim()} - {_cliente.Nombre.Trim()} {_cliente.Apellido1.Trim()} {_cliente.Apellido2.Trim()}").FontSize(10);
                        col1.Item().AlignLeft().Text($"No Tarjeta: {pFacturaEncabezado.NoReferencia}").FontSize(10);



                        col1.Item().LineHorizontal(0.5f);
                        col1.Item().Text("");

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
                                .Padding(2).AlignCenter().Text("Nº Linea").FontColor("#fff");

                                header.Cell().Background("#34495e")
                                .Padding(2).AlignCenter().Text("VIN").FontColor("#fff");

                                header.Cell().Background("#34495e")
                               .Padding(2).AlignCenter().Text("Marca").FontColor("#fff");

                                header.Cell().Background("#34495e")
                               .Padding(2).AlignCenter().Text("Descripcion Vehiculo").FontColor("#fff");

                                header.Cell().Background("#34495e")
                               .Padding(2).AlignCenter().Text("Impuesto").FontColor("#fff");

                                header.Cell().Background("#34495e")
                               .Padding(2).AlignCenter().Text("Precio").FontColor("#fff");
                            });


                            // recorrer la lista
                            foreach (var item in pFacturaEncabezado._ListaFacturaDetalle)
                            {
                                // Column 1 
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.Consecutivo.ToString()).FontSize(10);

                                // Column 2
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.IdVIN.ToString());

                                // Column 3                                        
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.Marca.ToString()).FontSize(10);

                                // Column 4                                        
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.DescripcionVehiculo.ToString()).FontSize(10);

                                // Column 5                                        
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.ImpuestoColones.ToString("##,###,###.00")).FontSize(10);

                                // Column 6                                        
                                tabla.Cell().BorderBottom(0.5f).BorderColor("#D9D9D9")
                                .Padding(2).AlignCenter().Text(item.PrecioColones.ToString("##,###,###.00")).FontSize(10);

                                total += item.PrecioColones + item.ImpuestoColones;

                                subTotal += item.PrecioColones;
                                granTotal += total;
                                impuestoTotal += item.ImpuestoColones;
                            }

                        });

                        col1.Item().AlignRight().Text("SubTotal " + subTotal.ToString("###,###.00")).FontSize(10).Bold();
                        col1.Item().AlignRight().Text("Impuesto " + impuestoTotal.ToString("###,###.00")).FontSize(10).Bold();
                        col1.Item().AlignRight().Text("Total " + granTotal.ToString("###,###.00")).FontSize(10).Bold();

                        // Bloque final con QR y Firma
                        col1.Item().PaddingTop(20).Column(col =>
                        {
                            // QR a la izq con tamaño fijo
                            col.Item().AlignLeft().Width(90).Height(90).Image(ms.ToArray());

                            // Espacio entre QR y firma
                            col.Item().PaddingTop(10);

                            // Firma a la izq con tamaño fijo
                            col.Item().AlignLeft().Width(120).Height(60).Image(pFacturaEncabezado.Firma.ToArray());



                            // Texto opcional debajo de la firma
                            col.Item().AlignLeft().Text("Firma").FontSize(10);
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



            // Salvado en disco
            File.WriteAllBytes(@"c:\temp\pdfFactura.pdf", pdfBytesArray);

            // Rutina para enviar correo

            SendEmailInvoice(_cliente.Correo, pFacturaEncabezado);

            Process.Start(@"c:\temp\pdfFactura.pdf");
        }

        private void SendEmailInvoice(string email, FacturaEncabezado factura)
        {
            
            String cuentaCorreoElectronico = "antpgs11@gmail.com";
            String contrasenaGeneradaXGmail = "biebdknewfzrrdsc";
            string correoDestinatario = email;  //;

            MailMessage mensaje = new MailMessage();
            mensaje.IsBodyHtml = true;
            mensaje.Subject = "Su factura Electronica ";
            mensaje.Body = "Adjunto su factura electronica ";
            mensaje.From = new MailAddress(cuentaCorreoElectronico);
            mensaje.To.Add(correoDestinatario); //Correo del destinatario
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(cuentaCorreoElectronico, contrasenaGeneradaXGmail);
            smtp.EnableSsl = true;
            // Adjuntar un archivo
            string xmlFactura = factura.XML;
            byte[] xmlByte = Encoding.UTF8.GetBytes(xmlFactura);
            MemoryStream memoryStream = new MemoryStream(xmlByte);
            mensaje.Attachments.Add(new Attachment(memoryStream, "Factura.xml", "application/xml"));
        
            Attachment attachment = new Attachment(@"c:\temp\pdfFactura.pdf");
            mensaje.Attachments.Add(attachment);

            smtp.Send(mensaje);


            MessageBox.Show("La factura ha sido enviada al correo", "Atención");

        }

        private void toolStripBtnSalir_Click(object sender, EventArgs e)
        {
            Close();
        }
    }

}