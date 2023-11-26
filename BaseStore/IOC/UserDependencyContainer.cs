using Core.Interface.Users;
using Core.Services.Users;
using Data.MasterInterface;
using Data.MasterServices;
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
         

            #region Survey

 

      
            #endregion

            #region User
            Services.AddScoped<IUser, UserServices>();
            Services.AddScoped<IPermisionList, PermissionListServices>();
            Services.AddScoped<IRole, RoleServices>();
            Services.AddScoped<IRolePermission, RolePermissionServices>();


            Services.AddScoped<IMaster<PermissionList>, MasterServices<PermissionList>>();
            Services.AddScoped<IMaster<User>, MasterServices<User>>();
            Services.AddScoped<IMaster<Role>, MasterServices<Role>>();
            Services.AddScoped<IMaster<RolePermission>, MasterServices<RolePermission>>();
            #endregion


        }
    }
}
