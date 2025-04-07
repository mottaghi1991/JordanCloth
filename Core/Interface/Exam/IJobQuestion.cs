using Core.Dto.ViewModel.Exam;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Interface.Exam
{
    public interface IJobQuestion
    {
        public IEnumerable<JobQuestion> GetAll();
        public IEnumerable<JobTestViewModel> ShowJobExamToUser();
        public JobQuestion Insert(JobQuestion JobQuestion);
        public JobQuestion Update(JobQuestion JobQuestion);
        public bool Delete(int JobQuestionId);
        public JobQuestion GetQuestionById(int JobQuestionId);
    }
}
