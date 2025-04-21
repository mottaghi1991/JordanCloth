using Core.Dto.ViewModel.User;
using Core.Extention;
using Core.Interface.Users;
using Core.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static WebStore.Base.BaseController;

namespace Personal.Areas.UserPanel.Controllers
{
    [Authorize]
    [Area(areaName: AreaNames.UserPanel)]
    public class UserController : Controller
    {
        private readonly IUser _User;

        public UserController(IUser user)
        {
            _User = user;
        }

        public IActionResult CHangePassword()
        {
           
            return View();
        }
        [HttpPost]
        public IActionResult CHangePassword(ChangePasswordViewModel model)
        {
            var CurrentUser = _User.GetUserByUserId(User.GetUserId());
            if(CurrentUser.PassWord!=PasswordHelper.EncodePasswordMD5(model.OldPassWord))
            {
                ModelState.AddModelError("OldPassWord", "رمز عبور قدیمی اشتباه می باشد");
                return View(model);
            }
            if (CurrentUser.PassWord != model.RePassword)
            {
                ModelState.AddModelError("OldPassWord", "رمز عبور و تکرار آن یکسان نمی باشد");
                return View(model);
            }
            CurrentUser.PassWord = PasswordHelper.EncodePasswordMD5(model.PassWord);
            var Result = _User.Update(CurrentUser);
            if (Result == null)
            {
                TempData[Error] = ErrorMessage;
                return View(CurrentUser);
            }
            else
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");

            }
            return View();
        }

    }
}
