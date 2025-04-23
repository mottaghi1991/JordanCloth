using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class ProductFeatureValue : BaseModel
    {
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public Product Product { get; set; }

        public int FeatureValueId { get; set; }
        [ForeignKey("FeatureValueId")]
        public FeatureValue FeatureValue { get; set; }
    }
}
