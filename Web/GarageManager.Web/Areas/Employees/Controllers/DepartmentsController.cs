using GarageManager.Common;
using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.ViewModels.Department;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class DepartmentsController : BaseEmployeeController
    {
        private readonly IDepartmentService departmentService;

        public DepartmentsController(IDepartmentService departmentService)
        {
            this.departmentService = departmentService;
        }
        public async Task<IActionResult> CarsInDepartment(string id)
        {
            if (!this.IsValidId(id))
            {

            }
            var result = await this.departmentService.GetDepartmentCarsAsync(id);

            if (result == null)
            {
                this.ShowNotification(NotificationMessages.InvalidOperation,
                    NotificationType.Error);
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }
            var viewModel = new DepartmentCarsList
            {
                Name = result.Name,
                Cars = result.Cars.Select(car => new DepartmentCarDetails
                {
                    Id = car.Id,
                    Make = car.Make,
                    Model = car.Model,
                    RegistrationPlate = car.RegisterPlate
                }).ToList()
            };

            return this.View(viewModel);
        }

    }
}
