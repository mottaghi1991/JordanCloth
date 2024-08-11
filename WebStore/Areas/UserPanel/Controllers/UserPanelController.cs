using Microsoft.AspNetCore.Mvc;

namespace WebStore.Areas.UserPanel.Controllers
{
    [Area("UserPanel")]
    public class UserPanelController : Microsoft.AspNetCore.Mvc.Controller
    {
    
        public IActionResult Index()
        {
            return View();
        }
    }
}
