using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Enums;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    internal class Vehiculo
    {
        public string IdVIN { set; get; }
        public int IdMarca { set; get; }
        public int IdEstilo { set; get; }
        public string DescripcionVehiculo { set; get; }
        public int Anno { set; get; }
        public int CantidadPaasajero { set; get; }
        public TipoCombustible TipoCombustible { set; get; }
        public string Color { set; get; }
        public TipoTransmision TipoTransmision { set; get; }
        public double Precio { set; get; }
        public byte[] Foto { set; get; }
        public byte[] Documento { set; get; }
        public string Extras { set; get; }

    }
}
