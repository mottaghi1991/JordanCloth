using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IProductFeatureValue
    {
        public IEnumerable<Product> GetProductOfFeatureValuue(int FeatureValueId);
        public bool Insert(int FeatureValueId, int ProductId);
        public bool Delete(ProductFeatureValue featureValue);
        public ProductFeatureValue CheckExist(int FeatureValueId, int ProductId);
    }
}
