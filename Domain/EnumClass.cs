using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
  public  enum PermissionStatus
    {
        System=0,
        Dastresi=1,
        menu=2

    }
    public static class EventId
    {
        public static int InsertId = 1000;
        public static int DeleteId = 1001;
        public static int UpdateId = 1002;
        public static int BulkInsertId = 1003;
        public static int BulkeDelete = 1004;
        public static int Login = 1005;
        public static int APi = 1006;
        public static int Read = 1007;
        public static int Error = 1008;
        public static int NotFound = 1009;
        public static int Info = 1010;





    }

}
