using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Dto.ViewModel.Admin.Role;
using Core.Dto.ViewModel.User;
using Core.Interface.Admin;
using Core.Interface.Exam;
using Core.Interface.Users;
using Domain.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly ISubOption _subOption;


        public UserController(IUser user, IRole role, ISubOption subOption)
        {
            _user = user;
            _role = role;
            _subOption = subOption;
        }
        public IActionResult Index(int pageid=1)
        {
            var obj=_user.GetPAggingUser(1,10);
            return View(obj);
        }
        public IActionResult UserExam(string Username)
        {
            var User=_user.GetUserByUserName(Username);

            return View(new ShowUserBrifViewModel()
            {
                UserName = Username, 
            });
        }
        public IActionResult ExamDetail(/*int UserId,int ExamId*/)
        {
            int ExamId = 1;
            switch (ExamId)
            {
                case 1:
                    return RedirectToAction("ShowExamDetail", new { UserId =4});
                    break;
                case 2:
                    return RedirectToAction("");
                    break;
                case 3:
                    return RedirectToAction("");
                    break;
                default:
                    return RedirectToAction("");
                    break;
            }
        }
        public IActionResult ShowExamDetail(int UserId)
        {
            var obj = _subOption.GetAllQuestion(0);
            return View(obj);
        }
      
    }
}
