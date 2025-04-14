using Core.Interface.Exam;
using Core.Interface.Users;
using Dapper;
using Data.MasterInterface;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class ninQuestionServices : INinQuestion
    {
        private readonly IMaster<NinQuestion> _master;
        private readonly IMaster<NinOption> _Ninmaster;
        private readonly INinExam _ninExam;

        public ninQuestionServices(IMaster<NinQuestion> master, IMaster<NinOption> ninmaster, INinExam ninExam)
        {
            _master = master;
            _Ninmaster = ninmaster;
            _ninExam = ninExam;
        }

        public bool Delete(int NinQuestionId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<NinOption> GetAllNinOption()
        {
            return _Ninmaster.GetAllEf();
        }

        public IEnumerable<NinQuestion> GetAllNinQuestions()
        {
            return _master.GetAllEf();
        }

        public IEnumerable<NinQuestion> GetNextQuestions(int seriId, int UserId)
        {
           var maxSeri= _ninExam.GetMaxSerUserAnswer(UserId);
            if(maxSeri!=0)
            {
                seriId = maxSeri;
            }
            var Seri = _ninExam.GetSeriById(seriId);
            if (Seri == null)
            {
               return GetNinQuestionBySeriLevel(1);

            }
          
            if (Seri.Level >= 3 & Seri.Level < 6)
            {
                var MaxLetter = _ninExam.GetMaxFirstLevel(UserId);
                return GetNinQuestionBySeriLevelAndLetter(Seri.Level + 1, MaxLetter);
            }
            if (Seri.Level == 6)
            {
                
                return null;
            }
          
                return GetNinQuestionBySeriLevel(Seri.Level +1);

         
        }

        public NinQuestion GetNinQuestionById(int NinQuestionId)
        {
         return _master.GetAllEf(a=>a.Id == NinQuestionId).FirstOrDefault();
        }

        public IEnumerable<NinQuestion> GetNinQuestionBySeriId(int seriId)
        {
           return _master.GetAllEf(a=>a.seriId== seriId);
        }

        public IEnumerable<NinQuestion> GetNinQuestionBySeriLevel(int seriLevel)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("seriLevel", seriLevel, dbType: System.Data.DbType.Int32);
            return _master.GetAll("GetNinQuestionBySeriLevel", dynamicParameters);
        }

        public IEnumerable<NinQuestion> GetNinQuestionBySeriLevelAndLetter(int seriLevel, string Letter)
        {
            DynamicParameters dynamicParameters = new DynamicParameters();
            dynamicParameters.Add("seriLevel", seriLevel, dbType: System.Data.DbType.Int32);
            dynamicParameters.Add("Letter", Letter, dbType: System.Data.DbType.String);
            return _master.GetAll("GetNinQuestionBySeriLevelAndLetter", dynamicParameters);
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
