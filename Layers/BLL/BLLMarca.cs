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
    internal class BLLMarca : IBLLMarca
    {
        public bool Delete(int pId)
        {

            IDALMarca dalMarca = new DALMarca();

            return dalMarca.Delete(pId);
        }

        public List<Marca> GetAll()
        {
            IDALMarca dalMarca = new DALMarca();

            return dalMarca.GetAll();
        }

        public Marca GetById(int pId)
        {
            IDALMarca dalMarca = new DALMarca();

            return dalMarca.GetById(pId);
        }

        public Marca Save(Marca pMarca)
        {
            IDALMarca dalMarca = new DALMarca();
            Marca oMarca = null;

            if (dalMarca.GetById(pMarca.IdMarca) == null)
                oMarca = dalMarca.Save(pMarca);
            else
                oMarca = dalMarca.Update(pMarca);


            return oMarca;
        }
    }
}
