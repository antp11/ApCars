using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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

                _facturaEncabezado.IdTarjeta = Convert.ToInt32(this.cmbTarjeta.Text);
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
            cmbTarjeta.ValueMember = "IdTarjeta";
        }

        private void btnBuscarVehiculo_Click(object sender, EventArgs e)
        {
            frmFiltroVehiculo oFrmFiltroVehiculo = new frmFiltroVehiculo();
            IBLLMarca bLLMarca = new BLLMarca();
            Vehiculo oVehiculo = null;
            Marca oMarca = null;
            try
            {
                oFrmFiltroVehiculo.ShowDialog();

                if (oFrmFiltroVehiculo.DialogResult == DialogResult.OK)
                {
                    oVehiculo = oFrmFiltroVehiculo.Vehiculo;
                    txtDescripcionVehiculo.Text = oVehiculo.DescripcionVehiculo;
                    txtVIN.Text = oVehiculo.IdVIN;
                    oMarca = bLLMarca.GetById(oVehiculo.IdMarca);
                    txtMarca.Text = oMarca.ToString();
                    txtExistencia.Text = oVehiculo.Estado;
                    txtPrecio.Text = oVehiculo.Precio.ToString();
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
                this.txtExistencia.Text = oVehiculo.Estado;


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


                // Formato en dólares
                txtDolares.Text = dolares.ToString("C", CultureInfo.CreateSpecificCulture("en-US"));


                this.txtDescripcionVehiculo.Text = "";
                this.txtExistencia.Text = "";
                this.txtPrecio.Text = "";


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
                _facturaEncabezado.XML= bllFactura.GenerarXML(
                    _facturaEncabezado,
                    _facturaEncabezado._ListaFacturaDetalle);

                _facturaEncabezado.Firma = firmaBytes;

                toolStripBtnFacturar.Enabled = false;
                _facturaEncabezado = bllFactura.Save(_facturaEncabezado);


                // Crear Reporte en PDF
                // CreateReportPDF(_facturaEncabezado);

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
                this.txtPrecio.Text = "";
                this.cmbTarjeta.SelectedIndex = 0;
                this.txtVIN.Text = "";
                this.txtNombreCliente.Text = "-";
                this.txtExistencia.Text = "";
                this.txtDescripcionVehiculo.Text = "";
                this.rdbCredito_Click(null, null);
                this.txtNumeroTarjeta.Text = "";
                txtNumeroTarjeta.Focus();
                _facturaEncabezado = null;
                this.dgvDetalleFactura.Rows.Clear();
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
    }
}