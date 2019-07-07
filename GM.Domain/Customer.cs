using Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class Customer
    {
        public Customer()
        {
            this.Cars = new HashSet<Car>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLengthCustomerName)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(GlobalConstants.MaxLengthCustomerName)]
        public string LastName { get; set; }

        //TODO Add property for  Full Name 

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars{ get; set; }
    }
}
