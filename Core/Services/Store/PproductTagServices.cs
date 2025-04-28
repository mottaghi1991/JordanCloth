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
    public class PproductTagServices : IPProductTag
    {
        private readonly IMaster<Product_ProductTag> _master;

        public PproductTagServices(IMaster<Product_ProductTag> master)
        {
            _master = master;
        }

        public Product_ProductTag CheckExist(int ProductTagId, int ProductId)
        {
            return _master.GetAllEf(a=>a.ProductId == ProductId&&a.ProductTagId==ProductTagId).FirstOrDefault();
        }

        public bool Delete(Product_ProductTag productTag)
        {
            return _master.Delete(productTag);
        }

        public bool Insert(int TagId, int ProductId)
        {
            var obj= _master.Insert(new Product_ProductTag()
            {
                ProductId = ProductId,
                ProductTagId = TagId
            });
            if (obj != null)
            {
                return true;
            }
            return false;
        }
    }
}
