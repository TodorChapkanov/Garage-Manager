using GarageManager.DAL.Contracts;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class DepartmentServices : IDepartmentServices
    {
        private readonly IRepository<Department> departmentRepository;
        private readonly IRepository<Car> carRepository;

        public DepartmentServices(IRepository<Department> departmentRepository, IRepository<Car> carRepository)
        {
            this.departmentRepository = departmentRepository;
            this.carRepository = carRepository;
        }
        public async Task<IEnumerable<DepartmentAll>> AllDepartments()
        {
            var result = await this.departmentRepository.All()
                .Select(department => new DepartmentAll
                {
                    Id = department.Id,
                    Name = department.Name
                })
                .ToListAsync();

            return result;
        }

        public async Task<Department> GetByIdAsync(string departmentId)
        {
            var departmentFromDb = await this.departmentRepository.GetByIdAsync(departmentId);

            return departmentFromDb;

        }

        public async Task<DepartmentAllCars> GetDepartmentCars(string id)
        {
            var departmentFromDb =await this.departmentRepository.All().Where(department => department.Id == id)
                .Include(department => department.Cars)
                .Select(department => new DepartmentAllCars
                {
                    Name = department.Name,
                    Cars = department.Cars.Select(car => new DepartmentCarDetails
                    {
                        Id = car.Id,
                        Make = car.Manufacturer.Name,
                        Model = car.Model.Name,
                        RegisterPlate = car.RegistrationPlate,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return departmentFromDb;
        }

        public async Task<CarServicesDetails> GetCarServicesAsync(string id)
        {
            var carServices = await this.carRepository.All().Where(car => car.Id == id).Include(car => car.Manufacturer).Include(car => car.Model).Include(car => car.Services).Include(service => service.Services.Parts).Include(services => services.Services.Repairs).Select(car => new CarServicesDetails
            {
                Make = car.Manufacturer.Name,
                Model = car.Model.Name,
                RegisterPlate = car.RegistrationPlate,
                ServiceId = car.Services.Id,
                Parts = car.Services.Parts.Select(part => new PartDetails
                {
                    Id = part.Part.Id,
                    Name = part.Part.Name,
                    Number = part.Part.Number,
                    Price = part.Part.Price
                }),
                Repairs = car.Services.Repairs.Select(repair => new RepairDetails
                {
                    Id = repair.Repair.Id,
                    Description = repair.Repair.Description,
                    Hours = repair.Repair.Hours,
                    PricePerHour = repair.Repair.PricePerHour
                })

            }).FirstOrDefaultAsync();

            return carServices;

        }

        public string CreatePart(string name, string number, decimal price)
        {
            return null;
        }
    }
}
