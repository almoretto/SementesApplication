using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SementesApplication
{
    public class Team
    {
        public int TeamID { get; set; }
        public List<int> TeamSchedule { get; set; }

        public virtual ICollection<TeamSchedule> TeamSchedules { get; set; }
        public virtual Job job { get; set; }
    }
}
