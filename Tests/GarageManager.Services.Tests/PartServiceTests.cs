using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Part;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class PartServiceTests
    {
        private const string SamplePartId = "1";
        private const string SamplePartName = "Front bumper";
        private const string SamplePartNumber = "123456789";
        private const decimal SamplePartPrice = 125.50M;
        private const int SamplePartQuantity = 1;
        private const string SampleCarId = "1";
        private const string SampleCarServiceId = "1";
        private const string SampleInvalidPartName = "Part Name MaxLength is 60 symbols, so this is not a valid name";
        private const string SampleInvalidPartNumber = "Part number MaxLength is 25 and this is not valid number";
        private const string SampleInvalidPartId = "2000";

        private List<Part> testPartList;
        private Mock<IDeletableEntityRepository<Part>> partRepository;
        private Mock<IDeletableEntityRepository<Car>> carRepository;
        private IPartService partService;

        public PartServiceTests()
        {
            this.testPartList = this.GetTestPartList();
            this.partRepository = this.GetConfiguredPartRepository(testPartList);
            this.carRepository = this.GetConfiguredCarRepository();
            this.partService = new PartService(partRepository.Object, carRepository.Object);
        }
      
        #region CreateAsync Tests
        [Fact]
        public async Task CreateAsyncShouldCreatePartWithValidData()
        {
            //Arrange
            var partRepository = this.GetConfiguredPartRepository(new List<Part>());
            var carRepoaitory = this.GetConfiguredCarRepository();
            var partService = new PartService(partRepository.Object, carRepoaitory.Object);

            //Act
            var result = await partService.CreateAsync(
                SampleCarId,
                SamplePartName,
                SamplePartNumber,
                SamplePartPrice,
                SamplePartQuantity);

            //Arrange
            var newPart = partRepository.Object.All();

            result
                .Should()
                .NotBeNull();

            newPart
                .Count()
                .Should()
                .BePositive();

            newPart
                .First()
                .Should()
                .Match<Part>(part => part.Name == SamplePartName)
                .And
                .Match<Part>(part => part.Number == SamplePartNumber)
                .And
                .Match<Part>(part => part.Price == SamplePartPrice)
                .And
                .Match<Part>(part => part.Quantity == SamplePartQuantity)
                .And
                .Match<Part>(part => part.ServiceId == SampleCarServiceId);


            
        }

        [Theory]
        [InlineData(SampleInvalidPartId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidCarId(string carId)
        {
            //Act
            var result = await this.partService.CreateAsync(
               carId,
               SamplePartName,
               SamplePartNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Arrange
            result
                .Should()
                .BeNull();

        }

        [Theory]
        [InlineData(SampleInvalidPartName)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidPartName(string partName)
        {
            //Act
            var result = await this.partService.CreateAsync(
               SampleCarId,
               partName,
               SamplePartNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Arrange
            result
                .Should()
                .BeNull();

        }

        [Theory]
        [InlineData(SampleInvalidPartNumber)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateAsyncShouldReturnNullWithInvalidPartNumber(string partNumber)
        {
            //Act
            var result = await this.partService.CreateAsync(
               SampleCarId,
               SamplePartName,
               partNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Arrange
            result
                .Should()
                .BeNull();

        }
        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(20001)]
        public async Task CreateAsyncShouldReturnNullWithInvalidPartPrice(decimal price)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.CreateAsync(
               testPartId,
               SamplePartName,
               SamplePartNumber,
               price,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .BeNull();
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task CreateAsyncShouldReturnNullWithInvalidPartQuantity(int price)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.CreateAsync(
               testPartId,
               SamplePartName,
               SamplePartNumber,
               price,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .BeNull();
        }
        #endregion

        #region GetEditDetailsByIdAsync Tests
        [Fact]
        public async Task GetEditDetailsByIdAsyncShouldReturnProperDataWithCorrectId()
        {
            //Act
            var result = await this.partService.GetEditDetailsByIdAsync(SamplePartId);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Should()
                .Match<PartEditDetils>(part => part.Name == SamplePartName)
                .And
                .Match<PartEditDetils>(part => part.Number == SamplePartNumber)
                .And
                .Match<PartEditDetils>(part => part.Price == SamplePartPrice)
                .And
                .Match<PartEditDetils>(part => part.Quantity == SamplePartQuantity);
        }

        [Theory]
        [InlineData(SampleInvalidPartId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetEditDetailsByIdAsyncShouldReturnNullWithInvalidId(string id)
        {
            //Act
            var result = await this.partService.GetEditDetailsByIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region  UpdatePartByIdAsync Tests
        [Fact]
        public async Task UpdatePartByIdAsyncShouldSetProperiesCorrectWithCorrectId()
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.UpdatePartByIdAsync(
                testPartId,
                SamplePartName,
                SamplePartNumber,
                SamplePartPrice,
                SamplePartQuantity);

            //Assert
            var updatedEntity = await this.partRepository.Object.GetEntityByKeyAsync(testPartId);

            result
                .Should()
                .BePositive();

            updatedEntity
                .Should()
                .Match<Part>(part => part.Name == SamplePartName)
                .And
                .Match<Part>(part => part.Number == SamplePartNumber)
                .And
                .Match<Part>(part => part.Price == SamplePartPrice)
                .And
                .Match<Part>(part => part.Quantity == SamplePartQuantity);
        }

        [Theory]
        [InlineData(SampleInvalidPartId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdatePartByIdAsyncShouldReturnZeroWithInvalidId(string id)
        {
            //Act
            var result = await this.partService.UpdatePartByIdAsync(
               id,
               SamplePartName,
               SamplePartNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(SampleInvalidPartName)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdatePartByIdAsyncShouldReturnZeroWithInvalidPartName(string partName)
        {
            //Arrange
            var testPartId = "10";

            //Act
            var result = await this.partService.UpdatePartByIdAsync(
               testPartId,
               partName,
               SamplePartNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(SampleInvalidPartNumber)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdatePartByIdAsyncShouldReturnZeroWithInvalidPartNumber(string partNumber)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.UpdatePartByIdAsync(
               testPartId,
               SamplePartName,
               partNumber,
               SamplePartPrice,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .Be(0);
        }
        [Theory]
        [InlineData(0)]
        [InlineData(-0.1)]
        [InlineData(20001)]
        public async Task UpdatePartByIdAsyncShouldReturnZeroWithInvalidPartPrice(decimal price)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.UpdatePartByIdAsync(
               testPartId,
               SamplePartName,
               SamplePartNumber,
               price,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(0)]
        [InlineData(-1)]
        public async Task UpdatePartByIdAsyncShouldReturnZeroWithInvalidPartQuantity(int price)
        {
            //Arrange
            var testPartId = "10";
            //Act
            var result = await this.partService.UpdatePartByIdAsync(
               testPartId,
               SamplePartName,
               SamplePartNumber,
               price,
               SamplePartQuantity);

            //Assert

            result
                .Should()
                .Be(0);
        }
        #endregion

        #region HardDeleteAsync Tests
        [Fact]
        public async Task HardDeleteAsyncShouldRemoveEntityWithCorrectId()
        {
            //Act
            var result = await this.partService.HardDeleteAsync(SamplePartId);

            //Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () =>
                await this.partRepository.Object
                .GetEntityByKeyAsync(SamplePartId));

            result
                .Should()
                .Be(1);
        }

        [Theory]
        [InlineData(SampleInvalidPartId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task HardDeleteAsyncShouldZeroWithInvalidId(string id)
        {
            //Act
            var result = await this.partService.HardDeleteAsync(id);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region Configuration of PartRepository
        private Mock<IDeletableEntityRepository<Part>> GetConfiguredPartRepository(List<Part> testPartList)
        {
            var repository = new Mock<IDeletableEntityRepository<Part>>();

            repository.Setup(all => all.All()).Returns(testPartList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(getById => getById
            .GetEntityByKeyAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => testPartList.Where(x => x.Id == id).Single());

            repository.Setup(delete => delete.HardDelete(It.IsAny<Part>())).ReturnsAsync(
                (Part[] target) =>
                {
                    if (testPartList.Contains(target[0]))
                    {
                        testPartList.Remove(target[0]);
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(car => car.CreateAsync(It.IsAny<Part>())).ReturnsAsync(
                (Part target) =>
                {

                    var partCount = testPartList.Count;
                    testPartList.Add(target);
                    if (partCount != testPartList.Count)
                    {
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(repo => repo.Update(It.IsAny<Part>())).ReturnsAsync(

             (Part target) =>
             {
                 if (testPartList.Any(car => car.Id == target.Id))
                 {
                     var partFromList = testPartList.First(car => car.Id == target.Id);
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
                    CurrentServiceId = SampleCarServiceId
                }
            };
            var repository = new Mock<IDeletableEntityRepository<Car>>();

            repository.Setup(all => all.All()).Returns(testCarList.AsQueryable().BuildMockDbQuery().Object);

            return repository;
        }
        #endregion

        #region TestPartList
        private List<Part> GetTestPartList()
        {
            var list = new List<Part>
            {
                new Part
                {
                    Id = SamplePartId,
                    Name = SamplePartName,
                    Number = SamplePartNumber,
                    Price = SamplePartPrice,
                    Quantity = SamplePartQuantity,
                    ServiceId = "1"
                },
                new Part
                {
                    Id = "10",
                    Name = "Nut",
                    Number = "852963741",
                    Price = 0.85M,
                    Quantity = 7,
                    ServiceId = "2"

                }
            };

            return list;
        }

        #endregion

    }
}
