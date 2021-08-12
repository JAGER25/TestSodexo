using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models.ViewModels
{
    public class FacturasProducto
    {
        public decimal Idfacturaproductos { get; set; }
        public decimal FacturasIdfactura { get; set; }
        public decimal ProductosIdproducto { get; set; }

        public virtual Factura FacturasIdfacturaNavigation { get; set; }
        public virtual Producto ProductosIdproductoNavigation { get; set; }
    }
}
