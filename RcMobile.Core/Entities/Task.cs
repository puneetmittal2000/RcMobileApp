using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RcMobile.Core.Entities
{
    public class Task
    {
        public string RoNumber { get; set; }

        public string OwnerFirstName { get; set; }

        public string OwnerLastName { get; set; }

        public string JobId { get; set; }

        public string VehicleMake { get; set; }

        public string VehicleLicense { get; set; }

        public string VehicleYear { get; set; }

        public string VehicleLicenseState { get; set; }

        public string VehicleVin { get; set; }

        public string ClaimNumber { get; set; }

        public string InsuranceCompanyName { get; set; }

        public DateTime? DueOut { get; set; }

        public DateTime? ArrivedDate { get; set; }

        public Address Address { get; set; }
    }
}
