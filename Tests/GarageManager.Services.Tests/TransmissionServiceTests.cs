using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
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
   public  class TransmissionServiceTests
    {
        #region GetAllTypesAsync Tests
        [Fact]
        public async Task GetAllAsyncShouldReturnCollectionOfTransmissionTypeIfAny()
        {
            //Arrange
            var repository = this.GetManufacturerRepository(this.GetTestTransmissionTypeList());
            var transmissionService = new TransimissionService(repository.Object);

            //Act
            var result = await transmissionService.GetAllTypesAsync();

            //Assert
            result
                .Should()
                .NotBeEmpty();
        }

        [Fact]
        public async Task GetAllAsyncShouldReturnEmptyCollectionIfNoManufacturers()
        {
            //Arrange
            var repository = this.GetManufacturerRepository(new List<TransmissionType>());
            var transmissionService = new TransimissionService(repository.Object);

            //Act
            var result = await transmissionService.GetAllTypesAsync();

            //Assert
            result
                .Should()
                .BeEmpty();
        }

        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<TransmissionType>>
        private Mock<IDeletableEntityRepository<TransmissionType>> GetManufacturerRepository(List<TransmissionType> testTransmissionTypeList)
        {
            var repository = new Mock<IDeletableEntityRepository<TransmissionType>>();
            repository.Setup(all => all.All()).Returns(testTransmissionTypeList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);
            return repository;
        }
        #endregion

        #region TestTransmissionTypeList
        private List<TransmissionType> GetTestTransmissionTypeList()
        {
            var list = new List<TransmissionType>
            {
                new TransmissionType
                {
                    Id ="1",
                    Name = "Manual"
                },
                new TransmissionType
                {
                    Id ="2",
                    Name = "Automatic"
                }
            };

            return list;
        }
        #endregion
    }
}
