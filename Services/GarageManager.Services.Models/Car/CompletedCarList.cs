using GarageManager.Services.Mapping;

namespace GarageManager.Services.Models.Car
{
    public class CompletedCarList : IMapFrom<Domain.Car>
    {
        public string  Id { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegistrationPlate { get; set; }
    }
}
