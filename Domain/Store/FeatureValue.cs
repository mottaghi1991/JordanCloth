using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class FeatureValue : BaseModel
    {
        public string Value { get; set; }
        public int FeatureId { get; set; }
        [ForeignKey("FeatureId")]
        public Feature Feature { get; set; }
        public string Image { get; set; }
        public virtual IEnumerable<ProductFeatureValue> ProductFeatureValues { get; set; }

    }
}
