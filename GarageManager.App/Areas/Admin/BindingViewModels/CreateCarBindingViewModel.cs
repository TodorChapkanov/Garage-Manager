using GarageManager.Common;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.Admin.BindingViewModels
{
    public class CreateCarBindingViewModel
    {
        public string Id { get; set; }

        public string ManufacturerId { get; set; }

        public string RegistrationPlate { get; set; }

        public string ModelName { get; set; }

        public string Vin { get; set; }

        public int Кilometers { get; set; }

        public DateTime YearOfManufacture { get; set; }

        public string EngineModel { get; set; }

        public int EngineHorsePower { get; set; }

         public string FuelTypeId { get; set; }

         public string TransmissionId { get; set; }

    }
}
