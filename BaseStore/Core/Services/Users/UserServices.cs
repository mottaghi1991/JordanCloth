using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface.Users;
using Data.MasterInterface;
using Domain.User;
using Domain.Users;

namespace Core.Services.Users
{
    public class UserServices:IUser
    {
        private readonly IMaster<User> _User;

        public UserServices(IMaster<User> user)
        {
        _User=user;
        }

        public List<User> UserPermissions()
        {
          return  _User.GetAll().ToList();
        }
    }
}
