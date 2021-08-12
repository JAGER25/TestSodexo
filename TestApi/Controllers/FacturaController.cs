using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDomain.Entities;
using TestInfrastructure.Tools;
using TestInfrastructure.ViewModel;
using TestService.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : Controller
    {
        private IProductServices _productServices;

        private IFacturaServices _facturaServices;

        Operations operations = new Operations();

        public FacturaController(IFacturaServices facturaServices, IProductServices productServices)
        {
            _facturaServices = facturaServices;
            _productServices = productServices;
        }
        [HttpGet]
        [Route("GetFacturas")]
        public async Task<List<Factura>> GetFacturas()
        {
            return await _facturaServices.GetFacturas();
        }
        [HttpPost]
        [Route("CreateFactura")]
        public async Task<decimal> CreateFactura(FacturaViewModel model)
        {
            var products = await _productServices.GetProductsFactura(model.productos);
            var impuesto = operations.GetTotalWithIVA(products.Sum(x => x.Precio).Value, 19);
            var sudtotal = products.Sum(x => x.Precio);
            var total = impuesto + sudtotal;
            var obj = new Factura()
            {
                Descuento = model.Descuento,
                Documentocliente = model.Documentocliente,
                Fecha = DateTime.Now,
                Iva = 19,
                Nombrecliente = model.Nombrecliente,
                Numerofactura = DateTime.Now.ToString("yyyyMMddmmss"),
                Subtotal = products.Sum(x => x.Precio),
                Tipopago = model.Tipopago,
                Total = total,
                Totaldescuento = total - model.Descuento,
                Totalimpuesto =impuesto
            };
            var id = await _facturaServices.CreateFactura(obj);
            var relation = new List<FacturasProducto>();
            foreach (var item in model.productos)
            {
                var i = new FacturasProducto()
                {
                    FacturasIdfactura = id,
                    ProductosIdproducto = item
                };
                relation.Add(i);
            }
            await _facturaServices.AddRelation(relation);
           
            return id;
        }
    }
}
