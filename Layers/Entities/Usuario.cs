using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    internal class Usuario
    {
        public string IdUsuario { set; get; }
        public int IdRol { set; get; }
        public string Nombre { set; get; }
        public string Apellido1 { set; get; }
        public string Apellido2 { set; get; }
        public string Contrasenna { set; get; }
        public bool Estado { set; get; }
        public byte[] Foto { set; get; }

        public override string ToString() => $"{IdUsuario.Trim()} - {Nombre.Trim()}";

    }
}
