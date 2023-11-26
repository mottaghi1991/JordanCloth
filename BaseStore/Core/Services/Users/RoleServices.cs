using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface.Users;
using Data.MasterInterface;
using Domain.User.Permission;

namespace Core.Services.Users
{
    public class RoleServices:IRole
    {
        private readonly  IMaster<Role> _master;

        public RoleServices(IMaster<Role> master)
        {
            _master = master;
        }
        public IEnumerable<Role> GetAllRole()
        {
            return _master.GetAll();
        }

        public Role GetRole(int RoleId)
        {
            return _master.GetAll(a => a.RoleId == RoleId).FirstOrDefault();
        }

        public Role insert(Role role)
        {
            return _master.Insert(role);
        }

        public Role update(Role role)
        {
            return _master.Update(role);
        }

        public bool delete(Role role)
        {
            return _master.Delete(role);
        }
    }
}
