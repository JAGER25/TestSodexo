using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestPersistence.DbContextApi;
using TestService.Interfaces;
using Microsoft.EntityFrameworkCore;
using TestDomain.Entities;
using System.Linq;

namespace TestService.Services
{
    public class ProductServices : IProductServices
    {
        private readonly ModelContext _modelContext;

        public ProductServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }
        public async Task<decimal> CreateProduct(Producto model)
        {
             _modelContext.Add(model);
            await _modelContext.SaveChangesAsync();
            return model.Idproducto;
        }

        public async Task<List<Producto>> GetProducts()
        {
            return await _modelContext.Productos.ToListAsync();
        }

        public async Task<List<Producto>> GetProductsFactura(List<decimal> lstId)
        {
            var products = from p in _modelContext.Productos
                           where (lstId.Contains((int)p.Idproducto))
                           select p;
            return await products.ToListAsync();
                
        }
    }
}
