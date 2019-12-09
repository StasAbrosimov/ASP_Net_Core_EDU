using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReEngage.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ReEngage.Middleware
{
    public class SingeltonMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ISingletonService singletonService;
        private string _guid = Guid.NewGuid().ToString();

        public SingeltonMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            ISingletonService singletonService = context.RequestServices.GetService<ISingletonService>();
            await context.Response.WriteAsync($"Single: {singletonService.Value} midleWguid:{_guid}\n");
            await _next(context);
        }
    }
}
