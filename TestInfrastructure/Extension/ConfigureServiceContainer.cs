using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.OpenApi.Models;
using TestPersistence.DbContextApi;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using TestService.Interfaces;
using TestService.Services;

namespace TestInfrastructure.Extension
{
    public static class ConfigureServiceContainer
    {
        public static void AddDbContext(this IServiceCollection serviceCollection,
              IConfiguration configuration, IConfigurationRoot configRoot)
        {
            serviceCollection.AddDistributedMemoryCache();

            serviceCollection.AddDbContext<ModelContext>(options =>
            options.UseOracle(configuration.GetConnectionString("TestDB") ?? configRoot["ConnectionStrings:TestDB"]));


        }

        public static void AddTransientServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<IProductServices, ProductServices>();
            serviceCollection.AddTransient<IFacturaServices, FacturaServices>();
        }

        public static void ConfigureSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(setupAction =>
            {
                setupAction.SwaggerEndpoint("/swagger/OpenAPISpecification/swagger.json", "Test API");
                setupAction.RoutePrefix = "TestApi";
            });
        }
        public static void AddSwaggerOpenAPI(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSwaggerGen(setupAction =>
            {

                setupAction.SwaggerDoc(
                    "OpenAPISpecification",
                    new OpenApiInfo()
                    {
                        Title = "Test WebAPI",
                        Version = "1",
                        Description = "Through this API you can access bills details",
                        Contact = new OpenApiContact()
                        {
                            Email = "test@gmail.com",
                            Name = "Test Api",
                            Url = new Uri("https://test")
                        },
                        License = new OpenApiLicense()
                        {
                            Name = "MIT License",
                            Url = new Uri("https://opensource.org/licenses/MIT")
                        }
                    });

                
            });

        }
    }
}
