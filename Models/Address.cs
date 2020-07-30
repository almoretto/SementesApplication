using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }

        [EnumDataType(typeof(AddressKind))]
        public AddressKind AddressKind { get; set; }
        public string Designation { get; set; }
        public string  Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }

        public City City { get; set; }

        //Navigation
        public virtual Volunteer  Volunteer { get; set; } //Navigation 1 to 1 with volunte

        
    }
}