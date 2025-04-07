using Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class ExamEvent:BaseModel
    {
        public int UserId { get; set; }
        public int ExamId { get; set; }
        public int Status { get; set; }
        [ForeignKey("UserId")]
        public MyUser  myUser{ get; set; }
        public ExamList examList{ get; set; }
    }
}
