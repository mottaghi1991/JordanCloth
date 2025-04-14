using System.Collections.Generic;
using Core.Dto.ViewModel.Admin.Role;
using Domain;
using Domain.User;
using Domain.User.Permission;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Core.Interface.Admin
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
        IEnumerable<PermissionList> GetpermissionLists();
        IEnumerable<PermissionList> permissionAllLists();

        IEnumerable<RolePermission> GetPermissionOfRole(int RoleId);
        public IEnumerable<SelectListItem> GetContrllersOfArea(int SystemMenuId);
        public IEnumerable<SelectListItem> ParentList();
        public IEnumerable<PermissionList> GetAllParentPermissionList();
        public IEnumerable<SelectListItem> PermissionParentList();
        public IEnumerable<PermissionList> GetAllMenu();
        public PermissionList InsertParentMenu(PermissionList permissionList);
        public bool CheckFirst();
    }
}
