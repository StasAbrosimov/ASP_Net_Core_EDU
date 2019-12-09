using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using ReEngage.Middleware;
using ReEngage.Services;

namespace ReEngage
{
    public class Startup
    {
        IWebHostEnvironment _hEnv;
        List<ServiceDescriptor> _descriptions;

        public Startup(IWebHostEnvironment hEnv)
        {
            _hEnv = hEnv;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            _descriptions = services.ToList();
            services.AddTransient<IServiceViewer, ServiceViewer>((s) =>
            {
                return new ServiceViewer(services);
            });
            services.AddTransient<ITransendService, CounertService>();
            services.AddScoped<IScopedService, CounertService>();
            services.AddSingleton<ISingletonService, CounertService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceViewer serviceViewer)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStatusCodePages();

            app.UseMiddleware<SingeltonMiddleware>();
            app.UseMiddleware<ScopedMiddleware>();
            app.UseMiddleware<TransendMiddleware>();
            app.UseMiddleware<TransendMiddleware>();
            app.UseMiddleware<TransendMiddleware>();
            app.UseMiddleware<ScopedMiddleware>();

            app.UseMiddleware<SingeltonMiddleware>();
            app.UseMiddleware<SingeltonMiddleware>();
            app.UseMiddleware<ScopedMiddleware>();
            app.UseMiddleware<TransendMiddleware>();

            app.Map("/services", ap => ap.Run(async context =>
            {
                await context.Response.WriteAsync(serviceViewer.GetServiceInfo());
            }));

            app.Run(async (context) =>
            {
                await context.Response.WriteAsync($"AppName: {_hEnv.ApplicationName}");
            });

        }
    }
}
