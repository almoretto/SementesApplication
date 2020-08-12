using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Entity
    {
        [Key]
        public int EntityId { get; set; }
        public string EntityName { get; set; }

        [EnumDataType(typeof(DayOfWeek))]
        public DayOfWeek VisitDay { get; set; }

        [DataType(DataType.Time)]
        public DateTime VisitTime { get; set; }
        public TimeSpan VisitDuration { get; set; }

        [EnumDataType(typeof(VisitScale))]
        public VisitScale VisitScale { get; set; }
        public int MaxVolunteer { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

       //One Entity Has many Jobs
        public ICollection<Job> Jobs { get; set; } 

    }
}