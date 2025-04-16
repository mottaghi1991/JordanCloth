using Core.Extention;
using Core.Interface.Admin;
using Domain.User.Permission;
using Fuel_Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Tools
{
    public class PermissionFilterAttribute : TypeFilterAttribute
    {
        public PermissionFilterAttribute() : base(typeof(PermissionFilterImpl))
        {
        }
        private class PermissionFilterImpl : ActionFilterAttribute
        {
            private readonly IPermisionList _permisionList;
            private readonly IHttpContextAccessor _httpContextAccessor;


            public PermissionFilterImpl(IPermisionList permisionList, IHttpContextAccessor httpContextAccessor)
            {
                _permisionList = permisionList;
                _httpContextAccessor = httpContextAccessor;
            }

            public override void OnActionExecuting(ActionExecutingContext context)
            {
                var session = context.HttpContext.Session;
                var controller = context.RouteData.Values["controller"].ToString();
                var action = context.RouteData.Values["action"].ToString();
                var area = context.RouteData.DataTokens.ContainsKey("area") ?
                           context.RouteData.DataTokens["area"]?.ToString() : null;

                var menus = new List<PermissionList>();
                if (session.GetString("menus") == null)
                {

                    menus = _permisionList.UserMenu(_httpContextAccessor.HttpContext.User.GetUserId());
                    session.SetData("menus", menus);
                }
                else
                {
                    menus = session.GetData<List<PermissionList>>("menus");
                }

                                if (menus == null || !menus.Any(p =>
                        p.ControllerName == controller &&
                        p.ActionName == action &&
                        ((p.Area ?? "") == (area ?? ""))))
                {
                    context.Result = new RedirectResult("/Login");
                }

                base.OnActionExecuting(context);
            }
        }
    }
}
