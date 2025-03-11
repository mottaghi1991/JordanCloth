using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User.Permission;
using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Domain.User;
using Domain.Exam;

namespace Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
        #region Permission
        public virtual DbSet<MyUser> MyUser { get; set; }
        public virtual DbSet<PermissionList> PermissionList { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }
        #endregion

        public virtual DbSet<Question> Questions{ get; set; }
        public virtual DbSet<Option> Options{ get; set; }
        public virtual DbSet<SubOption> SubOptions{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
