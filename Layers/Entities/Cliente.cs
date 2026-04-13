using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UTN.WinForms.ApCars.Enums;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    public class Cliente
    {
        public string IdCliente { set; get; }
        public int IdProvincia { set; get; }
        public string TipoCliente { set; get; }
        public string Nombre { set; get; }
        public string Apellido1 { set; get; }
        public string Apellido2 { set; get; }
        public string Sexo { set; get; }
        public string Correo { set; get; }
        public string Direccion { set; get; }
        public string Telefono { set; get; }
        public byte[] Foto { set; get; }

    }
}
