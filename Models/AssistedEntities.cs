using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class AssistedEntities
    {
        [Key]
        public int AssistedEntitiesID { get; set; }
        public string AssistedEntitiesName { get; set; }

        [EnumDataType(typeof(DayOfWeek))]
        public DayOfWeek AssistedEntitiesVisitDay { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime AssistedEntitiesVisitTime { get; set; }
        public TimeSpan AssistedEntitiesVisitDuration { get; set; }

        [EnumDataType(typeof(VisitScale))]
        public VisitScale AssitedEntitiesVisitScale { get; set; }

        [EnumDataType(typeof(VisitMaximumPeople))]
        public VisitMaximumPeople AssistedEntitiesMaxVolunteer { get; set; }
        public string AssistedEntitiesContact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        //Navigations
        public virtual ICollection<Job> Jobs { get; set; } //Navigation One Entity Has Many Actions

       
    }
}