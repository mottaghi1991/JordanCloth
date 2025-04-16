using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class ShowExamDetailToAdmin
    {
        public IEnumerable<ExamDetailItem> examDetailItems { get; set; }
        public ExamResultFinal examResultFinal{ get; set; }
    }
}
