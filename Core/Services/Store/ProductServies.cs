using Core.Interface.Store;
using Data.GenericRepository;
using Data.MasterInterface;
using Domain.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Store
{
    public class ProductServies : IProduct
    {
        private readonly IMaster<Product> _master;

        public ProductServies(IMaster<Product> master)
        {
            _master = master;
        }

        public IEnumerable<Product> GetAll()
        {
           return _master.GetAllEf();
        }

        public IEnumerable<Product> GetProductByFeatureValueId(int FeatureValueId)
        {
            var obj= _master.GetAllAsQueryable().Where(p=>p.FeatureValues.Any(pf=>pf.FeatureValueId==FeatureValueId)).ToList();
            return obj;
        }

        public IEnumerable<Product> GetProductBySubcategory(int SubCategoryId)
        {
            return _master.GetAllEf(a => a.SubCategoryId == SubCategoryId);
        }

        public IEnumerable<Product> GetProductByTagId(int TagId)
        {
            var obj = _master.GetAllAsQueryable().Where(p => p.Product_ProductTags.Any(pf => pf.ProductTagId== TagId)).ToList();
            return obj;
        }
    }
}
