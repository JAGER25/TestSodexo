using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDomain.Entities;
using TestInfrastructure.ViewModel;
using TestService.Interfaces;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : Controller
    {
        private IProductServices _productServices;

        public ProductoController(IProductServices productServices)
        {
            _productServices = productServices;
        }

        [HttpGet]
        [Route("GetProducts")]
        public async Task<List<Producto>> GetProducts()
        {
            return await _productServices.GetProducts();
        }
        [HttpPost]
        [Route("CreateProduct")]
        public async Task<decimal> CreateProduct(ProductViewModel model)
        {
            var obj = new Producto()
            {
                Nombre = model.Nombre,
                Precio = model.precio
            };
            return await _productServices.CreateProduct(obj);
        }

    }
}
