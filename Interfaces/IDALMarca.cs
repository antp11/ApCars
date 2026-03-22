using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALMarca
    {
        List<Marca> GetAll();
        Marca GetById(int pId);
        Marca Save(Marca pMarca);
        bool Delete(int pId);
        Marca Update(Marca pMarca);
    }
}
