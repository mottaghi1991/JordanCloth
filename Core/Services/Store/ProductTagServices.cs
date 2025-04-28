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

        public bool Delete(int ProductTagId)
        {
          return _master.Delete(GetProductTagById(ProductTagId));
                }

        public IEnumerable<ProductTag> GetAll()
        {
         return _master.GetAllEf();
        }

        public ProductTag GetProductTagById(int ProductTagId)
        {
            return _master.GetAllEf(a => a.Id == ProductTagId).FirstOrDefault();
        }

        public ProductTag Insert(ProductTag ProductTag)
        {
            return _master.Insert(ProductTag);
        }

        public ProductTag Update(ProductTag ProductTag)
        {
            return _master.Update(ProductTag);
        }
    }
}
