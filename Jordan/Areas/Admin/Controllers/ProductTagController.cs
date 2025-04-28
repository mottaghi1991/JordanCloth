using Core.Dto.ViewModel.Store.ProductFeatureValue;
using Core.Dto.ViewModel.Store.ProductTag;
using Core.Interface.Store;
using Data.GenericRepository;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Personal.Base;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class ProductTagController : BaseController
    {
        private readonly IProductTag _productTag;
        private readonly IProduct _product;
        private readonly IPProductTag _PproductTag;

        public ProductTagController(IProductTag productTag, IProduct product, IPProductTag pproductTag)
        {
            _productTag = productTag;
            _product = product;
            _PproductTag = pproductTag;
        }

        public IActionResult Index()
        {
            return View(_productTag.GetAll());
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductTag productTag)
        {
            if(!ModelState.IsValid)
            {
                return View(productTag);
            }
            var result = _productTag.Insert(productTag);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return View(productTag);
            }
          
        }
        [HttpGet]
        public IActionResult Edit(int TagId)
        {
            var obj=_productTag.GetProductTagById(TagId);
            if (obj==null)
            {
                
                return NotFound();
            }

            return View(obj);
        }
        [HttpPost]
        public IActionResult Edit(ProductTag productTag)
        {
            if (!ModelState.IsValid)
            {
                return View(productTag);
            }
            var result = _productTag.Update(productTag);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return View(productTag);
            }

        }
        [HttpGet]
        public IActionResult Delete(int TagId)
        {
            var obj = _productTag.GetProductTagById(TagId);
            if (obj == null)
            {

                return NotFound();
            }
            var result = _productTag.Delete(TagId);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return RedirectToAction("Index");
            }
        }
        public IActionResult ProductTag(int ProductTagId)
        {
            var productTag = _productTag.GetProductTagById(ProductTagId);
            if (productTag == null)
            {
                return NotFound();
            }
            ViewBag.Product = new SelectList(_product.GetAll(), "Id", "ProductName");
            var VM = new ShowProductByProductTagVm()
            {
                ProductTagId = productTag.Id,
                TagTitle = productTag.Title,
                products = _product.GetProductByTagId(ProductTagId)
            };
            return View(VM);
        }
        public IActionResult RemoveProductFromTagId(int ProductTagId, int ProductId)
        {
            var obj = _PproductTag.CheckExist(ProductTagId, ProductId);
            if (obj==null)
            {
                return NotFound();

            }
            var result = _PproductTag.Delete(obj);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("ProductTag", new
                {
                    ProductTagId = ProductTagId
                });
            }
            else
            {
                TempData[Error] = ErrorMessage;

                return RedirectToAction("ProductTag", new
                {
                    ProductTagId = ProductTagId
                });
            }


        }
        public IActionResult AddProductToTag(int ProductTagId, int ProductId)
        {
            var exist = _PproductTag.CheckExist(ProductTagId, ProductId);
            if (exist != null)
            {
                TempData[warning] = "این محصول در لیست موجود می باشد";
                return RedirectToAction("ProductTag", new
                {
                    ProductTagId = ProductTagId
                });
            }
            var result = _PproductTag.Insert(ProductTagId, ProductId);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("ProductTag", new
                {
                    ProductTagId = ProductTagId
                });
            }
            else
            {
                TempData[Error] = ErrorMessage;

                return RedirectToAction("ProductTag", new
                {
                    ProductTagId = ProductTagId
                });
            }

        }


    }
}
