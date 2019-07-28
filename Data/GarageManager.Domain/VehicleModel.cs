using GarageManager.Common;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class VehicleModel : BaseEntity
    {
        
        

        [Required]
        [StringLength(GlobalConstants.RegisterNameMaxLength)]
        public string Name { get; set; }

        public string ManufactirerId { get; set; }

        public VehicleManufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
