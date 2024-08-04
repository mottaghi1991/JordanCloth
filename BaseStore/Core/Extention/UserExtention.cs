using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Core.Extention
{
    public static class UserExtention
    {
        public static int GetUserId(this ClaimsPrincipal principal)
        {
            try
            {
                var Identifier = principal.Claims.SingleOrDefault(a => a.Type == ClaimTypes.NameIdentifier);
                return Identifier.Value == null ? 0 : int.Parse(Identifier.Value);
            }
            catch (Exception e)
            {
                return 0;
            }
        }
    }
}
