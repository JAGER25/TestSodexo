using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestWeb.Models.ViewModels
{
    public class Producto
    {
        public decimal Idproducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }

        public virtual ICollection<FacturasProducto> FacturasProductos { get; set; }
    }
}
