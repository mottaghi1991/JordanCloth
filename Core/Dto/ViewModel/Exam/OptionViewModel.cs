using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class OptionViewModel
    {
        public int QuestionId { get; set; }
        public string QuestionTitle { get; set; }
        public List<Option> options{ get; set; }
    }
}
