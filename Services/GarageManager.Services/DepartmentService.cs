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
    public class DepartmentService : IDepartmentService
    {
        private readonly IDeletableEntityRepository<Department> departmentRepository;

        public DepartmentService(
            IDeletableEntityRepository<Department> departmentRepository)
        {
            this.departmentRepository = departmentRepository;
        }
        public async Task<IEnumerable<DepartmentAll>> AllDepartmentsAsync()
        {
            var result = await this.departmentRepository
                .All()
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
            var departmentFromDb = await this.departmentRepository
                .All().FirstOrDefaultAsync(department => department.Id == departmentId);

            return departmentFromDb;

        }

        public async Task<DepartmentAllCars> GetDepartmentCars(string id)
        {
            var departmentFromDb = await this.departmentRepository
                .All()
                .Where(department => department.Id == id)
                .Include(department => department.Cars)
                .Select(department => new DepartmentAllCars
                {
                    Name = department.Name,
                    Cars = department.Cars.Where(isDeleteed => !isDeleteed.IsDeleted).Select(car => new DepartmentCarDetails
                    {
                        Id = car.Id,
                        Make = car.Manufacturer.Name,
                        Model = car.Model.Name,
                        RegisterPlate = car.RegistrationPlate,
                    }).ToList()
                }).FirstOrDefaultAsync();

            return departmentFromDb;
        }
    }
}
