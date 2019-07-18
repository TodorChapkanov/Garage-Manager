using GarageManager.Data.Repository;
using GarageManager.Services.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IEmployeesServices
    {
        Task<bool> CreateNewAsync(
            string firstName,
            string lastName,
            string password,
            string email,
            string phoneNumber,
            DateTime recruitedOn,
            string departmentId);

        Task<List<AllEmployees>> GetAllEmployeesAsync();

        Task<EmployeeDetails> EditEmployeeDetailsByIdAsync(string id);

        Task<bool> UpdateCustomerByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber,
            string departmentId,
            DateTime recruitedOn);

        bool IsAnyEmployee();
    }
}
