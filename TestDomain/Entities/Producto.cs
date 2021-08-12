using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace TestDomain.Entities
{
    public partial class Producto
    {
        public Producto()
        {
            FacturasProductos = new HashSet<FacturasProducto>();
        }

        public decimal Idproducto { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<FacturasProducto> FacturasProductos { get; set; }
    }
}
