using Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class UserExam

    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int ExamId { get; set; }
        [ForeignKey("UserId")]
        public MyUser myUser{ get; set; }
        [ForeignKey("ExamId")]
        public ExamList examList { get; set; }
    }
}
