using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Store
{
    public interface IFeature
    {
        public IEnumerable<Feature> GetAll();
     
        public Feature Insert(Feature Feature);
        public Feature Update(Feature Feature);
        public bool Delete(int FeatureId);
        public Feature GetFeatureById(int FeatureId);
    }
}
