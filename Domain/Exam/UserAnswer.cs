using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class UserAnswer:BaseModel
    {
        public int QuestionId { get; set; }
        public int OptionId { get; set; }
        public int SubOptionId { get; set; }
        public DateTime InsertDate { get; set; } = DateTime.Now;
    }
}
