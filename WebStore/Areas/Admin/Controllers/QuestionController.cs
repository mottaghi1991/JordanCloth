using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class QuestionController : BaseController
    {
        private readonly IQuestion _question;

        public QuestionController(IQuestion question)
        {
            _question = question;
        }
        public  IActionResult MangeExamHaland()
        {
            return View();
        }
        public IActionResult Index()
        {
            return View(_question.GetAllQuestions());
        }
        // GET: RoleController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Question question )
        {
            try

            {

                if (!ModelState.IsValid)
                {
                    return View(question);
                }
            }
            catch
            {
                return View(question);
            }

            try
            {
              

                var result = _question.Insert(question);
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

            var result =_question.GetQuestionById(Id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Question question)
        {
            if (!ModelState.IsValid)
            {
                return View(question);
            }

           

           
            var result = _question.Update(question);
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

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {


           
            var obj = _question.GetQuestionById(id);
            if (obj == null)
            {
                return NotFound();
            }

            if (_question.GetQuestionById(id)!=null)
            {
                TempData["Error"] = "منو دارای مجموعه می باشد لطفا ابتدا آنها را پاک کنید";
                return RedirectToAction("Index");
            }
          
            var result = _question.Delete(id);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            TempData[Error] = ErrorMessage;
            return RedirectToAction("Index");


        }
    }
}
