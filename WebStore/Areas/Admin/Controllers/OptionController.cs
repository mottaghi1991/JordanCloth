using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI.Common;
using System;
using System.Linq;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize]
    public class OptionController : BaseController
    {
        private readonly IOption _option;
        private readonly IQuestion _question;

        public OptionController(IOption option, IQuestion question)
        {
            _option = option;
            _question = question;
        }

        public IActionResult Index(int QuestionId)
        {
           

            var Question = _question.GetQuestionById(QuestionId);
            if(Question==null)
            {
                return NotFound();
            }
            return View(new OptionViewModel()
            {
                QuestionId=Question.Id,
                QuestionTitle=Question.Title,
                options= _option.GetOptionByQuestionId(QuestionId).ToList()
            });
        }
        public ActionResult Create(int QuestionId)
        {
            return View(new Option()
            {
                QuestionId=QuestionId
            });
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
                    return RedirectToAction("Index", new { QuestionId =result.QuestionId});
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return View(option);
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                return View(option);
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
                return RedirectToAction("Index", new { QuestionId =result.QuestionId});
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return View(option);
            }

        }
    }
}
