using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SementesApplication
{
    public class TeamVolunteer
    {
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }

        public int TeamId { get; set; }
        public Team Team { get; set; }
        
    }
}
