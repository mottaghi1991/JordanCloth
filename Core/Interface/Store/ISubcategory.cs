using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface ISubcategory
    {
        public IEnumerable<SubCategory> GetAllSubcategory();
        public IEnumerable<SubCategory> GetAllSubCategories();
        public SubCategory Insert(SubCategory SubCategory);
        public SubCategory Update(SubCategory SubCategory);
        public bool Delete(int QuestionId);
        public SubCategory GetSubCategoryById(int SubCategoryId);
    }
}
