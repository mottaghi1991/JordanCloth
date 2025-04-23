using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class SubCategory : BaseModel
    {
        [DisplayName("عنوان")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string SubCategoryName { get; set; }
        public int CategoryId { get; set; } = 1;
        [DisplayName("تصویر")]
        public string Image { get; set; }

        public ICollection<Product> Products { get; set; }
        public ICollection<Feature> Features { get; set; }
    }
}
