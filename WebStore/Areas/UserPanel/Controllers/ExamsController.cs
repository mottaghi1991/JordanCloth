using Core.Extention;
using Core.Interface.Exam;
using Domain.Exam;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using WebStore.Base;

namespace Personal.Areas.UserPanel.Controllers
{
    [Area(AreaNames.UserPanel)]
    public class ExamsController : BaseController
    {
        private readonly IJobQuestion _jobQuestion;
        private readonly IJobUserNaswer _jobUserNaswer;
        private readonly ISubOption _subOption;
        private readonly IQuestion _Question;
        private readonly IUserAnswer _userAnswer;
        private readonly IExamResult _examResult;
        private readonly IExamResultFinals _examResultFinal;
        private readonly INinQuestion _ninQuestion;
        private readonly INinExam _ninExam;


        public ExamsController(IJobQuestion jobQuestion, IJobUserNaswer jobUserNaswer, IUserAnswer userAnswer, IQuestion question, ISubOption subOption, IExamResult examResult, IExamResultFinals examResultFinal, INinQuestion ninQuestion, INinExam ninExam)
        {
            _jobQuestion = jobQuestion;
            _jobUserNaswer = jobUserNaswer;
            _userAnswer = userAnswer;
            _Question = question;
            _subOption = subOption;
            _examResult = examResult;
            _examResultFinal = examResultFinal;
            _ninQuestion = ninQuestion;
            _ninExam = ninExam;
        }

        public IActionResult Index()
        {
            var list = _examResult.GetListOfUserExamByUserId(User.GetUserId());
            return View(list);
        }
        public IActionResult JobExams()
        {
            if (_examResult.UserExistInExam(User.GetUserId(), 2))
            {
                TempData[warning] = "شما قبلا در این آزمون شرکت نموده اید";
                return RedirectToAction("Index");
            }
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

            return RedirectToAction("");
        }


        public IActionResult ShowMbtiResult()
        {
          var a=  _examResult.MBTIResult(User.GetUserId());
            var obj = _examResultFinal.resultFinal(a);
            return View(obj);
        }
        public IActionResult GetExam(int? QuestionId)
        {

            //noe azmon moshakhas gardad
            if (QuestionId == null)
            {
                return View(_subOption.GetAllQuestion(1));
            }
            int next = _Question.GetNextQuestionNum(QuestionId.Value);
            var obj = _subOption.GetAllQuestion(next);
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
                                ItUserId = User.GetUserId(),
                                Score=null
                            });


                        }
                    }
                }
                _subOption.BulkInsert(answers);
            }

            return RedirectToAction("GetExam", new { QuestionId = SelectedOptions.Keys.FirstOrDefault() });
        }
        [HttpPost]
        public IActionResult SubmitExamFour([FromForm] Dictionary<int, int> Answers, [FromForm] Dictionary<int, int> QuestionIds, [FromForm] Dictionary<int, int> OptionIds)
        {
            List<UserAnswer> answers = new List<UserAnswer>();
            foreach (var answer in Answers)
            {
                var subOptionId = answer.Key;
                var score = answer.Value;
                var questionId = QuestionIds[subOptionId];
                var optionId = OptionIds[subOptionId];

                answers.Add(new UserAnswer
                {
                    SubOptionId = subOptionId,
                    Score = score,
                    QuestionId = questionId,
                    OptionId = optionId,
                    ItUserId = User.GetUserId(),
                    InsertDate = DateTime.Now
                });

               
            }


            _subOption.BulkInsert(answers);
            return RedirectToAction("ExamResult");
        }

        public IActionResult ExamResult()
        {
            string Res = _examResult.HAlandResult(User.GetUserId());
            var Result= _examResultFinal.resultFinal(Res);
            return View(Result);
        }
        public IActionResult NinExam(int Seri)
        {
            IEnumerable<NinQuestion> Question =null;
            if (Seri==0)
            {
              Question=_ninQuestion.GetNinQuestionBySeriLevel(1);

            }
            else
            {
                Question = _ninQuestion.GetNinQuestionBySeriLevel(Seri);

            }
            ViewBag.NinOptions=_ninQuestion.GetAllNinOption();
            return View(Question);
        }
        [HttpPost]
        public IActionResult NinExamSubmit(Dictionary<int,int> Answer)
        {
            List<NinUserAnswer> Answers = new List<NinUserAnswer>();
            foreach (var pair in Answer)
            {
                int questionId = pair.Key;
                int selectedOptionIds = pair.Value;
                Answers.Add(new NinUserAnswer()
                {
                    ItUserId = User.GetUserId(),
                    ninOptionId = selectedOptionIds,
                    ninQuestionId = questionId,

                });
               
            }
          var Result= _ninExam.BulkInsertUserAnswer(Answers);
            var Question = _ninQuestion.GetNinQuestionById(Answer.FirstOrDefault().Key);
            var seri = _ninExam.GetSeriById(Question.seriId);
            if (seri.Level==3)
            {
                int check=0;
            }
            return RedirectToAction("NinExam", new
            {
                Seri = seri.Level + 1
            });
        
        }
    }
}
