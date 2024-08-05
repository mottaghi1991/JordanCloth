using Data.MasterInterface;
using Domain.User.Permission;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Core.Extention;
using Domain;
using Domain.User;
using Core.Interface.Admin;
using Microsoft.Extensions.Logging;
using EventId = Core.Enums.EventId;

namespace NoorMehr.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PermissionListController : Controller
    {
        private IPermisionList _permisionList;
        private ILogger _logger;

        public PermissionListController(IPermisionList permisionList,ILogger<PermissionListController> logger)
        {
            _permisionList = permisionList;
            _logger = logger;
        }
        [HttpGet]
        public IActionResult ShowPermision(string MyArea, string SearchController )
        {
            if (MyArea == null)
            {
                ViewBag.Area = new SelectList(_permisionList.GetAllArea(), "Area", "Area", MyArea);
                ViewBag.Controller = new SelectList(_permisionList.GetControllerByArea(MyArea), "ControllerName", "ControllerName", SearchController);
                return View(_permisionList.GetAllParentPermissionList());
            }
            var obj = _permisionList.GetPermisionByAreaAndController(MyArea, SearchController);
            ViewBag.Area = new SelectList(_permisionList.GetAllArea(), "Area", "Area", MyArea);
            ViewBag.Controller = new SelectList(_permisionList.GetControllerByArea(MyArea), "ControllerName", "ControllerName", SearchController);
            return View(obj);


        }
        [HttpGet]
        public IActionResult Edit(int Id)
        {
            var result = _permisionList.GetById(Id);
            if (result == null)
            {
                _logger.LogWarning(EventId.NotFound, "User With UserId={UserId} search Id={ItemId} and not Found ", User.GetUserId(), Id);
                return NotFound();
            }

            if (result.Status == 1)
            {
                ViewBag.Parent = new SelectList(_permisionList.ParentList(), "Value", "Text", result.ParentId);
            }
            else
            {
                ViewBag.Parent = new SelectList(_permisionList.PermissionParentList(), "Value", "Text", result.ParentId);
                ViewBag.Controller = new SelectList(_permisionList.GetContrllersOfArea(result.ParentId.Value), "Value", "Text", result.PermissionListId.ToString());
            }


            return View(result);
        }
        [HttpPost]
        public IActionResult Edit(PermissionList permissionList)
        {
            if (!ModelState.IsValid)
            {
                return View(permissionList);
            }
            var obj = _permisionList.GetById(permissionList.PermissionListId);
            obj.ParentId = permissionList.ParentId!=-1?permissionList.ParentId:obj.ParentId;
            obj.Radif=permissionList.Radif;
            obj.Descript=permissionList.Descript;
            obj.Status=permissionList.Status;
            _permisionList.Update(obj);
            return RedirectToAction("ShowPermision",new { MyArea =obj.Area, SearchController =obj.ControllerName});
        }

        [HttpGet]
        public IActionResult Delete(int Id)
        {
            if (Id == null)
            {
                return BadRequest();
            }
            var result = _permisionList.GetById(Id);
            if (result == null)
            {
                return NotFound();
            }

            _permisionList.Delete(result);
            return RedirectToAction("ShowPermision");
        }



        [HttpGet]
        public ActionResult GetController(string MyArea)
        {
            var obj = new SelectList(_permisionList.GetControllerByArea(MyArea), "ControllerName", "ControllerName");
            return Json(obj);
        }
        public IActionResult insertArea()
        {
            var ali = ActionAndControllerNamesList();
         



            foreach (var item in ali)
            {


                int AreaId = 0;
                if (item.Area != null)
                {
                    if (_permisionList.checkExistArea(item.Area) == 0)
                    {
                        _permisionList.Insert(new PermissionList()
                        {
                            Area = item.Area,
                            ControllerName = null,
                            ActionName = null,
                            ParentId = null,
                            Descript = null,
                            Status = 0
                        });

                        AreaId = _permisionList.checkExistArea(item.Area);
                    }
                    else
                    {
                        AreaId = _permisionList.checkExistArea(item.Area);
                    }
                }
                else
                {
                    AreaId = _permisionList.checkExistArea(item.Area);
                }


                if (_permisionList.checkExistController(item.Area, item.Controller) == 0)
                {
                    var menu = new PermissionList()
                    {
                        Area = item.Area,
                        ControllerName = item.Controller,
                        ActionName = null,
                        ParentId = AreaId,
                        Descript = null,
                        Status = null

                    };
                    _permisionList.Insert(menu);
                    AreaId = _permisionList.checkExistController(item.Area, item.Controller);
                }
                else
                {
                    AreaId = _permisionList.checkExistController(item.Area, item.Controller);
                }
                if (!_permisionList.CheckExistPermission(item.Area, item.Controller, item.Action))
                {
                    var menu = new PermissionList()
                    {
                        Area = item.Area,
                        ControllerName = item.Controller,
                        ActionName = item.Action,
                        ParentId = AreaId,
                        Descript = null,
                        Status = null

                    };
                    _permisionList.Insert(menu);
                }

            }
            return RedirectToAction("ShowPermision", _permisionList.GetPermisionByAreaAndController(null,null));
        }
        public IList<ControllerActions> ActionAndControllerNamesList()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            var controlleractionlist = asm.GetTypes()
                .Where(type => typeof(Controller).IsAssignableFrom(type))
                .SelectMany(type => type.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public))
                .Select(x => new
                {
                    Controller = x.DeclaringType.Name,
                    Action = x.Name,
                    Area = x.DeclaringType.CustomAttributes.Where(c => c.AttributeType == typeof(AreaAttribute))

                }).ToList();
            var list = new List<ControllerActions>();
            foreach (var item in controlleractionlist)
            {
                if (item.Area.Count() != 0)
                {
                    list.Add(new ControllerActions()
                    {
                        Controller = item.Controller.Replace("Controller", null),
                        Action = item.Action,
                        Area = item.Area.Select(v => v.ConstructorArguments[0].Value.ToString()).FirstOrDefault()
                    });
                }
                else
                {
                    list.Add(new ControllerActions()
                    {
                        Controller = item.Controller.Replace("Controller", null),
                        Action = item.Action,
                        Area = null,
                        
                    });
                }
            }

            return list;
        }
        [HttpGet]
        public JsonResult FillParent(int Id)
        {
            if (Id == 0)
            {
                var result = new SelectList(_permisionList.GetAllParentPermissionList(), "SystemMenuID", "Description");

                return Json(result);
            }
            else
            {
                var result = new SelectList(_permisionList.ParentList(), "Value", "Text");

                return Json(result);
            }

        }
        public JsonResult FillController(int Id)
        {
            var result = new SelectList(_permisionList.GetContrllersOfArea(Id), "Value", "Text");

            return Json(result);
        }
    }
}
