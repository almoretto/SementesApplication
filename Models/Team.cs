using System.Collections.Generic;

namespace SementesApplication
{
    public class Team
    {
        public int TeamID { get; set; }
        public List<Volunteer> Volunteer { get; set; } = new List<Volunteer>();

        public virtual ICollection<Volunteer> Volunteers { get; set; }
        public virtual Job Job { get; set; }
    }
}
