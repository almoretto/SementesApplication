using System;
using SementesTeste.enums;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class AssistedEntities
    {
        [Key]
        public int AssistedEntitiesID { get; set; }
        public string AssistedEntitiesName { get; set; }
        public DayOfWeek AssistedEntitiesVisitDay { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime AssistedEntitiesVisitTime { get; set; }
        public TimeSpan AssistedEntitiesVisitDuration { get; set; }
        public VisitScale AssistedEntitiesScale { get; set; }
        public VisitMaximumPeople AssistedEntitiesMaxVolunteer { get; set; }
        public string AssistedEntitiesContact { get; set; }
        public string ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        //Navigations
        public virtual ICollection<Actions> Actions { get; set; } //Navigation One Entity Has Many Actions

        public AssistedEntities(int assistedEntitiesId, string assistedEntitiesName, DayOfWeek assistedEntitiesVisitDay,
            DateTime assistedEntitiesVisitTime, TimeSpan assistedEntitiesVisitDuration, VisitScale assistedEntitiesScale,
            VisitMaximumPeople assistedEntitiesMaxVolunteer, string assistedEntitiesContact, string contactPhone,
            string contactEmail)
        {
            AssistedEntitiesID = assistedEntitiesId;
            AssistedEntitiesName = assistedEntitiesName;
            AssistedEntitiesVisitDay = assistedEntitiesVisitDay;
            AssistedEntitiesVisitTime = assistedEntitiesVisitTime;
            AssistedEntitiesVisitDuration = assistedEntitiesVisitDuration;
            AssistedEntitiesScale = assistedEntitiesScale;
            AssistedEntitiesMaxVolunteer = assistedEntitiesMaxVolunteer;
            AssistedEntitiesContact = assistedEntitiesContact;
            ContactPhone = contactPhone;
            ContactEmail = contactEmail;
        }
    }
}