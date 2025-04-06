using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class JobTestViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public int OptionId { get; set; }
        public string OptionTitle { get; set; }

    }
  
}
