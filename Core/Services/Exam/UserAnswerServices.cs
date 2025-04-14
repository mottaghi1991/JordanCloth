using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Data.MasterInterface;
using Domain.Exam;
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
        private readonly IMaster<UserAnswer> _UserAnswermaster;


        public UserAnswerServices(IMaster<ExamResultViewModel> examResultViewModel, IMaster<UserAnswer> userAnswermaster)
        {
            _ExamResultViewModel = examResultViewModel;
            _UserAnswermaster = userAnswermaster;
        }

        public IEnumerable<ExamResultViewModel> ExamResult()
        {
            return _ExamResultViewModel.GetAll("GetExamResult");
        }

        public int GetmaxQuestionOfUserNaswer(int UserId)
        {
            var obj = _UserAnswermaster.GetAllEf(a => a.ItUserId == UserId);
            if(!obj.Any())
            {
                return 0;
            }
            return obj.Max(a => a.QuestionId);
        }
    }
}
