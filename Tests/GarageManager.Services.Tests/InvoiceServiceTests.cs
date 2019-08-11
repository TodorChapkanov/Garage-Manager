using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Models.Invoice;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class InvoiceServiceTests
    {
        private const string SampleCarId = "1";
        private const string SampleCustomerFirstName = "Jhon";
        private const string SampleCustomerLastName = "Wick";
        private const string SampleCustomerEmail = "jhon@mail.com";
        private const string SampleCustomerPhoneNumber = "123456789";
        private const string SampleServiceId = "1";
        private const string SamplePartId = "1";
        private const string SamplePartName = "Bolt";
        private const decimal SamplePartPrice = 1.20M;
        private const int SamplePartQuantity = 10;
        private const string SampleRepairId = "1";
        private const string SampleRepairDescription = "Change all Bolts";
        private const double SampleRepairHours = 1.6;
        private const decimal SampleRepairPricePerHour = 60.00M;

        private Mock<IDeletableEntityRepository<Car>> carRepository;
        private IInvoiceService InvoiceService;

        public InvoiceServiceTests()
        {
            this.carRepository = this.GetConfiguredCarRepository();
            this.InvoiceService = new InvoiceService(carRepository.Object);
        }
        #region InvoiceService Tests
        [Fact]
        public async Task GetInvoiceDetailsByCarIdAsyncShouldReturnCorrectDetailsWithCorrectCarId()
        {
            //Arrange
            var customerFullName = $"{SampleCustomerFirstName} {SampleCustomerLastName}";
            var partTotalCost = SamplePartPrice * SamplePartQuantity;
            var repairTotalCost = ((decimal)SampleRepairHours) * SampleRepairPricePerHour;

            //Act
            var result = await this.InvoiceService.GetInvoiceDetailsByCarIdAsync(SampleCarId);

            //Assert
            result
                .Should()
                .Match<InvoiceDetails>(invoice => invoice.CustomerFullName == customerFullName)
                .And
                .Match<InvoiceDetails>(invoice => invoice.CustomerEmail == SampleCustomerEmail)
                .And
                .Match<InvoiceDetails>(invoice => invoice.CustomerPhoneNumber == SampleCustomerPhoneNumber)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Parts.First().Id == SamplePartId)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Parts.First().Name == SamplePartName)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Parts.First().Price == SamplePartPrice)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Parts.First().Quantity == SamplePartQuantity)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Parts.First().TotalCost == partTotalCost)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Repairs.First().Id == SampleRepairId)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Repairs.First().Description == SampleRepairDescription)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Repairs.First().Hours == SampleRepairHours)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Repairs.First().PricePerHour == SampleRepairPricePerHour)
                .And
                .Match<InvoiceDetails>(invoice => invoice.Repairs.First().TotalCost == repairTotalCost);


        }

        [Theory]
        [InlineData("20000")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetInvoiceDetailsByCarIdAsyncShouldReturnNullWithInvalidCarId(string id)
        {
            //Act
            var result = await this.InvoiceService.GetInvoiceDetailsByCarIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
#endregion

        #region Configuration of Mock<IdeletableEntityRepository<Car>>
        private Mock<IDeletableEntityRepository<Car>> GetConfiguredCarRepository()
        {
            var testCarList = this.GetTestCarList();
            var repository = new Mock<IDeletableEntityRepository<Car>>();
            repository.Setup(all => all.All()).Returns(testCarList.AsQueryable().BuildMockDbQuery().Object);
            return repository;
        }
        #endregion

        #region TestCarList
        private List<Car> GetTestCarList()
        {
            var list = new List<Car>
            {
                new Car
                {
                    Id = SampleCarId,
                    ServiceId = SampleServiceId,
                    Services = this.GetTestServiceIntervenionList(),
                    Customer = new Customer
                    {
                        FirstName = SampleCustomerFirstName,
                        LastName = SampleCustomerLastName,
                        Email = SampleCustomerEmail,
                        PhoneNumber = SampleCustomerPhoneNumber
                    }
                },
                new Car
                {
                    Id = "2",
                    ServiceId = "2",
                    Services = new List<ServiceIntervention>(),
                    Customer = new Customer { }
                }
            };

            return list;
        }
        #endregion

        #region TestServiceInterventionList
        private List<ServiceIntervention> GetTestServiceIntervenionList()
        {
            var list = new List<ServiceIntervention>
            {
                new ServiceIntervention
                {
                    Id = SampleServiceId,
                    Parts = new List<Part>
                    {
                        new Part
                        {
                            Id = SamplePartId,
                            Name = SamplePartName,
                            Price = SamplePartPrice,
                            Quantity = SamplePartQuantity
                        }
                    },
                    Repairs = new List<Repair>
                    {
                        new Repair
                        {
                             Id = SampleRepairId,
                        Description = SampleRepairDescription,
                        Hours = SampleRepairHours,
                        PricePerHour = SampleRepairPricePerHour,
                        }
                    }
                }

            };

            return list;
        }
        #endregion
       
    }
}
