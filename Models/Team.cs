﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public List<Volunteer> Volunteers { get; set; } = new List<Volunteer>();

        //Relation Many to Many Auxiliary Class TeamVolunteer
        public ICollection<TeamVolunteer> TeamVolunteer { get; set; }
       
        //Relation One Job Has one Team
        public int JobId { get; set; }
        public Job Job { get; set; }

        
    }
}
