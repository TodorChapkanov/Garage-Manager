using GarageManager.Common.GlobalConstant;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Customer : BaseEntity
    {
        public Customer()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Cars = new HashSet<Car>();
        }


        [Required]
        [StringLength(CustomerCnstants.RegisterNameMaxLength)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(CustomerCnstants.RegisterNameMaxLength)]
        public string LastName { get; set; }

        public string FullName => $"{this.FirstName} {this.LastName}";

        [Required]
        public string Email { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        public ICollection<Car> Cars{ get; set; }
    }
}
