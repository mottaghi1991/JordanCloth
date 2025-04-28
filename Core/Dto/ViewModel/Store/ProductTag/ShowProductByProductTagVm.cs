using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Store.ProductTag
{
    public class ShowProductByProductTagVm
    {
        public int ProductTagId { get; set; }
        public string TagTitle { get; set; }
        public IEnumerable<Product> products{ get; set; }
    }
}
