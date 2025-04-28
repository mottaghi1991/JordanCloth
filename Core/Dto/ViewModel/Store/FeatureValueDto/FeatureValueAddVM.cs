using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Store.FeatureValueDto
{
    public class FeatureValueAddVM
    {
        [DisplayName("دسته بندی بر اساس")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int FeatureId { get; set; }
        public string FeatureTitle { get; set; }
        [DisplayName("عنوان")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Value { get; set; }
        [DisplayName("تصویر")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        public string Image { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public IFormFile ImageFile{ get; set; }
    }
}
