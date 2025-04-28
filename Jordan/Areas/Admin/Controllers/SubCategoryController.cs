using AutoMapper;
using Core.Dto.ViewModel.Store.SubCategory;
using Core.Interface.Store;
using Core.Tools;
using Domain.Store;
using Google.Protobuf.WellKnownTypes;
using Microsoft.AspNetCore.Mvc;
using System;
using WebStore.Base;

namespace Personal.Areas.Admin.Controllers
{
    [Area(AreaNames.Admin)]
    public class SubCategoryController : BaseController
    {
        private readonly ISubcategory _subcategory;
        private readonly IMapper _mapper;

        public SubCategoryController(ISubcategory subcategory, IMapper mapper)
        {
            _subcategory = subcategory;
            _mapper = mapper;
        }

        public IActionResult Index()
        {
            return View(_subcategory.GetAllSubcategory());
        }
        public IActionResult Create()
        {
            return View();
        }

        // POST: RoleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubCategoryAddVM SubCategory)
        {
          

                if (!ModelState.IsValid)
                {
                    return View(SubCategory);
                }
        

            try
            {
                string FilePAthThumb, FIleName, FilePAth = null;
                FIleName = FileTools.GetFileName(SubCategory.ImageFile);
                FilePAth = FileTools.UploadFile(SubCategory.ImageFile, FIleName, "SubCategory");
                FilePAthThumb = FileTools.UploadFile(SubCategory.ImageFile, FIleName, "SubCategory/thumb");
                FileTools.Image_resize(FilePAth, FilePAthThumb, 150);
                var result = _subcategory.Insert(new SubCategory()
                {
                    SubCategoryName=SubCategory.SubCategoryName,
                    Image= FilePAth,
                    
                });
                if (result != null)
                {
                    TempData[Success] = SuccessMessage;
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData[Error] = ErrorMessage;
                    return RedirectToAction("Index");
                }
            }
            catch (Exception e)
            {
                TempData[Error] = ErrorMessage;
                return RedirectToAction("Index");
            }





        }

        // GET: RoleController/Edit/5
        public ActionResult Edit(int SubCategoryId)
        {

            var result = _subcategory.GetSubCategoryById(SubCategoryId);
            if (result == null)
            {
                return NotFound();
            }
            return View(_mapper.Map<SubCategoryEditVM>(result));
        }

        // POST: RoleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubCategoryEditVM SubCategory)
        {
            if (!ModelState.IsValid)
            {
                return View(SubCategory);
            }
            var old = _subcategory.GetSubCategoryById(SubCategory.Id);
            old.SubCategoryName = SubCategory.SubCategoryName;
            if (SubCategory.ImageFile!=null)
            {
          
                string FilePAthThumb, FIleName, FilePAth = null;
                FIleName = FileTools.GetFileName(SubCategory.ImageFile);
                FilePAth = FileTools.UploadFile(SubCategory.ImageFile, FIleName, "SubCategory");
                FilePAthThumb = FileTools.UploadFile(SubCategory.ImageFile, FIleName, "SubCategory/thumb");
                FileTools.Image_resize(FilePAth, FilePAthThumb, 150);
                FileTools.DeleteFile(old.Image);
                old.Image = FilePAth;
                
            }



            var result = _subcategory.Update(old);
            if (result != null)
            {
                TempData[Success] = SuccessMessage;
                return RedirectToAction("Index");
            }
            else
            {
                TempData[Error] = ErrorMessage;
                return RedirectToAction("Index");
            }

        }

        // GET: RoleController/Delete/5
        public ActionResult Delete(int id)
        {



            var obj = _subcategory.GetSubCategoryById(id);
            if (obj == null)
            {
                return NotFound();
            }

            if (_subcategory.GetSubCategoryById(id) != null)
            {
                TempData["Error"] = "منو دارای مجموعه می باشد لطفا ابتدا آنها را پاک کنید";
                return RedirectToAction("Index");
            }

            var result = _subcategory.Delete(id);
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
