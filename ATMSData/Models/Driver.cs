using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMSData.Models
{
    public class Driver
    {
       
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String DriverID { get; set; }
        public String FirstName { get; set; }
        public String SecondName { get; set; }
        public String LastName { get; set; }
        public String sex { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
        public String Job { get; set; }
        public virtual ICollection<Involve> Involves { get; set; }
    }
}
