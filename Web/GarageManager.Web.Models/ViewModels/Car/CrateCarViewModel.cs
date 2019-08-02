﻿using GarageManager.Common.GlobalConstant;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Web.Models.ViewModels.Car
{
    public class CreateCarViewModel
    {
        public string  CustomerId { get; set; }

        [Display(Name = DisplayNameConstants.ManufacturersDisplayName)]
        public IEnumerable<SelectListItem> AllManufacturers { get; set; }

        public string ManufacturerId { get; set; }

        [Display(Name = DisplayNameConstants.ModelDisplayName)]
        public string ModelName { get; set; }

        [Required]
        [Display(Name = DisplayNameConstants.RegistrationPlateDisplayName)]
        [StringLength(CarConstants.CarRegistrationPlateMaxLenth, ErrorMessage = CarConstants.CarRegistrationPlateErrorMassege,
          MinimumLength = CarConstants.CarRegistrationPlateMinLenth)]
        public string RegistrationPlate { get; set; }

        public string ModelId { get; set; }

        [Required]
        [MaxLength(CarConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        [Range(CarConstants.CarMinKilometers, CarConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Display(Name =DisplayNameConstants.YearOfManufacturingDisplayName)]
        [DataType(DataType.Date)]
        public DateTime? YearOfManufacturing { get; set; }

        [Required]
        [Display(Name =DisplayNameConstants.EngineModelDisplayName)]
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