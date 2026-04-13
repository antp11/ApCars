using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class BLLFactura : IBLLFactura
    {
        public double CalculateTax(double precio, int cantidad)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
    }
}
