using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Areas.Admin.BindingViewModels
{
    public class CreateCarBVM
    {
        public string ManufacturerId { get; set; }

        public string ModelName { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinKilometers, GlobalConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime YearOfManufacture { get; set; }

        [Required]
        [StringLength(GlobalConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinEngineHorsePower, GlobalConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

         public string FuelTypeId { get; set; }

         public string TransmissionId { get; set; }

    }
}
