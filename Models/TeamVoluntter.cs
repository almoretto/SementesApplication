using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class TeamVolunteer
    {
        [Key]
        public int TeamVolunteerId { get; set; }
        //Relation one volunteer has many teamvolunteer
        public int VolunteerId { get; set; }
        public Volunteer Volunteer { get; set; }

        //relation one team has many teamvolunteer
        public int TeamId { get; set; }
        public Team Team { get; set; }
        
    }
}
