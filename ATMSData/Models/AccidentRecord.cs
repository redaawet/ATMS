using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMSData.Models
{
    public class AccidentRecord
    {
        public AccidentRecord()
        {

        }
        //public int AccidentIdd { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String AccidentRecordID { get; set; }
        public string City { get; set; }
        public string SubCity { get; set; }
        public string Descriptions { get; set; }
        public virtual ICollection<Occur> Occurs { get; set; }
        public virtual ICollection<Injures> Injures { get; set; }
        public virtual ICollection<Damage> Damages { get; set; }
        public virtual ICollection<CauseOn> CausesOn { get; set; }
        public virtual ICollection<Involve> Involves { get; set; }
        //public virtual ICollection<Factory> Factories { get; set; }
        //public virtual ICollection<Propriety> Proprieties { get; set; }
        //public virtual ICollection<Victim> Victims { get; set; }
        //public virtual ICollection<Driver> Drivers { get; set; }
        public virtual ICollection<FactoryAndAccident > FactrieAccidents { get; set; }
    }
}
