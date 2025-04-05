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
        private readonly IMaster<SubOption> _SubMaster;


        public SubOptionServices(IMaster<ShowExamToUserViewModel> vmMaster, IMaster<UserAnswer> userAnswerMaster, IMaster<SubOption> subMaster)
        {
            _VmMaster = vmMaster;
            _UserAnswerMaster = userAnswerMaster;
            _SubMaster = subMaster;
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

        public IEnumerable<SubOption> GetAllSubOptions()
        {
            return _SubMaster.GetAllEf();
        }

        public IEnumerable<SubOption> GetSubOptionByQuestionAndOption(int QuestionId, int OptionId)
        {
           return _SubMaster.GetAllEf().Where(a=>a.QuestionId==QuestionId&a.OptionId==OptionId).ToList();   
        }

        public SubOption Insert(SubOption subOption)
        {
       return _SubMaster.Insert(subOption); 
        }
    }
}
