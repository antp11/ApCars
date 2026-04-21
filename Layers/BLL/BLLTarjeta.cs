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
    internal class BLLTarjeta : IBLLTarjeta
    {
        public IEnumerable<Tarjeta> GetAll()
        {
            IDALTarjeta dALTarjeta = new DALTarjeta();

            return dALTarjeta.GetAll();
        }
    }
}
