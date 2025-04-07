using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Core.Dto.ViewModel.Admin.Role;
using Core.Dto.ViewModel.User;
using Core.Interface.Admin;
using Core.Interface.Users;
using Domain.User;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IUser _user;
        private readonly IRole _role;

        public UserController(IUser user,IRole role)
        {
            _user = user;
            _role = role;
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
      
    }
}
