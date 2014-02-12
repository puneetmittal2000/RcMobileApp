using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcMobile.Core.Entities
{
    public class LoginResponse
    {
        public string AuthToken { get; set; }

        public string ShopId { get; set; }

        public string ShopOrgId { get; set; }
    }
}
