using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PojectGNB.AppStart;
using ProjectGNB.Data;

namespace PojectGNB
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            DependencyInjection.Register(services);
            SwaggerSetting.Register(services);

            services.AddOptions();
            services.AddControllers();
            services.AddHttpClient();

            services.AddCors();

            services.AddDistributedRedisCache(options => {
                options.Configuration = "localhost:6380,password=pruebas1234";
                options.InstanceName = "localhost";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
           
            
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            var urlAceptadas = Configuration
                      .GetSection("AllowedHosts").Value.Split(",");
            app.UseCors(builder => builder.WithOrigins(urlAceptadas)
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  );

            app.UseAuthorization();

            SwaggerSetting.Configure(app);
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
