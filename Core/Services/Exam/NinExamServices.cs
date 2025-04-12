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
    public class NinExamServices : INinExam
    {
        private readonly IMaster<Seri> _seri;
        private readonly IMaster<NinUserAnswer> _UserNaswer;

        public NinExamServices(IMaster<Seri> seri, IMaster<NinUserAnswer> userNaswer)
        {
            _seri = seri;
            _UserNaswer = userNaswer;
        }

        public bool BulkInsertUserAnswer(List<NinUserAnswer> ninUserAnswers)
        {
            return _UserNaswer.BulkeInsert(ninUserAnswers);
        }

        public IEnumerable<Seri> GetAllSeri()
        {
           return _seri.GetAllEf();
        }

        public Seri GetSeriById(int seriId)
        {
           return _seri.GetAllEf(a=>a.Id == seriId).FirstOrDefault();    
        }
    }
}
