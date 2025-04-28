using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IProductTag
    {
        public IEnumerable<ProductTag> GetAll();
        public ProductTag Insert(ProductTag ProductTag);
        public ProductTag Update(ProductTag ProductTag);
        public bool Delete(int ProductTagId);
        public ProductTag GetProductTagById(int ProductTagId);
        
    }
}
