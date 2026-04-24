using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALEstilo
    {
        List<Estilo> GetAll();

        Estilo GetById(int pId);
    }
}
