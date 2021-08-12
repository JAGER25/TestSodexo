using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWeb.Models;

namespace TestWeb.Services.Extensions
{
    public static class ConfigureServiceContainer
    {
        public static void AddSetting(this IServiceCollection serviceCollection,
           IConfiguration configuration)
        {
            serviceCollection.Configure<ServicesSetting>(configuration.GetSection("Services"));
        }
        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            //serviceCollection.AddTransient<IDateTimeService, DateTimeService>();
        }
    }
}
