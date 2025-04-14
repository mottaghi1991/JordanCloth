using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class Seri:BaseModel
    {
        public string Title { get; set; }
        public int Level { get; set; }
        public int Number { get; set; }
        public virtual IEnumerable<NinQuestion> NinQuestions{ get; set; }
    }
}
