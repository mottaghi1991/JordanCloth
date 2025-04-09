using Domain.Exam;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class MyUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int ItUserId { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [Display(Name = "کاربر سیستم")]
        [MaxLength(50, ErrorMessage = "بیشتر مقدار{0}می باشد")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        [Display(Name = "ایمیل")]
        [EmailAddress(ErrorMessage = "فرمت وراد صحیح نمی باشد")]
        public string Email { get; set; }
        [Display(Name = "رمزعبور")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string PassWord { get; set; }
        [Display(Name = "کد فعال سازی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string ActiveCode { get; set; }
        public bool IsActive { get; set; }
        public DateTime RegisterDate { get; set; }
        public string UserAvatar { get; set; }
        public bool IsAdmin { get; set; }
        public virtual List<UserRole> UserRoles { get; set; }
        public virtual IEnumerable<JobUserAnswer> JobUserAnswers { get; set; }
        public virtual IEnumerable<ExamEvent> ExamEvents { get; set; }
        public virtual IEnumerable<NinUserAnswer> NinUserAnswers { get; set; }
        public virtual IEnumerable<UserExam> UserExams{ get; set; }



    }



}

