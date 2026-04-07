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
    internal class BLLCliente : IBLLCliente
    {
        public bool Delete(string IdCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.Delete(IdCliente);
        }

        public List<Cliente> GetAll()
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.GetAll();
        }

        public Cliente GetById(string IdCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.GetById(IdCliente);
        }


        public Cliente Save(Cliente pCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            Cliente oCliente = null;

            if (dalCliente.GetById(pCliente.IdCliente) != null)

                oCliente = dalCliente.Update(pCliente);
            else
                oCliente = dalCliente.Save(pCliente);

            return oCliente;
        }
    }
}
