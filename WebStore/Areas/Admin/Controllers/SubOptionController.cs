using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize]
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

        public IActionResult Index(int questionId,int optionId)
        {
            if (questionId == 0 || optionId == 0) { return NotFound(); }

            var Question= _Question.GetQuestionById(questionId);
            var Option = _Option.GetOptionById(optionId);
            return View(new SubOptionViewModel()
            {
                QuestionId=Question.Id,
                QuestionTitle=Question.Title,
                OptionId=Option.Id,
                OptionTitle=Option.Title,
               subOptions= _subOption.GetSubOptionByQuestionAndOption(questionId,optionId)
            });
        }
        public ActionResult Create(int questionId, int optionId)
        {
     
            return View(new SubOption()
            {
                OptionId=optionId,
                QuestionId=questionId
            });
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubOption subOption)
        {


            if (!ModelState.IsValid)
            {
        
                return View(subOption);
            }


            try
            {


                var result = _subOption.Insert(subOption);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index", new { questionId =result.QuestionId, optionId =result.OptionId});
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return View(subOption);
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                return View(subOption);
            }





        }
        public ActionResult Edit(int SubOptionId)
        {
            var obj=_subOption.GetSubOptionById(SubOptionId);
            return View(obj);
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubOption subOption)
        {


            if (!ModelState.IsValid)
            {

                return View(subOption);
            }


            try
            {


                var result = _subOption.update(subOption);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index", new { questionId = result.QuestionId, optionId = result.OptionId });
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return View(subOption);
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                return View(subOption);
            }





        }
    }
}
