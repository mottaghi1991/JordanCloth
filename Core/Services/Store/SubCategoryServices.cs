using Core.Interface.Store;
using Data.MasterInterface;
using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Store
{
    public class SubCategoryServices : ISubcategory
    {
        private readonly IMaster<SubCategory> _master;

        public SubCategoryServices(IMaster<SubCategory> master)
        {
            _master = master;
        }

        public bool Delete(int QuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<SubCategory> GetAllSubCategories()
        {
            return _master.GetAllEf();
        }

        public IEnumerable<SubCategory> GetAllSubcategory()
        {
            return _master.GetAllEf();
        }

        public SubCategory GetSubCategoryById(int SubCategoryId)
        {
           return _master.GetAllEf(a=>a.Id == SubCategoryId).FirstOrDefault();
        }

        public SubCategory Insert(SubCategory SubCategory)
        {
          return _master.Insert(SubCategory);
        }

        public SubCategory Update(SubCategory SubCategory)
        {
         return _master.Update(SubCategory);
        }
    }
}
