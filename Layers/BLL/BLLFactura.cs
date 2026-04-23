using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class BLLFactura : IBLLFactura
    {
        private static readonly ILog _myLogControlEventos = log4net.LogManager.GetLogger("MyControlEventos");
        public double CalculateTax(double precio)
        {
            IBLLImpuesto bllImpuesto = new BLLImpuesto();
            double porcentaje = bllImpuesto.GetImpuesto().Porcentaje;
            return precio * (porcentaje / 100d);
        }

        public string GenerarXML(FacturaEncabezado facturaEncabezado, List<FacturaDetalle> detalles)
        {
            try
            {
                if (facturaEncabezado == null)
                    throw new ApplicationException("Factura inválida para generar XML.");

                if (detalles == null || !detalles.Any())
                    throw new ApplicationException("No se proporcionaron detalles para generar XML.");

                XmlDocument xmlDoc = new XmlDocument();
                XmlElement raiz = xmlDoc.CreateElement("Factura");
                xmlDoc.AppendChild(raiz);

                XmlElement nEncabezado = xmlDoc.CreateElement("Encabezado");
                raiz.AppendChild(nEncabezado);

                nEncabezado.AppendChild(xmlDoc.CreateElement("NumeroFactura")).InnerText = facturaEncabezado.IdFactura.ToString();
                nEncabezado.AppendChild(xmlDoc.CreateElement("TipoTarjeta")).InnerText = facturaEncabezado.IdTarjeta.ToString();
                nEncabezado.AppendChild(xmlDoc.CreateElement("NumeroReferencia")).InnerText = facturaEncabezado.NoReferencia;
                nEncabezado.AppendChild(xmlDoc.CreateElement("FechaFactura")).InnerText = facturaEncabezado.Fecha.ToString("yyyy-MM-ddTHH:mm:ss");
                nEncabezado.AppendChild(xmlDoc.CreateElement("IdCliente")).InnerText = facturaEncabezado.IdCliente;
                nEncabezado.AppendChild(xmlDoc.CreateElement("IdAgente")).InnerText = facturaEncabezado.IdUsuario;
                nEncabezado.AppendChild(xmlDoc.CreateElement("TipoPago")).InnerText = facturaEncabezado.TipoPago;



                XmlElement nDetalle = xmlDoc.CreateElement("Detalle");
                raiz.AppendChild(nDetalle);

                foreach (var d in detalles)
                {
                    XmlElement nLinea = xmlDoc.CreateElement("Linea");
                    nDetalle.AppendChild(nLinea);

                    nLinea.AppendChild(xmlDoc.CreateElement("NumeroFactura")).InnerText = d.IdFactura.ToString();
                    nLinea.AppendChild(xmlDoc.CreateElement("Consecutivo")).InnerText = d.Consecutivo.ToString();
                    nLinea.AppendChild(xmlDoc.CreateElement("VIN")).InnerText = d.IdVIN;
                    nLinea.AppendChild(xmlDoc.CreateElement("Marca")).InnerText = d.Marca;
                    nLinea.AppendChild(xmlDoc.CreateElement("DescripcionVehiculo")).InnerText = d.DescripcionVehiculo;
                    nLinea.AppendChild(xmlDoc.CreateElement("PrecioDolares")).InnerText = d.PrecioDolares.ToString("F2");
                    nLinea.AppendChild(xmlDoc.CreateElement("ImpuestoDolares")).InnerText = d.ImpuestoDolares.ToString("F2");
                    nLinea.AppendChild(xmlDoc.CreateElement("PrecioColones")).InnerText = d.PrecioColones.ToString("F2");
                    nLinea.AppendChild(xmlDoc.CreateElement("ImpuestoColones")).InnerText = d.ImpuestoColones.ToString("F2");
                }

                _myLogControlEventos.Info($"XML de factura generado correctamente. Número: {facturaEncabezado.IdFactura}");
                return xmlDoc.OuterXml;
            }
            catch (Exception ex)
            {
                _myLogControlEventos.Error("Error generando XML de factura.", ex);
                throw;
            }
        }

        public int GetCurrentNumeroFactura()
        {

            IDALFactura dalFactura = new DALFactura();
            return dalFactura.GetCurrentNumeroFactura();
        }

        public int GetNextNumeroFactura()
        {
            IDALFactura dalFactura = new DALFactura();
            return dalFactura.GetNextNumeroFactura();
        }

        public FacturaEncabezado Save(FacturaEncabezado pFactura)
        {
            IDALFactura dalFactura = new DALFactura();
            IBLLVehiculo bllVehiculo = new BLLVehiculo();

            // Vuelve a validar que exista en inventario
            foreach (FacturaDetalle oFacturaDetalle in pFactura._ListaFacturaDetalle)
            {
                bllVehiculo.AvabilityStock(oFacturaDetalle.IdVIN);
            }


            return dalFactura.Save(pFactura);
        }
    }
}
