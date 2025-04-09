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
      
    }
}
