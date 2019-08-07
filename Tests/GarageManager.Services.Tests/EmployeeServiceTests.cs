using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.DTO.Employee;
using Microsoft.AspNetCore.Identity;
using MockQueryable.Moq;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class EmployeeServiceTests
    {
        private const string SampleEmployeeId = "2";
        private const string SampleEmployeePassword = "1234560";
        private const string SampleEmployeeHashedPassword = "Success";
        private const string SampleEmployeeFirstName = "Jhon";
        private const string SampleEmployeeLastName = "Wick";
        private const string SampleEmployeeEmail = "jhon@mail.com";
        private const string SampleEmployeePhoneNumber = "1111111111";
        private const string SampleEmployeeDepartmentId = "1";
        private const string SampleEmployeeDepartmentName = "Painting";
        private Mock<IDeletableEntityRepository<GMUser>> employeeRepository;
        private Mock<UserManager<GMUser>> mockUserManager;
        private EmployeeService employeeService;
        private List<GMUser> employees;

        public EmployeeServiceTests()
        {
            this.employees = this.GetTestEmployeeList();
            this.employeeRepository = this.GetConfiguredEmployeeRepository(this.employees);
            this.mockUserManager = this.MockUserManager<GMUser>(this.employees);
            this.employeeService = new EmployeeService(employeeRepository.Object, mockUserManager.Object, new DateTimeProvider());
        }
        /*  

        Task<List<AllEmployees>> GetAllEmployeesAsync();

        Task<EditEmployeeDetails> EditEmployeeDetailsByIdAsync(string id);

        Task<EmployeeDetails> GetEmployeeDetailsByIdAsync(string id);

        Task<bool> UpdateEmployeeByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber,
            string departmentId,
            string password,
            DateTime? recruitedOn);

        Task<int> DeleteEmployeeAsync(string id);
        bool IsAnyEmployee();*/

        #region CreateNewEmployeeAsync Tests
        [Fact]
        public async Task CreateNewEmployeeAsyncShouldSetAndSaveDataWithCorrectParameters()
        {
            //Act
            var sampleEmail = "wick@mail.com";
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      SampleEmployeeFirstName,
                      SampleEmployeeLastName,
                      SampleEmployeePassword,
                      sampleEmail,
                      SampleEmployeePhoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
            //Assert
            var employeeFromRepository = this.mockUserManager.Object.Users
                .First(employee => employee.Id == "1");

            result
                .Should()
                .NotBeNull();

            employeeFromRepository
                .Should()
                .Match<GMUser>(user => user.FirstName == SampleEmployeeFirstName)
                .And
                .Match<GMUser>(user => user.LastName == SampleEmployeeLastName)
                .And
                .Match<GMUser>(user => user.Email == sampleEmail)
                .And
                .Match<GMUser>(user => user.PhoneNumber == SampleEmployeePhoneNumber)
                .And
                .Match<GMUser>(user => user.PasswordHash == SampleEmployeeHashedPassword);

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateNewEmployeeAsyncShouldReturnNullWuthInvalidFirsName(string firstName)
        {
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      firstName,
                      SampleEmployeeLastName,
                      SampleEmployeePassword,
                      SampleEmployeeEmail,
                      SampleEmployeePhoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateNewEmployeeAsyncShouldReturnNullWuthInvalidLastName(string lastName)
        {
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      SampleEmployeeFirstName,
                      lastName,
                      SampleEmployeePassword,
                      SampleEmployeeEmail,
                      SampleEmployeePhoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateNewEmployeeAsyncShouldReturnNullWuthInvalidPassword(string password)
        {
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      SampleEmployeeFirstName,
                      SampleEmployeeLastName,
                      password,
                      SampleEmployeeEmail,
                      SampleEmployeePhoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateNewEmployeeAsyncShouldReturnNullWuthInvalidEmail(string email)
        {
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      SampleEmployeeFirstName,
                      SampleEmployeeLastName,
                      SampleEmployeePassword,
                      email,
                      SampleEmployeePhoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task CreateNewEmployeeAsyncShouldReturnNullWuthInvalidPhoneNumber(string phoneNumber)
        {
            var result = await this.employeeService.CreateNewEmployeeAsync
                (
                      SampleEmployeeFirstName,
                      SampleEmployeeLastName,
                      SampleEmployeePassword,
                      SampleEmployeeEmail,
                      phoneNumber,
                      DateTime.UtcNow,
                      SampleEmployeeDepartmentId
                );
        }
        #endregion

        #region GetAllEmployeesAsync Tests
        [Fact]
        public async Task GetAllEmployeesAsyncShouldReturnCorrectData()
        {
            //Arrange 
            var listCount = this.employeeRepository.Object
                .All()
                .Count();

            //Act
            var result = await this.employeeService.GetAllEmployeesAsync();

            //Assert
            result
                .Should()
                .NotBeEmpty();

            result.Count()
                .Should()
                .Be(listCount);

            result
                .First(user => user.Id == SampleEmployeeId)
                .Should()
                .Match<AllEmployees>(employee => employee.FullName == $"{SampleEmployeeFirstName} {SampleEmployeeLastName}")
                .And
                .Match<AllEmployees>(employee => employee.Email == SampleEmployeeEmail)
                .And
                .Match<AllEmployees>(employee => employee.PhoneNumber == SampleEmployeePhoneNumber)
                .And
                .Match<AllEmployees>(employee => employee.DepartmentName == SampleEmployeeDepartmentName);
        }

        [Fact]
        public async Task GetAllEmployeesAsyncShouldReturnEmptyCollectionIfNoEmployees()
        {
            //Arrange
            var employees = this.employeeRepository.Object.All();
            foreach (var employee in employees)
            {
                await this.employeeRepository.Object.SoftDeleteAsync(employee);
            }

            //Act
            var result = await this.employeeService.GetAllEmployeesAsync();

            //Assert
            result
                .Should()
                .BeEmpty();

        }
        #endregion

        #region GetEmployeeDetailsByIdAsync Tests
        [Fact]
        public async Task GetEmployeeDetailsByIdAsyncShouldReturncorrectDataWithValidId()
        {
            //Act
            var result = await this.employeeService.GetEmployeeDetailsByIdAsync(SampleEmployeeId);

            //Assert
            result
                .Should()
                .Match<EmployeeDetails>(employee => employee.FirstName == SampleEmployeeFirstName)
                .And
                .Match<EmployeeDetails>(employee => employee.LastName == SampleEmployeeLastName)
                .And
                .Match<EmployeeDetails>(employee => employee.Email == SampleEmployeeEmail)
                .And
                .Match<EmployeeDetails>(employee => employee.PhoneNumber == SampleEmployeePhoneNumber);

        }

        [Theory]
        [InlineData("100")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetEmployeeDetailsByIdAsyncShouldReturnNullWithInvalidId(string id)
        {
            //Act
            var result = await this.employeeService.GetEmployeeDetailsByIdAsync(id);

            //Assert
            result
                .Should()
                .BeNull();
        }
        #endregion

        #region UpdateEmployeeByIdAsync Tests
        [Fact]
        public async Task UpdateEmployeeByIdAsyncShouldUpdateChangesWithCorrectData()
        {
            //rrange
            var firstName = "Mark";
            var lastName = "Show";
            var email = "mark@mail.bg";
            var phoneNumber = "88888888";
            var departmentId = "150";
            var password = "NewPassword";
            var recruitesOn = DateTime.UtcNow;

            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                firstName,
                lastName,
                email,
                phoneNumber,
                departmentId,
                password,
                recruitesOn
                );

            //Assert
            var changedEmployee = this.mockUserManager.Object
                .Users
                .First(employee => employee.Id == SampleEmployeeId);

            result
                .Should()
                .BeTrue();

            changedEmployee
                .Should()
                .NotBeNull();

            changedEmployee
                .Should()
                .Match<GMUser>(employee => employee.FirstName == firstName)
                .And
                .Match<GMUser>(employee => employee.LastName == lastName)
                .And
                .Match<GMUser>(employee => employee.Email == email)
                .And
                .Match<GMUser>(employee => employee.PhoneNumber == phoneNumber)
                .And
                .Match<GMUser>(employee => employee.DepartmentId == departmentId)
                .And
                .Match<GMUser>(employee => employee.PasswordHash == SampleEmployeeHashedPassword)
                .And
                .Match<GMUser>(employee => employee.RecruitedOn != null);
        }

        [Theory]
        [InlineData("")]
        [InlineData("     ")]
        [InlineData(null)]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidId(string id)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                id,
                SampleEmployeeFirstName,
                SampleEmployeeLastName,
                SampleEmployeeEmail,
                SampleEmployeePhoneNumber,
                SampleEmployeeDepartmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidFirstName(string firstName)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                firstName,
                SampleEmployeeLastName,
                SampleEmployeeEmail,
                SampleEmployeePhoneNumber,
                SampleEmployeeDepartmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidLastName(string lastName)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                SampleEmployeeFirstName,
                lastName,
                SampleEmployeeEmail,
                SampleEmployeePhoneNumber,
                SampleEmployeeDepartmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidEmail(string email)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                SampleEmployeeFirstName,
                SampleEmployeeLastName,
                email,
                SampleEmployeePhoneNumber,
                SampleEmployeeDepartmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidPhoneNumber(string phoneNumber)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                SampleEmployeeFirstName,
                SampleEmployeeLastName,
                SampleEmployeeEmail,
                phoneNumber,
                SampleEmployeeDepartmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidDepartmentId(string departmentId)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                SampleEmployeeFirstName,
                SampleEmployeeLastName,
                SampleEmployeeEmail,
                SampleEmployeePhoneNumber,
                departmentId,
                SampleEmployeeHashedPassword,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }

        [Theory]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("     ")]
        public async Task UpdateEmployeeByIdAsyncShouldReturnFalseWithInvalidPassword(string password)
        {
            //Act
            var result = await this.employeeService.UpdateEmployeeByIdAsync
                (
                SampleEmployeeId,
                SampleEmployeeFirstName,
                SampleEmployeeLastName,
                SampleEmployeeEmail,
                SampleEmployeePhoneNumber,
                SampleEmployeeDepartmentId,
                password,
                DateTime.UtcNow
                );

            //Assert
            result
                .Should()
                .BeFalse();

        }
        #endregion

        #region DeleteEmployeeAsync Tests
        [Fact]
        public async Task DeleteEmployeeByIdAsyncShouldRemoveEmployeeWithCorrectId()
        {
            //Act
            var result = await this.employeeService.DeleteEmployeeByIdAsync(SampleEmployeeId);

            //Assert
            var employee = this.mockUserManager.Object
                .Users
                .First(user => user.Id == SampleEmployeeId);

            result
                .Should()
                .BePositive();

            employee
                .IsDeleted
                .Should()
                .BeTrue();

            employee
                .DeletedOn
                .Should()
                .NotBeNull();
        }
        #endregion

        #region IsAnyEmployee Tests
        [Fact]
        public void IsAnyEmployeeShouldReturnTrueIfAnyEmployee()
        {
            //Act
            var result = this.employeeService.IsAnyEmployee();

            //Assert
            result
                .Should()
                .BeTrue();
        }

        [Fact]
        public void IsAnyEmployeeShouldReturnFalseIfNoEmployees()
        {
            //Arrange
            var emptyEmployeeRepository = this.GetConfiguredEmployeeRepository(new List<GMUser>());
            var emptyEmployeeService = new EmployeeService(emptyEmployeeRepository.Object, mockUserManager.Object, new DateTimeProvider());

            //Act
            var result = emptyEmployeeService.IsAnyEmployee();

            //Assert
            result
                .Should()
                .BeFalse();
        }
        #endregion

        #region Configuration of Mock<IDeletableEntityRepository<GMUser>>
        private Mock<IDeletableEntityRepository<GMUser>> GetConfiguredEmployeeRepository(List<GMUser> testEmployeeList)
        {
            var repository = new Mock<IDeletableEntityRepository<GMUser>>();
            repository.Setup(all => all.All()).Returns(testEmployeeList.Where(x => !x.IsDeleted).AsQueryable().BuildMockDbQuery().Object);

            repository.Setup(delete => delete.SoftDeleteAsync(It.IsAny<GMUser>())).ReturnsAsync(
                 (GMUser target) =>
                 {
                     if (testEmployeeList.Contains(target))
                     {
                         target.DeletedOn = DateTime.UtcNow;
                         target.IsDeleted = true;
                         return 1;
                     }
                     return 0;
                 });


            repository.Setup(repo => repo.Update(It.IsAny<GMUser>())).ReturnsAsync(

             (GMUser target) =>
             {
                 if (testEmployeeList.Any(car => car.Id == target.Id))
                 {
                     var carFromList = testEmployeeList.First(car => car.Id == target.Id);
                     carFromList = target;
                     return 1;
                 }
                 return 0;
             });

            return repository;
        }
        #endregion

        #region Configuration of Mock<UserManage<GMUser>
        public Mock<UserManager<GMUser>> MockUserManager<TUser>(List<GMUser> ls) where TUser : class
        {
            var store = new Mock<IUserStore<GMUser>>();
            var passwordHasher = new Mock<IPasswordHasher<GMUser>>();
            passwordHasher
                .Setup(password => password.HashPassword(It.IsAny<GMUser>(), It.IsAny<string>()))
                .Returns(SampleEmployeeHashedPassword);

            var mgr = new Mock<UserManager<GMUser>>(store.Object, null, passwordHasher.Object, null, null, null, null, null, null);

            mgr.Object.UserValidators.Add(new UserValidator<GMUser>());

            mgr.Object.PasswordValidators.Add(new PasswordValidator<GMUser>());

            mgr.Setup(x => x.FindByIdAsync(It.IsAny<string>())).ReturnsAsync(
                (string id) =>
                {
                    if (ls.Any(user => user.Id == id))
                    {
                        return ls.First(user => user.Id == id);
                    }

                    return null;
                });

            mgr.Setup(x => x.AddToRoleAsync(It.IsAny<GMUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);

            mgr.Setup(x => x.Users).Returns(ls.AsQueryable<GMUser>);

            mgr.Setup(x => x.DeleteAsync(It.IsAny<GMUser>())).ReturnsAsync(
                (GMUser target) =>
                {
                    if (ls.Contains(target))
                    {
                        ls.Remove(target);
                        return IdentityResult.Success;
                    }
                    return IdentityResult.Failed();
                });

            mgr.Setup(x => x.CreateAsync(It.IsAny<GMUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success).Callback<GMUser, string>((x, y) =>
            {
                x.Id = "1";
                x.PasswordHash = SampleEmployeeHashedPassword;
                x.Department = new Department { Id = "1", Name = "Painting" };
                ls.Add(x);
            });

            mgr.Setup(x => x.UpdateAsync(It.IsAny<GMUser>())).ReturnsAsync(IdentityResult.Success)
                .Callback<GMUser>((target) =>
                {
                    if (ls.Any(user => user.Id == target.Id))
                    {
                        var userFromList = ls.First(user => user.Id == target.Id);
                        userFromList = target;
                    }
                });

            return mgr;
        }
        #endregion

        #region Test EmployeeList
        private List<GMUser> GetTestEmployeeList()
        {
            var employees = new List<GMUser>
            {
                new GMUser
                {
                     Id = SampleEmployeeId,
                     FirstName = SampleEmployeeFirstName,
                     LastName = SampleEmployeeLastName,
                     PasswordHash = SampleEmployeePassword,
                     Email = SampleEmployeeEmail,
                     PhoneNumber =  SampleEmployeePhoneNumber,
                     CreatedOn = DateTime.UtcNow,
                     DepartmentId = SampleEmployeeDepartmentId,
                     Department = new Department
                       {
                           Id = SampleEmployeeDepartmentId,
                           Name = SampleEmployeeDepartmentName
                       }
                },
                new GMUser
                {
                     Id = "2",
                     FirstName = "Jhon",
                     LastName = "Doe",
                     PasswordHash = "JhonDoe",
                     Email = "doe@mail.com",
                     PhoneNumber =  "2222222222",
                     CreatedOn = DateTime.UtcNow,
                     DepartmentId = "2",
                     Department = new Department
                       {
                          Id = "2",
                          Name = "Mechanical Repair"
                       }
                }
            };

            return employees;
        }
        #endregion
    }
}
