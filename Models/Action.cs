using SementesTeste.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SementesApplication
{
    public class Action
    {
        [Key]
        public int ActionID { get; set; }
        public DateTime ActionDateAndTime { get; set; }
        public VisitPeriod ActionVisitPeriod { get; set; }
        public int TeamID { get; set; }

        public virtual Actions Actions { get; set; } //Navigation 1 TeamAction Belongs to 1 Action
        public virtual ICollection<Team> Team { get; set; } //Navigation 1 team action has many volunteers

       
    }
}