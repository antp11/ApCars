using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    public class Tarjeta
    {
        public int IdTarjeta { set; get; }
        public string DescripcionTarjeta { set; get; }

        public override string ToString() => $"{IdTarjeta} {DescripcionTarjeta}";

    }
}
