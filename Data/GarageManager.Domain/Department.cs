using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
   public class Department : BaseEntity
    {
        public Department()
        {
            this.Cars = new HashSet<Car>();
            this.Employees = new HashSet<GMUser>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<GMUser> Employees { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
