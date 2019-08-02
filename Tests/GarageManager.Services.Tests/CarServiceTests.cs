using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using Moq;
using System;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class CarServiceTests
    {
        private readonly ICarService carService;

        public CarServiceTests()
        {
            var carRepository = new Mock<IDeletableEntityRepository<Car>>();

           this.carService = new CarService()
        }
        [Fact]
        public void Test1()
        {

        }
    }
    /*  Task<IEnumerable<CustomerCarListDetails>> GetAllCarsByCustomerIdAsync(string id);

        Task<bool> CreateAsync
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

        Task<CustomerCarDetails> GetCarDetailsByIdAsync(string id);

        Task<int> UpdateCarByIdAsync(
           string id,
           string registrationPlate,
           int kilometers,
           DateTime yearOfManufacturing,
           string engineModel,
           int engineHorsePower,
           string fuelTypeId,
           string transmissionId);
        Task<CarServiceDetails> GetServiceDescription(string id);

        Task<int> AddToService(string carId, string carDescription, string departmentId);

        Task<CarServicesDetails> GetCarServicesAsync(string id);

        Task<int> FinishCarServiceAsync(string carId);

        Task<List<CompletedCarList>> CompletedCarsList();

        Task<string> CompleteTheOrderByCarId(string carId);

        Task<int> HardDeleteAsync(string id);*/
}
