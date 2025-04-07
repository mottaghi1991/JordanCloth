using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IJobOption
    {
        public IEnumerable<JobOption> GetAllJobOption();
        public IEnumerable<JobOption> JobOptionByQuestionId(int questionId);
        public JobOption Insert(JobOption JobOption);
        public JobOption Update(JobOption JobOption);
        public bool Delete(int JobOptionId);
        public JobOption GetJobOptionById(int JobOptionId);


        public IEnumerable<JopGroupIndex> AllJobGroupIndex();
    }
}
