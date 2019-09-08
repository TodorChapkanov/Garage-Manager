using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels.Employee;
using GarageManager.Web.Models.ViewModels.Employee;
using GarageManager.Web.Models.ViewModels.Page;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Admin.Controllers
{
    public class EmployeesController : BaseAdminController
    {
        private readonly IEmployeeService employeesService;
        private readonly IDepartmentService departmentService;

        public EmployeesController(IEmployeeService employeesService, IDepartmentService departmentService)
        {
            this.employeesService = employeesService;
            this.departmentService = departmentService;
        }


        public async Task<IActionResult> AllEmployees()
        {
            var employeesModel = (await this.employeesService.GetAllEmployeesAsync())
               .Select(employee => AutoMapper.Mapper.Map<AllEmployeesViewModel>(employee));

            var model = new PaginatedList<AllEmployeesViewModel>(employeesModel);
            
           

            return this.View(model);
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
            if (employeeId == NotificationMessages.EmailExistResult)
            {
                this.ShowNotification(NotificationMessages.EmailExist,
                    NotificationType.Warning);

                return this.View(model);
            }

            if (employeeId == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                return this.Redirect(WebConstants.HomeIndex);
            }

            this.ShowNotification(string.Format(NotificationMessages.EmployeeCreateSuccessfull,
                model.FirsName, model.LastName),
                NotificationType.Success);
            
            return this.Redirect(string.Format(WebConstants.AdminEmployeesDetails, employeeId));
        }

        public async Task<IActionResult> Edit(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.RedirectToAction(nameof(AllEmployees));
            }
          var employeeFromDb = await this.employeesService.EditEmployeeDetailsByIdAsync(id);

            if (employeeFromDb == null)
            {
                this.ShowNotification(NotificationMessages.EmployeeNotExist,
                    NotificationType.Warning);

                return this.Redirect(WebConstants.HomeIndex);
            }

            var employeeModel = new EmployeeEditViewModel
            {
                Id = employeeFromDb.Id,
                FirstName = employeeFromDb.FirstName,
                LastName = employeeFromDb.LastName,
                Password = string.Empty,
                DepartmentId = employeeFromDb.DepartmentId,
                Departments = (await this.departmentService.AllDepartmentsAsync())
                                .Select(department => new SelectListItem(department.Name, department.Id)),
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
                return this.Redirect(string.Format(WebConstants.AdminEmployeesEdit,model.Id));
            }

          var result = await this.employeesService.UpdateEmployeeByIdAsync(
                model.Id,
                model.FirstName,
                model.LastName,
                model.Email,
                model.PhoneNumber,
                model.DepartmentId,
                model.Password,
                model.RecruitedOn);

            if (!result)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation
                    , NotificationType.Error);
                return this.Redirect(WebConstants.HomeIndex);
            }

            this.ShowNotification(NotificationMessages.EmployeeEditSuccessfull,
                NotificationType.Success);

            return this.Redirect(string.Format(WebConstants.AdminEmployeesDetails, model.Id));
        }

        public async Task<IActionResult> Details(string id )
        {
            if (!this.IsValidId(id))
            {
                return this.RedirectToAction(nameof(AllEmployees));
            }
            var employeeFromDb = await this.employeesService.GetEmployeeDetailsByIdAsync(id);

            if (employeeFromDb == null)
            {
                this.ShowNotification(NotificationMessages.EmployeeNotExist,
                    NotificationType.Warning);
                return this.Redirect(WebConstants.HomeIndex);
            }
            var employeeModel = AutoMapper.Mapper.Map<EmployeeDetailsViewModel>(employeeFromDb);
           
            return this.View(employeeModel);
        }

        public async  Task<IActionResult> Delete(string id)
        {
            if (!this.IsValidId(id)) 
            {
                return this.Redirect(WebConstants.AdminAllEmnployees);
            }
            if (id == this.User.FindFirstValue(ClaimTypes.NameIdentifier))
            {
                this.ShowNotification(NotificationMessages.DeleteCurentUserErrorMessage,
                    NotificationType.Error);
                return this.Redirect(WebConstants.AdminAllEmnployees);
            }

            var result = await this.employeesService.DeleteEmployeeByIdAsync(id);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);

                return this.Redirect(string.Format(WebConstants.AdminEmployeesEdit, id));
            }

            this.ShowNotification(NotificationMessages.EmployeeDeleteSuccessfull,
                   NotificationType.Warning);
            
            return this.Redirect(WebConstants.AdminAllEmnployees);
        }
    }
}
