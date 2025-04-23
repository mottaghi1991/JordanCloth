using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Personal.Component.SixFeature
{
    public class SixFeature:ViewComponent
    {
        private readonly IProduct _product;

        public SixFeature(IProduct product)
        {
            _product = product;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var Obj = _product.GetProductByTagId(2);
            return View("/Component/SixFeature/SixFeature.cshtml", Obj);
        }
    }
}
