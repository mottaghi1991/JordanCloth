using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IExamResultFinals
    {
        public ExamResultFinal resultFinal(string ResultText);
        public ExamResultFinal resultFinalById(int ResultId);
        public IEnumerable<ExamResultFinal> resultFinalByExamId(int ExamId);
    }
}
