using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface INinQuestion
    {
        public IEnumerable<NinQuestion> GetAllNinQuestions();
        public IEnumerable<NinQuestion> GetNinQuestionBySeriId(int seriId);
        public IEnumerable<NinQuestion> GetNinQuestionBySeriLevel(int seriLevel);
        public NinQuestion Insert(NinQuestion NinQuestion);
        public NinQuestion Update(NinQuestion NinQuestion);
        public bool Delete(int NinQuestionId);
        public NinQuestion GetNinQuestionById(int NinQuestionId);



        public IEnumerable<NinOption> GetAllNinOption();
   
    }
}
