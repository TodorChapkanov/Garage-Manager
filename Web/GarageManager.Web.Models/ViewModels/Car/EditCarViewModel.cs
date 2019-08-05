using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class EditCarViewModel
    {
        public string Id { get; set; }
        public string CustomerId { get; set; }
        public string Make { get; set; }

        [Display(Name = DisplayNameConstants.ModelDisplayName)]
        public string Model { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.RegistrationPlateDisplayName)]
        [StringLength(CarConstants.CarRegistrationPlateMaxLenth, ErrorMessage = CarConstants.CarRegistrationPlateErrorMassege,
          MinimumLength = CarConstants.CarRegistrationPlateMinLenth)]
        public string RegistrationPlate { get; set; }


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

        [Display(Name = DisplayNameConstants.FuelTypeDisplayName)]
        public string FuelTypeId { get; set; }

        public IEnumerable<SelectListItem> FuelTypes { get; set; }

        public string TransmissionId { get; set; }

        public IEnumerable<SelectListItem> Transmissions { get; set; }
    }
}
