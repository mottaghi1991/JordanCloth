using System.Collections.Generic;
using System.Reflection;
using Domain.User.Permission;

namespace Core.Interface.Users
{
    public interface IRolePermission
    {
        IEnumerable<RolePermission> GetPermissionOfRole(int RoleId);
    }
}