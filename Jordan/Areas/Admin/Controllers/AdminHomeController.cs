using Microsoft.AspNetCore.Mvc;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class AdminHomeController : BaseController
    {
        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
