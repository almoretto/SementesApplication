using System.ComponentModel.DataAnnotations;
using SementesTeste.enums;

namespace SementesApplication
{
    public class Address
    {
        [Key]
        public int AddressID { get; set; }
        public AddressKind AddressKind { get; set; }
        public string AddressPublicPlace { get; set; }
        public string  AddressNumber { get; set; }
        public string AddressNeighborhood { get; set; }
        public string AddressComplement { get; set; }
        public int CityID { get; set; }

        //Navigation
        public virtual Volunteer  Volunteer { get; set; } //Navigation 1 to 1 with volunteer
        public virtual City City { get; set; } //Navigation many address to 1 city

        public Address(int addressId, AddressKind addressKind, string addressPublicPlace, string addressNumber, 
            string addressNeighborhood, string addressComplement, int cityId)
        {
            AddressID = addressId;
            AddressKind = addressKind;
            AddressPublicPlace = addressPublicPlace;
            AddressNumber = addressNumber;
            AddressNeighborhood = addressNeighborhood;
            AddressComplement = addressComplement;
            CityID = cityId;
        }
    }
}