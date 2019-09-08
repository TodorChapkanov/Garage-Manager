using FluentAssertions;
using GarageManager.Common.GlobalConstant;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Car;
using Microsoft.EntityFrameworkCore;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class CarServiceTests : BaseTest
    {
        private Mock<IDeletableEntityRepository<Car>> carRepository;
        private ICarService carService;
        public CarServiceTests()
        {
            this.carRepository = this.GetConfiguredCarRepository(this.GetCarList());
            this.carService = this.GetCarServiceWithDefaultDependencies(carRepository);
        }

        private const string SampleCustomerId = "1";
        private const string SampleDepartmentId = "1";
        private const string SampleCarId = "1";
        private const string SampleVin = "11111111111111111";
        private const string SampleDescrioption = "Description is correct";
        private const string SampleRegistrationPlate = "A888888A";
        private const int SampleKilometers = 123;
        private const int SampleYearOfManufacturing = 2015;
        private const string SampleEngineModel = "4.6";
        private const string SampleLongEnginModel = "Not have engine yet!";
        private const int SampleEngineHorsePower = 380;
        private const string SampleTransmissionId = "5";
        private const string SampleFuelTypeId = "5";
        private const string SampleModelId = "5";
        private const string SampleModelName = "Ford";
        private const string SampleMakeId = "5";
        private const string SampleMakeName = "Ka";

        #region GetAllCarsByCustomerIdAsync Tests
        [Fact]
        public async Task GetAllCarsByCustomerIdAsyncShouldReturnCustomerCarsWithCorrectId()
        {
            //Act
            var result = await this.carService.GetCarsByCustomerIdAsync(SampleCustomerId,1, null);

            //Assert
            result
                .Count()
                .Should()
                .Be(2);

            result
                .ToList()[0]
                .Id
                .Should()
                .Be("1");

            result
                .ToList()[1]
                .Id
                .Should()
                .Be("2");
        }

        [Fact]
        public async Task GetAllCarsByCustomerIdAsyncShouldReturnNullIfNotHaveCarWithCustomerId()
        {
            //Arrange
            var customerId = "10000000";

            //Act
            var result = await this.carService.GetCarsByCustomerIdAsync(customerId,1,null);

            //Assert
            result
                .Should()
                .BeEmpty();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetAllCarsByCustomerIdShouldThrowExceptionIfIdIsInvalidString(string id)
        {
            //Act
            var result = await this.carService.GetCarsByCustomerIdAsync(id,2, null);

            //Assert
            result
             .Should()
             .BeNull();
        }
        #endregion

        #region CreateAsync Tests
        [Fact]
        public async Task CreateAsyncShouldCreateAndSavaCarWithCorrectData()
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
               SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            var actual = await this.carRepository.Object.All().LastAsync();
            result
                .Should()
                .BePositive();

            actual
                .Should()
                .Match<Car>(car => car.CustomerId == SampleCustomerId)
                .And
                .Match<Car>(car => car.Vin == SampleVin)
                .And
                .Match<Car>(car => car.RegistrationPlate == SampleRegistrationPlate)
                .And
                .Match<Car>(car => car.MakeId == SampleMakeId)
                .And
                .Match<Car>(car => car.Model.Name == SampleModelName)
                .And
                .Match<Car>(car => car.Êilometers == SampleKilometers)
                .And
                .Match<Car>(car => car.YearOfManufacturing == SampleYearOfManufacturing)
                .And
                .Match<Car>(car => car.EngineModel == SampleEngineModel)
                .And
                .Match<Car>(car => car.EngineHorsePower == SampleEngineHorsePower)
                .And
                .Match<Car>(car => car.FuelTypeId == SampleFuelTypeId)
                .And
                .Match<Car>(car => car.TransmissionId == SampleTransmissionId);
        }

        [Fact]
        public async Task CreateAsyncShouldReturnNegativeNumberoWithExistingCarVin()
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                "1111111111",
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .BeNegative();
        }

        [Fact]
        public async Task CreateAsyncShouldReturnNegativeNumberoWithExistingCarRegistrationPlate()
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                "CC3333CC",
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .BeNegative();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidCustomerId(string customerId)
        {
            //Act
            var result = await this.carService.CreateAsync(
                customerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidVin(string vin)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                vin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("AAAAAAAAAAA")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidRegistrationPlate(string registrationPlate)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                registrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidMakeId(string makeId)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                makeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData("NoModel")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidModelName(string modelName)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                modelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        [InlineData(SampleLongEnginModel + "!!!")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidEnginModel(string engineModel)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                engineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(-1)]
        [InlineData(5000000)]
        public async Task CreateAsyncShouldReturnZeroWithInvalidEngineHorsePower(int engineHorsePower)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                engineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidFuelTypeId(string fuelTypeId)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                fuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task CreateAsyncShouldReturnZeroWithInvalidTransmissionId(string transmissionId)
        {
            //Act
            var result = await this.carService.CreateAsync(
                SampleCustomerId,
                SampleVin,
                SampleRegistrationPlate,
                SampleMakeId,
                SampleModelName,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                transmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region GetCarDetailsByIdAsync Tests
        [Fact]
        public async Task GetCarDetailsByIdAsyncShouldReturnCarWithCorrectId()
        {
            var result = await this.carService.GetCarDetailsByIdAsync(SampleCarId);
            //Assert
            result
                .Should()
                .Match<CustomerCarDetails>(car => car.Id == SampleCarId)
                .And
                .Match<CustomerCarDetails>(car => car.MakeName == "Mazda")
                .And
                .Match<CustomerCarDetails>(car => car.ModelName == "323F")
                .And
                .Match<CustomerCarDetails>(car => car.CustomerId == "1")
                .And
                .Match<CustomerCarDetails>(car => car.RegistrationPlate == "AA1111AA")
                .And
                .Match<CustomerCarDetails>(car => car.YearOfManufacturing == 1988)
                .And
                .Match<CustomerCarDetails>(car => car.Vin == "1111111111")
                .And
                .Match<CustomerCarDetails>(car => car.Êilometers == 123456789)
                .And
                .Match<CustomerCarDetails>(car => car.EngineModel == "1.9")
                .And
               .Match<CustomerCarDetails>(car => car.EngineHorsePower == 125)
               .And
               .Match<CustomerCarDetails>(car => car.FuelTypeName == "Gasolin")
               .And
               .Match<CustomerCarDetails>(car => car.TransmissionName == "Automatic");
        }

        [Fact]
        public async Task GetCarDetailsByIdAsyncShouldReturnNullWithNotExistiongId()
        {
            //Act
            var result = await this.carService.GetCarDetailsByIdAsync("100");
            //Assert
            result
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("      ")]
        public async Task GetCarDetailsByIdAsyncShoulReturnNullWithInvalidId(string id)
        {

            //Act
            var result = await this.carService.GetCarDetailsByIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region UpdateCarByIdAsync Tests
        [Theory]
        [InlineData(SampleCarId,
            SampleRegistrationPlate,
            SampleKilometers,
            SampleYearOfManufacturing,
            SampleEngineModel,
            SampleEngineHorsePower,
            SampleFuelTypeId,
            SampleTransmissionId)]
        [InlineData(SampleCarId,
            SampleRegistrationPlate,
            0,
            CarConstants.CarMinYearOfManufactorer,
            SampleLongEnginModel,
            CarConstants.CarMinEngineHorsePower,
            SampleFuelTypeId,
            SampleTransmissionId)]
        [InlineData(SampleCarId,
            SampleRegistrationPlate,
            0,
            int.MaxValue,
            SampleEngineModel,
            CarConstants.CarMaxEngineHorsePower,
            SampleFuelTypeId,
            SampleTransmissionId)]
        public async Task UpdateCarByIdAsyncShoultUpdateCarWithCorrectIdAndCorrectData(
            string id,
            string registrationPlate,
            int kilometers,
            int yearOfManufacturing,
            string engineModel,
            int engineHorsePower,
            string fuelTypeId,
            string transmissionId)
        {


            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                id,
                registrationPlate,
                kilometers,
                yearOfManufacturing,
                engineModel,
                engineHorsePower,
                fuelTypeId,
                transmissionId);

            var actual = await carRepository.Object.All().FirstOrDefaultAsync(car => car.Id == id);

            actual.
                 Should()
                 .Match<Car>(car => car.RegistrationPlate == registrationPlate)
                 .And
                 .Match<Car>(car => car.Êilometers == kilometers)
                 .And
                 .Match<Car>(car => car.YearOfManufacturing == yearOfManufacturing)
                 .And
                 .Match<Car>(car => car.EngineModel == engineModel)
                 .And
                 .Match<Car>(car => car.EngineHorsePower == engineHorsePower)
                 .And
                 .Match<Car>(car => car.FuelTypeId == fuelTypeId)
                 .And
                 .Match<Car>(car => car.TransmissionId == transmissionId);

        }

        [Fact]
        public async Task UpdateCarByIdAsyncShoulReturnZeroWithNotExistingId()
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                "10",
                SampleRegistrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);
            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task UpdateCarByIdAsyncShoulReturnZeroWithInvalidId(string id)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                id,
                SampleRegistrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("   ")]
        [InlineData("AAA11111222AAAAAA")]
        public async Task UpdateCarByIdAsyncShouldReturnZeroWithInvalidRegisterPlate(string registrationPlate)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                "1",
                registrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Fact]
        public async Task UpdateCarByIdAsyncShouldReturZeroWithNegativeKilometers()
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                SampleCarId,
                SampleRegistrationPlate,
                -125,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task UpdateCarByIdShouldReturnZeroWithInvalidRgistratoinPlate(string registrationPlate)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                SampleCarId,
                registrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task UpdateCarByIdShouldReturnZeroWithInvalidEngineModel(string engineModel)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                SampleCarId,
                SampleRegistrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                engineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task UpdateCarByIdShouldReturnZeroWithInvalidFuelTypeId(string fuelTypeId)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                SampleCarId,
                SampleRegistrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                fuelTypeId,
                SampleTransmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task UpdateCarByIdShouldReturnZeroWithInvalidTransmissionId(string transmissionId)
        {
            //Act
            var result = await this.carService.UpdateCarByIdAsync(
                SampleCarId,
                SampleRegistrationPlate,
                SampleKilometers,
                SampleYearOfManufacturing,
                SampleEngineModel,
                SampleEngineHorsePower,
                SampleFuelTypeId,
                transmissionId);

            //Assert
            result
                .Should()
                .Be(0);
        }


        #endregion

        #region GetServiceDescriptionByIdAsync Tests
        [Fact]
        public async Task GetServiceDescriptionByIdAsyncShouldReturnCorrectValuesWithCorrectCarId()
        {
            //Act
            var result = await this.carService.GetServiceDescriptionByIdAsync(SampleCarId);

            //Assert
            result
            .Should()
            .Match<CarServiceDetails>(service => service.DepartmentId == SampleDepartmentId)
            .And
            .Match<CarServiceDetails>(service => service.Description == SampleDescrioption);
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        [InlineData("     ")]
        public async Task GetServiceDescriptionByIdAsyncShoulReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.carService.GetServiceDescriptionByIdAsync(carId);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region AddToServiceAsync Tests
        [Fact]
        public async Task AddToServiceAsyncShouldSaveDescrioptionAndDepartmentIdWithCorrectData()
        {
            //Arrange
            var description = "New Description";
            var departmentId = "15";

            //Act 
            var result = await this.carService.AddToServiceAsync(SampleCarId, description, departmentId);

            //Assert
            var actual = await this.carRepository.Object.All().FirstAsync(car => car.Id == SampleCarId);

            actual
                .Should()
                .Match<Car>(service => service.Description == description)
                .And
                .Match<Car>(service => service.DepartmentId == departmentId)
                .And
                .Match<Car>(inService => inService.IsInService == true);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task AddToServiceAsyncShouldReturnZeroWithInvalidCarId(string carId)
        {

            //Act 
            var result = await this.carService.AddToServiceAsync(
                carId,
                SampleDescrioption,
                SampleDepartmentId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task AddToServiceAsyncShouldReturnZeroWithInvalidDescription(string description)
        {

            //Act 
            var result = await this.carService.AddToServiceAsync(
                SampleCarId,
                description,
                SampleDepartmentId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task AddToServiceAsyncShouldReturnZeroWithInvalidDepartmentId(string departmentId)
        {

            //Act 
            var result = await this.carService.AddToServiceAsync(
                SampleCarId,
                SampleDescrioption,
                departmentId);

            //Assert
            result
                .Should()
                .Be(0);
        }

        #endregion

        #region GetCarServiceDetailsByIdAsync Tests
        [Fact]
        public async Task GetCarServiceDetailsByIdAsyncShouldReturnCorrectServiceDetailsaWithCorrectId()
        {
            //Arraing
            var carFromList = this.GetCarList().First(car => car.Id == SampleCarId);

            //Act
            var carFromService = await this.carService.GetCarServiceDetailsByIdAsync(SampleCarId);

            //Assert
            carFromService
                .Should()
                .Match<CarServiceDetailsList>(service => service.RegisterPlate == carFromList.RegistrationPlate)
                .And
                .Match<CarServiceDetailsList>(service => service.Id == carFromList.Id)
                .And
                .Match<CarServiceDetailsList>(
                       service => service.Parts.First().Name == carFromList.Services.First().Parts.First().Name)
                .And
                .Match<CarServiceDetailsList>(
                      service => service.Repairs.First().Description == carFromList.Services.First().Repairs.First().Description);
        }

        [Theory]
        [InlineData("1000")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task GetCarServiceDetailsByIdAsyncShouldReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.carService.GetCarServiceDetailsByIdAsync(carId);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region FinishCarServiceAsync Tests
        [Fact]
        public async Task FinishCarServiceAsyncShouldSetCorrecValuesWithCarrectCarId()
        {
            //Act
            var result = await this.carService.FinishCarServiceAsync(SampleCarId);

            //Assert
            var actual = await this.carRepository.Object.All().FirstAsync(car => car.Id == SampleCarId);

            result
                .Should()
                .BePositive();
            actual
                .Should()
                .Match<Car>(car => car.IsFinished == true)
                .And
               .Match<Car>(car => car.IsInService == false)
               .And
               .Match<Car>(car => car.DepartmentId == null);
        }

        [Theory]
        [InlineData("1500")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task FinishCarServiceAsyncShouldReturnZeroWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.carService.FinishCarServiceAsync(carId);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region CompletedCarsListAsync Tests
        [Fact]
        public async Task CompletedCarsListAsyncShouldRetutnOnlyCompletedCars()
        {
            //Arrang
            await this.carService.FinishCarServiceAsync(SampleCarId);

            //Act
            var result = await this.carService.CompletedCarsListAsync();

            //Assert
            var actual = await this.carRepository.Object.All().FirstAsync(car => car.IsFinished == true);
            result.Count
                .Should()
                .Be(1);
            actual
                .Should()
                .Match<Car>(car => car.IsFinished == true)
                .And
                .Match<Car>(car => car.Model.Name == result.First().ModelName)
                .And
                .Match<Car>(car => car.Make.Name == result.First().MakeName)
                .And
                .Match<Car>(car => car.Id == result.First().Id)
                .And
                .Match<Car>(car => car.RegistrationPlate == result.First().RegistrationPlate);

        }
        #endregion

        #region CompleteTheOrderByCarIdAsync Tests
        [Fact]
        public async Task CompleteTheOrderByCarIdAsyncShoulCompleteTheOrderWithCorrectCarId()
        {
            //Act
            var result = await this.carService.CompleteTheOrderByCarIdAsync(SampleCarId);

            //Assert
            var actual = await this.carRepository.Object.All().FirstAsync(car => car.Id == SampleCarId);
            result
                .Should()
                .NotBeNull();
            actual
                .Should()
                .Match<Car>(car => car.IsInService == false)
                .And
                .Match<Car>(car => car.Description == default(string))
                .And
                .Match<Car>(car => car.ServiceId != "1");
        }

        [Theory]
        [InlineData("150")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task CompleteTheOrderByCarIdAsyncShoulReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.carService.CompleteTheOrderByCarIdAsync(carId);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region Hard Delete Async Tests
        [Fact]
        public async Task HardDeleteAsyncShouldRemoveTheCarWithCorrectCarId()
        {
            //Arrange
            var initialCount = await this.carRepository.Object.All().ToListAsync();
            //Act
            var result = await this.carService.HardDeleteAsync(SampleCarId);

            //Assert
            var actualCount = await this.carRepository.Object.All().ToListAsync();

            result
                .Should()
                .BePositive();

            actualCount.Count
                .Should()
                .BeLessThan(initialCount.Count);

        }

        [Theory]
        [InlineData("100")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task HardDeleteAsyncShouldReturnZeroWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.carService.HardDeleteAsync(carId);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region Configuration of CarService
        private ICarService GetCarServiceWithDefaultDependencies(Mock<IDeletableEntityRepository<Car>> carRepository)
        {

            ICarService carService = new CarService(carRepository.Object, this.GetConfiguredModelService(this.GetVehicleModels()).Object, this.GetConfiguredInteventionSerice().Object);

            return carService;
        }
        #endregion

        #region Configuration of ModelService
        private Mock<IModelService> GetConfiguredModelService(List<VehicleModel> testModelList)
        {
            var repository = new Mock<IModelService>();
            repository.Setup(model => model.GetByNameAsync(It.IsAny<string>())).ReturnsAsync((string name) =>
             testModelList.Where(x => x.Name == name).Single());
            return repository;
        }
        #endregion

        #region Configuration of CarRepository
        private Mock<IDeletableEntityRepository<Car>> GetConfiguredCarRepository(List<Car> testCarList)
        {
            var repository = new Mock<IDeletableEntityRepository<Car>>();
            repository.Setup(all => all.All()).Returns(testCarList.AsQueryable().BuildMockDbQuery().Object);
            repository.Setup(all => all.AllAsNoTracking()).Returns(testCarList.AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(getById => getById
            .GetEntityByKeyAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => testCarList.Where(x => x.Id == id).Single());
            repository.Setup(delete => delete.HardDelete(It.IsAny<Car>())).ReturnsAsync(
                (Car[] target) =>
            {
                if (testCarList.Contains(target[0]))
                {
                    testCarList.Remove(target[0]);
                    return 1;
                }
                return 0;
            });

            repository.Setup(car => car.CreateAsync(It.IsAny<Car>())).ReturnsAsync(
                (Car target) =>
                {
                    target.Model = new VehicleModel { Id = SampleModelId, Name = SampleModelName };
                    target.Make = new VehicleManufacturer { Id = SampleMakeId, Name = SampleMakeName };
                    target.MakeId = SampleMakeId;

                    var carCount = testCarList.Count;
                    testCarList.Add(target);
                    if (carCount != testCarList.Count)
                    {
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(repo => repo.Update(It.IsAny<Car>())).ReturnsAsync(

             (Car target) =>
             {
                 if (testCarList.Any(car => car.Id == target.Id))
                 {
                     var carFromList = testCarList.First(car => car.Id == target.Id);
                     carFromList = target;
                     return 1;
                 }
                 return 0;
             });

            return repository;
        }
        #endregion

        #region Configuration of InterventionService
        private Mock<IInterventionService> GetConfiguredInteventionSerice()
        {
            var interventionService = new Mock<IInterventionService>();
            interventionService.Setup(intervention => intervention.FinishServiceByIdAsync(It.IsAny<string>())).ReturnsAsync(1);
            return interventionService;
        }
        #endregion



        #region  Test Car List
        private List<Car> GetCarList()
        {
            var testCarList = new List<Car>
            {
                new Car
                {
                    Id =SampleCarId,
                    ServiceId = "1",
                    CustomerId = "1",
                    DeletedOn = DateTime.UtcNow.AddYears(-10),
                    DepartmentId = SampleDepartmentId,
                    Description = SampleDescrioption,
                    EngineHorsePower = 125,
                    EngineModel = "1.9",
                    FuelTypeId = "1",
                    IsDeleted = false,
                    IsFinished = false,
                    IsInService = false,
                    MakeId = "1",
                    ModelId = "1",
                    RegistrationPlate = "AA1111AA",
                    Services = new List<ServiceIntervention>
                    {
                        new ServiceIntervention
                        {
                            Id = "1",
                            Parts = new List<Part>
                            {
                                new Part
                                {
                                    Id = "1",
                                    Name = "Bolt"
                                }
                            },
                            Repairs = new List<Repair>
                            {
                               new Repair
                               {
                                    Id = "1",
                                    Description = "Change the bolt"
                                }
                            }
                        }
                    },
                    TransmissionId = "1",
                    Vin = "1111111111",
                    YearOfManufacturing = 1988,
                    Êilometers = 123456789,
                    FuelType = new FuelType
                    {
                        Id = "1",
                        Name = "Gasolin"
                    },
                    Make = new VehicleManufacturer
                    {
                        Id = "1",
                        Name = "Mazda"
                    },
                    Model = new VehicleModel
                    {
                        Id = "1",
                        Name = "323F"
                    },
                    Transmission = new TransmissionType
                    {
                        Id = "1",
                        Name = "Automatic"
                    }
                },
                new Car
                {
                    Id = "2",
                    ServiceId = "2",
                    CustomerId = "1",
                    DeletedOn = DateTime.UtcNow.AddYears(-10),
                    DepartmentId = "2",
                    Description = string.Empty,
                    EngineHorsePower = 100,
                    EngineModel = "2.0",
                    FuelTypeId = "2",
                    IsDeleted = false,
                    IsFinished = false,
                    IsInService = false,
                    MakeId = "2",
                    ModelId = "2",
                    RegistrationPlate = "BB2222BB",
                    Services = new List<ServiceIntervention>(),
                    TransmissionId = "2",
                    Vin = "22222222",
                    YearOfManufacturing = 1988,
                    Êilometers = 123456789,
                    FuelType = new FuelType
                    {
                        Id = "2",
                        Name = "Disel"
                    },
                    Make = new VehicleManufacturer
                    {
                        Id = "2",
                        Name = "Opel"
                    },
                    Model = new VehicleModel
                    {
                        Id = "2",
                        Name = "Astra"
                    },
                    Transmission = new TransmissionType
                    {
                        Id = "2",
                        Name = "Manual"
                    }
                },
                new Car
                {
                    Id = "3",
                    ServiceId = "3",
                    CustomerId = "2",
                    DeletedOn = DateTime.UtcNow.AddYears(-10),
                    DepartmentId = "3",
                    Description = string.Empty,
                    EngineHorsePower = 100,
                    EngineModel = "2.0",
                    FuelTypeId = "2",
                    IsDeleted = false,
                    IsFinished = false,
                    IsInService = false,
                    MakeId = "2",
                    ModelId = "2",
                    RegistrationPlate = "CC3333CC",
                    Services = new List<ServiceIntervention>(),
                    TransmissionId = "2",
                    Vin = "22222222",
                    YearOfManufacturing = 1988,
                    Êilometers = 123456789,
                    FuelType = new FuelType
                    {
                        Id = "2",
                        Name = "Disel"
                    },
                    Make = new VehicleManufacturer
                    {
                        Id = "2",
                        Name = "Ford"
                    },
                    Model = new VehicleModel
                    {
                        Id = "2",
                        Name = "Ka"
                    },
                    Transmission = new TransmissionType
                    {
                        Id = "2",
                        Name = "Manual"
                    }
                }
            };

            return testCarList;
        }
        #endregion

        #region Test Vehicle Model List
        public List<VehicleModel> GetVehicleModels()
        {
            var models = new List<VehicleModel>
            {
                new VehicleModel
                {
                    Id = "1",
                    Name = "Astra"
                },
                new VehicleModel
                {
                    Id= "2",
                    Name = "Enzo"
                },
                new VehicleModel
                {
                    Id= SampleModelId,
                    Name = SampleModelName
                }
            };

            return models;
        }
        #endregion
    }
}


