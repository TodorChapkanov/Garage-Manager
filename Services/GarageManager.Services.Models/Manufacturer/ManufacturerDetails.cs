using GarageManager.Domain;
using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Manufacturer
{
   public  class ManufacturerDetails : IMapFrom<VehicleManufacturer>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
