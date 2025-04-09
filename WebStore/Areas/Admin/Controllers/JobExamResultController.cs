using Core.Interface.Exam;
using Microsoft.AspNetCore.Mvc;
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
    }
}
