using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace ReEngage.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _token;

        public TokenMiddleware(RequestDelegate next, string token)
        {
            _token = token;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var token = context.Request.Query["token"];
            if(token != _token)
            {
                context.Response.StatusCode = StatusCodes.Status501NotImplemented;
                await context.Response.WriteAsync($"invalidToken:{token}");
            } else if (_next != null)
            {
                await _next(context);
            }
            else
            {
                context.Response.StatusCode = StatusCodes.Status501NotImplemented;
            }
        }
    }

    public static class TokenExtensions
    {
        public static IApplicationBuilder UseTokenMidTest(this IApplicationBuilder builder, string pattern)
        {
            return builder.UseMiddleware<TokenMiddleware>(pattern);
        }
    }
}
