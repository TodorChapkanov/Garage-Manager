using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Repair;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class RepairServiceTests
    {
        private const string SampleRepairId = "1";
        private const string SampleRepairDescription = "Changing front bumper";
        private const decimal SampleRepairPricePerHour = 125.50M;
        private const int SampleRepairHours = 1;
        private const bool SampleRepairIsFinishedValue = true;
        private const string SampleCarId = "1";
        private const string SampleCarServiceId = "1";
        private const string SampleEmployeeFirsName = "Jhon";
        private const string SampleEmployeeLastName = "Wick";
        private const string SampleEmployeeFullName = "Jhon Wick";
        private const string SampleEmployeeId = "1";
        private const string SampleInvalidReapirId = "800";
        private const string SampleInvalidRepairDescription = "The Max Length of the description is 500 symbols" +
            " and is a  damn long for one row, but is need to be tested." +
            "Lorem ipsum dolor sit amet, consectetur adipiscing elit," +
            " sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." +
            " Ut enim ad minim veniam," +
            " quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat." +
            " Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur" +
            ". Excepteur sint occaecat cupidatat non proident.It's long!!!!";


        private List<Repair> testRepairList;
        private Mock<IDeletableEntityRepository<Repair>> repairRepository;
        private Mock<IDeletableEntityRepository<Car>> carRepository;
        private IRepairService repairService;

        public RepairServiceTests()
        {
            this.testRepairList = this.GetTestRepairList();
            this.repairRepository = this.GetConfiguredRepairRepository(testRepairList);
            this.carRepository = this.GetConfiguredCarRepository();
            this.repairService = new RepairService(repairRepository.Object, carRepository.Object);
        }
       

        #region CreateAsync Tests
        [Fact]
        public async Task CreateAsyncShouldCreateRepairWithValidData()
        {
            //Arrange
            var RepairRepository = this.GetConfiguredRepairRepository(new List<Repair>());
            var carRepoaitory = this.GetConfiguredCarRepository();
            var repairService = new RepairService(RepairRepository.Object, carRepoaitory.Object);

            //Act
            var result = await repairService.CreateAsync(
                SampleCarId,
                SampleRepairDescription,
                SampleRepairHours,
                SampleRepairPricePerHour,
                SampleEmployeeId);

            //Arrange
            var newRepair = RepairRepository.Object.All();

            result
                .Should()
                .NotBeNull();

            newRepair
                .Count()
                .Should()
                .BePositive();

            newRepair
                .First()
                .Should()
                .Match<Repair>(repair => repair.Description == SampleRepairDescription)
                .And
                .Match<Repair>(repair => repair.Hours == SampleRepairHours)
                .And
                .Match<Repair>(repair => repair.PricePerHour == SampleRepairPricePerHour)
                .And
                .Match<Repair>(repair => repair.ServiceId == SampleCarServiceId);



        }

        [Theory]
        [InlineData(SampleInvalidReapirId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.repairService.CreateAsync(
               carId,
               SampleRepairDescription,
               SampleRepairHours,
               SampleRepairPricePerHour,
               SampleEmployeeId);

            //Arrange
            result
                .Should()
                .BeNull();

        }

        [Theory]
        [InlineData(SampleInvalidRepairDescription)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidRepairDescription(string repairDescription)
        {
            //Act
            var result = await this.repairService.CreateAsync(
               SampleCarId,
               repairDescription,
               SampleRepairHours,
               SampleRepairPricePerHour,
               SampleEmployeeId);

            //Arrange
            result
                .Should()
                .BeNull();

        }


        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(20001)]
        public async Task CreateAsyncShouldReturnNullWithInvalidRepairPricePerHours(double hours)
        {
            //Arrange
            var testRepairId = "10";

            //Act
            var result = await this.repairService.CreateAsync(
               testRepairId,
               SampleRepairDescription,
                hours,
               SampleRepairPricePerHour,
               SampleEmployeeId);

            //Assert
            result
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task CreateAsyncShouldReturnNullWithInvalidRepairHours(decimal pricePerHour)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.repairService.CreateAsync(
               testPartId,
               SampleRepairDescription,
               SampleRepairHours,
               pricePerHour,
               SampleEmployeeId);

            //Assert

            result
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidEmployeeId(string employeeId)
        {
            //Act
            var result = await this.repairService.CreateAsync(
               SampleCarId,
               SampleRepairDescription,
               SampleRepairHours,
               SampleRepairPricePerHour,
               employeeId);

            //Arrange
            result
                .Should()
                .BeNull();

        }
        #endregion

        #region  UpdateRepairByIdAsync Tests
        [Fact]
        public async Task UpdateRepairByIdAsyncShouldSetProperiesCorrectWithCorrectId()
        {
            //Arrange
            var testRepairId = "10";
            //Act
            var result = await this.repairService.UpdateRepairByIdAsync(
                testRepairId,
                SampleRepairDescription,
                SampleRepairHours,
                SampleRepairPricePerHour,
                SampleRepairIsFinishedValue);

            //Assert
            var updatedEntity = await this.repairRepository.Object.GetEntityByKeyAsync(testRepairId);

            result
                .Should()
                .BePositive();

            updatedEntity
                .Should()
                .Match<Repair>(repair => repair.Description == SampleRepairDescription)
                .And
                .Match<Repair>(repair => repair.Hours == SampleRepairHours)
                .And
                .Match<Repair>(repair => repair.PricePerHour == SampleRepairPricePerHour)
                .And
                .Match<Repair>(repair => repair.IsFinished == SampleRepairIsFinishedValue);
        }

        [Theory]
        [InlineData(SampleInvalidReapirId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateRepairByIdAsyncShouldReturnZeroWithInvalidId(string id)
        {
            //Act
            var result = await this.repairService.UpdateRepairByIdAsync(
               id,
               SampleRepairDescription,
               SampleRepairHours,
               SampleRepairPricePerHour,
               SampleRepairIsFinishedValue);

            //Assert

            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(SampleInvalidRepairDescription)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateRepairByIdAsyncShouldReturnZeroWithInvalidRepairDescription(string repairDescription)
        {
            //Arrange
            var testRepairId = "10";

            //Act
            var result = await this.repairService.UpdateRepairByIdAsync(
               testRepairId,
               repairDescription,
               SampleRepairHours,
               SampleRepairPricePerHour,
               SampleRepairIsFinishedValue);

            //Assert

            result
                .Should()
                .Be(0);
        }

      
        [Theory]
        [InlineData(0.09)]
        [InlineData(-0.1)]
        [InlineData(121)]
        public async Task UpdateRepairByIdAsyncShouldReturnZeroWithInvalidRepairHours(double hours)
        {
            //Arrange
            var testRepairId = "10";
            //Act
            var result = await this.repairService.UpdateRepairByIdAsync(
               testRepairId,
               SampleRepairDescription,
               hours,
               SampleRepairPricePerHour,
               SampleRepairIsFinishedValue);

            //Assert

            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(0.99)]
        [InlineData(-0.1)]
        public async Task UpdateRepairByIdAsyncShouldReturnZeroWithInvalidRepairPricePerHour(decimal pricePerHour)
        {
            //Arrange
            var testRepairId = "10";
            //Act
            var result = await this.repairService.UpdateRepairByIdAsync(
               testRepairId,
               SampleInvalidRepairDescription,
               SampleRepairHours,
               pricePerHour,
               SampleRepairIsFinishedValue);

            //Assert

            result
                .Should()
                .Be(0);
        }
        #endregion

        #region GetEditDetailsByIdAsync Tests
        [Fact]
        public async Task GetEditDetailsByIdAsyncShouldReturnProperDataWithCorrectId()
        {
            //Act
            var result = await this.repairService.GetEditDetailsByIdAsync(SampleRepairId);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Should()
                .Match<RepairEditDetails>(repair => repair.Description == SampleRepairDescription)
                .And
                .Match<RepairEditDetails>(repair => repair.Hours == SampleRepairHours)
                .And
                .Match<RepairEditDetails>(repair => repair.PricePerHour == SampleRepairPricePerHour)
                .And
                .Match<RepairEditDetails>(repair => repair.EmployeeFullName == SampleEmployeeFullName)
                .And
                .Match<RepairEditDetails>(repair => repair.IsFinished == false);
        }

        [Theory]
        [InlineData(SampleInvalidReapirId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetEditDetailsByIdAsyncShouldReturnNullWithInvalidId(string id)
        {
            //Act
            var result = await this.repairService.GetEditDetailsByIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region HardDeleteAsync Tests
        [Fact]
        public async Task HardDeleteAsyncShouldRemoveEntityWithCorrectId()
        {
            //Act
            var result = await this.repairService.HardDeleteAsync(SampleRepairId);

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this.repairRepository.Object
                .GetEntityByKeyAsync(SampleRepairId));

            result
                .Should()
                .Be(1);
        }

        [Theory]
        [InlineData(SampleInvalidReapirId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task HardDeleteAsyncShouldZeroWithInvalidId(string id)
        {
            //Act
            var result = await this.repairService.HardDeleteAsync(id);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region Configuration of RepairRepository
        private Mock<IDeletableEntityRepository<Repair>> GetConfiguredRepairRepository(List<Repair> testRepairList)
        {
            var repository = new Mock<IDeletableEntityRepository<Repair>>();

            repository.Setup(all => all.All()).Returns(testRepairList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(getById => getById
            .GetEntityByKeyAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => testRepairList.Where(x => x.Id == id).Single());

            repository.Setup(delete => delete.HardDelete(It.IsAny<Repair>())).ReturnsAsync(
                (Repair[] target) =>
                {
                    if (testRepairList.Contains(target[0]))
                    {
                        testRepairList.Remove(target[0]);
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(car => car.CreateAsync(It.IsAny<Repair>())).ReturnsAsync(
                (Repair target) =>
                {

                    var partCount = testRepairList.Count;
                    testRepairList.Add(target);
                    if (partCount != testRepairList.Count)
                    {
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(repo => repo.Update(It.IsAny<Repair>())).ReturnsAsync(

             (Repair target) =>
             {
                 if (testRepairList.Any(car => car.Id == target.Id))
                 {
                     var partFromList = testRepairList.First(car => car.Id == target.Id);
                     partFromList = target;
                     return 1;
                 }
                 return 0;
             });

            return repository;
        }
        #endregion

        #region Configuration of Mock<IDelaetableEntityRepository<Car>>
        private Mock<IDeletableEntityRepository<Car>> GetConfiguredCarRepository()
        {
            var testCarList = new List<Car>
            {
                new Car
                {
                    Id = SampleCarId,
                    ServiceId = SampleCarServiceId
                }
            };
            var repository = new Mock<IDeletableEntityRepository<Car>>();

            repository.Setup(all => all.All()).Returns(testCarList.AsQueryable().BuildMockDbQuery().Object);

            return repository;
        }
        #endregion

        #region TestRepairList
        private List<Repair> GetTestRepairList()
        {
            var list = new List<Repair>
            {
                new Repair
                {
                    Id = SampleRepairId,
                    Description = SampleRepairDescription,
                    PricePerHour = SampleRepairPricePerHour,
                    Hours = SampleRepairHours,
                    ServiceId = "1",
                    Employee = new GMUser
                    {
                        Id = SampleEmployeeId,
                        FirstName = SampleEmployeeFirsName,
                        LastName = SampleEmployeeLastName
                    }
                },
                new Repair
                {
                    Id = "10",
                    Description = "Nut",
                    PricePerHour = 0.85M,
                    Hours = 7,
                    ServiceId = "2",
                    EmployeeId = "2"

                }
            };

            return list;
        }

        #endregion

    }
}
