using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Car;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CustomerCarDetailsViewModel : IMapFrom<CustomerCarListDetails>
    {
        public string Id { get; set; }

        public string RegistrationPlate { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public bool IsInService { get; set; }
    }
}
