using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.User.Permission;
using Microsoft.EntityFrameworkCore;
using Domain.Users;
using Domain.User;

using Domain;
using Domain.Store;

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

        #region Store
        public virtual DbSet<Category> Categories{ get; set; }
        public virtual DbSet<SubCategory> SubCategories{ get; set; }
        public virtual DbSet<Product> Products{ get; set; }
        public virtual DbSet<Product_ProductTag> Product_ProductTage{ get; set; }
        public virtual DbSet<ProductTag> ProductTags{ get; set; }
        public virtual DbSet<Feature> Features{ get; set; }
        public virtual DbSet<FeatureValue> FeatureValues{ get; set; }
        public virtual DbSet<ProductFeatureValue> ProductFeatureValues{ get; set; }


        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("dbo");
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                if (typeof(BaseModel).IsAssignableFrom(entityType.ClrType))
                {
                    var prop = entityType.FindProperty(nameof(BaseModel.IsDelete));
                    if (prop != null)
                    {
                        prop.SetDefaultValue(false);
                    }
                }
            }
            modelBuilder.Entity<ProductFeatureValue>()
    .HasKey(pf => new { pf.ProductId, pf.FeatureValueId });

            modelBuilder.Entity<ProductFeatureValue>()
                .HasOne(pf => pf.Product)
                .WithMany(p => p.FeatureValues)
                .HasForeignKey(pf => pf.ProductId)
                .OnDelete(DeleteBehavior.Restrict); // یا NoAction

            modelBuilder.Entity<ProductFeatureValue>()
                .HasOne(pf => pf.FeatureValue)
                .WithMany(fv => fv.ProductFeatureValues)
                .HasForeignKey(pf => pf.FeatureValueId)
                .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
