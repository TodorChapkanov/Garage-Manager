using GarageManager.Common.GlobalConstant;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Car;
using System;
using System.ComponentModel;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CarDetailsViewModel : IMapFrom<CustomerCarDetails>
    {
        public string CustomerId { get; set; }

        [DisplayName(DisplayNameConstants.ManufacturersDisplayName)]
        public string MakeName { get; set; }

        [DisplayName(DisplayNameConstants.ModelDisplayName)]
        public string ModelName { get; set; }

        [DisplayName(DisplayNameConstants.RegistrationPlateDisplayName)]
        public string RegistrationPlate { get; set; }

        [DisplayName(DisplayNameConstants.YearOfManufacturingDisplayName)]
        public int YearOfManufacturing { get; set; }

        public string Vin { get; set; }

        public int Кilometers { get; set; }

        [DisplayName(DisplayNameConstants.EngineModelDisplayName)]
        public string EngineModel { get; set; }

        [DisplayName(DisplayNameConstants.EngineHorsePowerDisplayName)]
        public int EngineHorsePower { get; set; }

        [DisplayName(DisplayNameConstants.FuelTypeDisplayName)] 
        public string FuelTypeName { get; set; }

        [DisplayName(DisplayNameConstants.TransmissionTypeDisplayName)]
        public string TransmissionName { get; set; }
    }
}
