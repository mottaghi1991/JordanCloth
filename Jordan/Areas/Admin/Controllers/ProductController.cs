using AutoMapper;
using Core.Dto.ViewModel.Store.ProductDto;
using Core.Interface.Store;
using Core.Tools;
using Data.GenericRepository;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Personal.Base;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class ProductController : BaseController
    {

    
        private readonly IProduct _Product;
        private readonly IProductTag _productTag;
        private readonly IFeatureValue _featureValue;
        private readonly ISubcategory _subcategory;
        private readonly IMapper _mapper;

        public ProductController(IProduct product, IFeatureValue featureValue, IProductTag productTag, ISubcategory subcategory, IMapper mapper)
        {
            _Product = product;
            _featureValue = featureValue;
            _productTag = productTag;
            _subcategory = subcategory;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_Product.GetAll());
        }
        public IActionResult Create()
        {
            ViewBag.subcategory = new SelectList(_subcategory.GetAllSubcategory(), "Id", "SubCategoryName");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ProductAddVM addVM)
        {
            if(!ModelState.IsValid)
            {
                ViewBag.subcategory = new SelectList(_subcategory.GetAllSubcategory(), "Id", "SubCategoryName",addVM.SubCategoryId);
                return View(addVM);
            }
            string  FIleName, FilePAth = null;
            FIleName = FileTools.GetFileName(addVM.ImageFile);
            FilePAth = FileTools.UploadFile(addVM.ImageFile, FIleName, "Product");
            addVM.ImageUrl = FilePAth;
            var result = _Product.Insert(_mapper.Map<Product>(addVM));
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                FileTools.DeleteFile(FilePAth);
                return RedirectToAction("Index");
            }
        }

        public IActionResult AddGroupToPrduct(int ProductId)
        {
            var product=_Product.GetProductById(ProductId);
            if (product == null)
            {
                return NotFound();
            }
           
            ViewBag.Featurevalue = _featureValue.GetFeatureValueBySubcategoryId(product.SubCategoryId);
            ViewBag.ProductTag = _productTag.GetAll();
            return View();
        }
    }
}
