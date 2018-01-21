
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ATMSData.Models
{
    public partial class RoadGeometry
    {
        public RoadGeometry()
        {
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string RoadName { get; set; }
        public String Latitude { get; set; }
        public String Longutide { get; set; }
        public double AADT { get; set; }
        public double ADT { get; set; }
        public string SurfaceType { get; set; }
        public short SpeedLimit { get; set; }
        public short NoLine { get; set; }
        public string TrafficMovement { get; set; }
        public string JunctionType { get; set; }
        public string JunctionControl { get; set; }
        public string RoadClassifaction { get; set; }
        public double RoadWidth { get; set; }
        public double CarriageWidth { get; set; }
        public double ShoulderWidth { get; set; }
        public string HorizontalFeature { get; set; }
        public string VerticalFeature { get; set; }
        public virtual ICollection<Occur> Occurs { get; set; }
    }
}
