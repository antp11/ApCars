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
    internal class BLLTipoTransmision : IBLLTipoTransmision
    {
        public List<TipoTransmision> GetAll()
        {
            IDALTipoTransmision dalTipoTransmision = new DALTipoTransmision();
            return dalTipoTransmision.GetAll();
        }
    }
}
