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

        public IEnumerable<FeatureValue> GetFeatureValueByfeatureId(int featureId)
        {
            return _master.GetAllAsQueryable().Include(a=>a.Feature).Where(a => a.FeatureId == featureId);
        }
    }
}
