using Core.Interface.Exam;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebStore.Base;
using Domain.Exam;
using System.Linq;
using Core.Extention;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ExamsController : BaseController
    {
        private readonly ISubOption _subOption;
        private readonly IQuestion _Question;
        private readonly IUserAnswer _userAnswer;

        public ExamsController(ISubOption subOption, IQuestion question, IUserAnswer userAnswer)
        {
            _subOption = subOption;
            _Question = question;
            _userAnswer = userAnswer;
        }

        public IActionResult Index()
        {
          return View();
        }
        public IActionResult GetExam(int? QuestionId)
        {

            //noe azmon moshakhas gardad
       if(QuestionId==null)
            {
                return View(_subOption.GetAllQuestion(1));
            }
            int next = _Question.GetNextQuestionNum(QuestionId.Value);
            if (next == 0)
            {
                return RedirectToAction("ExamResult");
            }
            var obj =_subOption.GetAllQuestion(next); 
            return View(obj);

        }
        [HttpPost]
        public IActionResult SubmitExam(Dictionary<int, Dictionary<int, List<int>>> SelectedOptions)
        {
            if (SelectedOptions != null)
            {
                List<UserAnswer> answers = new List<UserAnswer>();
                foreach (var question in SelectedOptions)
                {
                    int questionId = question.Key;
                  
                    foreach (var option in question.Value)
                    {
                        int optionId = option.Key;
                        List<int> selectedSubOptions = option.Value;

                        foreach (var subOptionId in selectedSubOptions)
                        {
                            answers.Add(new UserAnswer
                            {
                                QuestionId = questionId,
                                OptionId = optionId,
                                SubOptionId = subOptionId,
                                ItUserId = User.GetUserId()
                            });
                           
                           
                        }
                    }
                }
                _subOption.BulkInsert(answers);
            }

            return RedirectToAction("GetExam", new { QuestionId = SelectedOptions.Keys.FirstOrDefault()});
        }
        public IActionResult ExamResult()
        {

            return View(_userAnswer.ExamResult());
        }
    }
}
