using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                _facturaEncabezado.IdFactura=Convert.ToInt32(this.txtNumeroFactura.Text);
                _facturaEncabezado.IdCliente = _cliente.IdCliente;
                _facturaEncabezado.IdUsuario= Settings.Default.IdUsuario;
                _facturaEncabezado.TipoPago = rdbCredito.Checked ? "Credito" : "Transferencia";
                _facturaEncabezado.NoReferencia=this.txtNumeroTarjeta.Text;
                _facturaEncabezado.Fecha = DateTime.Now;
                _facturaEncabezado.Estado = true;
                _facturaEncabezado.TipoCambio=Convert.ToDouble(this.toolStripStatusLblDolar.Text);

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
          //  IBLLDolar bllDolar = new BLLDolar();
            try
            {
                // Mostar Numero de factura
                this.txtNumeroFactura.Text = bllFactura.GetCurrentNumeroFactura().ToString();
              //  toolStripStatusLblDolar.Text = "Venta Dolar " + bllDolar.GetVentaDolar().ToString();
                // Cargar las Tarjetas
              //  LoadCreditCards();

            }
            catch (Exception er)
            {
                string msg = "";
                _myLogControlEventos.ErrorFormat("Error {0}", msg.ToExceptionDetail(er, MethodBase.GetCurrentMethod()));
                MessageBox.Show("Se ha producido el siguiente error: " + er.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}