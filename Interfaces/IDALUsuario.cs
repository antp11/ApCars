using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;

namespace UTN.WinForms.ApCars.Interfaces
{
    internal interface IDALUsuario
    {


        Usuario Login(string pLogin, string pPassword);
        IEnumerable<Usuario> GetAll();
        Usuario Save(Usuario pUsuario);
        Usuario Update(Usuario pUsuario);
        Usuario GetById(string pLogin);
        bool Delete(string pLogin);
    }
}
