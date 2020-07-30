using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SementesApplication
{
    public class Volunteer
    {
        [Key]
        public int VolunteerId { get; set; }
        public string VDocCPF { get; set; }
        public string VDocRG { get; set; }
        public string VName { get; set; }

        [DataType(DataType.Date)]
        public DateTime VBirthDate { get; set; }
        public int VAge { get; private set; }
        public string VResumee { get; set; }
        public string VPhone { get; set; }
        public bool VMessagePhone { get; set; }
        public string VEmail { get; set; }
        public string VSocialMidiaProfile { get; set; }
        public bool VActive { get; set; }

        //Relationship One volunteer has one Address
        public int AddressId { get; set; }
        public Address Address { get; set; }

        //One Volunteers Has Many TeamSchedule
        public ICollection<TeamSchedule> TeamSchedules { get; set; } 
       
        //Relation Many Volunteers Has Many Teams
        public ICollection<TeamVolunteer> TeamVolunteer { get; set; }
               
        public void AgeCalculator()
        {
            int age = DateTime.Now.Year - VBirthDate.Year;
            if (DateTime.Now.DayOfYear < VBirthDate.DayOfYear)
            {
                age -= 1;
            }
            VAge = age;
        }
    }
}