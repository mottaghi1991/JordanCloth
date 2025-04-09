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
    public class JobOptionServices : IJobOption
    {
        private readonly  IMaster<JobOption> _master;
        private readonly  IMaster<JobGroupIndex> _JobGroupmaster;

        public JobOptionServices(IMaster<JobOption> master, IMaster<JobGroupIndex> jobGroupmaster)
        {
            _master = master;
            _JobGroupmaster = jobGroupmaster;
        }

        public IEnumerable<JobGroupIndex> AllJobGroupIndex()
        {
            return _JobGroupmaster.GetAllEf();
        }

        public bool Delete(int JobOptionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<JobOption> GetAllJobOption()
        {
            return _master.GetAllEf();
        }

        public JobOption GetJobOptionById(int JobOptionId)
        {
           return _master.GetAllEf(a=>a.Id == JobOptionId).FirstOrDefault(); 
        }

        public JobOption Insert(JobOption JobOption)
        {
            return _master.Insert(JobOption);
        }

        public IEnumerable<JobOption> JobOptionByQuestionId(int questionId)
        {
           return _master.GetAllEf(a=>a.JobQuestionId == questionId);
        }

        public JobOption Update(JobOption JobOption)
        {
            return _master.Update(JobOption);
        }
    }
}
