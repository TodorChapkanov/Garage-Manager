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

namespace GarageManager.Web.Areas.Employees.Controllers
{
    public class CarsController : BaseController
    {
        private readonly ICarService carService;
        private readonly IPartsService partsService;
        private readonly IRepairsService repairsService;

        public CarsController(ICarService carService, IPartsService partsService, IRepairsService repairsService)
        {
            this.carService = carService;
            this.partsService = partsService;
            this.repairsService = repairsService;
        }

        public async Task<IActionResult> Details(string id)
        {
            var result = await this.carService.GetDetailsByIdAsync(id);

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

        public async Task<IActionResult> ServiceDetails(string id)
        {

            var carModel = await this.carService.GetCarServicesAsync(id);

            var model = new CarServicesDetailsViewModel
            {
                Id = carModel.Id,
                Make = carModel.Make,
                Model = carModel.Model,
                RegisterPlate = carModel.RegisterPlate,
                Description = carModel.Description,
                DepartmentId = carModel.DepartmentId,
                Parts = carModel.Parts.Select(part => new PartDetailsViewModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    Price = part.Price,
                    Quantity = part.Quantity,
                    TotalCost = part.TotalCost
                }),
                Repairs = carModel.Repairs.Select(repair => new RepairDetailsViewModel
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
            var model = new AddCarToServiceViewModel();
            var carDetails = await  this.carService.GetServiceDescription(id);
            model.DepartmentId = carDetails.DepartmentId;
            model.Description = carDetails.Description == null ? string.Empty : carDetails.Description;

            return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Service(AddCarToServiceBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return this.LocalRedirect($"/Admin/Cars/Service({model})");
            }

            await this.carService.AddToService(model.Id, model.Description, model.DepartmentId);

            return this.Redirect($"/Employees/Departments/CarsInDepartment/{model.DepartmentId}");
        }


        public async Task<IActionResult> CarIsFinished(string carId, string departmentId)
        {
           var result =await this.carService.FinishCarServiceAsync(carId);
            if (result == default)
            {
                return this.Redirect($"/Employees/Cars/ServiceDetails/{carId}");
            }

            return this.Redirect($"/Employees/Departments/CarsInDepartment/{departmentId}");
        }
    }
}
