using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobOption:BaseModel
    {
        public string TItle { get; set; }
        public int Value { get; set; }
        public int jobGroupIndexId { get; set; }
        public int JobQuestionId { get; set; }

        [ForeignKey("JobQuestionId")]
        public JobQuestion jobQuestion { get; set; }
        [ForeignKey("jobGroupIndexId")]
        public JopGroupIndex jopGroupIndex { get; set; }
        public virtual IEnumerable<JobUserAnswer> JobUserAnswers { get; set; }

    }
}
