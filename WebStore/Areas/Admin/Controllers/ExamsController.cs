using Core.Interface.Exam;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using WebStore.Base;
using Domain.Exam;
using System.Linq;
using Core.Extention;
using Microsoft.AspNetCore.Authorization;
using Core.Dto.ViewModel.User;
using Core.Dto.ViewModel.Exam;
using Core.Interface.Users;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    [Authorize]
    public class ExamsController : BaseController
    {

        private readonly IExamResult _examResult;
        private readonly IExamResultFinals _examResultFinal;
        private readonly IUser _user;

        public ExamsController(IExamResult examResult, IExamResultFinals examResultFinal, IUser user)
        {
            _examResult = examResult;
            _examResultFinal = examResultFinal;
            _user = user;
        }

        public IActionResult Index()
        {
          return View();
        }
        public IActionResult GetUserDoneExam(int ExamId)
        {
            var Exam=_examResult.examById(ExamId);
            if (Exam==null)
            {
                return NotFound();
            }
            return View(new ShowUsersExam
            {
                ExamId=ExamId,
                ExamTitle=Exam.Title,
                UsersList= _examResult.GetListOfUserDoneExam(ExamId)
            });
        }
        public IActionResult UserExamInfo(int UserId,int ExamId)
        {
            switch(ExamId)
            {
                case (int)Core.Enums.ExamId.Haland:
                    string letter = _examResult.HAlandResult(UserId);
                    var obj = new ShowExamDetailToAdmin()
                    {
                        examDetailItems = _examResult.GetHalandResultDetailByUserId(UserId),
                        examResultFinal = _examResultFinal.resultFinal(letter)
                    };
                     
                    return View(obj);
                   
                case (int)Core.Enums.ExamId.MBTI:
                     letter = _examResult.MBTIResult(UserId);
                     obj = new ShowExamDetailToAdmin()
                    {
                        examDetailItems = _examResult.GetMBTIResultDetailByUserId(UserId),
                        examResultFinal = _examResultFinal.resultFinal(letter)
                    };
                    return View(obj);
                  
                case (int)Core.Enums.ExamId.Anageram:
                    letter = _examResult.AnageramResult(UserId);
                    obj = new ShowExamDetailToAdmin()
                    {
                        examDetailItems = _examResult.GetAnageramResultDetailByUserId(UserId),
                        examResultFinal = _examResultFinal.resultFinal(letter)
                    };
                    return View(obj);
                 
                default:
                    return View(new ExamResultFinal()
                    {
                        Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                        FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید"
                    });
                 
            }
              return View(new ExamResultFinal()
            {
                Descript = "لطفا با دفتر موسسه تماس حاصل فرمائید",
                FinalResult = "لطفا با دفتر موسسه تماس حاصل فرمائید"
            });
        }
        public IActionResult GetExamOfUser(int UserId)
        {
            var User=_user.GetUserByUserId(UserId);
            if (User == null)
            {
                return NotFound();
            }
            return View(new ShowExamOfUserViewModel()
            {
                UserId = UserId,
                UserName = User.UserName,
                examLists = _examResult.GetListOFExamDoneWithUser(UserId)
            });


              
        }

    }
}
