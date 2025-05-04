using Core.Interface.Admin;
using Data.MasterInterface;
using Domain.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Services.Admin
{
    public class SiteSettingServices : ISiteSetting
    {
        private readonly IMaster<SitSetting> _master;

        public SiteSettingServices(IMaster<SitSetting> master)
        {
            _master = master;
        }

        public SitSetting GetSitSetting()
        {
           return _master.GetAllEf().FirstOrDefault();
        }
    }
}
