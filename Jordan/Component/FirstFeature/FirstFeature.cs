using Core.Interface.Store;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Personal.Component.FirstFeature
{
    public class FirstFeature:ViewComponent
    {
        private readonly  IFeatureValue _featureValue;

        public FirstFeature(IFeatureValue featureValue)
        {
            _featureValue = featureValue;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var Obj = _featureValue.GetFeatureValueByfeatureId(1);



            return View("/Component/FirstFeature/FirstFeature.cshtml", Obj);
        }
    }
}
