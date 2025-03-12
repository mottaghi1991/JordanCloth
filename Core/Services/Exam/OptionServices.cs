using Core.Interface.Exam;
using Data.MasterInterface;
using Domain.Exam;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class OptionServices : IOption
    {
        private readonly IMaster<Option> _master;

        public OptionServices(IMaster<Option> option)
        {
            _master = option;
        }

        public bool Delete(int OptionId)
        {
            var obj = GetOptionById(OptionId);
            if (obj != null)
            {
                var Result = _master.Delete(obj);
                return true;
            }
            return false;
        }

        public IEnumerable<Option> GetAllOptions()
        {
            return _master.GetAllEf().ToList();
        }

        public Option GetOptionById(int OptionId)
        {
            return _master.GetAllEf().FirstOrDefault(a => a.Id == OptionId);
        }

        public Option Insert(Option Option)
        {
            return _master.Insert(Option);
        }

        public Option Update(Option Option)
        {
            return _master.Update(Option);
        }
    }
}
