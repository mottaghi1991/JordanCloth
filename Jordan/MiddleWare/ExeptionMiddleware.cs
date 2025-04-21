using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using System.Net;
using Serilog;

namespace WebStore.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExeptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExeptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
          var responsecode=  httpContext.Response.StatusCode;
            try
            {
                await _next(httpContext);

            }
            catch (Exception e)
            {
                await HandleExceptionAsync(httpContext, e);
            }

        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
         
                Log.Error(exception, "error");
                context.Response.Redirect("/Error");
            return Task.CompletedTask;
            var response = new { message = "An error occurred while processing your request." };


            return context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));
        }
    }


    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExeptionMiddlewareExtensions
    {
        public static IApplicationBuilder UseExeptionMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExeptionMiddleware>();
        }
    }
}
