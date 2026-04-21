using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Interfaces;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Layers.BLL
{
    internal class BLLImpuesto : IBLLImpuesto
    {
        public bool Delete(DateTime pId)
        {
            IDALImpuesto dalImpuesto = new DALImpuesto();
            return dalImpuesto.Delete(pId);
        }

        public List<Impuesto> GetAll()
        {
            IDALImpuesto dalImpuesto = new DALImpuesto();
            return dalImpuesto.GetAll();
        }

        public Impuesto GetById(DateTime pId)
        {
            IDALImpuesto dalImpuesto = new DALImpuesto();
            return dalImpuesto.GetById(pId);
        }

        public Impuesto GetImpuesto()
        {

            IDALImpuesto dalImpuesto = new DALImpuesto();

            return dalImpuesto.GetImpuesto();
        }

        public Impuesto Save(Impuesto pImpuesto)
        {
            IDALImpuesto dalImpuesto = new DALImpuesto();
            Impuesto oImpuesto = null;

            if (dalImpuesto.GetById(pImpuesto.IdFecha) == null)
                oImpuesto = dalImpuesto.Save(pImpuesto);
            else
                oImpuesto = dalImpuesto.Update(pImpuesto);
            return oImpuesto;
        }
    }
}
