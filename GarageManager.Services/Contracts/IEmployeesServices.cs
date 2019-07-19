﻿using GarageManager.Data.Repository;
using GarageManager.Services.DTO.Employee;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GarageManager.Services.Contracts
{
    public interface IEmployeesServices
    {
        Task<string> CreateNewEmployeeAsync(
            string firstName,
            string lastName,
            string password,
            string email,
            string phoneNumber,
            DateTime? recruitedOn,
            string departmentId);

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
        bool IsAnyEmployee();
    }
}
