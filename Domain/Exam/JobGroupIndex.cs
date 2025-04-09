using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobGroupIndex:BaseModel
    {
        public string Title { get; set; }
        public int Order { get; set; }
        public virtual IEnumerable<JobOption> JobOptions { get; set; }

    }
}
