using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User.Permission;
using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Domain.User;

namespace Data
{
    public class MyContext:DbContext
    {
        public MyContext(DbContextOptions<MyContext> options):base(options)
        {
            
        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<PermissionList> PermissionList { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<RolePermission> RolePermission { get; set; }

 




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}
