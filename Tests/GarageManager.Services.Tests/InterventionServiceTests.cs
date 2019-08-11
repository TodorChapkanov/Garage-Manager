using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Models.Service;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class InterventionServiceTests
    {
        private const string SampleServiceInterventionId = "1";
        private const string SampleCarId = "1";
        private const string SampleCarManufacturerName = "Ferrari";
        private const string SampleCarRegistrationPlate = "AA 1111 AA";
        private const string SamplePartName = "Bolt";
        private const string SamplePartNumber = "12F856841";
        private const decimal SamplePartPrice = 12.50M;
        private const int SamplePartQuantity = 12;
        private const string SampleRepairDescription = "Change the Bolts";
        private const double SampleRepairHours = 1.50;
        private const decimal SampleRepairPricePerHouer = 60.00M;
        private const string SampleEmployeeId = "1";
        private const string SampleEmployeeFirstName = "Jhon";
        private const string SampleEmployeeLastName = "Wick";
        private const string SampleDateTime = "2019-01-01 11:11:11";
        private const string DateTimeStringFormat = "yyyy-MM-dd HH:mm:ss";

        private List<ServiceIntervention> testInterventionList;
        private Mock<IDateTimeProvider> dateTimeProvider;
        private Mock<IDeletableEntityRepository<ServiceIntervention>> interventionRepository;
        private InterventionService interventionService;

        public InterventionServiceTests()
        {
            this.testInterventionList = this.GetTestServiceInterventionList();
            this.dateTimeProvider = this.GetDateTimeProvider();
            this.interventionRepository = this.GetConfiguredServiceInterventionRepository(testInterventionList);
            this.interventionService = new InterventionService(interventionRepository.Object, dateTimeProvider.Object);
        }
        /* Task<IEnumerable<CarServiceHistory>> GetCarServicesHistoryAsync(string id);
        Task<int> FinishServiceAsync(string id);


        Task<CarServiceHistoryDetails> GetServiceHistoryDetailsByIdAsync(string serviceId); */
        #region GetCarServicesHistoryAsync Tests
        [Fact]
        public async Task GetCarServicesHistoryAsyncShouldReturnCorrectDataWithValidId()
        {
            //Arrange
           
            var serviceTotalPrice = (SamplePartPrice * SamplePartQuantity)
                + (SampleRepairPricePerHouer * ((decimal)SampleRepairHours));

            //Act
            var result = await this.interventionService.GetCarServicesHistoryByCarIdAsync(SampleCarId);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .First(intervention => intervention.Id == SampleServiceInterventionId)
                .Should()
                .Match<CarServiceHistory>(intervention => intervention.CarMake == SampleCarManufacturerName)
                .And
                .Match<CarServiceHistory>(intervention => intervention.CarRegistrtionPlate == SampleCarRegistrationPlate)
                .And
                .Match<CarServiceHistory>(intervention => intervention.FinishedOn.ToString(DateTimeStringFormat) == SampleDateTime)
                .And
                .Match<CarServiceHistory>(intervention => intervention.Price == serviceTotalPrice);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetCarServicesHistoryAsyncShouldReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.interventionService.GetCarServicesHistoryByCarIdAsync(carId);

            //Assert
            result
                .Should()
                .BeNull();
        }

        [Fact]
        public async Task GetCarServicesHistoryAsyncShouldReturnEmptyCollectionWithNotExistCarId()
        {

            //Arrange
            var carId = "10000";
            

            //Act
            var result = await this.interventionService.GetCarServicesHistoryByCarIdAsync(carId);

            //Assert
            result
                .Should()
                .BeEmpty();
        }
        #endregion

        #region FinishServiceByIdAsync Tests
        [Fact]
        public async Task  FinishServiceAsyncShouldSetPropertiesWithCorrectId()
        {
            //Arrange
            var serviceInterventionId = "2";

            //Act
            var result = await this.interventionService.FinishServiceByIdAsync(serviceInterventionId);

            //Assert
            var serviceIntervention = this.interventionRepository.Object
                .All()
                .First(intervention => intervention.Id == serviceInterventionId);

            result
                .Should()
                .BePositive();

            serviceIntervention
                .IsFinished
                .Should()
                .BeTrue();

            serviceIntervention
                .FinishedOn.ToString(DateTimeStringFormat)
                .Should()
                .BeEquivalentTo(SampleDateTime);

        }

        [Theory]
        [InlineData("200000")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task FinishServiceAsyncShouldReturnZeroWithInvalidInterventionId(string id)
        {
            //Act
            var result = await this.interventionService.FinishServiceByIdAsync(id);

            //Assert
            result
                 .Should()
                 .Be(0);
        }
        #endregion

        #region GetServiceHistoryDetailsByIdAsync Tests
        [Fact]
        public async Task GetServiceHistoryDetailsByIdAsyncShouldReturnInterventionDetailsWithCorrectId()
        {
            //Act
            var result = await this.interventionService.GetServiceHistoryDetailsByIdAsync(SampleCarId);
            var partTotalCost = SamplePartQuantity * SamplePartPrice;
            var repairTotalCost = ((decimal)SampleRepairHours) * SampleRepairPricePerHouer;
            var employeeName = $"{SampleEmployeeFirstName} {SampleEmployeeLastName}";

            //Assert
            result
                .Should()
                .Match<CarServiceHistoryDetails>(car => car.CarId == SampleCarId)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Parts.First().Name == SamplePartName)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Parts.First().Number == SamplePartNumber)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Parts.First().Quantity == SamplePartQuantity)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Parts.First().TotalCost == partTotalCost)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Repairs.First().Description == SampleRepairDescription)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Repairs.First().Hours == SampleRepairHours)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Repairs.First().TotalCosts == repairTotalCost)
                .And
                .Match<CarServiceHistoryDetails>(car => car.Repairs.First().EmployeeFullName == employeeName);
        }

        [Theory]
        [InlineData("200000")]
        [InlineData(null)]
        [InlineData("    ")]
        [InlineData("")]
        public async Task GetServiceHistoryDetailsByIdAsyncShouldReturnNullWithInvalidInterventionId(string id)
        {
            //Act
            var result = await this.interventionService.GetServiceHistoryDetailsByIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<ServiceIntervention>>
        private Mock<IDeletableEntityRepository<ServiceIntervention>> GetConfiguredServiceInterventionRepository(List<ServiceIntervention> testServiceInterventionList)
        {
            var repository = new Mock<IDeletableEntityRepository<ServiceIntervention>>();
            repository.Setup(all => all.All()).Returns(testServiceInterventionList.AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(getById => getById
            .GetEntityByKeyAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => testServiceInterventionList.Where(service => service.Id == id).Single());

            repository.Setup(repo => repo.Update(It.IsAny<ServiceIntervention>())).ReturnsAsync(

             (ServiceIntervention target) =>
             {
                 if (testServiceInterventionList.Any(service => service.Id == target.Id))
                 {
                     var carFromList = testServiceInterventionList.First(service => service.Id == target.Id);
                     carFromList = target;
                     return 1;
                 }
                 return 0;
             });

            return repository;
        }
        #endregion

        #region Configuration of DateTimeProvider
        private Mock<IDateTimeProvider> GetDateTimeProvider()
        {
            var provider = new Mock<IDateTimeProvider>();
            provider.Setup(date => date.GetDateTime()).Returns(DateTime.Parse(SampleDateTime));
            return provider;
        }

        #endregion

        #region TestServiceInterventionList
        private List<ServiceIntervention> GetTestServiceInterventionList()
        {
            var list = new List<ServiceIntervention>
            {
               new ServiceIntervention
               {
                   Id = SampleServiceInterventionId,
                   CarId = SampleCarId,
                   IsFinished = true,
                   FinishedOn = DateTime.Parse(SampleDateTime),
                   Car = new Car
                   {
                       Id = SampleCarId,
                       Make = new VehicleManufacturer
                       {
                           Name = SampleCarManufacturerName
                       },
                       RegistrationPlate = SampleCarRegistrationPlate,
                       IsFinished = true
                   },
                   Parts = new List<Part>
                   {
                       new Part
                       {
                           Name = SamplePartName,
                           Number = SamplePartNumber,
                           Quantity = SamplePartQuantity,
                           Price = SamplePartPrice
                       }
                   },
                   Repairs = new List<Repair>
                   {
                       new Repair
                       {
                            Description = SampleRepairDescription,
                           Employee  = new GMUser
                           {
                               Id = SampleEmployeeId,
                               FirstName = SampleEmployeeFirstName,
                               LastName = SampleEmployeeLastName
                           },
                           Hours = SampleRepairHours,
                           PricePerHour = SampleRepairPricePerHouer
                       }
                   }
               },
               new ServiceIntervention
               {
                   Id = "2",
                   CarId = "2",
                   Car = new Car
                   {
                       Id = "2",
                       Make = new VehicleManufacturer
                       {
                           Name = "Lada"
                       },
                       RegistrationPlate = "BB 2222BB",
                       IsFinished = true
                   },
                   Parts = new List<Part>
                   {
                       new Part
                       {
                           Name = "Oil Filter",
                           Number = "18OIL18F",
                           Quantity = 1,
                           Price = 45.50M
                       }
                   },
                   Repairs = new List<Repair>
                   {
                       new Repair
                       {
                            Description = "Change the oil",
                           Employee  = new GMUser{Id = "1", FirstName = "Jhon", LastName = "Wick"},
                           Hours = 3.50,
                           PricePerHour = 60.00M
                       }
                   }
               }
            };
            return list;
        }
        #endregion
    }
}
