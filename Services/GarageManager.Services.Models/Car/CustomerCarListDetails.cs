using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Car
{
    public class CustomerCarListDetails : IMapFrom<Domain.Car>
    {
        public string Id { get; set; }

        public string RegistrationPlate { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public bool IsInService { get; set; }
    }
}
