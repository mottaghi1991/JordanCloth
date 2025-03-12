using Core.Dto.ViewModel.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IUserAnswer
    {
        public IEnumerable<ExamResultViewModel> ExamResult();
    }
}
