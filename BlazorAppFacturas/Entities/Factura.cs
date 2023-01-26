namespace BlazorAppFacturas.Entities
{
    public class Factura
    {
        public Factura(string codigo, string descripcion, string vendedor, string metodoPago, decimal total, decimal subTotal, bool pagado)
        {
            Codigo = codigo;
            Descripcion = descripcion;
            Vendedor = vendedor;
            MetodoPago = metodoPago;
            Total = total;
            SubTotal = subTotal;
            Pagado = pagado;
        }

        public int Id { get; set; }
        public string Codigo { get; set; }
        public string Descripcion { get; set; }
        public string Vendedor { get; set; }
        public string MetodoPago { get; set; }
        public decimal Total { get; set; }
        public decimal SubTotal { get; set; }
        public bool Pagado { get; set; }

    }
}
