using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
   public class FuelType
    {
        public FuelType()
        {
            this.Cars = new HashSet<Car>();
        }

        public string Id { get; set; }

        [Required]
        public string Type { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
