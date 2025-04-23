using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class Product : BaseModel
    {
        [DisplayName("نام محصول")]
        [MaxLength(100, ErrorMessage = "طول نام محصول بیشتر از 100 کاراکتر است")]
        [Required(ErrorMessage = "وارد کردن {0} الزامی است")]
        public string ProductName { get; set; }

        [DisplayName("توضیحات")]
        public string Description { get; set; }

        [DisplayName("قیمت")]
        [Range(0, double.MaxValue, ErrorMessage = "قیمت نمی‌تواند منفی باشد")]
        public decimal Price { get; set; }

        [DisplayName("موجودی")]
        public int Stock { get; set; }



        [DisplayName("تصویر محصول")]
        public string ImageUrl { get; set; }
        [DisplayName("وضعیت")]
        public bool IsActive { get; set; }
        [DisplayName("شناسه زیرشاخه")]
        public int SubCategoryId { get; set; }

        [ForeignKey("SubCategoryId")]
        public SubCategory SubCategory { get; set; }
        public virtual ICollection<ProductFeatureValue> FeatureValues { get; set; }
        public virtual ICollection<Product_ProductTag> Product_ProductTags{ get; set; }


    }
}
