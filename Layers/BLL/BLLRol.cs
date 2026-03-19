using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.Winform.Electronics.Interfaces;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.DAL;
using UTN.WinForms.ApCars.Layers.Entities;


namespace UTN.WinForms.ApCars.Layers.BLL
{
    public  class BLLRol : IBLLRol
    {
        public List<Rol> GetAll()
        {
            IDALRol dalRol = new DALRol();
            return dalRol.GetAll();
        }
    }
}
