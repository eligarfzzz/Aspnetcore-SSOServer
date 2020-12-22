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

namespace FrameWork.WebAPI
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
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.Use(async (context, next) =>
            {
               context.Response.OnStarting(() =>
               {
                   context.Response.Headers.Add("Access-Control-Allow-Headers", "Authorization,X-API-KEY, Origin,  Content-Type, Accept, Access-Control-Request-Method");

                   context.Response.Headers.Add("Access-Control-Allow-Origin", context.Request.Headers["Origin"]);

                   context.Response.Headers.Add("Access-Control-Allow-Methods", "GET, POST, OPTIONS, PATCH, PUT, DELET");
                   context.Response.Headers.Add("Allow", "GET, POST, PATCH, OPTIONS, PUT, DELETE");

                   return Task.CompletedTask;
               });
               await next();
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
