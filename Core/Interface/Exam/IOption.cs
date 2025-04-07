using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Exam
{
    public interface IOption
    {
        public IEnumerable<Option> GetAllOptions();
        public IEnumerable<Option> GetOptionByQuestionId(int QuestionId);
                public Option Insert(Option Option);
        public Option Update(Option Option);
        public bool Delete(int OptionId);
        public Option GetOptionById(int OptionId);
    }
}
