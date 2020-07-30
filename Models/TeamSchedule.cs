using System;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class TeamSchedule
    {
        [Key]
        public int TeamScheduleId { get; set; }
       
        [DataType(DataType.Date)]
        public DateTime TSDate { get; set; }
        public char TSPeriod { get; set; }

        //Relationship Volunteer Has many TeamSchedule
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }
       
       
    }
}