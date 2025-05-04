using Core.Interface.Admin;
using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Configuration;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class AdminHomeController : BaseController
    {
        private readonly ISiteSetting _siteSetting;
        private readonly IFeatureValue _featureValue;
        private readonly IFeature _feature;
        private readonly IProduct _product;
        private readonly IProductTag _productTag;


        public AdminHomeController(ISiteSetting siteSetting, IFeatureValue featureValue, IProduct product, IProductTag productTag, IFeature feature)
        {
            _siteSetting = siteSetting;
            _featureValue = featureValue;
            _product = product;
            _productTag = productTag;
            _feature = feature;
        }

        [Route("/Admin")]
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult FirstPageSetting()
        {
            var obj = _siteSetting.GetSitSetting();
            ViewBag.FirstComponent = new SelectList(_feature.GetAll(),"Id","Title",obj.FirstSlider);
            ViewBag.SecondComponent = new SelectList(_featureValue.GetAll(),"Id", "Value", obj.SecondSlider);
            ViewBag.thiradComponent = new SelectList(_featureValue.GetAll(), "Id", "Value", obj.ThirdSlider);
            ViewBag.fourthComponent = new SelectList(_productTag.GetAll(), "Id", "Title", obj.FourthSlider);
            ViewBag.SixComponent = new SelectList(_productTag.GetAll(), "Id", "Title", obj.SixSlider);

            return View(obj);
        }
    }
}
