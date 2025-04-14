using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Dto.ViewModel.User;
using Core.Interface.Users;
using Core.Tools;
using Data.MasterInterface;
using Domain.User;
using Domain.Users;

namespace Core.Services.Users
{
    public class UserServices : IUser
    {
        private readonly IMaster<MyUser> _User;

        public UserServices(IMaster<MyUser> user)
        {
        _User=user;
        }

     

        public bool ISExistUserName(string userName)
        {
            var obj= _User.GetAll(a => a.UserName == userName).Any();
            return obj;
        }

        public bool ISExistEmail(string Email)
        {
            return _User.GetAll(a => a.Email ==StringTools.FixEmail(Email)).Any();
        }

        public MyUser AddUser(MyUser user)
        {
            return _User.Insert(user);
        }

        public MyUser LoginCheck(LoginViewModel model)
        {
            try
            {
                return _User.GetAllEf(a =>
                a.UserName == StringTools.FixEmail(model.UserName) &&
                a.PassWord == PasswordHelper.EncodePasswordMD5(model.PassWord) & a.IsActive == true).FirstOrDefault();

            }
            catch (Exception ex) { 
                return null;
            }
          
        }

        public InformationUserViewModel GetUserInformation(string userName)
        {
            var user = GetUserByUserName(userName);
            var infomation=new InformationUserViewModel()
            {
                Email = user.Email,
                UserName = user.UserName,
                RegisterDate = user.RegisterDate,
                Wallet = 0
            };
            return infomation;
        }

        public MyUser GetUserByUserName(string userName)
        {
            return _User.GetAll(a => a.UserName == StringTools.FixEmail(userName)).SingleOrDefault();
        }

        public int BalanceUserWallet(string userName)
        {
            throw new NotImplementedException();
        }

        public UserPanelViewModel GetUserPanel(string userName)
        {
            return _User.GetAll(a => a.UserName == StringTools.FixEmail(userName)).Select(u => new UserPanelViewModel()
            {
                Name = u.Email,
                Image = u.UserAvatar
            }).Single();
        }

        public bool IsActiveCode(string code)
        {
            return _User.GetAll(a => a.ActiveCode == code).Any();
        }

        public MyUser GetUserByActiveCode(string code)
        {
            return _User.GetAll(a => a.ActiveCode == code).FirstOrDefault();
        }

        public MyUser Update(MyUser user)
        {
            return _User.Update(user);
        }

        public IEnumerable<ShowUserBrifViewModel> GetPAggingUser(int Page, int pagesize)
        {
            return _User.GetPaging(Page,pagesize).Select(a=>new ShowUserBrifViewModel(){Email = a.Email,UserName = a.UserName,UserId = a.ItUserId});
        }

        public IEnumerable<ShowUserBrifViewModel> GetAllAdmin()
        {
            return _User.GetAll(a=>a.IsAdmin==true).Select(a => new ShowUserBrifViewModel() { Email = a.Email, UserName = a.UserName, UserId = a.ItUserId });
        }

        public MyUser GetUserByUserId(int userId)
        {
         return _User.GetAllEf(a=>a.ItUserId == userId).FirstOrDefault();
        }
    }
}
