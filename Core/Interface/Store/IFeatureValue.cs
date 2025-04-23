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
    }
}
