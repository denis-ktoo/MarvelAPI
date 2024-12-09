using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace MarvelAPI.Middleware
{
    public class RestrictHttpMethodsMiddleware
    {
        private readonly RequestDelegate _next;

        public RestrictHttpMethodsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            // Allow only GET methods
            if (context.Request.Method != HttpMethods.Get)
            {
                context.Response.StatusCode = StatusCodes.Status405MethodNotAllowed;
                await context.Response.WriteAsync("405 Method Not Allowed: Only GET requests are supported.");
                return;
            }

            await _next(context);
        }
    }
}