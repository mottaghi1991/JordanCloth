using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class Feature : BaseModel
    {
        public string Title { get; set; }
        public int subCategoryId { get; set; }
        [ForeignKey("subCategoryId")]
        public SubCategory subCategorycategory { get; set; }
        public ICollection<FeatureValue> Values { get; set; }

    }
}
