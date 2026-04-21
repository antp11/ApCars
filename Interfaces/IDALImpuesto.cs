using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALImpuesto
    {
        List<Impuesto> GetAll();
        Impuesto GetImpuesto();
        Impuesto GetById(DateTime pId);
        Impuesto Save(Impuesto pImpuesto);
        bool Delete(DateTime pId);
        Impuesto Update(Impuesto pImpuesto);
    }
}
