using GarageManager.Web.Models.BindingModels;
using GarageManager.Web.Models.BindingModels.Part;
using GarageManager.Web.Models.BindingModels.RepairService;
using GarageManager.Web.Models.ViewModels.Car;
using GarageManager.Web.Models.ViewModels.Department;
using GarageManager.Web.Models.ViewModels.Part;
using GarageManager.Web.Models.ViewModels.Repair;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;
using GarageManager.Common.Notification;
using GarageManager.Common;
using GarageManager.Common.GlobalConstant;

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
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }
            var result = await this.carService
                .GetCarDetailsByIdAsync(id);

            if (result != null)
            {
                var model = new CarDetailsViewModel
                {
                    Id = result.Id,
                    Make = result.Make,
                    Model = result.Model,
                    RegistrationPlate = result.RegistrationPlate,
                    Vin = result.Vin,
                    ManufacturedOn = result.ManufacturedOn,
                    Кilometers = result.Кilometers,
                    EngineModel = result.EngineModel,
                    EngineHorsePower = result.EngineHorsePower,
                    FuelType = result.FuelType,
                    Transmission = result.Transmission
                };

                return this.View(model);
            }

            this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);

            return this.Redirect(RedirectUrl_s.HomeIndex);
            
        }

        public async Task<IActionResult> ServiceDetails(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var carModel = await this.carService
                .GetCarServicesAsync(id);

            if (carModel == null)
            {
                this.ShowNotification(string.Format(
                    NotificationMessages.InvalidOperation),
                    NotificationType.Error);

                return this.Redirect(RedirectUrl_s.HomeIndex);
            }
            var model = new CarServicesDetailsViewModel
            {
                Id = carModel.Id,
                Make = carModel.Make,
                Model = carModel.Model,
                RegisterPlate = carModel.RegisterPlate,
                Description = carModel.Description,
                DepartmentId = carModel.DepartmentId,
                Parts = carModel.Parts
                .Select(part => new PartDetailsViewModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    TotalCost = part.TotalCost
                }),
                Repairs = carModel.Repairs
                .Select(repair => new RepairDetailsViewModel
                {
                    Id = repair.Id,
                    Description = repair.Description,
                    Hours = repair.Hours,
                    PricePerHour = repair.PricePerHour,
                    TotalCost = repair.TotalCosts,
                    IsFinished = repair.IsFinished
                })
            };

            return this.View(model);
        }

        public async Task<IActionResult> Service(string id)
        {
            if (!this.IsValidId(id))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var model = new AddCarToServiceViewModel();
            var carDetails = await  this.carService
                .GetServiceDescription(id);
            if (carDetails == null)
            {
                this.ShowNotification(NotificationMessages.CarNotExist
                    , NotificationType.Warning);
                return this.Redirect(RedirectUrl_s.HomeIndex);
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
                return this.LocalRedirect($"/Admin/Cars/Service({model})");
            }

            var result = await this.carService
                .AddToService(model.Id, model.Description, model.DepartmentId);

            if (result != default(int))
            {
                this.ShowNotification(NotificationMessages.CarServiceAdded,
               NotificationType.Success);

                return this.Redirect($"/Employees/Departments/CarsInDepartment/{model.DepartmentId}");
            }

            this.ShowNotification(NotificationMessages.CarAddToServiceFail,
              NotificationType.Warning);

            return this.View(model);
        }

        public async Task<IActionResult> CarIsFinished(string carId, string departmentId)
        {
            if (!this.IsValidId(carId) || !this.IsValidId(departmentId))
            {
                return this.Redirect(RedirectUrl_s.HomeIndex);
            }

            var result = await this.carService.FinishCarServiceAsync(carId);

            if (result == default(int))
            {
                this.ShowNotification(NotificationMessages.CarServiceNotCompleted,
                NotificationType.Warning);

                return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
            }

            this.ShowNotification(NotificationMessages.CarServiceCmpletedSuccessfull,
                NotificationType.Success);

            return this.Redirect($"/Employees/Departments/CarsInDepartment/{departmentId}");
        }
    }
}
