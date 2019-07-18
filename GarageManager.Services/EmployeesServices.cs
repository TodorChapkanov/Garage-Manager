using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Employee;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class EmployeesServices : IEmployeesServices
    {
        private readonly IDeletableEntityRepository<GMUser> employeeRepository;

        public EmployeesServices(IDeletableEntityRepository<GMUser> employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        public async Task<bool> CreateNewAsync(
            string firstName,
            string lastName,
            string password,
            string email,
            string phoneNumber,
            DateTime recruitedOn,
            string departmentId)
        {
            try
            {
                var customer = new GMUser()
                {
                    PasswordHash = password,
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RecruitedOn = recruitedOn,
                    DepartmentId = departmentId,
                    CreatedOn = DateTime.UtcNow
                };

                await this.employeeRepository.CreateAsync(customer);

                return true;
            }
            catch (Exception)
            {
                throw new InvalidOperationException("Invalid Employee parameters!");
            }

           
        }

        public Task<List<AllEmployees>> GetAllEmployeesAsync()
        {
            var allEmployees =  this.employeeRepository
                .All()
                .Include(employee => employee.Department)
                .Select(employee => new AllEmployees
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    DepartmentName = employee.Department.Name
                }).ToListAsync();
            return allEmployees;
        }



        public async Task<EmployeeDetails> EditEmployeeDetailsByIdAsync(string id)
        {
            var employeeFromDb = await this.employeeRepository
                .All()
                .Include(department => department.Department)
                .FirstOrDefaultAsync(employee => employee.Id == id);
            var customerDetails = new EmployeeDetails
            {
                Id = id,
                FirstName = employeeFromDb.FirstName,
                LastName = employeeFromDb.LastName,
                Email = employeeFromDb.Email,
                PhoneNumber = employeeFromDb.PhoneNumber,
                Department = employeeFromDb.Department.Name,
                RecruitedOn = employeeFromDb.RecruitedOn,
                CreatedOn = employeeFromDb.CreatedOn
            };

            return customerDetails;
        }

        public async Task<bool> UpdateCustomerByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber,
            string departmentId,
            DateTime recruitedOn )
        {
            try
            {
                var employeeFromDb = await this.employeeRepository
                    .All()
                    .FirstAsync(emp => emp.Id == id);

                employeeFromDb.FirstName = firstName;
                employeeFromDb.LastName = lastName;
                employeeFromDb.Email = email;
                employeeFromDb.PhoneNumber = phonenumber;
                employeeFromDb.DepartmentId = departmentId;
                employeeFromDb.RecruitedOn = recruitedOn;



                await this.employeeRepository.UpdateAsync(employeeFromDb);
                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public bool IsAnyEmployee()
        {
            var result =  this.employeeRepository.All().Count();

            return result > 0;
        }
    }
}
