using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SementesApplication.Models.ViewModels
{
    public class SchedulersOfVolunteers
    {
        [DataType(DataType.Date)]
        public DateTime DateSchedule { get; set; }
        public List<Volunteer> Volunteers { get; set; }
    }
}
