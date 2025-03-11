using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class ShowExamToUserViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }

        public int OptionId { get; set; }
        public string OptionTitle { get; set; }

        public int subOptionId { get; set; }
        public string subOptionTitle { get; set; }
    }
}
