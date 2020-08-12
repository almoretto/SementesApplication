using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SementesApplication
{
    public class Address
    {
        [Key]
        public int AddressId { get; set; }

        [EnumDataType(typeof(AddressKind))]
        public AddressKind AddressKind { get; set; }
        public string Designation { get; set; }
        //public string  Number { get; set; }
        public string District { get; set; }
        public string Complement { get; set; }
        public string CEP { get; set; }
        //public string  DesignationGroup { get; private set; }

        //Relationship One City has Many Address
        public int CityId { get; set; }
        public City City { get; set; }

        //Relationship one Volunteer has one address
        public Volunteer  Volunteer { get; set; } //Navigation 1 to 1 with volunte

        
        
    }
}