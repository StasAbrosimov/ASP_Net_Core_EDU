using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ReEngage.Services;

namespace ReEngage.Middleware
{
    public class ScopedMiddleware
    {
        private readonly RequestDelegate _next;
        private string _guid = Guid.NewGuid().ToString();

        public ScopedMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, IScopedService service)
        {
            await context.Response.WriteAsync($"Scoped: {service.Value} midleWguid:{_guid}\n");
            await _next(context);
        }
    }
}
