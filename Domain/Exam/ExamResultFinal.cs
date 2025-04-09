using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Exam
{
    public class ExamResultFinal:BaseModel
    {
        [DisplayName("عنوان")]
        [MaxLength(50, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }
        [DisplayName("توضیح")]
        [MaxLength(500, ErrorMessage = "طول رشته بیشتر از 50 کاراکتر می باشد")]
        
        public string? Descript { get; set; }
        [DisplayName("توضیح")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string FinalResult { get; set; }
        public int ExamId { get; set; }
        [ForeignKey("ExamId")]
        public ExamList examList { get; set; }
    }
}
