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
    public class ProductFeatureValueServices : IProductFeatureValue
    {
        private readonly IMaster<Product> _ProductMaster;
        private readonly IMaster<ProductFeatureValue> _ProductFeatureMaster;

        public ProductFeatureValueServices(IMaster<Product> productMaster, IMaster<ProductFeatureValue> productFeatureMaster)
        {
            _ProductMaster = productMaster;
            _ProductFeatureMaster = productFeatureMaster;
        }

        public ProductFeatureValue CheckExist(int FeatureValueId, int ProductId)
        {
            var obj = _ProductFeatureMaster
                .GetAllEf(a => a.FeatureValueId == FeatureValueId & a.ProductId == ProductId)
                .FirstOrDefault();
            return obj;
        }

        public bool Delete(ProductFeatureValue featureValue)
        {
            var obj = CheckExist(featureValue.FeatureValueId,featureValue.ProductId);
            if (obj == null)
                return false;
            if (!_ProductFeatureMaster.Delete(obj))
                return false;
            return true;
        }

        public IEnumerable<Product> GetProductOfFeatureValuue(int FeatureValueId)
        {
            var obj = _ProductMaster.GetAllAsQueryable().Where(p => p.FeatureValues.Any(pf => pf.FeatureValueId == FeatureValueId)).ToList();
            return obj;
        }

        public bool Insert(int FeatureValueId, int ProductId)
        {
    
            if (_ProductFeatureMaster.Insert(new ProductFeatureValue()
            {
                FeatureValueId = FeatureValueId,
                ProductId =ProductId,
            }) == null)
                return false;
            return true;
        }
    }
}
