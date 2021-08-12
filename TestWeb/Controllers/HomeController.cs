using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Services;

namespace TestWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        
        private readonly IConfiguration _configuration;
        private readonly ServicesSetting _servicesSetting;    

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration, IOptions<ServicesSetting> servicesSetting)
        {
            _logger = logger;
            _configuration = configuration;
            _servicesSetting = servicesSetting.Value;
        }
        private FacturasServices _facturasServices = new FacturasServices();
        public async Task<IActionResult> Index()
        {
            var model = await _facturasServices.GetFactura(_servicesSetting.Url);
            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
