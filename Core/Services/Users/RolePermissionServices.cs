using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Enums;
using Core.Interface.Admin;
using Core.Interface.Users;
using Dapper;
using Data.MasterInterface;
using Domain.User.Permission;

namespace Core.Services.Users
{
    public class RolePermissionServices:IRolePermission
    {
        private IMaster<RolePermission> _master;

        public RolePermissionServices(IMaster<RolePermission> master)
        {
            _master = master;
        }
        public IEnumerable<RolePermission> GetPermissionOfRole(int RoleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("RoleId", RoleId, System.Data.DbType.Int32);

            return _master.GetAll("GetMenuOfRole", p);
        }
        public IEnumerable<RolePermission> GetMenuOfRole(int RoleId)
        {
            DynamicParameters p = new DynamicParameters();
            p.Add("RoleId", RoleId, System.Data.DbType.Int32);

            return _master.GetAll("GetMenuOfRole",p);
        }
        public bool BulkInsert(List<RolePermission> list)
        {
            return _master.BulkeInsert(list);
        }

        public bool BulkDelete(List<RolePermission> list)
        {
            return _master.BulkeDelete(list);
        }
    }
}
