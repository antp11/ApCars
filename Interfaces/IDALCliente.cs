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
        List<Cliente> GetAll();
        Cliente Save(Cliente pCliente);
        Cliente Update(Cliente pCliente);
        Cliente GetById(string IdCliente);
        bool Delete(string IdCliente);
    }
}
