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
    }
}
