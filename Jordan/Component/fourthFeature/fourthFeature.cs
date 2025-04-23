using Core.Interface.Store;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Personal.Component.fourthFeature
{
   
        public class fourthFeature : ViewComponent
        {
            private readonly IProduct _product;

            public fourthFeature(IProduct product)
            {
                _product = product;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {

                var Obj = _product.GetProductByTagId(1);



                return View("/Component/fourthFeature/fourthFeature.cshtml", Obj);
            }
        }
    
}
