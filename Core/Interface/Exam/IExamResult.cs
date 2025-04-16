using Core.Dto.ViewModel.Exam;
using Core.Dto.ViewModel.User;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IExamResult
    {
        public bool InsertUserExamDone(int UserId, int ExamId);
        public IEnumerable<UserExam> GetListOfUserExamByUserId(int UserId);
        public bool UserExistInExam(int userid,int ExamId);
        public string MBTIResult(int UserId);
        public string HAlandResult(int UserId);
        public string AnageramResult(int UserId);
        public IEnumerable<ShowUserBrifViewModel> GetListOfUserDoneExam(int ExamId);
        public IEnumerable<ExamList> examLists();
        public IEnumerable<ExamList> GetListOFExamDoneWithUser(int UserId);
        public ExamList examById(int examId);

        public IEnumerable<ExamDetailItem> GetHalandResultDetailByUserId(int UserId);
        public IEnumerable<ExamDetailItem> GetMBTIResultDetailByUserId(int UserId);
        public IEnumerable<ExamDetailItem> GetAnageramResultDetailByUserId(int UserId);
    }
}
