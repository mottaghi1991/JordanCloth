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
    public class JobUserAnswerServices : IJobUserNaswer
    {
        private readonly IMaster<JobUserAnswer> _master;

        public JobUserAnswerServices(IMaster<JobUserAnswer> master)
        {
            _master = master;
        }

        public bool BulkInsert(List<JobUserAnswer> jobUserAnswers)
        {
            return _master.BulkeInsert(jobUserAnswers);  
        }
    }
}
