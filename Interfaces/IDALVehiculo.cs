using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;
using UTN.WinForms.ApCars.Layers.Entities.DTO;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALVehiculo
    {
        List<Vehiculo> GetAll();
        Vehiculo Save(Vehiculo pVehiculo);
        Vehiculo Update(Vehiculo pVehiculo);
        Vehiculo GetById(string pVin);
        bool Delete(string pVin);
        List<Vehiculo> GetByFilter(string pDescripcion);
        List<VehiculoMarcaEstiloDTO> GetAllDTO();
        List<VehiculoMarcaEstiloDTO> GetByMarca(string pMarca);
        List<VehiculoMarcaEstiloDTO> GetByEstilo(string pEstilo);
        List<VehiculoMarcaEstiloDTO> GetByDescripcion(string pDescripcion);

      //  Task<IEnumerable<VehiculoMarcaEstiloDTO>> GetTotalCantidadInventario();

    }
}
