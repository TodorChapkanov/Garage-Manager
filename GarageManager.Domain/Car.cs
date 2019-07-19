using GarageManager.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GarageManager.Domain
{
    public class Car : BaseEntity
    {
        public Car()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Services = new ServiceIntervention();
        }

        [Required]
        [StringLength(GlobalConstants.CarRegistrationPlateMaxLenth)]
        public string RegistrationPlate { get; set; }

        [Required]
        [MaxLength(GlobalConstants.CarVinNumberMaxLength)]
        public string Vin { get; set; }

        [Required]
        public string  ManufactureId { get; set; }

        public VehicleManufacturer Manufacturer { get; set; }

        [Required]
        public string ModelId { get; set; }

        public VehicleModel Model { get; set; }

        [Required]
        public string CustomerId { get; set; }

        public Customer Customer { get; set; }

        public string DepartmentId { get; set; }

        public Department Department { get; set; }

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

        [StringLength(GlobalConstants.CarDescriptionMaxLength)]
        public string  Description { get; set; }

        [Required]
        public string TransmissionId { get; set; }

        public TransmissionType Transmission { get; set; }

        public ServiceIntervention Services { get; set; }

        public bool IsFinished { get; set; }

        public bool IsInService { get; set; }
    }
}
