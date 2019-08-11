using GarageManager.Services.Models.Department;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentAll>> AllDepartmentsAsync();

        Task<DepartmentAllCars> GetDepartmentCarsAsync(string id);
   
    }
}
