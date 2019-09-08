using GarageManager.Common.GlobalConstant;
using GarageManager.Common.Notification;
using GarageManager.Services.Contracts;
using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.ViewModels.Car;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class CarsController : BaseEmployeeController
    {
        private readonly ICarService carService;

        public CarsController(ICarService carService)
        {
            this.carService = carService;
        }

        

        public async Task<IActionResult> Details(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }
            var result = await this.carService
                .GetCarDetailsByIdAsync(id);

            if (result != null)
            {
                var model = AutoMapper.Mapper.Map<CarDetailsViewModel>(result);
               
                return this.View(model);
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);

            return this.Redirect(WebConstants.HomeIndex);
            
        }

        public async Task<IActionResult> ServiceDetails(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var carModel = await this.carService
                .GetCarServiceDetailsByIdAsync(id);

            if (carModel == null)
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);

                return this.Redirect(WebConstants.HomeIndex);
            }
            var model = AutoMapper.Mapper.Map<CarServicesDetailsViewModel>(carModel);

            return this.View(model);
        }

        public async Task<IActionResult> Service(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var model = new AddCarToServiceViewModel();
            var carDetails = await  this.carService
                .GetServiceDescriptionByIdAsync(id);
            if (carDetails == null)
            {
                this.ShowNotification(NotificationMessages.CarNotExist
                    , NotificationType.Warning);
                return this.Redirect(WebConstants.HomeIndex);
            }
            model.DepartmentId = carDetails.DepartmentId;
            model.Description = carDetails.Description == null
                                                         ? string.Empty 
                                                         : carDetails.Description;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Service(AddCarToServiceBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.View(model);
            }

            var result = await this.carService
                .AddToServiceAsync(model.Id, model.Description, model.DepartmentId);

            if (result != default(int))
            {
                this.ShowNotification(NotificationMessages.CarServiceAdded,
               NotificationType.Success);

                return this.Redirect(string.Format(WebConstants.EmployeesDepartmentsCarsInDepartment, model.DepartmentId));
            }

            this.ShowNotification(NotificationMessages.CarAddToServiceFail,
              NotificationType.Warning);

            return this.View(model);
        }

        public async Task<IActionResult> CarIsFinished(string carId, string departmentId)
        {
            if (!this.IsValidId(carId) || !this.IsValidId(departmentId))
            {
                return this.Redirect(WebConstants.HomeIndex);
            }

            var result = await this.carService.FinishCarServiceAsync(carId);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.CarServiceNotCompleted,
                NotificationType.Warning);

                return this.Redirect(string.Format(WebConstants.EmployeesCarsServiceDetails,carId));
            }

            this.ShowNotification(NotificationMessages.CarServiceCmpletedSuccessfull,
                NotificationType.Success);

            return this.Redirect(string.Format(WebConstants.EmployeesDepartmentsCarsInDepartment, departmentId));
        }
    }
}
