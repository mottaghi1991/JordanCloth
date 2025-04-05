using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class OptionController : BaseController
    {
        private readonly IOption _option;

        public OptionController(IOption option)
        {
            _option = option;
        }

        public IActionResult Index(int QuestionId)
        {
            TempData["QuestionId"] = QuestionId;
            return View(_option.GetAllOptions());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Option option)
        {
           

                if (!ModelState.IsValid)
                {
                    return View(option);
                }
         

            try
            {


                var result =_option.Insert(option);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                return RedirectToAction("Index");
            }





        }
        public ActionResult Edit(int Id)
        {

            var result =_option.GetOptionById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Option option)
        {
            if (!ModelState.IsValid)
            {
                return View(option);
            }




            var result =_option.Update(option);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return RedirectToAction("Index");
            }

        }
    }
}
