using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobOption:BaseModel
    {
        [DisplayName("عنوان")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string TItle { get; set; }
        [DisplayName("ارزش")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Value { get; set; }
        [DisplayName("دسته بندی")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int jobGroupIndexId { get; set; }
        [DisplayName("سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int JobQuestionId { get; set; }

        [ForeignKey("JobQuestionId")]
        public JobQuestion jobQuestion { get; set; }
        [ForeignKey("jobGroupIndexId")]
        public JopGroupIndex jopGroupIndex { get; set; }
        public virtual IEnumerable<JobUserAnswer> JobUserAnswers { get; set; }

    }
}
