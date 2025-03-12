using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IQuestion
    {
        public int GetNextQuestionNum(int cuurentNumber);
        public IEnumerable<Question> GetAllQuestions();
        public Question Insert(Question question);
        public Question Update(Question question);
        public bool Delete(int QuestionId);
        public Question GetQuestionById(int QuestionId);
    }
}
