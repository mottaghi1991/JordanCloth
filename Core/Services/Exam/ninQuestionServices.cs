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
    public class ninQuestionServices : INinQuestion
    {
        private readonly IMaster<NinQuestion> _master;

        public ninQuestionServices(IMaster<NinQuestion> master)
        {
            _master = master;
        }

        public bool Delete(int NinQuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NinQuestion> GetAllNinQuestions()
        {
            return _master.GetAllEf();
        }

        public NinQuestion GetNinQuestionById(int NinQuestionId)
        {
         return _master.GetAllEf(a=>a.Id == NinQuestionId).FirstOrDefault();
        }

        public IEnumerable<NinQuestion> GetNinQuestionBySeriId(int seriId)
        {
           return _master.GetAllEf(a=>a.seriId== seriId);
        }

        public NinQuestion Insert(NinQuestion NinQuestion)
        {
         return _master.Insert(NinQuestion);
        }

        public NinQuestion Update(NinQuestion NinQuestion)
        {
            return _master.Update(NinQuestion);
        }
    }
}
