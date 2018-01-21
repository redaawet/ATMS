using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMSData.Models
{
    public class Factory
    {
        public Factory()
        {
           
        }
        //[Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int FactorID { get; set; }
        public String FactorType { get; set; }
        //public virtual ICollection<AccidentRecord> AccidentRecords { get; set; }
        public List<FactoryAndAccident > AccidentFactries { get; set; }
    }
}
