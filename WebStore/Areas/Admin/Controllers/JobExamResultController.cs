using Core.Enums;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class JobExamResultController : BaseController
    {
        private readonly IExamResultFinals _examResultFinals;

        public JobExamResultController(IExamResultFinals examResultFinals)
        {
            _examResultFinals = examResultFinals;
        }

        public IActionResult Index(int ExamId)
        {

            return View(_examResultFinals.resultFinalByExamId(ExamId));
        }
        public IActionResult Edit(int ResultId)
        {
            var obj=_examResultFinals.resultFinalById(ResultId);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(ExamResultFinal examResultFinals)
        {
            if(!ModelState.IsValid)
            {
                return View(examResultFinals);
            }
            var result = _examResultFinals.Update(examResultFinals);
          
            if (result == null)
            {
                TempData[Error] = ErrorMessage;
                return View(examResultFinals);
            }
            TempData[Success] = SuccessMessage;
            return RedirectToAction("Index",new { ExamId = result.ExamId });
        }
        public IActionResult Create()
        {
            return View(new ExamResultFinal() { ExamId=1});
        }
        [HttpPost]
        public IActionResult Create(ExamResultFinal examResultFinal)
        {
            if (!ModelState.IsValid)
            {
                return View(examResultFinal);
            }
            var result = _examResultFinals.Insert(examResultFinal);

            if (result == null)
            {
                TempData[Error] = ErrorMessage;
                return View(examResultFinal);
            }
            TempData[Success] = SuccessMessage;
            return RedirectToAction("Index", new { ExamId = result.ExamId });
      
        }
    }
}
