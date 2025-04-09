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

        public NinExamServices(IMaster<Seri> seri)
        {
            _seri = seri;
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
