using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SementesApplication
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }
        public State State { get; set; }

        //Navigation
        public virtual ICollection<Address> Addresses { get; set; } //Navigation many address to 1 city
       
       

    }
}