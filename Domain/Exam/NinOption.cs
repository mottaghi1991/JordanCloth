using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class NinOption:BaseModel
    {
        [DisplayName("متن سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }

        [DisplayName("ترتیب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Order { get; set; }
        [DisplayName("امتیاز")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Score { get; set; }
        public virtual IEnumerable<NinUserAnswer> NinUserAnswers { get; set; }
    }
}
