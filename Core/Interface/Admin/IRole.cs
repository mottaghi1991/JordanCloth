using System.Collections.Generic;
using Domain.User;
using Domain.User.Permission;

namespace Core.Interface.Admin
{
    public interface IRole
    {
        IEnumerable<Role> GetAllRole();
        Role GetRole(int RoleId);
        Role insert(Role role);
        Role update(Role role);
        bool delete(Role role);

        IEnumerable<UserRole> GetAllUSerOfRole(int RoleId);
        bool BulkDelete(IEnumerable<UserRole> List);
        bool BulkInsert(IEnumerable<UserRole> List);
        bool UserRoleInsert(UserRole userRole);
    }
}