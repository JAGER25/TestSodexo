using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

#nullable disable

namespace TestDomain.Entities
{
    public partial class FacturasProducto
    {
        public decimal Idfacturaproductos { get; set; }
        public decimal FacturasIdfactura { get; set; }
        public decimal ProductosIdproducto { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual Factura FacturasIdfacturaNavigation { get; set; }
        public virtual Producto ProductosIdproductoNavigation { get; set; }
    }
}
