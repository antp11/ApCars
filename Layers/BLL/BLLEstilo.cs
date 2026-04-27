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
        /// <summary>
        /// Metodo que busca el estilo de carro por el id
        /// </summary>
        /// <param name="pId"></param>
        /// <returns></returns>
        public Estilo GetById(int pId)
        {
            IDALEstilo dalEstilo = new DALEstilo();
            return dalEstilo.GetById(pId);
        }
    }
}
