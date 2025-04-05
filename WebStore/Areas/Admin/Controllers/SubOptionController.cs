using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class SubOptionController : BaseController
    {
        private readonly ISubOption _subOption;
        private readonly IQuestion _Question;
        private readonly IOption _Option;

        public SubOptionController(ISubOption subOption, IQuestion question, IOption option)
        {
            _subOption = subOption;
            _Question = question;
            _Option = option;
        }

        public IActionResult Index(int? questionId,int? optionId)
        {
            ViewBag.Questions = new SelectList(_Question.GetAllQuestions(), "Id", "Title");
            ViewBag.options = new SelectList(_Option.GetAllOptions(), "Id", "Title");
            if (questionId == null || optionId == null)
            {
                return View(_subOption.GetAllSubOptions()); 
            }
            
            return View(_subOption.GetSubOptionByQuestionAndOption(questionId.Value,optionId.Value));
        }
        public ActionResult Create()
        {
            ViewBag.Questions = new SelectList(_Question.GetAllQuestions(), "Id", "Title");
            ViewBag.options = new SelectList(_Option.GetAllOptions(), "Id", "Title");
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubOption subOption)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.Questions = new SelectList(_Question.GetAllQuestions(), "Id", "Title",subOption.QuestionId);
                ViewBag.options = new SelectList(_Option.GetAllOptions(), "Id", "Title",subOption.OptionId);
                return View(subOption);
            }


            try
            {


                var result = _subOption.Insert(subOption);
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
    }
}
