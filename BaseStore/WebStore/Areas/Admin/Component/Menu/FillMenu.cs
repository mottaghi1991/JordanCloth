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

namespace MYCms.Areas.Admin.Component.Menu
{
    [Authorize]
    public class FillMenu:ViewComponent
    {
        private IPermisionList _permisionList;

        public FillMenu(IPermisionList permisionList)
        {
            _permisionList = permisionList;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            var menus = new List<PermissionList>();
            if (HttpContext.Session.GetString("menus") ==null)
            {
              
             var Identity=   User.Identity;
                DynamicParameters p = new DynamicParameters();
                p.Add("UserId", Identity);
                 menus =_permisionList.UserMenu();
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
