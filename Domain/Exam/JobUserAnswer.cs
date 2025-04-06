using Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class JobUserAnswer:BaseModel
    {

        public int JobQuestionId { get; set; }
        public int OptionId { get; set; }
        public int UserId { get; set; }
        [ForeignKey("JobQuestionId")]
        public virtual JobQuestion JobQuestion{ get; set; }
        [ForeignKey("OptionId")]
        public virtual JobOption jobOption { get; set; }
        [ForeignKey("UserId")]
        public virtual MyUser MyUser { get; set; }
    }
}
