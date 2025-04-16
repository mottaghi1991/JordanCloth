using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.User
{
    public class AdminUserEditViewModel
    {
        public int ItUserId { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [Display(Name = "کاربر سیستم")]
        [MaxLength(50, ErrorMessage = "بیشتر مقدار{0}می باشد")]
        public string UserName { get; set; }
        [Display(Name = "رمزعبور جدید")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
     
        public string PassWord { get; set; }
       

    }
}
