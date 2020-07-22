using SementesTeste.enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SementesApplication
{
    public class TeamAction
    {
        [Key]
        public int TeamActionID { get; set; }
        public DateTime TeamActionDateAndTime { get; set; }
        public VisitPeriod TeamActionVisitPeriod { get; set; }
        public List<Volunteer> TeamActionVolunteers { get; set; }
        public int ActionID { get; set; }

        public virtual Actions Actions { get; set; } //Navigation 1 TeamAction Belongs to 1 Action
        public virtual ICollection<Volunteer> Volunteers { get; set; } //Navigation 1 team action has many volunteers

        public TeamAction(int teamActionId, int actionId, DateTime teamActionDateAndTime, VisitPeriod teamActionVisitPeriod, 
            List<Volunteer> teamActionVolunteers)
        {
            TeamActionID = teamActionId;
            ActionID = actionId;
            TeamActionDateAndTime = teamActionDateAndTime;
            TeamActionVisitPeriod = teamActionVisitPeriod;
            TeamActionVolunteers = teamActionVolunteers;
        }
    }
}