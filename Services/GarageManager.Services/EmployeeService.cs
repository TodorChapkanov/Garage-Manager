using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Contracts;
using GarageManager.Services.Mapping;
using GarageManager.Services.Models.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Services
{
    public class EmployeeService : BaseService, IEmployeeService
    {
        private readonly IDeletableEntityRepository<GMUser> employeeRepository;
        private readonly UserManager<GMUser> userManager;
        private readonly IDateTimeProvider dateTimeProvider;

        public EmployeeService(
            IDeletableEntityRepository<GMUser> employeeRepository,
            UserManager<GMUser> userManager,
            IDateTimeProvider dateTimeProvider)
        {
            this.employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.dateTimeProvider = dateTimeProvider;
        }


        public async Task<string> CreateNewEmployeeAsync(
            string firstName,
            string lastName,
            string password,
            string email,
            string phoneNumber,
            DateTime? recruitedOn,
            string departmentId)
        {
            if (this.employeeRepository.All().Select(emp => emp.Email).Contains(email))
            {
                return NotificationMessages.EmailExistResult;
            }

            try
            {
                var employee = new GMUser()
                {
                    FirstName = firstName,
                    LastName = lastName,
                    UserName = email,
                    Email = email,
                    PhoneNumber = phoneNumber,
                    RecruitedOn = recruitedOn,
                    DepartmentId = departmentId,
                    CreatedOn = this.dateTimeProvider.GetDateTime()
                };

                this.ValidateEntityState(employee);

                var result = await this.userManager.CreateAsync(employee, password);
                var departmentName = this.userManager.Users
                    .Where(user => user.Id == employee.Id)
                    .Select(department => department.Department.Name)
                    .First();



                if (result.Succeeded)
                {
                    var role = departmentName == DepartmentConstants.FacilitiesManagement
                        ? RoleConstants.AdministratorRoleName
                        : RoleConstants.EmployeeRoleName;

                    await this.userManager.AddToRoleAsync(employee, role);

                }

                return employee.Id;
            }
            catch
            {
                return null;
            }

        }

        public Task<List<AllEmployees>> GetAllEmployeesAsync()
        {
            var allEmployees = this.employeeRepository.All()
                .To<AllEmployees>().ToListAsync();

            return allEmployees;
        }



        public async Task<EditEmployeeDetails> EditEmployeeDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);

                var employeeFromDb = await this.employeeRepository.All()
                    .To<EditEmployeeDetails>()
                .FirstOrDefaultAsync(employee => employee.Id == id);


                return employeeFromDb;
            }
            catch
            {
                return null;
            }

        }

        public async Task<EmployeeDetails> GetEmployeeDetailsByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var employeeFromDb = await this.employeeRepository.All()
                .Where(employee => employee.Id == id)
                .To<EmployeeDetails>()
                .FirstOrDefaultAsync();


                return employeeFromDb;
            }
            catch
            {
                return null;
            }

        }

        public async Task<bool> UpdateEmployeeByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phoneNumber,
            string departmentId,
            string password,
            DateTime? recruitedOn)
        {
            try
            {
                this.ValidateNullOrEmptyString(id, firstName, lastName, email, phoneNumber, departmentId, password);
                var employeeFromDb = await this.userManager.FindByIdAsync(id);

                employeeFromDb.FirstName = firstName;
                employeeFromDb.LastName = lastName;
                employeeFromDb.Email = email;
                employeeFromDb.PhoneNumber = phoneNumber;
                employeeFromDb.DepartmentId = departmentId;
                employeeFromDb.RecruitedOn = recruitedOn;



                employeeFromDb.PasswordHash = this.userManager.PasswordHasher.HashPassword(employeeFromDb, password);
                await this.userManager.UpdateAsync(employeeFromDb);

                return true;
            }
            catch
            {

                return false;
            }

        }

        public async Task<int> DeleteEmployeeByIdAsync(string id)
        {
            try
            {
                this.ValidateNullOrEmptyString(id);
                var employeeFromDb = await this.userManager.FindByIdAsync(id);
                return await this.employeeRepository.SoftDeleteAsync(employeeFromDb);
            }
            catch
            {

                return default(int);
            }

        }

        public bool IsAnyEmployee()
        {
            var result = this.employeeRepository.All().Count();

            return result > 0;
        }
    }
}
