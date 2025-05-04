using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interface.Admin
{
    public interface ISiteSetting
    {
        public SitSetting GetSitSetting();
    }
}
