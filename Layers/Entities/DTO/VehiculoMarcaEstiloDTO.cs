using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Enums;

namespace UTN.WinForms.ApCars.Layers.Entities.DTO
{
    internal class VehiculoMarcaEstiloDTO
    {
        public string IdVIN { set; get; }
        public int IdMarca { set; get; }
        public string DescripcionMarca { set; get; }
        public byte[] Logo { set; get; }
        public int IdEstilo { set; get; }
        public string Descripcion { set; get; }
        public string DescripcionVehiculo { set; get; }
        public int Anno { set; get; }
        public int CantidadPaasajero { set; get; }
        public int IdTipoCombustible { set; get; }
        public string DescripcionTipoCombustible { set; get; }
        public string Color { set; get; }
        public int IdTransmision { set; get; }
        public string DescripcionTransmision { set; get; }
        public double Precio { set; get; }
        public byte[] Foto { set; get; }
        public byte[] Documento { set; get; }
        public string Extras { set; get; }
        public string Estado { set; get; }

    }
}
