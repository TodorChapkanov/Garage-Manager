using GarageManager.Common.GlobalConstant;
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
            this.Services = new HashSet<ServiceIntervention>();
        }

        [Required]
        [StringLength(CarConstants.CarRegistrationPlateMaxLenth)]
        public string RegistrationPlate { get; set; }

        [Required]
        [MaxLength(CarConstants.CarVinNumberMaxLength)]
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
        [Range(CarConstants.CarMinKilometers, CarConstants.CarMaxKilometers)]
        public int Кilometers { get; set; }

        [Required]
        [Range(CarConstants.CarMinYearOfManufactore, int.MaxValue)]
        public DateTime? YearOfManufacture { get; set; }

        [Required]
        [StringLength(CarConstants.CarMaxEngineModelLength)]
        public string EngineModel { get; set; }

        [Required]
        [Range(CarConstants.CarMinEngineHorsePower, CarConstants.CarMaxEngineHorsePower)]
        public int EngineHorsePower { get; set; }

        public string FuelTypeId { get; set; }

        public FuelType FuelType { get; set; }

        [StringLength(CarConstants.CarDescriptionMaxLength)]
        public string  Description { get; set; }

        [Required]
        public string TransmissionId { get; set; }

        public TransmissionType Transmission { get; set; }

        public string CurrentServiceId { get; set; }
        public ICollection<ServiceIntervention> Services { get; set; }

        public bool IsFinished { get; set; }

        public bool IsInService { get; set; }
    }
}
