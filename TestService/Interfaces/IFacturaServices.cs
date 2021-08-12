using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDomain.Entities;

namespace TestService.Interfaces
{
    public interface IFacturaServices
    {
        Task<List<Factura>> GetFacturas();
        Task<decimal> CreateFactura(Factura model);
        Task<decimal> AddRelation(List<FacturasProducto> facturasProductos);
    }
}
