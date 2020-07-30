using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        //Onde Entity has many Jobs
        public int EntityId { get; set; }
        public Entity Entity { get; set; }

        //Relation one Job has one Team
        public int TeamId { get; set; }
        public Team Team { get; set; }
       

    }
}