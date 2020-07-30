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

        [EnumDataType(typeof(ActionKind))]
        public ActionKind ActionKind { get; set; }
        public AssistedEntities AssistedEntities { get; set; }
        public Team Team { get; set; }
       

    }
}