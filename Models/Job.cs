using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SementesApplication.Models.enums;

namespace SementesApplication
{
    public class Job
    {
        [Key]
        public int JobId { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime JobDay { get; set; }
        public char JobPeriod { get; set; } //M, T, N

        [EnumDataType(typeof(ActionKind))]
        public ActionKind ActionKind { get; set; }
        public int MaxVolunteer { get; private set; }
        //Onde Entity has many Jobs
        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        //Relation one Job has one Team
        public Team Team { get; set; }
       
        public void SetMaxVolunteer()
        {
            MaxVolunteer = Entity.MaxVolunteer;
        }
    }
}