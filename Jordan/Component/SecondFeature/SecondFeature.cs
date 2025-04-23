using Core.Interface.Store;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Personal.Component.SecondFeature
{
    public class SecondFeature : ViewComponent
    {
        private readonly IProduct _product;

        public SecondFeature(IProduct product)
        {
            _product = product;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var Obj = _product.GetProductByFeatureValueId(5);



            return View("/Component/SecondFeature/SecondFeature.cshtml", Obj);
        }
    }
}
