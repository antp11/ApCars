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
    internal class BLLEstilo : IBLLEstilo
    {
        public List<Estilo> GetAll()
        {
           IDALEstilo dalEstilo = new DALEstilo();

            return dalEstilo.GetAll();
        }
    }
}
