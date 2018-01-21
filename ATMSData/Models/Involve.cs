using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSData.Models
{
    public class Involve
    {
        public String Severity;
        public string AccidentRecordID { get; set; }
        public virtual AccidentRecord AccidentRecords { get; set; }
        //[Key]
        public string DriverID { get; set; }
        public virtual Driver Drivers { get; set; }
    }
}
