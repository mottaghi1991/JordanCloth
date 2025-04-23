using Core.Interface.Store;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Personal.Component.ThirdFeature
{
    public class ThirdFeature:ViewComponent
    {
        private readonly IProduct _product;

        public ThirdFeature(IProduct product)
        {
            _product = product;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var Obj = _product.GetProductByFeatureValueId(6);



            return View("/Component/ThirdFeature/ThirdFeature.cshtml", Obj);
        }
    }
}
