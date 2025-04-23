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

        public IEnumerable<SubCategory> GetAllSubcategory()
        {
            return _master.GetAllEf();

        }
    }
}
