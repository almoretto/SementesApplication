using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class AssistedEntities
    {
        [Key]
        public int EntityID { get; set; }
        public string EntityName { get; set; }

        [EnumDataType(typeof(DayOfWeek))]
        public DayOfWeek VisitDay { get; set; }

        [DataType(DataType.Date)]
        public DateTime VisitTime { get; set; }
        public TimeSpan VisitDuration { get; set; }

        [EnumDataType(typeof(VisitScale))]
        public VisitScale VisitScale { get; set; }
        public int MaxVolunteer { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }

        //Navigations
        public virtual ICollection<Job> Jobs { get; set; } //Navigation One Entity Has Many Actions


    }
}