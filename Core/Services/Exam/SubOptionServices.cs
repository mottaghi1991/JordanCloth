using Core.Dto.ViewModel.Exam;
using Core.Interface.Exam;
using Data.MasterInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Exam
{
    public class SubOptionServices : ISubOption
    {
        private readonly IMaster<ShowExamToUserViewModel> _VmMaster;

        public SubOptionServices(IMaster<ShowExamToUserViewModel> vmMaster)
        {
            _VmMaster = vmMaster;
        }

        public IEnumerable<ShowExamToUserViewModel> GetAllQuestion()
        {
            return _VmMaster.GetAll("GetAllQuestion");
        }
    }
}
