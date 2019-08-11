using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
   public class FuelType : BaseEntity
    {

        [Required]
        public string Name { get; set; }
    }
}
