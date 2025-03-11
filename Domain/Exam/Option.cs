using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exam
{
    public class Option:BaseModel
    {
      
        public string Title { get; set; }

    
        public IEnumerable<SubOption> SubOptions { get; set; }
    }
}
