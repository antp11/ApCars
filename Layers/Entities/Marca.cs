using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    internal class Marca
    {

        public int IdMarca { set; get; }
        public string DescripcionMarca { set; get; }
        public byte[] Logo { set; get; }

        public override string ToString()
        {
            return DescripcionMarca;
        }

    }
}
