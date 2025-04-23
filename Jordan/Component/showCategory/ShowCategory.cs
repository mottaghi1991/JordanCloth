using Core.Interface.Store;
using Domain.User.Permission;
using Fuel_Core;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Personal.Component
{
    public class ShowCategory:ViewComponent
    {
        private readonly ISubcategory _subcategory;

        public ShowCategory(ISubcategory subcategory)
        {
            _subcategory = subcategory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

         var Subs=_subcategory.GetAllSubcategory();



            return View("/Component/showCategory/ShowCategory.cshtml", Subs);
        }
    }
}
