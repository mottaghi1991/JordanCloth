using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Store.FeatureValueDto
{
    public class ShowFeatureValueVM
    {
        public Domain.Store.Feature feature { get; set; }
        public IEnumerable<Domain.Store.FeatureValue> FeatureValues { get; set; }
    }
}
