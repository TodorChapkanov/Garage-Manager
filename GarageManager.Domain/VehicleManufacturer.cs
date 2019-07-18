using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class VehicleManufacturer : BaseEntity
    {
        public VehicleManufacturer()
        {
            this.Cars = new HashSet<Car>();
            this.VehicleModels = new HashSet<VehicleModel>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
