using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Interface.Admin;
using Data.MasterInterface;
using Domain.User;
using Domain.User.Permission;

namespace Core.Services.Users
{
    public class RoleServices : IRole
    {
        private readonly  IMaster<Role> _master;
        private readonly  IMaster<UserRole> _UserRolemaster;

        public RoleServices(IMaster<Role> master, IMaster<UserRole> userRolemaster)
        {
            _master = master;
            _UserRolemaster = userRolemaster;
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

        public IEnumerable<UserRole> GetAllUSerOfRole(int RoleId)
        {
            return _UserRolemaster.GetAll(a => a.RoleId == RoleId);
        }

        public bool BulkDelete(IEnumerable<UserRole> List)
        {
            return _UserRolemaster.BulkeDelete(List);
        }

        public bool BulkInsert(IEnumerable<UserRole> List)
        {
            return _UserRolemaster.BulkeInsert(List.ToList());
        }

        public bool UserRoleInsert(UserRole userRole)
        {
            var result = _UserRolemaster.Insert(userRole);
            return result==null?false:true;
        }
    }
}
