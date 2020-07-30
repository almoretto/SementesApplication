using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public List<Volunteer> Volunteer { get; set; } = new List<Volunteer>();

        public virtual Job Job { get; set; }
    }
}
