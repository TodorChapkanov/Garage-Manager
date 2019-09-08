using GarageManager.Services.Models.Car;
using GarageManager.Services.Models.Service;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface ICarService
    {
        Task<IEnumerable<CustomerCarListDetails>> GetCarsByCustomerIdAsync(string id, int page, string searchTerm);

        Task<int> CreateAsync
            (
            string customerIs,
            string vin,
            string registrationPlate,
            string manufactirerId,
              string modelName,
              int kilometers,
              int yearOfManufacture,
              string engineModel, 
              int enginePower,
              string FuelTypeId,
              string transmissionId
            );

        Task<CustomerCarDetails> GetCarDetailsByIdAsync(string id);

        Task<int> UpdateCarByIdAsync(
           string id,
           string registrationPlate,
           int kilometers,
           int yearOfManufacturing,
           string engineModel,
           int engineHorsePower,
           string fuelTypeId,
           string transmissionId);
        Task<CarServiceDetails> GetServiceDescriptionByIdAsync(string id);

        Task<int> AddToServiceAsync(string carId, string carDescription, string departmentId);

        Task<CarServiceDetailsList> GetCarServiceDetailsByIdAsync(string id);

        Task<int> FinishCarServiceAsync(string carId);

        Task<List<CompletedCarList>> CompletedCarsListAsync();

        Task<string> CompleteTheOrderByCarIdAsync(string carId);


        Task<int> HardDeleteAsync(string id);

        CompletedCarServiceDetails GetCompletedCarDetailsByCarId(string id);
    }
}
