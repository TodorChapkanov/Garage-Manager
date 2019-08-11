using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Car;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CompletedCarListViewModel : IMapFrom<CompletedCarList>
    {
        public string Id { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string  RegistrationPlate { get; set; }
    }
}
