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
    public class FeatureServices : IFeature
    {
        private readonly IMaster<Feature> _Master;

        public FeatureServices(IMaster<Feature> master)
        {
            _Master = master;
        }

        public bool Delete(int FeatureId)
        {
            return _Master.Delete(GetFeatureById(FeatureId));
        }

        public IEnumerable<Feature> GetAll()
        {
        return _Master.GetAllAsQueryable().Include(a=>a.subCategorycategory).ToList();
        }

        public Feature GetFeatureById(int FeatureId)
        {
            return _Master.GetAllEf(a => a.Id == FeatureId).FirstOrDefault();
        }

        public Feature Insert(Feature Feature)
        {
            return _Master.Insert(Feature);
        }

        public Feature Update(Feature Feature)
        {
            return _Master.Update(Feature);    
        }
    }
}
