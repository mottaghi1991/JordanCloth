using Dapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fuel_Core;
using Microsoft.AspNetCore.Authorization;
using Domain.User;
using Domain.User.Permission;
using Core.Interface.Admin;
using System.Security.Claims;
using Core.Extention;

namespace MYCms.Areas.Admin.Component.Menu
{
    [Authorize]
    public class FillMenu:ViewComponent
    {
        private IPermisionList _permisionList;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public FillMenu(IPermisionList permisionList,IHttpContextAccessor httpContextAccessor)
        {
            _permisionList = permisionList;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var menus = new List<PermissionList>();
            var obj = HttpContext.Session.GetData<List<PermissionList>>("menus");
            if (obj==null)
            {

             menus =_permisionList.UserMenu(_httpContextAccessor.HttpContext.User.GetUserId());
             HttpContext.Session.SetData("menus", menus);
            }
            else
            {
                menus =HttpContext.Session.GetData<List<PermissionList>>("menus");
            }
           
             
           
            return  View("/Areas/Admin/Component/Menu/MyFillMenu.cshtml", menus);
        }
    }
}
