﻿using GarageManager.Common;
using GarageManager.Data.Repository;
using GarageManager.Domain;
using GarageManager.Extensions.DateTimeProviders;
using GarageManager.Services.Contracts;
using GarageManager.Services.DTO.Employee;
using Microsoft.AspNetCore.Identity;
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
        private readonly UserManager<GMUser> userManager;
        private readonly SignInManager<GMUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly IDateTimeProvider dateTimeProvider;

        public EmployeesServices(
            IDeletableEntityRepository<GMUser> employeeRepository,
            UserManager<GMUser> userManager, 
            SignInManager<GMUser> signInManager,
            RoleManager<IdentityRole> roleManager,
            IDateTimeProvider dateTimeProvider)
        {
            this.employeeRepository = employeeRepository;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
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
                return GlobalConstants.EmailExistResult;
            }

            var employee = new GMUser()
            {
                FirstName = firstName,
                LastName = lastName,
                UserName = $"{firstName}{lastName}",
                Email = email,
                PhoneNumber = phoneNumber,
                RecruitedOn = recruitedOn,
                DepartmentId = departmentId,
                CreatedOn = this.dateTimeProvider.GetDateTime()
            };
            
            var result = await this.userManager.CreateAsync(employee, password);
            var departmentName = this.userManager.Users
                .Include(department => department.Department)
                .Where(user => user.Id == employee.Id)
                .Select(department => department.Department.Name)
                .First();
                
                

            if (result.Succeeded)
            { 
                var role = departmentName == GlobalConstants.FacilitiesManagement
                    ? GlobalConstants.AdministratorRoleName 
                    : GlobalConstants.EmployeeRoleName;

                await this.userManager.AddToRoleAsync(employee,role);
                
            }

            return employee.Id;
        }

        public Task<List<AllEmployees>> GetAllEmployeesAsync()
        {
            var allEmployees = this.employeeRepository.All()
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



        public async Task<EditEmployeeDetails> EditEmployeeDetailsByIdAsync(string id)
        {
            var employeeFromDb = await this.userManager.Users
               .Select(employee => new EditEmployeeDetails
               {
                   Id = id,
                   FirstName = employee.FirstName,
                   LastName = employee.LastName,
                   Email = employee.Email,
                   PhoneNumber = employee.PhoneNumber,
                   DepartmentId = employee.DepartmentId,
                   RecruitedOn = employee.RecruitedOn,
                   CreatedOn = employee.CreatedOn
               })
                .FirstOrDefaultAsync(employee => employee.Id == id);


            return employeeFromDb;
        }

        public async Task<EmployeeDetails> GetEmployeeDetailsByIdAsync(string id)
        {
            var employeeFromDb = await this.userManager.Users
                .Include(department => department.Department).
                Select(employee => new EmployeeDetails
                {
                    Id = id,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                    Email = employee.Email,
                    PhoneNumber = employee.PhoneNumber,
                    Department = employee.Department.Name,
                    RecruitedOn = employee.RecruitedOn,
                    CreatedOn = employee.CreatedOn
                })
                .FirstOrDefaultAsync(employee => employee.Id == id);


            return employeeFromDb;
        }

        public async Task<bool> UpdateEmployeeByIdAsync(
            string id,
            string firstName,
            string lastName,
            string email,
            string phonenumber,
            string departmentId,
            string password,
            DateTime? recruitedOn)
        {
            try
            {
                var employeeFromDb = await this.userManager.FindByIdAsync(id);

                employeeFromDb.FirstName = firstName;
                employeeFromDb.LastName = lastName;
                employeeFromDb.Email = email;
                employeeFromDb.PhoneNumber = phonenumber;
                employeeFromDb.DepartmentId = departmentId;
                employeeFromDb.RecruitedOn = recruitedOn;



                employeeFromDb.PasswordHash = this.userManager.PasswordHasher.HashPassword(employeeFromDb, password);
                await this.userManager.UpdateAsync(employeeFromDb);

                return true;
            }
            catch (Exception)
            {

                return false;
            }

        }

        public async Task<int> DeleteEmployeeAsync(string id)
        {
            var employeeFromDb = await this.userManager.FindByIdAsync(id);
            this.employeeRepository.SoftDelete(employeeFromDb);

            return await this.employeeRepository.SavaChangesAsync();
        }

        public bool IsAnyEmployee()
        {
            var result = this.employeeRepository.All().Count();

            return result > 0;
        }
    }
}
