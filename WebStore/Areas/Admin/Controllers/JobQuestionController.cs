using Core.Interface.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
