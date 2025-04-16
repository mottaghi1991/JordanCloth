using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class ExamDetailItem
    {
        [DisplayName("تعداد انتخاب")]
        public int SelectCount { get; set; }
        [DisplayName("عنوان")]
        public string Title { get; set; }
    }
}
