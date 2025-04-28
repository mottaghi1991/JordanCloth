using Core.Interface.Store;
using Data.GenericRepository;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Personal.Base;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class ProductController : BaseController
    {

    
        private readonly IProduct _Product;

        public ProductController(IProduct product)
        {
            _Product = product;
        }

        public IActionResult Index()
        {
            return View(_Product.GetAll());
        }
        public IActionResult Create()
        {
            return View();
        }
    }
}
