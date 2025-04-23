using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class SubCategoryController : BaseController
    {
        private readonly ISubcategory _subcategory;

        public SubCategoryController(ISubcategory subcategory)
        {
            _subcategory = subcategory;
        }

        public IActionResult Index()
        {
            return View(_subcategory.GetAllSubcategory());
        }
    }
}
