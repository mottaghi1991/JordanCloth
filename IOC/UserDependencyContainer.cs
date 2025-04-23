
using Core.Dto.ViewModel.User;
using Core.Interface.Admin;
using Core.Interface.Store;
using Core.Interface.Users;
using Core.Services.Store;
using Core.Services.Users;
using Data.GenericRepository;
using Data.MasterInterface;
using Data.MasterServices;
using Domain.Store;
using Domain.User;
using Domain.User.Permission;
using Domain.Users;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public class UserDependencyContainer
    {
        public static void RegisterServices(IServiceCollection Services)
        {


            #region Admin
            Services.AddScoped<IUser, UserServices>();
            Services.AddScoped<IMaster<ShowUserBrifViewModel>, MasterServices<ShowUserBrifViewModel>>();



            #endregion

            #region User
            Services.AddScoped<IUser, UserServices>();
            Services.AddScoped<IPermisionList, PermissionListServices>();
            Services.AddScoped<IRole, RoleServices>();
            Services.AddScoped<IRolePermission, RolePermissionServices>();
            Services.AddScoped<IViewRender, RenderViewToStringServices>();


            Services.AddScoped<IMaster<PermissionList>, MasterServices<PermissionList>>();
            Services.AddScoped<IMaster<MyUser>, MasterServices<MyUser>>();
            Services.AddScoped<IMaster<Role>, MasterServices<Role>>();
            Services.AddScoped<IMaster<RolePermission>, MasterServices<RolePermission>>();
            Services.AddScoped<IMaster<UserRole>, MasterServices<UserRole>>();
            #endregion

            #region Store
            //Services.AddScoped<IGenericRepository<Product>, GenericRepository<Product>>();


            Services.AddScoped<IMaster<SubCategory>, MasterServices<SubCategory>>();
            Services.AddScoped<IMaster<FeatureValue>, MasterServices<FeatureValue>>();
            Services.AddScoped<IMaster<Product>, MasterServices<Product>>();
            Services.AddScoped<IMaster<Feature>, MasterServices<Feature>>();
            Services.AddScoped<IMaster<ProductTag>, MasterServices<ProductTag>>();




            Services.AddScoped<IProduct, ProductServies>();
            Services.AddScoped<IFeatureValue, FeatureValieServices>();
            Services.AddScoped<ISubcategory, SubCategoryServices>();
            Services.AddScoped<IFeature, FeatureServices>();
            Services.AddScoped<IProductTag, ProductTagServices>();


            #endregion

        }
    }
}
