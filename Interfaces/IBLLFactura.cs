using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    public interface IBLLFactura
    {
        FacturaEncabezado Save(FacturaEncabezado pFactura);

        int GetNextNumeroFactura();

        int GetCurrentNumeroFactura();

        double CalculateTax(double precio);

        string GenerarXML(FacturaEncabezado facturaEncabezado, List<FacturaDetalle> detalles);

        // Task<IEnumerable<VentasDTO>> GetTotalVentasXFecha(DateTime pFechaInicial, DateTime pFechaFinal);
    }
}
