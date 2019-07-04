using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GM.Domain
{
    public class Car
    {
        private const int VinNumberMaxLength = 17;
        private const int MinKilometers = 0;
        private const int MaxKilometers = 1000000;
        private const int MinYearOfManufactore = 1886;
        private const int MaxEngineHorsePower = 5000;
        private const int MinEngineHorsePower = 0;
        private const int MaxEngineModelLength = 20;

        public Car()
        {
            this.Services = new HashSet<Service>();
        }

        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(VinNumberMaxLength)]
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
        [Range(MinKilometers,MaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Range(MinYearOfManufactore, int.MaxValue)]
        public DateTime? YearOfManufacture { get; set; }

        [Required]
        [StringLength(MaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Range(MinEngineHorsePower, MaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

        public string FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }

        [Required]
        public string TransmissionId { get; set; }

        public TransmissionType Transmission { get; set; }

        public ICollection<Service> Services { get; set; }


    }
}
