using Microsoft.AspNetCore.Mvc;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class AdminHomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        [Route("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
