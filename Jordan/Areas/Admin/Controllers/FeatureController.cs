using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class FeatureController : BaseController
    {
        private readonly IFeature _feature;

        public FeatureController(IFeature feature)
        {
            _feature = feature;
        }

        public IActionResult Index()
        {
            return View(_feature.GetAll());
        }
    }
}
