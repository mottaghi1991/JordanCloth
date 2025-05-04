using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IFeatureValue
    {
        public IEnumerable<FeatureValue> GetFeatureValueByfeatureId(int featureId);
        public IEnumerable<FeatureValue> GetFeatureValueBySubcategoryId(int SubCategoryId);
        public IEnumerable<FeatureValue> GetAll();

        public FeatureValue Insert(FeatureValue FeatureValue);
        public FeatureValue Update(FeatureValue FeatureValue);
        public bool Delete(int FeatureValueId);
        public FeatureValue GetFeatureValueById(int FeatureValueId);
    }
}
