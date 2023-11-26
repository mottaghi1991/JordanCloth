using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using Core.Interface.Users;
using Dapper;
using Data.MasterInterface;
using Domain;
using Domain.User;
using Domain.User.Permission;

namespace Core.Services.Users
{
    public class PermissionListServices:IPermisionList
    {
        IMaster<PermissionList> _master;

        public PermissionListServices(IMaster<PermissionList> master)
        {
            _master = master;
        }

        public IEnumerable<PermissionList> GetAll()
        {
            return _master.GetAll();
        }

        public IEnumerable<PermissionList> GetPermisionByAreaAndController(string Area, string Controller)
        {
          return  _master.GetAll(a => a.Area == Area & a.ControllerName == Controller);
        }

        public IEnumerable<PermissionList> GetAllArea()
        {
            var obj = _master.GetAll("GetAllArea");
            return obj;
        }

        public IEnumerable<PermissionList> GetControllerByArea(string Area)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("Area", Area, DbType.String);
            return _master.GetAll("GetControllerByArea", p);
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
    }
}
