using System;
using System.Collections.Generic;
using System.Text;
using TestDomain.Entities;

namespace TestInfrastructure.ViewModel
{
    public class FacturaViewModel
    {
        public decimal Idfactura { get; set; }
        public string Numerofactura { get; set; }
        public DateTime? Fecha { get; set; }
        public decimal Tipopago { get; set; }
        public string Documentocliente { get; set; }
        public string Nombrecliente { get; set; }
        public decimal? Subtotal { get; set; }
        public decimal? Descuento { get; set; }
        public decimal? Iva { get; set; }
        public decimal? Totaldescuento { get; set; }
        public decimal? Totalimpuesto { get; set; }
        public decimal? Total { get; set; }

        public List<decimal> productos { get; set; }
    }
}
