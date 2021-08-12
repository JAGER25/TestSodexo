using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDomain.Entities;

namespace TestService.Interfaces
{
    public interface IProductServices
    {
        Task<List<Producto>> GetProducts();
        Task<decimal> CreateProduct(Producto model);
        Task<List<Producto>> GetProductsFactura(List<decimal> lstId);
    }
}
