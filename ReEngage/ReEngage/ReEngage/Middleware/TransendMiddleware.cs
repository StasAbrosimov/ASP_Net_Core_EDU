using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using ReEngage.Services;

namespace ReEngage.Middleware
{
    public class TransendMiddleware
    {
        private readonly RequestDelegate _next;
        private string _guid = Guid.NewGuid().ToString();

        public TransendMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ITransendService service = context.RequestServices.GetService<ITransendService>();
            await context.Response.WriteAsync($"Transend: {service.Value} midelWGUID:{_guid}\n");
            await _next(context);
        }
    }
}
