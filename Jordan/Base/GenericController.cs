using Data.GenericRepository;
using Microsoft.AspNetCore.Mvc;
using WebStore.Base;

namespace Personal.Base
{
    public class GenericController<T> : BaseController where T : class
    {
        private readonly IGenericRepository<T> _Repository;

        public GenericController(IGenericRepository<T> repository)
        {
            _Repository = repository;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var obj=_Repository.GetAll();
            return View(obj);
        }
    }
}
