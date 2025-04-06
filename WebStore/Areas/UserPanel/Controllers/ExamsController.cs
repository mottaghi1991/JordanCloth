using Core.Extention;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebStore.Base;

namespace Personal.Areas.UserPanel.Controllers
{
    [Area(AreaNames.UserPanel)]
    public class ExamsController : BaseController
    {
        private readonly IJobQuestion _jobQuestion;
        private readonly IJobUserNaswer _jobUserNaswer;

        public ExamsController(IJobQuestion jobQuestion, IJobUserNaswer jobUserNaswer)
        {
            _jobQuestion = jobQuestion;
            _jobUserNaswer = jobUserNaswer;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult JobExams()
        {
           
            return View(_jobQuestion.ShowJobExamToUser());
        }
        [HttpPost]
        public IActionResult SubmitJobTest(Dictionary<int,int> Answers)
        {
             List<JobUserAnswer> List=new List<JobUserAnswer>();
            foreach(var answer in Answers)
            {
                List.Add(new JobUserAnswer
                {
                    JobQuestionId = answer.Key,
                    OptionId = answer.Value,
                    UserId = User.GetUserId()
                });
            
            }
            _jobUserNaswer.BulkInsert(List);

            return View();
        }
    }
}
