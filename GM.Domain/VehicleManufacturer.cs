﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class VehicleManufacturer
    {
        public VehicleManufacturer()
        {
            this.Cars = new HashSet<Car>();
            this.VehicleModels = new HashSet<VehicleModel>();
        }
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Car> Cars { get; set; }

        public ICollection<VehicleModel> VehicleModels { get; set; }
    }
}
