using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace UTN.WinForms.ApCars.Layers.Entities
{
    public class FacturaEncabezado
    {
        public int IdFactura { set; get; }
        public string IdUsuario { set; get; }
        public int IdTarjeta { set; get; }
        public string IdCliente { set; get; }
        public string TipoPago { set; get; }
        public string NoReferencia { set; get; }
        public DateTime Fecha { set; get; }
        public string XML { set; get; }
        public byte[] Firma { set; get; }
        public double TipoCambio { set; get; }
        public bool Estado {  set; get; }   


        public List<FacturaDetalle> _ListaFacturaDetalle { get; } = new List<FacturaDetalle>();

        public void AddDetalle(FacturaDetalle pFacturaDetalle) => _ListaFacturaDetalle.Add(pFacturaDetalle);

        //public double GetSubTotal() => _ListaFacturaDetalle.Sum(p => p.Cantidad * p.Precio);

       // public double GetImpuesto() => _ListaFacturaDetalle.Sum(p => p.Impuesto);
    }
}
