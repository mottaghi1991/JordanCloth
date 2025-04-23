using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class ProductTag : BaseModel
    {
        [DisplayName("عنوان")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }
        [DisplayName("ترتیب نمایش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int SortOrder { get; set; }
        public virtual IEnumerable<Product_ProductTag> ProductProductTags { get; set; }

    }
}
