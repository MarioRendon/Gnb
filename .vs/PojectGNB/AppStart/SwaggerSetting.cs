using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PojectGNB.AppStart
{
    public class SwaggerSetting
    {
        public SwaggerSetting() { }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="services"></param>
        public static void Register(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Peliculas",
                    Description = "Servicio para transaccion de GNB",
                    Contact = new OpenApiContact() { Name = "Servicio de GNB ", Email = "mario03-11@hotmail.com" }
                });

                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);
                c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First()); //This line

            });
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="app"></param>
        public static void Configure(IApplicationBuilder app)
        {

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "MovieInventoryManagementService.App");
            });
        }
    }
}
