using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace WebStore.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AdminHomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IDistributedCache _cache;

        public AdminHomeController(IDistributedCache cache)
        {
            _cache = cache;
        }
        [Route("Admin")]
        public IActionResult Index()
        {
           
            return View();
        }

    
    }
}
