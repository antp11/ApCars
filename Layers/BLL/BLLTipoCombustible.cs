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
    internal class BLLTipoCombustible : IBLLTipoCombustible
    {
        public List<TipoCombustible> GetAll()
        {
            IDALTipoCombustible bllTipoCombustible = new DALTipoCombustible();
            return bllTipoCombustible.GetAll();
        }
    }
}
