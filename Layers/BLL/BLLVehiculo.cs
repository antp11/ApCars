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
    internal class BLLVehiculo : IBLLVehiculo
    {
        public bool Delete(string pVin)
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();
            return dALVehiculo.Delete(pVin);
        }

        public List<Vehiculo> GetAll()
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();

            return dALVehiculo.GetAll();
        }

        public Vehiculo GetById(string pVin)
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();
            return dALVehiculo.GetById(pVin);
        }

        public Vehiculo Save(Vehiculo pVehiculo)
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();
            Vehiculo oVehiculo = null;

            if (dALVehiculo.GetById(pVehiculo.IdVIN) != null)
                oVehiculo = dALVehiculo.Update(pVehiculo);
            else
                oVehiculo = dALVehiculo.Save(pVehiculo);

            return oVehiculo;
        }
    }
}
