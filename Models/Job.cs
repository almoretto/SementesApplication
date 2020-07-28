using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Job
    {
        [Key]
        public int JobID { get; set; }
        
        [DataType(DataType.Date)]
        public DateTime JobDay { get; set; }
        public char JobPeriod { get; set; } //M, T, N
        public ActionKind ActionKind { get; set; }
        public int AssistedEntitiesID { get; set; }
        public int TeamID { get; set; }

        public virtual Team Team { get; set; } //Navigation 1 team action has many volunteers
        public virtual AssistedEntities AssitedEntity { get; set; }
       

    }
}