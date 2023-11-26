using Microsoft.AspNetCore.Mvc;

namespace WebStore.Controller
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
