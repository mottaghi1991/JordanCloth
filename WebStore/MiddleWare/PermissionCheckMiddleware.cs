using Core.Extention;
using Core.Interface.Admin;
using Domain.User.Permission;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal.MiddleWare
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class PermissionCheckMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IPermisionList _permisionList;
        public PermissionCheckMiddleware(RequestDelegate next, IPermisionList permisionList)
        {
            _next = next;
            _permisionList = permisionList;
        }

        public Task Invoke(HttpContext httpContext)
        {
            var User=httpContext.User;
            if(!User.Identity.IsAuthenticated)
            {
                httpContext.Response.Redirect("/Login");
                return Task.CompletedTask;
            }
            var Permission= new List<PermissionList>();

         
            return _next(httpContext);
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class PermissionCheckMiddlewareExtensions
    {
        public static IApplicationBuilder UsePermissionCheckMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<PermissionCheckMiddleware>();
        }
    }
}
