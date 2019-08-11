using FluentAssertions;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Models.Department;
using MockQueryable.Moq;
using Moq;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace GarageManager.Services.Tests
{
    public class DepartmentServiceTests : BaseTest
    {
        private const string SampleDepartmentId = "1";
        private const string SampleDepartmentName = "Painting";
        private const string SampleCarid = "1";
        private const string SampleCarMakeName = "Opel";
        private const string SampleCarModelName = "Vectra";
        private const string SampleCarRegistrationPlate = "AA 1234 AA";

        #region AllDepatmentsAsync Tests

        [Fact]
        public async Task AllDepartmentsShouldReturnCorrectCountAndCorrectDataInModel()
        {
            //Arrange 
            var testDepartmentList = this.GetTestDepartmentList(new List<Car>());
            var departmentRrpository = this.GetConfiguredDepartmentRepository(testDepartmentList);
            var departmentService = new DepartmentService(departmentRrpository.Object);

            //Act
            var result = await departmentService.AllDepartmentsAsync();

            //Assert

            result
                .Count()
                .Should()
                .Be(2);

            result
                .First(department => department.Id == SampleDepartmentId)
                .Should()
                .Match<DepartmentAll>(department => department.Name == SampleDepartmentName);
        }

        [Fact]
        public async Task AllDepartmentsShouldReturnEmptyCollectionIfNoDepartmentsInDatabase()
        {
            //Arrange
            var departmentRepository = this.GetConfiguredDepartmentRepository(new List<Department>());
            var departmentService = new DepartmentService(departmentRepository.Object);

            //Act
            var result = await departmentService.AllDepartmentsAsync();

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Should()
                .BeEmpty();
        }
        #endregion

        #region GetDepartmentCars Tests
        [Fact]
        public async Task GetDepartmentCarsAsyncShouldReturnCorrectCarCount()
        {
            //Arrange
            var testCarList = this.GetTestCarList();
            var testDepartmentList = this.GetTestDepartmentList(testCarList);
            var departmentRepository = this.GetConfiguredDepartmentRepository(testDepartmentList);
            var departmentService = new DepartmentService(departmentRepository.Object);

            //Act
            var result = await departmentService.GetDepartmentCarsAsync(SampleDepartmentId);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Cars.Count
                .Should()
                .Be(3);

            result
                .Should()
                .Match<DepartmentAllCars>(department => department.Name == SampleDepartmentName)
                .And
                .Match<DepartmentAllCars>(department => department
                                              .Cars
                                              .First(car => car.Id == SampleCarid).RegistrationPlate == SampleCarRegistrationPlate)
                .And
                .Match<DepartmentAllCars>(department => department
                                             .Cars
                                             .First(car => car.Id == SampleCarid).MakeName == SampleCarMakeName)
                .And
                .Match<DepartmentAllCars>(department => department
                                             .Cars
                                             .First(car => car.Id == SampleCarid).ModelName == SampleCarModelName);
        }

        [Fact]
        public async Task GetDepartmentCarsAsyncShouldReturnEmptyCollectionOfCarsIfNoCarsInDepartment()
        {
            //Arrange
            var testDepartmentList = this.GetTestDepartmentList(new List<Car>());
            var departmentRepository = this.GetConfiguredDepartmentRepository(testDepartmentList);
            var departmentService = new DepartmentService(departmentRepository.Object);

            //Act
            var result = await departmentService.GetDepartmentCarsAsync(SampleDepartmentId);

            //Assert
            result
                .Should()
                .NotBeNull();

            result
                .Cars.Count
                .Should()
                .Be(0);
        }

        [Theory]
        [InlineData("100")]
        [InlineData(null)]
        [InlineData("")]
        [InlineData("    ")]
        public async Task GetDepartmentCarsAsyncShouldReturnNullWithInvalidDepartmentId(string departmentId)
        {
            //Arrange
            var departmentRepository = this.GetConfiguredDepartmentRepository(new List<Department>());
            var departmentService = new DepartmentService(departmentRepository.Object);

            //Act
            var result = await departmentService.GetDepartmentCarsAsync(departmentId);

            //Assert
            result
                .Should()
                .BeNull();
        }

        #endregion

        #region Configuration of Mock<IdeletableEntityRepository<Department>>
        private Mock<IDeletableEntityRepository<Department>> GetConfiguredDepartmentRepository(List<Department> testDepartmentList)
        {
            var repository = new Mock<IDeletableEntityRepository<Department>>();
            repository.Setup(all => all.All()).Returns(testDepartmentList.AsQueryable().BuildMockDbQuery().Object);



            return repository;
           
        }
        #endregion

        #region Test Department List
        private List<Department> GetTestDepartmentList(List<Car> testCarlist)
        {
            var departments = new List<Department>
            {
                new Department
                {
                    Id = SampleDepartmentId,
                    Name = SampleDepartmentName,
                    Cars = testCarlist
                },
                new Department
                {
                    Id = "2",
                    Name = "Body Repair",
                    Cars =  testCarlist
                }
            };

            return departments;
        }
        #endregion

        #region Test Car List
        private List<Car> GetTestCarList()
        {
            var cars = new List<Car>
            {
                new Car
                {
                     Id = SampleCarid,
                        Make =new VehicleManufacturer{Id= "1", Name = "Opel" },
                        Model = new VehicleModel { Id = "1", Name = "Vectra" },
                        RegistrationPlate = SampleCarRegistrationPlate,
                        IsDeleted = false
                },
                new Car
                {
                     Id = "2",
                        Make =new VehicleManufacturer{Id= "1", Name = SampleCarMakeName },
                        Model = new VehicleModel { Id = "1", Name = SampleCarModelName },
                        RegistrationPlate = "BB 2222 BB",
                        IsDeleted = false
                },
                new Car
                {
                     Id = "3",
                        Make =new VehicleManufacturer{Id= "1", Name = "Reanult" },
                        Model = new VehicleModel { Id = "1", Name = "Scenic" },
                        RegistrationPlate = "CC 3333 CC",
                        IsDeleted = true
                },
            };

            return cars;
        }
        #endregion
    }
}
