using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReEngage.Middleware;

namespace ReEngage
{
    public class Startup
    {
        IWebHostEnvironment _hEnv;

        public Startup(IWebHostEnvironment hEnv)
        {
            _hEnv = hEnv;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            var s = 2;


            app.Use(async (_context, _next) =>
            {
                //await _context.Response.WriteAsync($"Hello! {s} \n");
                await _next();
                s--;
                await _context.Response.WriteAsync($"\nPost! {s} \n");
            });

            app.Map("/index", (_builder) =>
            {
                _builder.UseTokenMidTest("1");

                _builder.Run(async (context) =>
                {
                    await context.Response.WriteAsync($"Index s:{s}");
                    s--;
                });
            });

            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    s+=2;
                    await context.Response.WriteAsync($"AppName: {_hEnv.ApplicationName} \ns: {s}");
                });
            });

        }
    }
}
