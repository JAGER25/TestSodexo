using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Design;
using TestPersistence.DbContextApi;
using Microsoft.EntityFrameworkCore;
using System.IO;
using TestInfrastructure.Extension;
using Microsoft.AspNetCore.Http;

namespace TestApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            //Log.Logger = new LoggerConfiguration().ReadFrom.configuration(configuration).CreateLogger();
            Configuration = configuration;

            IConfigurationBuilder builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            configRoot = builder.Build();
        }

        public IConfiguration Configuration { get; }
        private readonly IConfigurationRoot configRoot;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext(Configuration, configRoot);
            services.AddControllers();
            services.AddSwaggerOpenAPI();
            services.AddTransientServices();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
   
      
        
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureSwagger();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
