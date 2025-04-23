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

        public IEnumerable<Feature> GetAll()
        {
        return _Master.GetAllAsQueryable().Include(a=>a.subCategorycategory).ToList();
        }
    }
}
