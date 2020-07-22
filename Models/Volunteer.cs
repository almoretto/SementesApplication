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
        public string VolunteerDocCPF { get; set; }
        public string VolunteerDocRG { get; set; }
        public string VolunteerName { get; set; }
        public DateTime VolunteerBirthDate { get; set; }
        public int VolunteerAge { get; private set; }
        public string VolunteerResumee { get; set; }
        public string VolunteerPhone { get; set; }
        public bool VolunteerMessagePhone { get; set; }
        public string VolunteerEmail { get; set; }
        public string VolunteerSocialMidiaProfile { get; set; }
        public bool VolunteerActive { get; set; }
        public int AddressID { get; set; }

        //Navigation
        public virtual Address Address { get; set; } //Navigation 1 to 1 with address
        public virtual ICollection<TeamSchedule> TeamSchedules { get; set; } //Navigation 1 volunteer has many TeamSchedule
        public virtual TeamAction TeamAction { get; set; }

        public Volunteer(int volunteerId, string volunteerDocCPF, string volunteerDocRG, string volunteerName,
            DateTime volunteerBirthDate, int volunteerAge, string volunteerResumee, int addressId, string volunteerPhone,
            bool volunteerMessagePhone, string volunteerEmail, string volunteerSocialMidiaProfile, bool volunteerActive)
        {
            VolunteerID = volunteerId;
            VolunteerDocCPF = volunteerDocCPF;
            VolunteerDocRG = volunteerDocRG;
            VolunteerName = volunteerName;
            VolunteerBirthDate = volunteerBirthDate;
            VolunteerAge = volunteerAge;
            VolunteerResumee = volunteerResumee;
            AddressID = addressId;
            VolunteerPhone = volunteerPhone;
            VolunteerMessagePhone = volunteerMessagePhone;
            VolunteerEmail = volunteerEmail;
            VolunteerSocialMidiaProfile = volunteerSocialMidiaProfile;
            VolunteerActive = volunteerActive;
            AgeCalculator();
        }

        private void AgeCalculator()
        {
            int age = DateTime.Now.Year - VolunteerBirthDate.Year;
            if (DateTime.Now.DayOfYear < VolunteerBirthDate.DayOfYear)
            {
                age -= 1;
            }
            VolunteerAge = age;
        }
    }
}