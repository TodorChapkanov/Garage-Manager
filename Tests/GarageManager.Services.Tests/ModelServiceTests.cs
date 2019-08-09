using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class ModelServiceTests
    {
        private const string SampleModelId = "1";
        private const string SampleModelName = "323";
        private const string SampleManufacturerId = "1";

        #region GetAllByMakeIdAsync Tests
        [Fact]
        public async Task GetAllByMakeIdAsyncShouldReturnProparModelsWithValidId()
        {
            //Arrange
            var testModelList = this.GetTestModelList();
            var repository = this.GetModelRepository(testModelList);
            var modelService = new ModelService(repository.Object);

            //Act
            var result = await modelService.GetAllByMakeIdAsync(SampleManufacturerId);

            //Assert
            result
                .Count()
                .Should()
                .Be(2);

            result
                .Should()
                .Contain(SampleModelName);
        }

        [Fact]
        public async Task GetAllByMakeIdAsyncShouldReturnEmpryCollectionIfNoModels()
        {
            //Arrange
            var repository = this.GetModelRepository(new List<VehicleModel>());
            var modelService = new ModelService(repository.Object);

            //Act
            var result = await modelService.GetAllByMakeIdAsync(SampleManufacturerId);

            //Assert
            result
                .Should()
                .BeEmpty();
           
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetAllByMakeIdAsyncShouldReturnNullWithInvalidId(string id)
        {
            //Arrange
            var testList = this.GetTestModelList();
            var repository = this.GetModelRepository(testList);
            var modelService = new ModelService(repository.Object);

            //Act
            var result = await modelService.GetAllByMakeIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();

        }
        #endregion

        #region GetByNameAsync Tests
        [Fact]
        public async Task GetByNameAsyncShouldReturnProperDataWithCorrectModelName()
        {
            //Arrange
            var testModelList = this.GetTestModelList();
            var modelRepository = this.GetModelRepository(testModelList);
            var modelService = new ModelService(modelRepository.Object);

            //Act
            var result = await modelService.GetByNameAsync(SampleModelName);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Should()
                .Match<VehicleModel>(model => model.Name == SampleModelName)
                .And
                .Match<VehicleModel>(model => model.Id == SampleModelId);
        }

        [Theory]
        [InlineData("NoExistingModel")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task GetByNameAsyncShouldReturnNullWithInvalidModelName(string modelName)
        {
            //Arrange
            var testModelList = this.GetTestModelList();
            var modelRepository = this.GetModelRepository(testModelList);
            var modelService = new ModelService(modelRepository.Object);

            //Act
            var result = await modelService.GetByNameAsync(modelName);

            //Assert
            result
                .Should()
                .BeNull();

        }
        #endregion

        #region Configuration of Mock<IDeletableEntityRepository<VihicleModel>>
        private Mock<IDeletableEntityRepository<VehicleModel>> GetModelRepository(List<VehicleModel> testModelList)
        {
            var repository = new Mock<IDeletableEntityRepository<VehicleModel>>();
            repository.Setup(all => all.All()).Returns(testModelList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);
            return repository;
        }
        #endregion

        #region TestModelList
        private List<VehicleModel> GetTestModelList()
        {
            var list = new List<VehicleModel>
            {
                new VehicleModel
                {
                    Id = SampleModelId,
                    Name = SampleModelName,
                    ManufactirerId = SampleManufacturerId
                },
                new VehicleModel
                {
                    Id = "2",
                    Name = "MX-5",
                    ManufactirerId = SampleManufacturerId
                },
                new VehicleModel
                {
                    Id = "5",
                    Name  = "Astra",
                    ManufactirerId = "5"
                },
                new VehicleModel
                {
                    Id = "10",
                    Name = "Golf",
                    ManufactirerId = "10"
                }
            };

            return list;
        }
        #endregion
    }
}
