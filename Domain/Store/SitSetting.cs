using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Store
{
    public class SitSetting:BaseModel
    {
        public int FirstSlider { get; set; }
        public int SecondSlider { get; set; }
        public int ThirdSlider { get; set; }
        public int FourthSlider { get; set; }
        public int SixSlider { get; set; }

    }
}
