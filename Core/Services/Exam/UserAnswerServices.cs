using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Data.MasterInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class UserAnswerServices : IUserAnswer
    {
        private readonly IMaster<ExamResultViewModel> _ExamResultViewModel;

        public UserAnswerServices(IMaster<ExamResultViewModel> examResultViewModel)
        {
            _ExamResultViewModel = examResultViewModel;
        }

        public IEnumerable<ExamResultViewModel> ExamResult()
        {
            return _ExamResultViewModel.GetAll("GetExamResult");
        }
    }
}
