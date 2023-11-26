using Core.Interface.Users;
using Core.Services.Survey;
using Core.Services.Users;
using Data.MasterInterface;
using Data.MasterServices;
using Domain.Survey;
using Domain.User;
using Domain.User.Permission;
using Domain.Users;
using Fuel_Core.Interface.Survey;
using Microsoft.Extensions.DependencyInjection;

namespace IOC
{
    public class UserDependencyContainer
    {
        public static void RegisterServices(IServiceCollection Services)
        {
         

            #region Survey

            Services.AddScoped<ISurveyList, SurveyServices>();
            Services.AddScoped<IQuestion, QuestionServices>();
            Services.AddScoped<IAnswer, AnswerServices>();

            Services.AddScoped<IMaster<SurveyList>, MasterServices<SurveyList>>();
            Services.AddScoped<IMaster<Question>, MasterServices<Question>>();
            Services.AddScoped<IMaster<Answer>, MasterServices<Answer>>();
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
