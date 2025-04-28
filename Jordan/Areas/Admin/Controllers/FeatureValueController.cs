using AutoMapper;
using Core.Dto.ViewModel.Store.FeatureValueDto;
using Core.Dto.ViewModel.Store.ProductFeatureValue;
using Core.Interface.Store;
using Core.Tools;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MySqlX.XDevAPI.Common;
using WebStore.Base;
using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class FeatureValueController : BaseController
    {
        private readonly IFeatureValue _featureValue;
        private readonly IFeature _feature;
        private readonly IProduct _product;
        private readonly IProductFeatureValue _Productfeature;
        private readonly IMapper _mapper;

        public FeatureValueController(IFeatureValue featureValue, IFeature feature, IMapper mapper, IProductFeatureValue productfeature, IProduct product)
        {
            _featureValue = featureValue;
            _feature = feature;
            _mapper = mapper;
            _Productfeature = productfeature;
            _product = product;
        }

        public IActionResult Index(int FeatureId)
        {
            if (FeatureId == 0) {
                return NotFound();
            }
            var feature=_feature.GetFeatureById(FeatureId);
            if (feature == null)
            {
                return NotFound();
            }
            return View(new ShowFeatureValueVM()
            {
                feature= feature,
                FeatureValues=_featureValue.GetFeatureValueByfeatureId(FeatureId)
                
            });
        }
        [HttpGet]
        public IActionResult Create(int FeatureId)
        {
            if (FeatureId == 0)
            {
                return NotFound();
            }
            var feature = _feature.GetFeatureById(FeatureId);
            if (feature == null)
            {
                return NotFound();
            }

            return View(new FeatureValueAddVM()
            {
                FeatureId = FeatureId,
                FeatureTitle=feature.Title
                
            });
        }
        [HttpPost]
        public IActionResult Create(FeatureValueAddVM featureValue)
        {
            if (!ModelState.IsValid) {
                return View(featureValue);
            }
            string FilePAthThumb, FIleName, FilePAth = null;
            FIleName = FileTools.GetFileName(featureValue.ImageFile);
            FilePAth = FileTools.UploadFile(featureValue.ImageFile, FIleName, "featureValue");
            featureValue.Image=FilePAth;
            var result = _featureValue.Insert(new FeatureValue()
            {
                FeatureId = featureValue.FeatureId,
                Value = featureValue.Value,
                Image = FilePAth

            });
            
         
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index", new { FeatureId =result.FeatureId});
            }
            else
            {
                TempData[Error] = ErrorMessage;
                FileTools.DeleteFile(FilePAth);
                return View("create", new { FeatureId =featureValue.FeatureId});
            }
          
        }
        [HttpGet]
        public IActionResult Edit(int featureValueId)
        {
            var featurevalue = _featureValue.GetFeatureValueById(featureValueId);
            if(featurevalue == null)
            {
                return NotFound();
            }
            var feature=_feature.GetFeatureById(featurevalue.FeatureId);

            return View(new FeatureValueEditVM()
            {
                FeatureId=featurevalue.FeatureId,
                FeatureTitle=feature.Title,
                Id=featurevalue.Id,
                Value=featurevalue.Value,
            });
        }
        [HttpPost]
        public IActionResult Edit(FeatureValueEditVM editVM)
        {
            if(!ModelState.IsValid)
            {
                return View(editVM);
            }
            var old=_featureValue.GetFeatureValueById(editVM.Id);   
            if (editVM.ImageFile != null) {
                string  FIleName, FilePAth = null;
                FIleName = FileTools.GetFileName(editVM.ImageFile);
                FilePAth = FileTools.UploadFile(editVM.ImageFile, FIleName, "featureValue");
                FileTools.DeleteFile(old.Image);
                old.Image = FilePAth;
            }
            old.Value = editVM.Value;
            var Result = _featureValue.Update(old);
            if (Result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index", new { FeatureId = Result.FeatureId });
            }
            else
            {
                TempData[Error] = ErrorMessage;
                if (editVM.ImageFile != null)
                {
                    FileTools.DeleteFile(editVM.Image);
                }
                   
                return RedirectToAction("Edit", new { featureValueId = editVM.Id });
            }
        }
        public IActionResult ProductFeatureValue(int featureValueId)
        {
            var featureValue = _featureValue.GetFeatureValueById(featureValueId);
            if(featureValue==null)
            {
                return NotFound();
            }
            ViewBag.Product = new SelectList(_product.GetProductBySubcategory(featureValue.Feature.subCategoryId), "Id", "ProductName");
            var VM = new ShowProductFeatureValueVm()
            {
                FeatureValueId = featureValueId,
                FeatureValueTitle = featureValue.Value,
                products = _Productfeature.GetProductOfFeatureValuue(featureValueId)
            };
            return View(VM);
        }
        public IActionResult RemoveProductFromFeatureId(ProductFeatureValue featureValue)
        {
            var result = _Productfeature.Delete(featureValue);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("ProductFeatureValue", new
                {
                    featureValueId = featureValue.FeatureValueId
                });
            }
            else
            {
                TempData[Error] = ErrorMessage;

                return RedirectToAction("ProductFeatureValue", new
                {
                    featureValueId = featureValue.FeatureValueId
                });
            }

          
        }
      public IActionResult AddProductToFeatureValue(int FeatureValueId,int ProductId)
        {
            var exist=_Productfeature.CheckExist(FeatureValueId,ProductId);
            if (exist != null)
            {
                TempData[warning] = "این محصول در لیست موجود می باشد";
                return RedirectToAction("ProductFeatureValue", new
                {
                    featureValueId = FeatureValueId
                });
            }
            var result= _Productfeature.Insert(FeatureValueId,ProductId);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("ProductFeatureValue", new
                {
                    featureValueId = FeatureValueId
                });
            }
            else
            {
                TempData[Error] = ErrorMessage;
               
                return RedirectToAction("ProductFeatureValue", new
                {
                    featureValueId = FeatureValueId
                });
            }
            
        }
    }
}
