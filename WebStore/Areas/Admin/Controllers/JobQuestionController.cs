using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    [Authorize]
    public class JobQuestionController : BaseController
    {
        private readonly IJobQuestion _jobQuestion;

        public JobQuestionController(IJobQuestion jobQuestion)
        {
            _jobQuestion = jobQuestion;
        }

        public IActionResult Index()
        {
            return View(_jobQuestion.GetAll());
        }
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobQuestion JobQuestion)
        {
            try

            {

                if (!ModelState.IsValid)
                {
                    return View(JobQuestion);
                }
            }
            catch
            {
                return View(JobQuestion);
            }
            try
            {


                var result = _jobQuestion.Insert(JobQuestion);
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

        // GET: RoleController/Edit/5
        public ActionResult Edit(int Id)
        {

            var result = _jobQuestion.GetQuestionById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobQuestion JobQuestion)
        {
            if (!ModelState.IsValid)
            {
                return View(JobQuestion);
            }




            var result = _jobQuestion.Update(JobQuestion);
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
