using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.User
{
    public class ChangePasswordViewModel
    {
    

        [Display(Name = "رمز عبور قدیمی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string OldPassWord { get; set; }

        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string PassWord { get; set; }
        [Display(Name = "تکرار رمز عبور")]
        [Compare("PassWord", ErrorMessage = "رمز عبور و تکرار آن یکسان نمی باشد")]
        public string RePassword { get; set; }
    }
}
