using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SementesApplication
{
    public class City
    {
        [Key]
        public int CityID { get; set; }
        public string CityName { get; set; }

        [EnumDataType(typeof(State))]
        public  State CityStateId { get; set; }

        [EnumDataType(typeof(StateAbreviation))]
        public StateAbreviation UFId { get; set; }

        //Navigation
        public virtual ICollection<Address> Addresses { get; set; } //Navigation many address to 1 city
        public virtual int StateId
        {
            get
            {
                return (int)this.CityStateId;
            }
            set
            {
                CityStateId = (State)value;
            }
        }
        public virtual int StateAbreviationId
        {
            get
            {
                return (int)this.UFId;
            }
            set
            {
               UFId = (StateAbreviation)value;
            }
        }

    }
}