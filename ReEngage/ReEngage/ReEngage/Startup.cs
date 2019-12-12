using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ReEngage.Middleware;
using ReEngage.Services;

namespace ReEngage
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.Use(async (context, next) =>
            {
                // получаем конечную точку
                Endpoint endpoint = context.GetEndpoint();

                if (endpoint != null)
                {
                    // получаем шаблон маршрута, который ассоциирован с конечной точкой
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

                    Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
                    Debug.WriteLine($"Route Pattern: {routePattern}");

                    // если конечна€ точка определена, передаем обработку дальше
                    await next();
                }
                else
                {
                    Debug.WriteLine("Endpoint: null");
                    // если конечна€ точка не определена, завершаем обработку
                    
                    await next();

                }
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/index", async context =>
                {
                    await context.Response.WriteAsync("Hello Index!");
                });
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
            });


            // определ€ем обработчик маршрута
            var myRouteHandler = new RouteHandler(Handle);
            // создаем маршрут, использу€ обработчик
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            // само определение маршрута - он должен соответствовать запросу {controller}/{action}
            routeBuilder.MapRoute("default", "{controller}/{action}");

            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("трехсегментный запрос");
                });
            // строим маршрут
            
            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("RUN Hello World!");
            });
        }

        // собственно обработчик маршрута
        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
}
