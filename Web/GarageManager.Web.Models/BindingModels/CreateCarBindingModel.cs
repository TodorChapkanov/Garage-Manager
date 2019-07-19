using GarageManager.Common;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.App.Models.BindingModels
{
    public class CreateCarBindingModel
    {
        [Required]
        [BindProperty(Name ="id")]
        public string CustomerId { get; set; }

        [Display(Name = GlobalConstants.ModelDisplayName)]
        public string ManufacturerId { get; set; }

        [Required]
        [Display(Name = GlobalConstants.RegistrationPlateDisplayName)]
        [StringLength(GlobalConstants.CarRegistrationPlateMaxLenth, ErrorMessage = GlobalConstants.CarRegistrationPlateErrorMassege,
          MinimumLength = GlobalConstants.CarRegistrationPlateMinLenth)]
        public string RegistrationPlate { get; set; }

        [Required]
        [Display(Name = GlobalConstants.ModelDisplayName)]
        public string ModelName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }
        [Required]
        [Range(GlobalConstants.CarMinKilometers, GlobalConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }
        [Required]
        [Display(Name = GlobalConstants.YearOfManufacturingDisplayName)]
        [DataType(DataType.Date)]
        public DateTime ManufacturedOn { get; set; }
        [Required]
        [Display(Name = GlobalConstants.EngineModelDisplayName)]
        [StringLength(GlobalConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }
        [Required]
        [Display(Name = GlobalConstants.EngineHorsePowerDisplayName)]
        [Range(GlobalConstants.CarMinEngineHorsePower, GlobalConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

        [Required]
         public string FuelTypeId { get; set; }

        [Required]
        public string TransmissionId { get; set; }

    }
}
