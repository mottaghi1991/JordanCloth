using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface INinExam
    {
        public IEnumerable<Seri> GetAllSeri();  
        public Seri GetSeriById(int seriId);

        public bool BulkInsertUserAnswer(List<NinUserAnswer> ninUserAnswers);
        public string GetMaxFirstLevel(int UserId);
        public int GetMaxSerUserAnswer(int UserId);
    }
}
