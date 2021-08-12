using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TestDomain.Entities;
using TestPersistence.DbContextApi;
using TestService.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace TestService.Services
{
    public class FacturaServices : IFacturaServices
    {
        private readonly ModelContext _modelContext;

        public FacturaServices(ModelContext modelContext)
        {
            _modelContext = modelContext;
        }

        public async Task<decimal> AddRelation(List<FacturasProducto> facturasProductos)
        {
            try
            {
                foreach (var item in facturasProductos)
                {
                    _modelContext.Add(item);
                    await _modelContext.SaveChangesAsync();
                }
                
                return 1;
            }
            catch (Exception Ex)
            {
                return 0;
            }
        }

        public async Task<decimal> CreateFactura(Factura model)
        {
            _modelContext.Add(model);   
            await _modelContext.SaveChangesAsync();
            return model.Idfactura;
        }

        public async Task<List<Factura>> GetFacturas()
        {
            return await _modelContext.Facturas
                .Include(x => x.FacturasProductos)
                .ThenInclude(x => x.ProductosIdproductoNavigation)
                .ToListAsync();
                
        }
    }
}
