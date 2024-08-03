using System.Collections.Generic;
using System.Reflection;
using Domain.User.Permission;

namespace Core.Interface.Admin
{
    public interface IRolePermission
    {
        IEnumerable<RolePermission> GetPermissionOfRole(int RoleId);
        bool BulkInsert(List<RolePermission> list);

        bool BulkDelete(List<RolePermission> list);
    }
}