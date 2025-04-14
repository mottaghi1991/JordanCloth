using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize]
    public class jobOptionController : BaseController
    {
        private readonly IJobOption _jobOption;
        private readonly IJobQuestion _jobQuestion;

        public jobOptionController(IJobOption jobOption, IJobQuestion jobQuestion)
        {
            _jobOption = jobOption;
            _jobQuestion = jobQuestion;
        }

        public IActionResult Index(int JobQuestionId)
        {
            var Question=_jobQuestion.GetQuestionById(JobQuestionId);
            var obj = new JpbOptionViewModel() {
            QuestionId=Question.Id,
            QuestionTitle=Question.Title,
            jobOptions= _jobOption.JobOptionByQuestionId(JobQuestionId)
            };
            return View(obj);
        }
        public ActionResult Create(int QuestionId)
        {
            ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Id", "Title");
            
            return View(new JobOption()
            {
                JobQuestionId=QuestionId,
            });
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(JobOption option)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Title", "Id",option.jobGroupIndexId);
                return View(option);
            }


            try
            {


                var result = _jobOption.Insert(option);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index",new { JobQuestionId =result.JobQuestionId});
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Title", "Id", option.jobGroupIndexId);
                    return View(option);
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Title", "Id", option.jobGroupIndexId);
                return View(option);
            }





        }
        public ActionResult Edit(int Id)
        {      var result = _jobOption.GetJobOptionById(Id);
            if (result == null)
            {
                return NotFound();
            }

            ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Id", "Title",result.jobGroupIndexId);

            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(JobOption JobOption)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Id", "Title", JobOption.jobGroupIndexId);
                return View(JobOption);
            }
              var result = _jobOption.Update(JobOption);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index", new { JobQuestionId = result.JobQuestionId });
            }
            else
            {
                TempData[Error] = ErrorMessage;
                ViewBag.JobGroup = new SelectList(_jobOption.AllJobGroupIndex(), "Id", "Title", JobOption.jobGroupIndexId);
                return View(JobOption);
            }

        }
    }
}
