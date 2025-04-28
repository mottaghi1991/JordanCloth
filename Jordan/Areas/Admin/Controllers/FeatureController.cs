using Core.Dto.ViewModel.Store.SubCategory;
using Core.Interface.Store;
using Core.Tools;
using Domain.Store;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using WebStore.Base;
using static Google.Protobuf.Compiler.CodeGeneratorResponse.Types;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class FeatureController : BaseController
    {
        private readonly IFeature _feature;
        private readonly ISubcategory _subcategory;

        public FeatureController(IFeature feature, ISubcategory subcategory)
        {
            _feature = feature;
            _subcategory = subcategory;
        }

        public IActionResult Index()
        {
            return View(_feature.GetAll());
        }
        public IActionResult Create()
        {
            ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id","SubCategoryName");
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( Domain.Store.Feature feature)
        {


            if (!ModelState.IsValid)
            {
                ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName", feature.subCategoryId);
                return View(feature);
            }


            try
            {
              
                var result = _feature.Insert(feature);
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName", feature.subCategoryId);
                    return View(feature);
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName", feature.subCategoryId);
                return View(feature);
            }





        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int FeatureId)
        {

            var result = _feature.GetFeatureById(FeatureId);
            if (result == null)
            {
                return NotFound();
            }
            ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName", result.subCategoryId);
            return View(result);
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Domain.Store.Feature Feature)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName", Feature.subCategoryId);
                return View(Feature);
            }
            var result = _feature.Update(Feature);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                ViewBag.SubCategory = new SelectList(_subcategory.GetAllSubCategories(), "Id", "SubCategoryName",result.subCategoryId);
                return View(Feature);
            }

        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {



            var obj = _feature.GetFeatureById(id);
            if (obj == null)
            {
                return NotFound();
            }

          

            var result = _feature.Delete(id);
            if (result)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            TempData[Error] = ErrorMessage;
            return RedirectToAction("Index");


        }
      
    }
}
