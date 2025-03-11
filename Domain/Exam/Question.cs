using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class Question:BaseModel
    {
        public string Title { get; set; }
        public IEnumerable<Option> options { get; set; }
    }
}
