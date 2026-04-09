using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Layers.Entities.DTO;


namespace UTN.WinForms.ApCars.Interfaces
{
    public interface IBLLPadron
    {
        PadronDTO GetById(string pId);
    }
}
