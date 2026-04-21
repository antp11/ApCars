using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;
using UTN.WinForms.ApCars.Layers.Entities.DTO;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class BLLVehiculo : IBLLVehiculo
    {
        public Vehiculo AvabilityStock(string pVin)
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();
            Vehiculo oVehiculo = dALVehiculo.GetById(pVin);

            if (oVehiculo == null)
            {
                throw new Exception($"El VIN {pVin} no existe!");
            }
            if (oVehiculo.Estado == "Vendido")
            {
                throw new Exception($"El Vehiculo{oVehiculo.DescripcionVehiculo} ya fue Vendido");
            }
            return oVehiculo;

        }

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

        public List<VehiculoMarcaEstiloDTO> GetAllDTO()
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();

            return dALVehiculo.GetAllDTO();
        }

        public List<Vehiculo> GetByFilter(string pDescripcion)
        {
            IDALVehiculo dALVehiculo = new DALVehiculo();
            return dALVehiculo.GetByFilter(pDescripcion);
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
