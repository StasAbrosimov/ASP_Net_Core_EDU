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
                // �������� �������� �����
                Endpoint endpoint = context.GetEndpoint();

                if (endpoint != null)
                {
                    // �������� ������ ��������, ������� ������������ � �������� ������
                    var routePattern = (endpoint as Microsoft.AspNetCore.Routing.RouteEndpoint)?.RoutePattern?.RawText;

                    Debug.WriteLine($"Endpoint Name: {endpoint.DisplayName}");
                    Debug.WriteLine($"Route Pattern: {routePattern}");

                    // ���� �������� ����� ����������, �������� ��������� ������
                    await next();
                }
                else
                {
                    Debug.WriteLine("Endpoint: null");
                    // ���� �������� ����� �� ����������, ��������� ���������
                    
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


            // ���������� ���������� ��������
            var myRouteHandler = new RouteHandler(Handle);
            // ������� �������, ��������� ����������
            var routeBuilder = new RouteBuilder(app, myRouteHandler);
            // ���� ����������� �������� - �� ������ ��������������� ������� {controller}/{action}
            routeBuilder.MapRoute("default", "{controller}/{action}");

            routeBuilder.MapRoute("{controller}/{action}/{id}",
                async context => {
                    context.Response.ContentType = "text/html; charset=utf-8";
                    await context.Response.WriteAsync("�������������� ������");
                });
            // ������ �������
            
            app.UseRouter(routeBuilder.Build());

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync("RUN Hello World!");
            });
        }

        // ���������� ���������� ��������
        private async Task Handle(HttpContext context)
        {
            await context.Response.WriteAsync("Hello ASP.NET Core!");
        }
    }
}
