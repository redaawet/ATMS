using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSData.Models
{
    public class Vehicle   {
        public String VehicleID { get; set; }
        public String VehicleType { get; set; }
        public virtual ICollection<CauseOn> CausesOn { get; set; }

    }
}
