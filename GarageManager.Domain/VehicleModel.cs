using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class VehicleModel
    {
        private const int MaxNameLength = 30;
        public string Id { get; set; }

        [Required]
        [StringLength(MaxNameLength)]
        public string Name { get; set; }

        public string ManufactirerId { get; set; }

        public VehicleManufacturer Manufacturer { get; set; }

        public ICollection<Car> Cars { get; set; }
    }
}
