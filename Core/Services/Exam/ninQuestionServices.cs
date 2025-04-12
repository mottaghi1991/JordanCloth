using Core.Interface.Exam;
using Dapper;
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
        private readonly IMaster<NinOption> _Ninmaster;

        public ninQuestionServices(IMaster<NinQuestion> master, IMaster<NinOption> ninmaster)
        {
            _master = master;
            _Ninmaster = ninmaster;
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
