using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.FuelType
{
    public class FuelTypeDetails : IMapFrom<Domain.FuelType>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
