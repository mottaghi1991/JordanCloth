using System.Collections.Generic;
using Domain.User.Permission;

namespace Core.Interface.Users
{
    public interface IRole
    {
        IEnumerable<Role> GetAllRole();
        Role GetRole(int RoleId);
        Role insert(Role role);
        Role update(Role role);
        bool delete(Role role);
    }
}