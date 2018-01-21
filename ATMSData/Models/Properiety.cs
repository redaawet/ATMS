using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ATMSData.Models
{
    public class Properiety
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public String ProperietyID { get; set; }

        public String ProperietyType { get; set; }
        public virtual ICollection<Damage> Damages{ get; set; }


    }
}
