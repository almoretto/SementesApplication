using System;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class TeamSchedule
    {
        [Key]
        public int TeamScheduleID { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime TSDate { get; set; }
        public char TSPeriod { get; set; }
        public Volunteer Volunteer { get; set; }
       
       
    }
}