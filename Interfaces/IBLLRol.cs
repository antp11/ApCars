using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities;


namespace UTN.Winform.Electronics.Interfaces
{
    public interface IBLLRol
    {
        List<Rol> GetAll();
    }
}
