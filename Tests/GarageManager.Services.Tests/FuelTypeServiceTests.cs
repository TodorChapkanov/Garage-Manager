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
    public class FuelTypeServiceTests
    {
        #region GetAllTypesAsync Tests
        [Fact]
        public async Task GetAllTypesAsyncShouldReturnCollectionOfFuelTypesIfAny()
        {
            //Arrange
            var repository = this.GetFuelTypeRepository(this.GetTestFuelTypeList());
            var fuelTypeService = new FuelTypeService(repository.Object);

            //Act
            var result = await fuelTypeService.GetAllTypesAsync();

            //Assert
            result
                .Should()
                .NotBeEmpty();
        }

        [Fact]
        public async Task GetAllTypesAsyncShouldReturnEmptyCollectionIfNoFuelTypes()
        {
            //Arrange
            var repository = this.GetFuelTypeRepository(new List<FuelType>());
            var fuelTypeService = new FuelTypeService(repository.Object);

            //Act
            var result = await fuelTypeService.GetAllTypesAsync();

            //Assert
            result
                .Should()
                .BeEmpty();
        }

        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<FuelType>>
        private Mock<IDeletableEntityRepository<FuelType>> GetFuelTypeRepository(List<FuelType> testFuelTypeList)
        {
            var repository = new Mock<IDeletableEntityRepository<FuelType>>();
            repository.Setup(all => all.All()).Returns(testFuelTypeList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);
            return repository;
        }
        #endregion

        #region TestFuelTypeList
        private List<FuelType> GetTestFuelTypeList()
        {
            var list = new List<FuelType>
            {
                new FuelType
                {
                    Id ="1",
                    Type = "Disel"
                },
                new FuelType
                {
                    Id ="2",
                    Type = "Gasoline"
                }
            };

            return list;
        }
        #endregion
    }
}
