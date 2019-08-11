using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.BindingModels
{
    public class CreateCarBindingModel
    {
        [Required]
        [BindProperty(Name ="id")]
        public string CustomerId { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.ModelDisplayName)]
        public string ManufacturerId { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.RegistrationPlateDisplayName)]
        [StringLength(CarConstants.CarRegistrationPlateMaxLenth, ErrorMessage = CarConstants.CarRegistrationPlateErrorMassege,
          MinimumLength = CarConstants.CarRegistrationPlateMinLenth)]
        public string RegistrationPlate { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.ModelDisplayName)]
        public string ModelName { get; set; }

        [Required]
        [MaxLength(CarConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        [Range(CarConstants.CarMinKilometers, CarConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.YearOfManufacturingDisplayName)]
        public int YearOfManufacturing { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.EngineModelDisplayName)]
        [StringLength(CarConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }
        [Required]
        [Display(Name = DisplayNameConstants.EngineHorsePowerDisplayName)]
        [Range(CarConstants.CarMinEngineHorsePower, CarConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

        [Required]
         public string FuelTypeId { get; set; }

        [Required]
        public string TransmissionId { get; set; }

    }
}
