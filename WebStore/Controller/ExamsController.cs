using Core.Interface.Exam;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebStore.Base;

namespace Personal.Controller
{
    public class ExamsController : BaseController
    {
        private readonly ISubOption _subOption;

        public ExamsController(ISubOption subOption)
        {
            _subOption = subOption;
        }

        public IActionResult Index()
        {
           
            return View();
        }
      
    }
}
