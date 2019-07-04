using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
   public class Department 
    {
        public Department()
        {
            this.Cars = new HashSet<Car>();
            this.Employees = new HashSet<GMUser>();
        }
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<GMUser> Employees { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
