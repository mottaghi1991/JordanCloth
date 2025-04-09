using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Dto.ViewModel.Exam
{
    public class NinQuestionViewModel
    {
        public int SeriId { get; set; }
        public string SeriTitle { get; set; }
        public IEnumerable<NinQuestion> ninQuestions { get; set; }
    }
}
