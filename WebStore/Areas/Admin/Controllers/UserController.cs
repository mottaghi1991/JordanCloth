using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Dto.ViewModel.Admin.Role;
using Core.Dto.ViewModel.User;
using Core.Interface.Admin;
using Core.Interface.Exam;
using Core.Interface.Users;
using Core.Tools;
using Domain.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;
using Mysqlx;
using WebStore.Base;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class UserController : BaseController
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
        public IActionResult Index(int pageid = 1)
        {
            var obj = _user.GetPAggingUser(1, 10);
            return View(obj);
        }
        public IActionResult UserExam(string Username)
        {
            var User = _user.GetUserByUserName(Username);

            return View(new ShowUserBrifViewModel()
            {
                UserName = Username,
            });
        }
   
        public IActionResult ShowExamDetail(int UserId)
        {
            var obj = _subOption.GetAllQuestion(0);
            return View(obj);
        }

        public IActionResult Edit(int UserId)
        {
            var User = _user.GetUserByUserId(UserId);
            if (User == null)
            {
                return NotFound();
            }

            return View(new AdminUserEditViewModel()
            {
                ItUserId = UserId,
                UserName = User.UserName,
                PassWord = null,
             
            });
        }
        [HttpPost]
        public IActionResult Edit(AdminUserEditViewModel UserModel)
        {
            if(!ModelState.IsValid)
            {
                return View(UserModel);
            }
            var User = _user.GetUserByUserId(UserModel.ItUserId);
            if (User == null)
            {
                TempData[Error] = ErrorMessage;
                return View(UserModel);
            }
            User.PassWord = PasswordHelper.EncodePasswordMD5(UserModel.PassWord);
          
            var Result = _user.Update(User);
            if(Result==null)
            {
                TempData[Error] = ErrorMessage;
                return View(UserModel);
            }
            else
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");

            }
          
        }
        public IActionResult ChangePosition(int UserId)
        {
            var User = _user.GetUserByUserId(UserId);
            if (User == null)
                return NotFound();
            User.IsAdmin = true;
            var result = _user.Update(User);
            if(result==null)
            {
                TempData[Error] = ErrorMessage;
               return RedirectToAction("Index");
            }
            TempData[Success] = SuccessMessage;
               return RedirectToAction("Index");

        }

    }
}
