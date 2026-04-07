using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IBLLProvincia
    {
        List<Provincia> GetAll();
        Provincia GetById(int pId);
        Provincia Save(Provincia pBodega);
        Provincia GetProvinciaFromInternet(int pId);
        bool Delete(int pId);

    }

}
