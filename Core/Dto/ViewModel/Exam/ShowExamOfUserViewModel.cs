using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class ShowExamOfUserViewModel
    {
        public int UserId{ get; set; }
        public string UserName { get; set; }
        public IEnumerable<ExamList> examLists{ get; set; }
    }
}
