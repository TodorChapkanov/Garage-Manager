using System;

namespace GarageManager.Web.Models.BindingModels
{
    public class EditCarBindingModel
    {
        public string Id { get; set; }
        public string RegistrationPlate { get; set; }

        public int Кilometers { get; set; }

        public DateTime YearOfManufacturing { get; set; }

        public string EngineModel { get; set; }

        public int EngineHorsePower { get; set; }

        public string FuelTypeId { get; set; }


        public string TransmissionId { get; set; }
    }
}
