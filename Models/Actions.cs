using System;
using System.Collections.Generic;
using SementesTeste.enums;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Actions
    {
        [Key]
        public int ActionID { get; set; }

        [DataType(DataType.Date)]
        public DateTime ActionDay { get; set; }
        public VisitPeriod ActionPeriod { get; set; }
        public ActionKind ActionKind { get; set; }
        public int AssistedEntitiesID { get; set; }

        //Navigations
        public virtual AssistedEntities AssistedEntities { get; set; } //Navigation Many Actions Belongs to one Entity
        public virtual TeamAction TeamAction { get; set; } // Navigation 1 Action has 1 TeamAction

        public Actions(int actionId, int assistedEntitiesId, DateTime actionDay, VisitPeriod actionPeriod, ActionKind actionKind,
            AssistedEntities assistedEntities)
        {
            ActionID = actionId;
            AssistedEntitiesID = assistedEntitiesId;
            ActionDay = actionDay;
            ActionPeriod = actionPeriod;
            ActionKind = actionKind;
            AssistedEntities = assistedEntities;
        }
    }
}