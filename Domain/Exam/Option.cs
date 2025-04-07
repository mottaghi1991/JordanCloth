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
    public class Option:BaseModel
    {


       

        [DisplayName("متن سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }

        [DisplayName("ترتیب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Order { get; set; }

        public int QuestionId { get; set; }
        [ForeignKey("QuestionId")]
        public virtual Question Question { get; set; }

        public IEnumerable<SubOption> SubOptions { get; set; }
    }
}
