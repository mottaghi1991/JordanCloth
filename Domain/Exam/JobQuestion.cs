using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobQuestion:BaseModel
    {
        public string  Title{ get; set; }
        public virtual IEnumerable<JobOption> JobOptions { get; set; }  
        public virtual IEnumerable<JobUserAnswer> JobUserAnswers{ get; set; }  
    }
}
