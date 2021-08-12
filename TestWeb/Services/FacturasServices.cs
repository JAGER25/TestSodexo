using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using TestWeb.Models;
using TestWeb.Models.ViewModels;

namespace TestWeb.Services
{
    public class FacturasServices
    {
        
        public async Task<List<Factura>> GetFactura(string Url)
        {
            ServicePointManager.ServerCertificateValidationCallback += (sender, cert, chain, sslPolicyErrors) => { return true; };

            IRestResponse response = new RestResponse();
            try
            {
                var client = new RestClient(Url + "Factura/GetFacturas");
                var request = new RestRequest(Method.GET);
                request.AddHeader("Content-Type", "application/json");
                response = await client.ExecuteAsync(request);
                List<Factura> deptos = JsonConvert.DeserializeObject<List<Factura>>(response.Content);
                return deptos;
            }
            catch (Exception ex)
            {
                response.ResponseStatus = ResponseStatus.Error;
                response.ErrorMessage = ex.Message;
                response.ErrorException = ex;
                throw;
            }
        }
    }
}
