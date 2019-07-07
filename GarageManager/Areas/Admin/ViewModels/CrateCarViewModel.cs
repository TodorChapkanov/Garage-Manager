using Common;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Areas.User.Controllers
{
    public class CreateCarViewModel
    {
        [Display(Name = "Make")]
        public IEnumerable<SelectListItem> AllManufacturers { get; set; }

        public string ManufacturerId { get; set; }

        [Display(Name = "Model")]
        public string ModelName { get; set; }


     
        public string ModelId { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinKilometers, GlobalConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? YearOfManufacture { get; set; }

        [Required]
        [StringLength(GlobalConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinEngineHorsePower, GlobalConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

       public string FuelTypeId { get; set; }

        public IEnumerable<SelectListItem> FuelType { get; set; }

        public string TransmissionId { get; set; }

        public IEnumerable<SelectListItem> Transmission { get; set; }

    }
}