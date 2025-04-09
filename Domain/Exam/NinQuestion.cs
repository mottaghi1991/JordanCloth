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
    public class NinQuestion:BaseModel
    {
        [DisplayName("متن سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }

        [DisplayName("سری سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int seriId { get; set; }

        [DisplayName("ترتیب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Order { get; set; }
        [ForeignKey("seriId")]
        public Seri seri { get; set; }
        public virtual IEnumerable<NinUserAnswer> NinUserAnswers { get; set; }



    }
}
