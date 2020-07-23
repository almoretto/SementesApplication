﻿using System;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class TeamSchedule
    {
        [Key]
        public int TeamScheduleID { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime TeamScheduleDate { get; set; }
        public char TeamSchedulePeriod { get; set; }
        public int VolunteerId { get; set; }

        //Navigations
        public virtual Volunteer Volunteer { get; set; } //Navigation 1 volunteer has many TeamSchedule
       
       
    }
}