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
    public class ProductTagServices : IProductTag
    {
        private readonly IMaster<ProductTag> _master;

        public ProductTagServices(IMaster<ProductTag> master)
        {
            _master = master;
        }

        public IEnumerable<ProductTag> GetAll()
        {
         return _master.GetAllEf();
        }
    }
}
