using GarageManager.Domain;
using GarageManager.Services.DTO;
using GarageManager.Services.DTO.Car;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ICarServices
    {
        Task<IEnumerable<CustomerCarListDetails>> GetAllCarsByCustomerIdAsync(string id);

        Task<bool> CreateAsync<TEntity>
            (
            string customerIs,
            string vin,
            string registrationPlate,
            string manufactirerId,
              string modelId,
              int kilometers,
              DateTime yearOfManufacture,
              string engineModel, int enginePower,
              string FuelTypeId,
              string transmissionId
            );

        Task<CustomerCarDetails> GetDetailsByIdAsync(string id);

        Task<bool> UpdateCarByIdAsync(
           string id,
           string registrationPlate,
           int kilometers,
           DateTime yearOfManufacturing,
           string engineModel,
           int engineHorsePower,
           string fuelTypeId,
           string transmissionId);

        Task<bool> AddToService(string carId, string carDescription, string departmentId);

        Task<CarServicesDetails> GetCarServicesAsync(string id);

        Task<int> HardDeleteAsync(string id);
    }
}
