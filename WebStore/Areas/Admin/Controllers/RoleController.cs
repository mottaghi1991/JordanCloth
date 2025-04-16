using System;
using Core.Dto.ViewModel.Admin.Role;
using System.Collections.Generic;
using System.Linq;
using Core.Interface.Admin;
using Core.Interface.Users;
using Domain.User;
using Domain.User.Permission;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Core.Extention;

namespace MYCms.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class RoleController : Controller
    {
        private IRole _role;
        private readonly IUser _user;
        private readonly IRolePermission _permission;
        private readonly IPermisionList _permisionList;

        public RoleController(IRole role, IRolePermission permission,IPermisionList permisionList, IUser user)
        {
            _role = role;
            _permission = permission;
            _permisionList = permisionList;
            _user = user;
        }
        // GET: RoleController
        public ActionResult Index()
        {
            var obj = _role.GetAllRole();
            return View(obj);
        }

 
        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Role Role)
        {
            try
            {

                if (!ModelState.IsValid)
                {
                    return new JsonResult(Role);
                }
            }
            catch
            {
                return new JsonResult(Role);
            }

            _role.insert(Role);
            return RedirectToAction("Index");
        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int id)
        {
            if (id== null)
            {
                return BadRequest();
            }
            var result = _role.GetRole(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Role role)
        {
            if (!ModelState.IsValid)
            {
                return new JsonResult(role);
            }

            _role.update(role);
            return RedirectToAction("Index");
        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {


            if (id == null)
            {
                return BadRequest();
            }
            var result = _role.GetRole(id);
            if (result == null)
            {
                return NotFound();
            }

            _role.delete(result);
            return RedirectToAction("Index");
        }

      
        [HttpGet]
        public IActionResult UserRole(int RoleId)
        {
            var Role = _role.GetRole(RoleId);
            if (Role == null)
            {
                return BadRequest();
            }
            ViewBag.AdminUser = _user.GetAllAdmin();
            var obj = new EditUserRoleVm()
            {
                RoleId = RoleId,
                RoleName = Role.RoleTitle,
                UserRoles = _role.GetAllUSerOfRole(RoleId)
            };
            return View(obj);
        }

        [HttpPost]
        public IActionResult UserRole(List<int> UserList, int RoleId)
        {
            var deletedata = _role.GetAllUSerOfRole(RoleId);
            if (deletedata.Any())
            {
                if (!_role.BulkDelete(deletedata))
                {
                    TempData["Error"] = "خطایی رخ داده است";
                    return RedirectToAction("UserRole", new { RoleId = RoleId });
                }


            }
            List<UserRole> list = new List<UserRole>();
            foreach (int i in UserList)
            {
                list.Add(new UserRole()
                {
                    RoleId = RoleId,
                    UserId = i
                });
            }
            list.AddRange(list);

            var obj = _role.BulkInsert(list);
            if (obj)
            {
                TempData["Success"] = "عملیات با موفقیت انجام گردید";
                return RedirectToAction("Index", "Role");
            }
            else
            {
                TempData["Error"] = "خطایی رخ داده است";
                return RedirectToAction("Index", "Role");
            }


        }
        [HttpGet]
        public IActionResult RolePermission(int RoleId)
        {
            var deletedata = _permission.GetPermissionOfRole(RoleId).ToList();
            var Role = _role.GetRole(RoleId);
            if (Role == null)
            {
                return BadRequest();
            }
            ViewBag.PermssionList = _permisionList.GetpermissionLists();
            var obj = new EditPermissionRoleVm()
            {
                RoleId = RoleId,
                RoleName = Role.RoleTitle,
                MenuVm = _permisionList.GetPermissionOfRole(RoleId)
            };
            return View(obj);
        }
        [HttpPost]
        public IActionResult RolePermission(List<int> PermissionList,int RoleId)
        {
            var deletedata = _permission.GetPermissionOfRole(RoleId).ToList();
            if (deletedata.Any())
            {
                if (!_permission.BulkDelete(deletedata))
                {
                    TempData["Error"] = "خطایی رخ داده است";
                    return RedirectToAction("RolePermission", new { RoleId = RoleId });
                }


            }
            List<RolePermission> list = new List<RolePermission>();
            foreach (int i in PermissionList)
            {
                list.Add(new RolePermission()
                {
                    RoleId = RoleId,
                    PermissionListId = i
                });
            }
            list.AddRange(list);

            var obj = _permission.BulkInsert(list);
            if (obj)
            {
                TempData["Success"] = "عملیات با موفقیت انجام گردید";
                return RedirectToAction("Index", "Role");
            }
            else
            {
                TempData["Error"] = "خطایی رخ داده است";
                return RedirectToAction("Index", "Role");
            }
        }
        public IActionResult RoleMenu(int RoleId)
        {
                var Role = _role.GetRole(RoleId);
            if (Role == null)
            {
                return BadRequest();
            }
            ViewBag.PermssionList = _permisionList.GetAllMenu();
            var obj = new EditPermissionRoleVm()
            {
                RoleId = RoleId,
                RoleName = Role.RoleTitle,
                MenuVm = _permisionList.GetPermissionOfRole(RoleId)
            };
            return View(obj);
        }
        [HttpPost]
        public IActionResult RoleMenu(List<int> PermissionList, int RoleId)
        {
            var deletedata = _permission.GetMenuOfRole(RoleId).ToList();
            if (deletedata.Any())
            {
                if (!_permission.BulkDelete(deletedata))
                {
                    TempData["Error"] = "خطایی رخ داده است";
                    return RedirectToAction("RolePermission", new { RoleId = RoleId });
                }

            }
            List<RolePermission> list = new List<RolePermission>();
            foreach (int i in PermissionList)
            {
                list.Add(new RolePermission()
                {
                    RoleId = RoleId,
                    PermissionListId = i
                });
            }
            list.AddRange(list);

            var obj = _permission.BulkInsert(list);
            if (obj)
            {
                TempData["Success"] = "عملیات با موفقیت انجام گردید";
                return RedirectToAction("Index", "Role");
            }
            else
            {
                TempData["Error"] = "خطایی رخ داده است";
                return RedirectToAction("Index", "Role");
            }
        }
    }
}
