using System.Collections.Generic;
using Domain.User;
using Domain.User.Permission;

namespace Core.Interface.Users
{
    public interface IPermisionList
    {
        IEnumerable<PermissionList> GetAll();
        IEnumerable<PermissionList> GetPermisionByAreaAndController(string Area, string Controller);
        IEnumerable<PermissionList> GetAllArea();
        IEnumerable<PermissionList> GetControllerByArea(string Area);
        List<PermissionList> UserMenu();
        int checkExistArea(string Area);
        int checkExistController(string Area, string Controller);
        bool CheckExistPermission(string Area, string Controller, string Action);
      
        PermissionList Insert(PermissionList permissionList);
        PermissionList GetById(int PermissionId);
        PermissionList Update(PermissionList permissionList);
        IEnumerable<PermissionList> GetParentList();
        bool Delete(PermissionList permissionList);
        IEnumerable<PermissionList> permissionLists();
    }
}
