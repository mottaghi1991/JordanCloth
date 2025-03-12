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
    public class QuestionServices : IQuestion
    {
        private readonly IMaster<Question> _master;

        public QuestionServices(IMaster<Question> master)
        {
            _master = master;
        }

        public bool Delete(int QuestionId)
        {
            var obj=GetQuestionById(QuestionId);
            if (obj != null) {
               var Result= _master.Delete(obj);
                return true;
            }
            return false;
         
        }

        public IEnumerable<Question> GetAllQuestions()
        {
            return _master.GetAllEf().ToList();
        }

        public int GetNextQuestionNum(int cuurentNumber)
        {
            var nextQuestion = _master.GetAllEf()
                                       .OrderBy(a => a.Id)
                                       .Skip(cuurentNumber)  // Skip همه سوالات قبل از currentNumber
                                       .Take(1)              // یک سوال بعدی
                                       .FirstOrDefault();
            // اگر سوال بعدی وجود نداشت، 0 را برمی‌گرداند
            return nextQuestion?.Id ?? 0;  // اگر nextQuestion null بود، 0 برمی‌گرداند
        }

        public Question GetQuestionById(int QuestionId)
        {
            return _master.GetAllEf().FirstOrDefault(a => a.Id == QuestionId);
        }

        public Question Insert(Question question)
        {
          return _master.Insert(question);  
        }

        public Question Update(Question question)
        {
         return _master.Update(question);   
        }

       
    }
}
