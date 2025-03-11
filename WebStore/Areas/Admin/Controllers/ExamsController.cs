using Core.Interface.Exam;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ExamsController : BaseController
    {
        private readonly ISubOption _subOption;

        public ExamsController(ISubOption subOption)
        {
            _subOption = subOption;
        }

        public IActionResult Index()
        {
            var obj = _subOption.GetAllQuestion();
            return View(obj);
        }
        [HttpPost]
        public IActionResult SubmitExam(Dictionary<int, Dictionary<int, List<int>>> SelectedOptions)
        {
            if (SelectedOptions != null)
            {
                foreach (var question in SelectedOptions)
                {
                    int questionId = question.Key;

                    foreach (var option in question.Value)
                    {
                        int optionId = option.Key;
                        List<int> selectedSubOptions = option.Value;

                        foreach (var subOptionId in selectedSubOptions)
                        {
                            Console.WriteLine($"QuestionId: {questionId}, OptionId: {optionId}, SelectedSubOptionId: {subOptionId}");
                        }
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
