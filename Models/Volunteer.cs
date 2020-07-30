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
        public int VolunteerID { get; set; }
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
        public Address Address { get; set; }

        //Navigation
        public virtual ICollection<TeamSchedule> TeamSchedules { get; set; } //Navigation 1 volunteer has many TeamSchedule
       
               
        private void AgeCalculator()
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