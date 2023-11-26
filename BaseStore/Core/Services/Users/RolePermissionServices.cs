using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface.Users;
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
            return _master.GetAll(a => a.RoleId == RoleId);
        }
    }
}
