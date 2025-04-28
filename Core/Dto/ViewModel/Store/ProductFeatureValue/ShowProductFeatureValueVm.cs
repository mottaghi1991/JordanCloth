using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Store.ProductFeatureValue
{
    public class ShowProductFeatureValueVm
    {
        public int FeatureValueId { get; set; }
        public string FeatureValueTitle { get; set; }
        public IEnumerable<Product> products{ get; set; }
    }
}
