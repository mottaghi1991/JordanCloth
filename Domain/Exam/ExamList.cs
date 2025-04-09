using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class ExamList:BaseModel
    {
        [DisplayName("عنوان")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }
        public virtual IEnumerable<ExamEvent> ExamEvents { get; set; }
        public virtual IEnumerable<UserExam> UserExams { get; set; }
        public virtual IEnumerable<ExamResultFinal> ExamResultFinals{ get; set; }
    }
}
