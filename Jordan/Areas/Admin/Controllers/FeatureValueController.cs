using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(areaName:AreaNames.Admin)]
    public class FeatureValueController : BaseController
    {
        private readonly IFeatureValue _featureValue;

        public FeatureValueController(IFeatureValue featureValue)
        {
            _featureValue = featureValue;
        }

        public IActionResult Index(int FeatureId)
        {
            return View(_featureValue.GetFeatureValueByfeatureId(FeatureId));
        }
    }
}
