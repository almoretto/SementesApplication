using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class State
    {
        [Key]
        public int StateId { get; set; }
        public string UFAbreviation { get; set; }
        public string UFName { get; set; }

        public virtual ICollection<City> City { get; set; } //Navigation many Cities to 1 State
    }
}
