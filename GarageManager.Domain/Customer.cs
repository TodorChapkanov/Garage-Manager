using GarageManager.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.Cars = new HashSet<Car>();
        }


        [Required]
        [StringLength(GlobalConstants.CustomerNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.CustomerNameMaxLength)]
        public string LastName { get; set; }

        //TODO Add property for  Full Name 

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars{ get; set; }
    }
}
