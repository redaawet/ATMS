using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMSData.Models
{
    public class CauseOn
    {
       
        public String Severity;
        public string AccidentRecordID { get; set; }
        public virtual AccidentRecord AccidentRecords { get; set; }
        //[Key]
        public string VehicleID { get; set; }
        public virtual Vehicle Vehicles { get; set; }

        public String VehicleCost { get; set; }
    }
}
