namespace UTN.WinForms.ApCars.Layers.Entities
{
    public class FacturaDetalle
    {
        public int IdFactura { set; get; }
        public string Consecutivo { set; get; }
        public string DescripcionVehiculo { set; get; }
        public string IdVIN { set; get; }
        public double PrecioColones { set; get; }
        public double PrecioDolares { set; get; }
        public double ImpuestoColones { set; get; }
        public double ImpuestoDolares { set; get; }


    }
}