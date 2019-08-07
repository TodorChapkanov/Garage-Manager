using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using GarageManager.Services.DTO.Car;
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
    public class CustomerServiceTests
    {
        private const string SampleCustomerId = "1";
        private const string SampleCustomerFirstName = "Jhon";
        private const string SampleCustomerLastName = "Wick";
        private const string SampleCustomerPhoneNumber = "1111111111";
        private const string SampleCustomerEmail = "gmail@gmail.com";
        private const string SampleTestCustomerId = "10";
        private const string SampleNewCustomerFirstName = "Jack";
        private const string SampleNewCustomerLastName = "Sparrow";
        private const string SampleNewCustomerEmail = "noMail@mail.com";
        private const string SampleNewCustomerPhoneNumber = "3333333333";
        private const string SampleInvalidCustomerName = "ThisIsNameWithInvalidLength-MaxLengthIs30Symbols";

        private Mock<IDeletableEntityRepository<Customer>> customerRepository;
        private CustomerService customerService;
        private Mock<ICarService> carService;
        public CustomerServiceTests()
        {
            this.customerRepository = this.GetConfiguredCustomerRepository();
            this.customerService = new CustomerService(
                this.customerRepository.Object,
                this.GetConfiguredCarService().Object
                );
            this.carService = this.GetConfiguredCarService();
        }
        
        #region CreateAsync Tests
        [Fact]
        public async Task CreateAsyncShouldSetCorrecrCustomerDataAndSeveCustomerWithCorrectData()
        {


            //Act
            var result =await  this.customerService
                .CreateAsync(
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail, 
                SampleNewCustomerPhoneNumber
                );

            //Assert
            var actual = await this.customerRepository.Object
                .All()
                .FirstOrDefaultAsync(customer => customer.Id == SampleTestCustomerId);

            actual
                .Should()
                .NotBeNull();

            actual
                .Should()
                .Match<Customer>(customer => customer.Id == SampleTestCustomerId)
                .And
                .Match<Customer>(customer => customer.FirstName == SampleNewCustomerFirstName)
                .And
                .Match<Customer>(customer => customer.LastName == SampleNewCustomerLastName)
                .And
                .Match<Customer>(customer => customer.Email == SampleNewCustomerEmail)
                .And
                .Match<Customer>(customer => customer.PhoneNumber == SampleNewCustomerPhoneNumber);
        }

        [Theory]
        [InlineData(SampleInvalidCustomerName)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task CreateAsyncShoulReturnZeroWithInvalidCustomerFirstName(string customerFirstName)
        {
            //Act
            var result = await this.customerService.CreateAsync(
                customerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(SampleInvalidCustomerName)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task CreateAsyncShoulReturnZeroWithInvalidCustomerLastName(string customerLastName)
        {
            //Act
            var result = await this.customerService.CreateAsync(
                SampleNewCustomerFirstName,
                customerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task CreateAsyncShoulReturnZeroWithInvalidCustomerEmail(string customerEmail)
        {
            //Act
            var result = await this.customerService.CreateAsync(
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                customerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("   ")]
        public async Task CreateAsyncShoulReturnZeroWithInvalidCustomerPhoneNumber(string customerPhoneNumber)
        {
            //Act
            var result = await this.customerService.CreateAsync(
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                customerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region GetAllCustomersDetailsAsync Tests
        [Fact]
        public async Task GetAllCustomersDetailsAsyncShouldReturnCorectCountOfCustomersWithCorectDetails()
        {
            //Act
            var result = await this.customerService.GetAllCustomersDetailsAsync();

            //Assert
            var actualCustomerCount = this.GetTestCustomerLis().Count();
            result.Count()
                .Should()
                .Be(actualCustomerCount);

            result
                .First(customer => customer.Id == SampleCustomerId)
                .Should()
                .Match<CustomerDetail>(customer => customer.FullName == $"{SampleCustomerFirstName} {SampleCustomerLastName}")
                .And
                .Match<CustomerDetail>(customer => customer.Email == SampleCustomerEmail); ;
        }
        #endregion

        #region GetCustomerDetailsByIdAsync Tests
        [Fact]
        public async Task GetCustomerDetailsByIdAsyncShoulReturCorrecrCustomerWithCorrectCustomerId()
        {
            //Act
            var result = await this.customerService.GetCustomerDetailsByIdAsync(SampleCustomerId);

            //Assert

            result
                .Should()
                .Match<CustomerEditDetails>(customer => customer.FirstName == SampleCustomerFirstName)
                .And
                .Match<CustomerEditDetails>(customer => customer.LastName == SampleCustomerLastName)
                .And
                .Match<CustomerEditDetails>(customer => customer.Email == SampleCustomerEmail)
                .And
                .Match<CustomerEditDetails>(customer => customer.PhoneNumber == SampleCustomerPhoneNumber);
        }

        [Theory]
        [InlineData(SampleTestCustomerId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("      ")]
        public async Task GetCustomerDetailsByIdAsyncShoulReturnNullWithIvalidCustomerId(string customerId)
        {
            //Act
            var result = await this.customerService.GetCustomerDetailsByIdAsync(customerId);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region  SoftDeleteAsync Tests
        [Fact]
        public async Task SoftDeleteAsyncShouldRemoveCustomerFromDatabaseWithCorrectCustomerId()
        {


            //Act
            var result = await this.customerService.SoftDeleteAsync(SampleCustomerId);

            //Assert
            var actualDetails = await this.customerRepository.Object
                .All()
                .FirstAsync(customer => customer.Id == SampleCustomerId);
            var actualCarsCount = await this.carService.Object
                .GetAllCarsByCustomerIdAsync(SampleCustomerId);

            result
                .Should()
                .BePositive();

            actualDetails
                .IsDeleted
                .Should()
                .BeTrue();

            actualDetails
                .DeletedOn
                .Should()
                .NotBeNull();

            actualCarsCount
                .Count()
                .Should()
                .Be(0);

        }

        [Theory]
        [InlineData(SampleInvalidCustomerName)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task SoftDeleteAsyncShouldReturZeroWithInvalidCustomerId(string customerId)
        {
            //Act
            var result = await this.customerService.SoftDeleteAsync(customerId);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region UpdateCustomerByIdAsync Tests
        [Fact]
        public async Task UpdateCustomerByIdAsyncShouldSetDataWithCorrectData()
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                SampleCustomerId,
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            var actualCustomerDetails = await this.customerRepository.Object.GetEntityByKeyAsync(SampleCustomerId);

            result
                .Should()
                .BePositive();

            actualCustomerDetails
                .Should()
                .Match<Customer>(customer => customer.FirstName == SampleNewCustomerFirstName)
                .And
                .Match<Customer>(customer => customer.LastName == SampleNewCustomerLastName)
                .And
                .Match<Customer>(customer => customer.Email == SampleNewCustomerEmail)
                .And
                .Match<Customer>(customer => customer.PhoneNumber == SampleNewCustomerPhoneNumber);
        }

        [Theory]
        [InlineData(SampleTestCustomerId)]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateCustomerByIdAsyncShouldReturZeroWithInvalidCustomerId(string customerId)
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                customerId,
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateCustomerByIdAsyncShouldReturZeroWithInvalidCustomerFirstName(string customerFirstName)
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                SampleCustomerId,
                customerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateCustomerByIdAsyncShouldReturZeroWithInvalidCustomerLastName(string customerLastName)
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                SampleCustomerId,
                SampleNewCustomerFirstName,
                customerLastName,
                SampleNewCustomerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateCustomerByIdAsyncShouldReturZeroWithInvalidCustomerEmail(string customerEmail)
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                SampleCustomerId,
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                customerEmail,
                SampleNewCustomerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task UpdateCustomerByIdAsyncShouldReturZeroWithInvalidCustomerPhoneNumber(string customerPhoneNumber)
        {
            //Act
            var result = await this.customerService.UpdateCustomerByIdAsync(
                SampleCustomerId,
                SampleNewCustomerFirstName,
                SampleNewCustomerLastName,
                SampleNewCustomerEmail,
                customerPhoneNumber);

            //Assert
            result
                .Should()
                .Be(0);
        }
        #endregion

        #region Configuration of Mock<IDeletableEntityRepository<Customer>>
        private Mock<IDeletableEntityRepository<Customer>> GetConfiguredCustomerRepository()
        {
            var testCustomerList = this.GetTestCustomerLis();
            var repository = new Mock<IDeletableEntityRepository<Customer>>();
            repository.Setup(all => all.All()).Returns(testCustomerList.AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(getById => getById
            .GetEntityByKeyAsync(It.IsAny<string>()))
                .ReturnsAsync((string id) => testCustomerList.Where(x => x.Id == id).Single());
            repository.Setup(delete => delete.SoftDeleteAsync(It.IsAny<Customer>())).ReturnsAsync(
                (Customer target) =>
                {
                    if (testCustomerList.Contains(target))
                    {
                        target.DeletedOn = DateTime.UtcNow;
                        target.IsDeleted = true;
                        return 1;
                    }
                    return 0;
                });



            repository.Setup(car => car.CreateAsync(It.IsAny<Customer>())).ReturnsAsync(
                (Customer target) =>
                {
                    target.Id = SampleTestCustomerId;
                    var customerCount = testCustomerList.Count;
                    testCustomerList.Add(target);
                    if (customerCount != testCustomerList.Count)
                    {
                        return 1;
                    }
                    return 0;
                });

            repository.Setup(repo => repo.Update(It.IsAny<Customer>())).ReturnsAsync(

             (Customer target) =>
             {
                 if (testCustomerList.Any(car => car.Id == target.Id))
                 {
                     var customerFromList = testCustomerList.First(car => car.Id == target.Id);
                     customerFromList = target;
                     return 1;
                 }
                 return 0;
             });

            return repository;


        }
        #endregion

        #region Configuration of Mock<CarService>
        private Mock<ICarService> GetConfiguredCarService()
        {
            var testCarList = this.GetTestCarList();
            var carService = new Mock<ICarService>();
             carService.Setup(getAll => getAll.GetAllCarsByCustomerIdAsync(It.IsAny<string>())).ReturnsAsync((string carId) => testCarList.Where(car => car.CustomerId == carId).Select(car => new CustomerCarListDetails
            {
                Id = car.Id
            }));
             
            carService.Setup(delete => delete.HardDeleteAsync(It.IsAny<string>())).ReturnsAsync(
                (string targetId) =>
                {
                    if (testCarList.Any(car => car.Id == targetId))
                    {
                        var targetCar = testCarList.First(car => car.Id == targetId);
                        testCarList.Remove(targetCar);
                        return 1;
                    }
                    return 0;
                });

            return carService;
        }
        #endregion

        #region TestCarList
        private List<Car> GetTestCarList()
        {
            var list = new List<Car>
            {
                new Car
                {
                    Id = "1"
                },
                new Car
                {
                    Id= "2"
                }
            };

            return list;
        }
        #endregion

        #region TestCustomerList
        private List<Customer> GetTestCustomerLis()
        {
            var list = new List<Customer>
            {
               new Customer
               {
                   Id = SampleCustomerId,
                   FirstName = SampleCustomerFirstName,
                   LastName = SampleCustomerLastName,
                   PhoneNumber= SampleCustomerPhoneNumber,
                   Email = SampleCustomerEmail,
                   Cars = this.GetTestCarList(),
                   IsDeleted = false,
                   DeletedOn = null
               },
               new Customer
               {
                   Id = "2",
                   FirstName = "John ",
                   LastName = "Creasy",
                   PhoneNumber= "2222222222",
                   Email = "mail@mail.com",
                   IsDeleted = false,
                   DeletedOn = null
               }
            };

            return list;
        }
        #endregion
    }
}
