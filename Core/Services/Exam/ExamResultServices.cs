using Core.Dto.ViewModel.Exam;
using Core.Dto.ViewModel.User;
using Core.Enums;
using Core.Interface.Exam;
using Core.Interface.Users;
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
        private readonly IMaster<ShowUserBrifViewModel> _UserVm;
        private readonly IMaster<ExamList> _ExamList;
        private readonly IMaster<ExamDetailItem> _ExamDetailList;

        public ExamResultServices(IMaster<UserExam> userExam, IMaster<ShowUserBrifViewModel> userVm, IMaster<ExamList> examList, IMaster<ExamDetailItem> examDetailList)
        {
            _UserExam = userExam;
            _UserVm = userVm;
            _ExamList = examList;
            _ExamDetailList = examDetailList;
        }

        public string AnageramResult(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, dbType: System.Data.DbType.Int32);
            return _UserExam.GetStringFromDatabase("AnageramResult", dynamicParameters);
        }

        public ExamList examById(int examId)
        {
            return _ExamList.GetAllEf(a => a.Id == examId).FirstOrDefault();
        }

        public IEnumerable<ExamList> examLists()
        {
            return _ExamList.GetAllEf();
        }

        public IEnumerable<ExamDetailItem> GetAnageramResultDetailByUserId(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, System.Data.DbType.Int32);
            return _ExamDetailList.GetAll("GetAnageramResultDetail", dynamicParameters);
        }

        public IEnumerable<ExamDetailItem> GetHalandResultDetailByUserId(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, System.Data.DbType.Int32);
            return _ExamDetailList.GetAll("GetHalandResultDetail", dynamicParameters);
        }

        public IEnumerable<ExamList> GetListOFExamDoneWithUser(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, System.Data.DbType.Int32);
            return _ExamList.GetAll("GetListOFExamDoneWithUser", dynamicParameters);
        }

        public IEnumerable<ShowUserBrifViewModel> GetListOfUserDoneExam(int ExamId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("examId", ExamId, System.Data.DbType.Int32);
            return _UserVm.GetAll("GetListOfUserDoneExam", dynamicParameters);
        }

        public IEnumerable<UserExam> GetListOfUserExamByUserId(int UserId)
        {
            return _UserExam.GetAllEf(a => a.UserId == UserId);
        }

        public IEnumerable<ExamDetailItem> GetMBTIResultDetailByUserId(int UserId)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("UserId", UserId, System.Data.DbType.Int32);
            return _ExamDetailList.GetAll("GetMBTIResultDetail", dynamicParameters);
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
