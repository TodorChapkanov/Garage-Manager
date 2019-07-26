using GarageManager.Areas.Admin.Controllers;
using GarageManager.Common;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels.Employee;
using GarageManager.Web.Models.ViewModels.Employee;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Admin.Controllers
{
    public class EmployeesController : BaseAdminController
    {
        private readonly IEmployeesServices employeesService;
        private readonly IDepartmentServices departmentService;

        public EmployeesController(IEmployeesServices employeesService, IDepartmentServices departmentService)
        {
            this.employeesService = employeesService;
            this.departmentService = departmentService;
        }

        public async Task<IActionResult> AllEmployees()
        {
            var employeesModel = (await this.employeesService.GetAllEmployeesAsync())
                .Select(employee => new AllEmployeesViewModel
                {
                    Id = employee.Id,
                    FullName = employee.FullName,
                    DepartmentName = employee.DepartmentName,
                    PhoneNumber = employee.PhoneNumber,
                    Email = employee.Email
                });

            return this.View(employeesModel);
        }
        public IActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(EmployeeCreateBindingModel model)
        {
            if (!ModelState.IsValid)
            {
               
                return this.View(model);
            }

           var employeeId = await this.employeesService.CreateNewEmployeeAsync(
                model.FirsName,
                model.LastName,
                model.Password,
                model.Email,
                model.PhoneNumber,
                model.RecruitedOn,
                model.DepartmentId);
            if (employeeId == GlobalConstants.EmailExistResult)
            {
                ViewData["Email"] = GlobalConstants.EmailExistErrorMessage;
                return this.View(model);
            }

            
            return this.Redirect($"/Admin/Employees/Details/{employeeId}");
        }

        public async Task<IActionResult> Edit(string id)
        {
          var employeeFromDb = await this.employeesService.EditEmployeeDetailsByIdAsync(id);

            var employeeModel = new EmployeeEditViewModel
            {
                Id = employeeFromDb.Id,
                FirstName = employeeFromDb.FirstName,
                LastName = employeeFromDb.LastName,
                Password = string.Empty,
                DepartmentId = employeeFromDb.DepartmentId,
                Departments = (await this.departmentService.AllDepartmentsAsync()).Select(department => new SelectListItem(department.Name, department.Id)),
                Email = employeeFromDb.Email,
                PhoneNumber = employeeFromDb.PhoneNumber,
                RecruitedOn = employeeFromDb.RecruitedOn
            };

            return this.View(employeeModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EmployeeEditBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.Redirect($"/Admin/Employees/Edit/{model.Id}");
            }

           await this.employeesService.UpdateEmployeeByIdAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.Email,
                model.PhoneNumber,
                model.DepartmentId,
                model.Password,
                model.RecruitedOn);

            return this.Redirect($"/Admin/Employees/Details/{model.Id}");
        }

        public async Task<IActionResult> Details(string id )
        {
            var employeeFromDb = await this.employeesService.GetEmployeeDetailsByIdAsync(id);
            var employeeModel = new EmployeeDetailsViewModel
            {
                Id = employeeFromDb.Id,
                FirstName = employeeFromDb.FirstName,
                LastName = employeeFromDb.LastName,
                PhoneNumber = employeeFromDb.PhoneNumber,
                Email = employeeFromDb.Email,
                DepartmentName = employeeFromDb.Department,
                CreatedOn = employeeFromDb.CreatedOn,
                RecruitedOn = employeeFromDb.RecruitedOn
            };

            return this.View(employeeModel);
        }

        public async  Task<IActionResult> Delete(string id)
        {
            var result = await this.employeesService.DeleteEmployeeAsync(id);
            return this.Redirect("/Admin/Employees/AllEmployees");
        }
    }
}
