using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SementesApplication
{
    public class Team
    {
        public int TeamID { get; set; }
        public int VolunteerID { get; set; }
        public int ActionID { get; set; }

        public virtual ICollection<Volunteer> Volunteer { get; set; }

    }
}
