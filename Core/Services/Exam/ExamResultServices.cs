using Core.Interface.Exam;
using Dapper;
using Data.MasterInterface;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class ExamResultServices : IExamResult
    {
        private readonly IMaster<UserExam> _UserExam;

        public ExamResultServices(IMaster<UserExam> userExam)
        {
            _UserExam = userExam;
        }

        public IEnumerable<UserExam> GetListOfUserExamByUserId(int UserId)
        {
            return _UserExam.GetAllEf(a => a.UserId == UserId);
        }

        public string HAlandResult(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, dbType: System.Data.DbType.Int32);
            return _UserExam.GetStringFromDatabase("GetExamResult", dynamicParameters);
        }

        public bool InsertUserExamDone(int UserId, int ExamId)
        {
            var obj= _UserExam.Insert(new UserExam { UserId = UserId, ExamId = ExamId });
            if (obj != null) {
                return true;
            }
            return false;
        }

        public string MBTIResult(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, dbType: System.Data.DbType.Int32);
            return _UserExam.GetStringFromDatabase("MBTIResult", dynamicParameters);
        }

        public bool UserExistInExam(int userid, int ExamId)
        {
            return _UserExam.GetAllEf().Any(a => a.UserId == userid & a.ExamId == ExamId);
        }
    }
}
