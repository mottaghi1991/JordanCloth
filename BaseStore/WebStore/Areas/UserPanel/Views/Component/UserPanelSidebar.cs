using System.Threading.Tasks;
using Core.Interface.Users;
using Microsoft.AspNetCore.Mvc;

namespace WebStore.Areas.UserPanel.Views.Component
{
    public class UserPanelSidebar : ViewComponent
    {
        private readonly IUser _user;

        public UserPanelSidebar(IUser user)
        {
            _user = user;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View("~/Areas/UserPanel/Views/Component/UserPanelSidebar.cshtml", _user.GetUserPanel(User.Identity.Name));
        }
    }
}
