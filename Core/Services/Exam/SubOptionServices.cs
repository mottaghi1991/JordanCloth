using Core.Dto.ViewModel.Exam;
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
    public class SubOptionServices : ISubOption
    {
        private readonly IMaster<ShowExamToUserViewModel> _VmMaster;
        private readonly IMaster<UserAnswer> _UserAnswerMaster;


        public SubOptionServices(IMaster<ShowExamToUserViewModel> vmMaster, IMaster<UserAnswer> userAnswerMaster)
        {
            _VmMaster = vmMaster;
            _UserAnswerMaster = userAnswerMaster;
        }

        public bool BulkInsert(List<UserAnswer> ListOfAnswer)
        {
          return _UserAnswerMaster.BulkeInsert(ListOfAnswer);
        }

        public IEnumerable<ShowExamToUserViewModel> GetAllQuestion(int QuestionId)
        {
            DynamicParameters p=new DynamicParameters();
            p.Add("QuestionId", QuestionId, System.Data.DbType.Int32);
            return _VmMaster.GetAll("GetAllQuestion",p);
        }
    }
}
