using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User.Permission
{
    public class PermissionList
    {
        public int PermissionListId { get; set; }
        public int Radif { get; set; }
        public string Area { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Descript { get; set; }
        public int? ParentId { get; set; }

        public int? Status { get; set; }

        public List<RolePermission> RolePermissions { get; set; }
    }
}
