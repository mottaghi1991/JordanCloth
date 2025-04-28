using Data.GenericRepository;
using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IProduct
    {
        public IEnumerable<Product> GetProductByFeatureValueId(int FeatureValueId);
        public IEnumerable<Product> GetProductByTagId(int TagId);
        public IEnumerable<Product> GetAll();
        public IEnumerable<Product> GetProductBySubcategory(int SubCategoryId);
    }
}
