using System;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CarDetailsViewModel
    {
        public string Id { get; set; }

        public string Make { get; set; }

        public string Model { get; set; }

        public string RegistrationPlate { get; set; }

        public DateTime? ManufacturedOn { get; set; }

        public string Vin { get; set; }

        public int Кilometers { get; set; }

        public string EngineModel { get; set; }

        public int EngineHorsePower { get; set; }

        public string FuelType { get; set; }

        public string Transmission { get; set; }
    }
}
