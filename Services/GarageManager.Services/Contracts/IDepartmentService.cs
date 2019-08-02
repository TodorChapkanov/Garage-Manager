using GarageManager.Domain;
using GarageManager.Services.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IDepartmentService
    {
        Task<IEnumerable<DepartmentAll>> AllDepartmentsAsync();

        Task<DepartmentAllCars> GetDepartmentCars(string id);
   
    }
}
