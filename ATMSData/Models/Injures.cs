using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMSData.Models
{
    public class Injures
    {

        public String Severity;
        public string AccidentRecordID { get; set; }
        public virtual AccidentRecord AccidentRecords { get; set; }
        [Key]
        public string VictimID { get; set; }
        public virtual Victim Victims { get; set; }
    }
}
