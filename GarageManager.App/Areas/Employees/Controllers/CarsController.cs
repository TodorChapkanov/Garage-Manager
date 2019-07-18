using GarageManager.App.Models.BindingModels.Part;
using GarageManager.App.Models.BindingModels.RepairService;
using GarageManager.App.Models.ViewModels.Car;
using GarageManager.App.Models.ViewModels.Department;
using GarageManager.App.Models.ViewModels.Part;
using GarageManager.App.Models.ViewModels.Repair;
using GarageManager.Services;
using GarageManager.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace GarageManager.App.Areas.Employees.Controllers
{
    public class CarsController : BaseController
    {
        private readonly ICarServices carService;
        private readonly IPartsServices partsService;
        private readonly IRepairsServices repairsService;

        public CarsController(ICarServices carService, IPartsServices partsService, IRepairsServices repairsService)
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
                Parts = carModel.Parts.Select(part => new PartDetailsViewModel
                {
                    Id = part.Id,
                    Name = part.Name,
                    Number = part.Number,
                    Price = part.Price
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

     

       
    }
}
