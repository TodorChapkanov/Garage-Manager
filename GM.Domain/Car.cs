using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Common;

namespace GM.Domain
{
    public class Car
    {
       
        public Car()
        {
            this.Services = new HashSet<Service>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        public string  ManufactureID { get; set; }

        public VehicleManufacturer Manufacturer { get; set; }

        [Required]
        public string ModelId { get; set; }

        public VehicleModel Model { get; set; }

        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinKilometers, GlobalConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinYearOfManufactore, int.MaxValue)]
        public DateTime? YearOfManufacture { get; set; }

        [Required]
        [StringLength(GlobalConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Range(GlobalConstants.CarMinEngineHorsePower, GlobalConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

        public string FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }

        [Required]
        public string TransmissionId { get; set; }

        public TransmissionType Transmission { get; set; }

        public ICollection<Service> Services { get; set; }

        public bool ISFinished { get; set; }


    }
}
