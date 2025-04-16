using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using Core.Dto.ViewModel.User;
using Core.Extention;
using Core.Interface.Admin;
using Core.Interface.Users;
using Core.Tools;
using Domain.User;
using Domain.User.Permission;
using Fuel_Core;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using WebStore.Base;
using EventId = Domain.EventId;

namespace WebStore.Controller
{
    public class AccountController : BaseController
    {
        private IUser _user;
        private IRole _Role;
        private IViewRender _viewRender;
        private readonly ILogger _logger;
        public AccountController(IUser user, IViewRender viewRender, ILoggerFactory factory, IRole role)
        {
            _user = user;
            _viewRender = viewRender;
            _logger = factory.CreateLogger("Session");
            _Role = role;
        }
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (_user.ISExistUserName(model.UserName))
            {
                ModelState.AddModelError("UserName","نام کاربری معتبر نمی باشد");
                return View(model);
            }
            if (_user.ISExistEmail(model.UserName))
            {
                ModelState.AddModelError("UserName", "نام کاربری معتبر نمی باشد");
                return View(model);
            }

            var user = new MyUser()
            {
                UserName = model.UserName,
                Email = StringTools.FixEmail(model.UserName),
                IsActive = true,
                PassWord =PasswordHelper.EncodePasswordMD5(model.PassWord) ,
                RegisterDate = DateTime.Now,
                UserAvatar = "default.jpg",
                IsAdmin = false,
                ActiveCode = StringTools.GenerateUniqeCode()
            };
            var result = _user.AddUser(user);
            _Role.UserRoleInsert (new UserRole()
            {
                RoleId = 2,
                UserId = result.ItUserId
            });
            if(result!=null)
            {
                TempData[Success] = "ثبت نام با موفقیت انجام شد";

            }
            else
            {
                ModelState.AddModelError("UserName", "در حال حاصر سیستم در حال برزورسانی است");
                return View(model);
            }
            //Send Active Code
            return RedirectToAction("Login");
        }
      
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();

        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login(LoginViewModel loginViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            var user = _user.LoginCheck(loginViewModel);
            if (user==null)
            {
                _logger.LogWarning(EventId.Login,"User with {Email} Can not login",loginViewModel.UserName);
                ModelState.AddModelError("UserName","نام کاربری یا رمز عبور اشتباه می باشد");
                return View(loginViewModel);
            }
            else
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,user.ItUserId.ToString()),
                    new Claim(ClaimTypes.Name,user.UserName)
                };
                var identity=new ClaimsIdentity(claims,CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var Properties = new AuthenticationProperties()
                {
                    IsPersistent = loginViewModel.IsRemember
                };
                HttpContext.SignInAsync(principal, Properties);
                _logger.LogWarning(EventId.Login, "User with {Email} login", loginViewModel.UserName);

                if (user.IsAdmin==true)
                {
                    return RedirectToAction("Index", "AdminHome", new { area = AreaNames.Admin });
                }
                else
                {
                    return RedirectToAction("Index", "Exams", new { area = AreaNames.UserPanel });
                }
             
            }
            
        }
        [Route("Logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            HttpContext.SignOutAsync();
          
            return RedirectToAction("Index","Home");
        }

        [HttpGet]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword()
        {
            return View();
        }
        [HttpPost]
        [Route("ForgetPassword")]
        public IActionResult ForgetPassword(string Email)
        {
            if (Email==null)
            {
                return NotFound();
            }

            var User = _user.ISExistEmail(StringTools.FixEmail(email: Email));
            if (!User )
            {
                ModelState.AddModelError("UserName", "ایمیلی با این مشخصات ثبت نگردیده است");
                return View();
                
            }
            else
            {
                var u = _user.GetUserByUserName(StringTools.FixEmail(Email));
                //send Email
                string body = _viewRender.RenderToStringAsync("_ActiveEmail", u);
                Core.Tools.SendEmail.Send(u.Email, "فعالسازی", body);
                ModelState.AddModelError("Email", "ایمیل حاوی لینک تغییر رمز عبور برای شما ارسال گردید");
                ModelState.AddModelError("Email", "در صورت پیدا نکردن ایمیل قسمت spanرا چک فرمائید");

            }
            return View();
        }

        [HttpGet]
        public IActionResult ActiveAccount(string Code)
        {
            var ok = _user.IsActiveCode(Code);
            if (ok)
            {
              return  RedirectToAction("ResetPassword", new { ActiveCode = Code });
            }
            TempData["Error"] = "زمان کد منقضی گردیده است";
            return RedirectToAction("ForgetPassword");
        }

        public IActionResult ResetPassword(string ActiveCode)
        {
            ResetPasswordViewModel model = new ResetPasswordViewModel()
            {
                ActiveCode = ActiveCode
            };
            return View(model);
            
        }
        [HttpPost]
        public IActionResult ResetPassword(ResetPasswordViewModel Model)
        {
            if (!ModelState.IsValid)
            {
                return View(Model);
            }
            var ok = _user.IsActiveCode(Model.ActiveCode);
            if (!ok)
            {
                return BadRequest();
            }

            var user = _user.GetUserByActiveCode(Model.ActiveCode);
            if (user != null)
            {
                user.PassWord=PasswordHelper.EncodePasswordMD5(Model.PassWord);
                var Result = _user.Update(user);
                if (Result!=null)
                {
                    TempData["Success"] = "رمز عبور با موفقیت تغییر پیدا کرد";
                    return RedirectToAction("login");
                }
                TempData["Error"] = "رمز عبور تغییر پیدا نکرد";
                return RedirectToAction("Login");
            }
            return View();
        }
    }
}
