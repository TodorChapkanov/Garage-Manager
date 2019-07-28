using GarageManager.Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CreateCarViewModel
    {
        public string  CustomerId { get; set; }

        [Display(Name = GlobalConstants.ManufacturersDisplayName)]
        public IEnumerable<SelectListItem> AllManufacturers { get; set; }

        public string ManufacturerId { get; set; }

        [Display(Name = GlobalConstants.ModelDisplayName)]
        public string ModelName { get; set; }

        [Required]
        [Display(Name = GlobalConstants.RegistrationPlateDisplayName)]
        [StringLength(GlobalConstants.CarRegistrationPlateMaxLenth, ErrorMessage = GlobalConstants.CarRegistrationPlateErrorMassege,
          MinimumLength = GlobalConstants.CarRegistrationPlateMinLenth)]
        public string RegistrationPlate { get; set; }

        public string ModelId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinKilometers, GlobalConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Display(Name =GlobalConstants.YearOfManufacturingDisplayName)]
        [DataType(DataType.Date)]
        public DateTime? YearOfManufacturing { get; set; }

        [Required]
        [Display(Name =GlobalConstants.EngineModelDisplayName)]
        [StringLength(GlobalConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Display(Name = GlobalConstants.EngineHorsePowerDisplayName)]
        [Range(GlobalConstants.CarMinEngineHorsePower, GlobalConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }
        
        [Display(Name = GlobalConstants.FuelTypeDisplayName)]
       public string FuelTypeId { get; set; }

        public IEnumerable<SelectListItem> FuelTypes { get; set; }

        public string TransmissionId { get; set; }

        public IEnumerable<SelectListItem> Transmissions { get; set; }

    }
}