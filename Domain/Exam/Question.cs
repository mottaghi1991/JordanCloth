using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class Question:BaseModel
    {
        [DisplayName("ترتیب")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public int Order { get; set; }

        [DisplayName("عنوان سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string Title { get; set; }

        [DisplayName("متن سوال")]
        [Required(ErrorMessage = "وارد کردن {0} اجباری می باشد")]
        public string descript { get; set; }
        public IEnumerable<SubOption>subOptions { get; set; }
        public IEnumerable<Option> options{ get; set; }

    }
}
