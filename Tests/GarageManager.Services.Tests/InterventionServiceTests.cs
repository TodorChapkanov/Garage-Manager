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
    public class InterventionServiceTests
    {
        /* Task<IEnumerable<CarServiceHistory>> GetCarServicesHistoryAsync(string id);
        Task<int> FinishServiceAsync(string id);

        Task<CarServiceHistoryDetails> GetServiceHistoryDetailsAsync(string serviceId); */
        #region GetCarServicesHistoryAsync Tests
            [Fact]
            public async Task GetCarServicesHistoryAsyncShouldReturnCorrectDataWithValidId()
        {

        }
        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<ServiceIntervention>>
        private Mock<IDeletableEntityRepository<ServiceIntervention>> GetConfiguredCarRepository(List<ServiceIntervention> testServiceInterventionList)
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

        #region TestServiceInterventionList
        private List<ServiceIntervention> GetTestServiceInterventionList()
        {
            var list = new List<ServiceIntervention>
            {
               new ServiceIntervention
               {
                   Id = "1",
                   Car = new Car
                   {
                       Id = "1",
                       Manufacturer = new VehicleManufacturer
                       {
                           Name = "Ferrari"
                       },
                       RegistrationPlate = "AA 1111 AA",
                       IsFinished = false
                   },
                   Parts = new List<Part>
                   {
                       new Part
                       {
                           Name = "Bolt",
                           Number = "12F856841",
                           Quantity = 12,
                           Price = 12.50M
                       }
                   },
                   Repairs = new List<Repair>
                   {
                       new Repair
                       {
                            Description = "Change the Bolts",
                           Employee  = new GMUser{Id = "1", FirstName = "Jhon", LastName = "Wick"},
                           Hours = 1.50,
                           PricePerHour = 60.00M
                       }
                   }
               },
               new ServiceIntervention
               {
                   Id = "2",
                   Car = new Car
                   {
                       Id = "2",
                       Manufacturer = new VehicleManufacturer
                       {
                           Name = "Lada"
                       },
                       RegistrationPlate = "BB 2222BB",
                       IsFinished = false
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
