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
    public class JobQuestionServices : IJobQuestion
    {
        private readonly IMaster<JobQuestion> _master;
        private readonly IMaster<JobTestViewModel> _Showmaster;

        public JobQuestionServices(IMaster<JobQuestion> master, IMaster<JobTestViewModel> showmaster)
        {
            _master = master;
            _Showmaster = showmaster;
        }

        public bool Delete(int JobQuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobQuestion> GetAll()
        {
            return _master.GetAllEf();
        }

        public JobQuestion GetQuestionById(int JobQuestionId)
        {
            return _master.GetAllEf(a => a.Id == JobQuestionId).FirstOrDefault();
        }

        public JobQuestion Insert(JobQuestion JobQuestion)
        {
            return _master.Insert(JobQuestion);
        }

        public IEnumerable<JobTestViewModel> ShowJobExamToUser()
        {
           return _Showmaster.GetAll("ShowJobExamToUser");
        }

        public JobQuestion Update(JobQuestion JobQuestion)
        {
            return _master.Update(JobQuestion);
        }
    }
}
