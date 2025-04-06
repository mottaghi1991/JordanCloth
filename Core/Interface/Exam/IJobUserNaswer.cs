using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IJobUserNaswer
    {
        public bool BulkInsert(List<JobUserAnswer> jobUserAnswers);
    }
}
