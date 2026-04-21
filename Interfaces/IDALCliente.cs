using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALCliente
    {
        List<Cliente> GetByFilter(string pDescripcion);
        Task<IEnumerable<Cliente>> GetAll();
        Task<Cliente> Save(Cliente pCliente);
        Task<Cliente> Update(Cliente pCliente);
        Cliente GetById(string IdCliente);
        Task<bool> Delete(string IdCliente);
    }
}
