using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMSData.Models
{
    public  class Occur
    {
        public System.DateTime AccidentTime { get; set; }
      
        //[ForeignKey("AccidentRecord")]
        public string AccidentRecordID { get; set; }
        public virtual AccidentRecord AccidentRecord { get; set; }
        public virtual RoadGeometry RoadGeometry { get; set; }

    }
}
