using System;
using System.Collections.Generic;
using System.Text;

namespace ATMSData.Models
{
   public  class FactoryAndAccident
    {
        public int FactoryId { get; set; }
        public Factory Factories { get; set; }
        public String AccidentRecordId { get; set; }
        public AccidentRecord AccidentRecords { get; set; }
    }
}
