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
    public class ExamResultFinalServices : IExamResultFinals
    {
        private readonly IMaster<ExamResultFinal> _master;

        public ExamResultFinalServices(IMaster<ExamResultFinal> master)
        {
            _master = master;
        }

        public ExamResultFinal Insert(ExamResultFinal examResultFinal)
        {
            return _master.Insert(examResultFinal);
        }

        public ExamResultFinal resultFinal(string ResultText)
        {
          return _master.GetAllEf(a=>a.Title==ResultText).FirstOrDefault();
        }

        public IEnumerable<ExamResultFinal> resultFinalByExamId(int ExamId)
        {
            return _master.GetAllEf(a=>a.ExamId==ExamId);   
        }

        public ExamResultFinal resultFinalById(int ResultId)
        {
          return _master.GetAllEf(a=>a.Id==ResultId).FirstOrDefault();
        }

        public ExamResultFinal Update(ExamResultFinal examResultFinal)
        {
            return _master.Update(examResultFinal);
        }
    }
}
