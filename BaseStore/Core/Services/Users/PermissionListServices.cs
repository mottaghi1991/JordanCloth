using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Core.Dto.ViewModel.Admin.Role;
using Core.Interface.Admin;
using Dapper;
using Data.MasterInterface;
using Domain;
using Domain.User;
using Domain.User.Permission;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Services.Users
{
    public class PermissionListServices:IPermisionList
    {
        IMaster<PermissionList> _master;
        IMaster<RolePermission> _RolePemissionmaster;

        public PermissionListServices(IMaster<PermissionList> master,IMaster<RolePermission> rolePemissionmaster)
        {
            _master = master;
            _RolePemissionmaster=rolePemissionmaster;
        }

        public IEnumerable<PermissionList> GetAll()
        {
            return _master.GetAll();
        }

        public IEnumerable<PermissionList> GetPermisionByAreaAndController(string Area, string Controller)
        {
          return  _master.GetAll(a => a.Area == Area & a.ControllerName == Controller);
        }

        public IEnumerable<FillSelectList> GetAllArea()
        {
         var obj=   _master.GetAll().GroupBy(a=>a.Area).Select(a=>a.First()).Select(a => new FillSelectList(){ Value = a.Area, Text = a.Area }).Distinct();
            //var obj = _master.GetAll("GetAllArea");
            return obj;
        }

        public IEnumerable<FillSelectList> GetControllerByArea(string Area)
        {
            return _master.GetAll(a => a.Area == Area).GroupBy(a=> new {a.Area,a.ControllerName}).Select(c=>c.First()).Select(b => new FillSelectList()
                { Value = b.ControllerName, Text = b.ControllerName });
            
        }

        public List<PermissionList> UserMenu()
        {
            return _master.GetAll(a=>a.Status==2).ToList();
        }

        public int checkExistArea(string Area)
        {
            if (_master.GetAll(a => a.Area == Area && a.Area != null && a.ActionName == null && a.ControllerName == null).Any())
                return _master.GetAll(a => a.Area == Area && a.Area != null && a.ActionName == null && a.ControllerName == null).FirstOrDefault().PermissionListId;
            else
                return 0;
        }

        public int checkExistController(string Area, string Controller)
        {
            if (_master.GetAll( a=> a.Area == Area && a.ControllerName == Controller && a.ActionName == null).Any())
                return _master.GetAll( a=> a.Area == Area && a.ControllerName == Controller && a.ActionName == null).FirstOrDefault().PermissionListId;
            else
                return 0;
        }

        public bool CheckExistPermission(string Area, string Controller, string Action)
        {
            var t = _master.GetAll(a => a.Area == Area & a.ControllerName == Controller & a.ActionName == Action).Any();
            return t;
        }

    

        public PermissionList Insert(PermissionList permissionList)
        {
            return _master.Insert(permissionList);
        }

        public PermissionList GetById(int PermissionId)
        {
            return _master.GetAll(a => a.PermissionListId == PermissionId).FirstOrDefault();
        }

        public PermissionList Update(PermissionList permissionList)
        {
            return _master.Update(permissionList);
        }

        public IEnumerable<PermissionList> GetParentList()
        {
            return _master.GetAll(a => a.ActionName == null&a.Status==2);
        }

        public bool Delete(PermissionList permissionList)
        {
            return _master.Delete(permissionList);
        }

        public IEnumerable<PermissionList> permissionLists()
        {
            var obj = _master.GetAll(a => a.Status != (int)PermissionStatus.menu);
            return obj;
        }

        public IEnumerable<ShowMenuVm> GetAllMenu()
        {
            return _master.GetAll(a => a.Status == 2).Select(a => new ShowMenuVm()
                { PermissionListId = a.PermissionListId, MenuDesc = a.Descript,ParentId = a.ParentId});
        }

        public IEnumerable<RolePermission> GetPermissionOfRole(int RoleId)
        {
            return _RolePemissionmaster.GetAll(a => a.RoleId == RoleId);
        }
    }
}
