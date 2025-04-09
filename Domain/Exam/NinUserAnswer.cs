using Domain.User;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class NinUserAnswer:BaseModel
    {
        public int ItUserId { get; set; }
        public int ninQuestionId { get; set; }
        public int ninOptionId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
        [ForeignKey("ninOptionId")]
        public NinOption ninOption { get; set; }
        [ForeignKey("ninQuestionId")]
        public NinQuestion ninQuestion{ get; set; }
        [ForeignKey("ItUserId")]
        public MyUser users { get; set; }
    }
}
