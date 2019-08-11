using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Car;
using System;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CarDetailsViewModel : IMapFrom<CustomerCarDetails>
    {
        public string Id { get; set; }

        public string MakeName { get; set; }

        public string ModelName { get; set; }

        public string RegistrationPlate { get; set; }

        public int YearOfManufacturing { get; set; }

        public string Vin { get; set; }

        public int Кilometers { get; set; }

        public string EngineModel { get; set; }

        public int EngineHorsePower { get; set; }

        public string FuelTypeName { get; set; }

        public string TransmissionName { get; set; }
    }
}
