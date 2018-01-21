using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ATMSData.Models
{
    public class Damage
    {
        public String Severity;
        public string AccidentRecordID { get; set; }
        public virtual AccidentRecord AccidentRecords { get; set; }
        [Key]
        public string ProperietyID { get; set; }
        public virtual Properiety Properieties { get; set; }

        public String ProperietyCost { get; set; }
    }
}
