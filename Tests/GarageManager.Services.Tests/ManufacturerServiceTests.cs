﻿using FluentAssertions;
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
  public  class ManufacturerServiceTests
    {
        #region GetAllTypesAsync Tests
        [Fact]
        public async Task GetAllAsyncShouldReturnCollectionOfManufacturerIfAny()
        {
            //Arrange
            var repository = this.GetManufacturerRepository(this.GetTestManufacturerList());
            var manufacturerService = new ManufacturerService(repository.Object);

            //Act
            var result = await manufacturerService.GetAllAsync();

            //Assert
            result
                .Should()
                .NotBeEmpty();
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnEmptyCollectionIfNoManufacturers()
        {
            //Arrange
            var repository = this.GetManufacturerRepository(new List<VehicleManufacturer>());
            var fuelTypeService = new ManufacturerService(repository.Object);

            //Act
            var result = await fuelTypeService.GetAllAsync();

            //Assert
            result
                .Should()
                .BeEmpty();
        }

        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<VehicleManufacturer>>
        private Mock<IDeletableEntityRepository<VehicleManufacturer>> GetManufacturerRepository(List<VehicleManufacturer> testFuelTypeList)
        {
            var repository = new Mock<IDeletableEntityRepository<VehicleManufacturer>>();
            repository.Setup(all => all.All()).Returns(testFuelTypeList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);
            return repository;
        }
        #endregion

        #region TestFuelTypeList
        private List<VehicleManufacturer> GetTestManufacturerList()
        {
            var list = new List<VehicleManufacturer>
            {
                new VehicleManufacturer
                {
                    Id ="1",
                    Name = "Opel"
                },
                new VehicleManufacturer
                {
                    Id ="2",
                    Name = "Ford"
                }
            };

            return list;
        }
        #endregion
    }
}