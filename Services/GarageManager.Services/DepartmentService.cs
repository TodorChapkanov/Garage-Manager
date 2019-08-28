using GarageManager.Common.GlobalConstant;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Charts;
using GarageManager.Services.Models.Department;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class DepartmentService : BaseService, IDepartmentService
    {
        private readonly IDeletableEntityRepository<Department> departmentRepository;

        public DepartmentService(
            IDeletableEntityRepository<Department> departmentRepository
            )
        {
            this.departmentRepository = departmentRepository;
        }

        public async Task<IEnumerable<DepartmentAll>> AllDepartmentsAsync()
        {
            var result = await this.departmentRepository
                .All()
                .To<DepartmentAll>()
                .ToListAsync();

            return result;
        }

        public async Task<DepartmentAllCars> GetDepartmentCarsAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var departmentFromDb = await this.departmentRepository
                .All()
                .Where(department => department.Id == id)
                .To<DepartmentAllCars>()
               .FirstOrDefaultAsync();

                return departmentFromDb;
            }
            catch 
            {
                return null;
            }
            
        }

        public async Task<IEnumerable<SimpleReportViewModel>> GetCarsInDepartments()
        {
            var result = await this.departmentRepository
                 .All()
                 .Where(department => department.Name != DepartmentConstants.FacilitiesManagement)
                 .Select(department => new SimpleReportViewModel
                 {
                     DimensionOne = department.Name,
                     Quantity = department.Cars.Count()
                 }).ToListAsync();
               // .ToDictionaryAsync(dep => dep.Name, dep => dep.Cars.Count());

            //TODO add check for isFinished
            return result;
        }
    }
}
