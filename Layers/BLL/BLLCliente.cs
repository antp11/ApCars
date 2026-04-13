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
        public Task<bool> Delete(string IdCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.Delete(IdCliente);
        }

        public Task<IEnumerable<Cliente>> GetAll()
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.GetAll();
        }

        public List<Cliente> GetByFilter(string pDescripcion)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.GetByFilter(pDescripcion);
        }

        public Cliente GetById(string IdCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            return dalCliente.GetById(IdCliente);
        }


        public Task<Cliente> Save(Cliente pCliente)
        {
            IDALCliente dalCliente = new DALCliente();
            Task<Cliente> oCliente = null;

            if (dalCliente.GetById(pCliente.IdCliente) != null)

                oCliente = dalCliente.Update(pCliente);
            else
                oCliente = dalCliente.Save(pCliente);

            return oCliente;
        }
    }
}
