using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcMobile.Core.Entities
{
    public class Address
    {
        public string AddressLine { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string PostalCode { get; set; }
        public string OwnerWorkPhone { get; set; }
        public string OwnerEmail { get; set; }
    }
}
