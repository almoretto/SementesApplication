using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SementesApplication
{
    public class City
    {
        [Key]
        public int CityId { get; set; }
        public string CityName { get; set; }

        //Relationship Between City and State - One State has many cities
        public int StateId { get; set; }
        public State State { get; set; }

        //Relationship one City Has Many Address
        public ICollection<Address> Addresses { get; set; } //Relashionship
        


    }
}