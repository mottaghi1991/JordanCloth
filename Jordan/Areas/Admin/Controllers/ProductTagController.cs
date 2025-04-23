using Core.Interface.Store;
using Data.GenericRepository;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Personal.Base;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ProductTagController : BaseController
    {
        private readonly IProductTag _productTag;

        public ProductTagController(IProductTag productTag)
        {
            _productTag = productTag;
        }

        public IActionResult Index()
        {
            return View(_productTag.GetAll());
        }
      
    }
}
