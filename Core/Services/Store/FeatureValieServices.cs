using Core.Interface.Store;
using Data.MasterInterface;
using Domain.Store;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Store
{
    public class FeatureValieServices : IFeatureValue
    {
        private readonly IMaster<FeatureValue> _master;

        public FeatureValieServices(IMaster<FeatureValue> master)
        {
            _master = master;
        }

        public bool Delete(int FeatureValueId)
        {
          return _master.Delete(GetFeatureValueById(FeatureValueId));
        }

        public IEnumerable<FeatureValue> GetFeatureValueByfeatureId(int featureId)
        {
            return _master.GetAllAsQueryable().Include(a=>a.Feature).Where(a => a.FeatureId == featureId);
        }

        public FeatureValue GetFeatureValueById(int FeatureValueId)
        {
       return _master.GetAllAsQueryable().Include(a=>a.Feature).FirstOrDefault(a=>a.Id==FeatureValueId);  
        }

        public FeatureValue Insert(FeatureValue FeatureValue)
        {
           return _master.Insert(FeatureValue);
        }

        public FeatureValue Update(FeatureValue FeatureValue)
        {
      return _master.Update(FeatureValue);  
        }
    }
}
